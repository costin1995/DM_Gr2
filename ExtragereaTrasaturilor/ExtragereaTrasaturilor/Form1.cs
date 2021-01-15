using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Text.RegularExpressions;

namespace ExtragereaTrasaturilor
{
    public partial class Form1 : Form
    {
        XmlDocument document = new XmlDocument();

        List<int> indexCuvSubPrag = new List<int>();
        List<string> VectorGlobal = new List<string>();
        List<string> StopWords = new List<string>();
        List<Dictionary<int, int>> ListVectorRar = new List<Dictionary<int, int>>();
        List<Article> listToReturn = new List<Article>();
        Dictionary<string, int> EntropiaCuvantExistent = new Dictionary<string, int>();
        double rezEntropieCuvantExistent = 0.0;
        Dictionary<string, int> EntropiaCuvantCareNuExista = new Dictionary<string, int>();
        double rezEntropieCuvantCareNuExista = 0.0;
        
        List<double> CstInformational = new List<double>();
        List<Article> listTraining = new List<Article>();
        List<Article> listTesting = new List<Article>();


        public Form1()
        {
            InitializeComponent();
            string Location = ("..\\..\\..\\Reuters_34");
            CreateVectors(ListToReturn( Location));

        }


        public string GetXmlNodeContentByName(XmlDocument doc, string name)
        {

            string str = null;
            XmlNodeList xmlnodeList = doc.GetElementsByTagName(name);

            for (int i = 0; i < xmlnodeList.Count; i++)
            {
                str = xmlnodeList[i].InnerXml;

            }

            return str;

        }

        public List<string> GetClassCodeFromXml(XmlDocument doc)
        {
            List<string> listCodes = new List<string>();
            List<string> lines = new List<string>();
            string text = string.Empty;
            string search = "<codes class=\"bip:topics:1.0\">";

            XmlNodeList xmlnodeList = doc.GetElementsByTagName("metadata");

            text = xmlnodeList[0].InnerXml;

            int indexStart = text.IndexOf(search);
            if (indexStart != -1)
            {
                indexStart = indexStart + search.Length;
                int indexEnd = text.IndexOf("</codes>", indexStart);
                text = text.Substring(indexStart, indexEnd - indexStart);

                lines = text.Split('>').ToList();

                foreach (string line in lines)
                {
                    string code = "<code code=\"";
                    int start = line.IndexOf(code);
                    if (start != -1)
                    {
                        start = start + code.Length;
                        int end = line.IndexOf("\"", start);
                        listCodes.Add(line.Substring(start, end - start));
                    }
                }
            }

            return listCodes;

        }

        public List<Article> ListToReturn(string LocationFile)//citire fisier
        {

            XmlDocument xmldoc = new XmlDocument();
            List<string> files = new List<string>();

            foreach (string f in Directory.GetFiles(LocationFile, "*.*", SearchOption.AllDirectories))
            {
                files.Add(f);

            }

            foreach (string file in files)
            {
                if (file.Contains(".XML"))
                {

                    FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                    xmldoc.Load(fs);
                    string path = new DirectoryInfo(Path.GetDirectoryName(fs.Name)).Name;
                    listToReturn.Add(new Article(GetXmlNodeContentByName(xmldoc, "title"), GetXmlNodeContentByName(xmldoc, "text"), GetClassCodeFromXml(xmldoc), path));

                }
            }
            return listToReturn;

        }

        static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word.ToLower();
        }
        static string[] GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            return words.ToArray();
        }

        public void ListaWords()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\stopwords.txt");

            foreach (string line in lines)
            {
                StopWords.Add(line);

            }
        }

        public void CreateVectors(List<Article> ArticleList)
        {
            string[] text;
            string[] title;

            ListaWords();

            foreach (var Article in ArticleList)
            {
                text = GetWords(Article.text);
                title = GetWords(Article.title);
                PopulareVectorGlobal(text);
                PopulareVectorGlobal(title);
            }

            foreach (var Article in ArticleList)
            {
                text = GetWords(Article.text);
                title = GetWords(Article.title);

                ListVectorRar.Add(CreareVectorRar(title, text));
            }

        }

        public Dictionary<string, int> VectorFregventa(string[] title, string[] text)
        {
            Dictionary<string, int> vectorFregventa = new Dictionary<string, int>();

            PorterStemmer PorterStream = new PorterStemmer();
            foreach (var word in text)
            {
                if (!StopWords.Contains(word))
                {
                    string root = string.Empty;
                    root = PorterStream.StemWord(word);
                    if (vectorFregventa.ContainsKey(root) == false)
                    {
                        vectorFregventa.Add(root, 1);
                    }
                    else
                    {
                        vectorFregventa[root]++;
                    }

                }
            }
            foreach (var word in title)
            {
                if (!StopWords.Contains(word))
                {
                    string root = string.Empty;
                    root = PorterStream.StemWord(word);
                    if (vectorFregventa.ContainsKey(root) == false)
                    {
                        vectorFregventa.Add(root, 1);
                    }
                    else
                    {
                        vectorFregventa[root]++;
                    }

                }
            }
            return vectorFregventa;
        }

        public Dictionary<int, int> CreareVectorRar(string[] title, string[] text)
        {
            Dictionary<string, int> vectorFregventa = VectorFregventa(title, text);
            Dictionary<int, int> VectorRar = new Dictionary<int, int>();
            foreach (var word in vectorFregventa)
            {
                for (int i = 0; i < VectorGlobal.Count; i++)
                {
                    if (word.Key == VectorGlobal[i])
                    {
                        VectorRar.Add(i, word.Value);
                        break;
                    }
                }

            }

            return VectorRar;

        }

        public void PopulareVectorGlobal(string[] text)
        {
            PorterStemmer PorterStream = new PorterStemmer();
            foreach (var word in text)
            {

                if (!StopWords.Contains(word))
                {
                    string root = string.Empty;
                    root = PorterStream.StemWord(word);
                    if (!VectorGlobal.Contains(word))
                    {
                        VectorGlobal.Add(root);
                    }

                }
            }
        }

        public static double Entropie(Dictionary<string, int> aparitieClase, double totalArticole)
        {
            double elemente = 0.0;
            double entropie = 0;
            double resultEntropie = 0.0;


            foreach (var item in aparitieClase)
            {
                elemente = item.Value / (double)totalArticole;
                entropie = elemente * (double)Math.Log(elemente, 2);
                resultEntropie -= entropie;
            }
            return resultEntropie;
        }


        public static double EntropieGlobala(List<Article> articole)
        {
            double entropieGlobala = 0;
            Dictionary<string, int> repartitieClase = new Dictionary<string, int>();
            foreach (Article articol in articole)
            {

                if (!repartitieClase.ContainsKey(articol.ClassCodes.First()))
                {
                    repartitieClase.Add(articol.ClassCodes.First(), 1);
                }
                else
                {
                    repartitieClase[articol.ClassCodes.First()]++;
                }

            }
            entropieGlobala = Entropie(repartitieClase, articole.Count);
            return entropieGlobala;
        }

        public double EntropieCuvantExistent(List<Article> listaArticole, int NrCuvant/*numarul corespunzator cuvantului pentru care se calculeaza entropia*/)
        {
            int nrArticoleNrCuvant = 0;
            foreach (var a in ListVectorRar)
            {
                foreach (var b in a)
                {
                    if (b.Key == NrCuvant)
                    {
                        nrArticoleNrCuvant++;
                        foreach (var c in listaArticole)
                        {
                            if (listaArticole.IndexOf(c) == ListVectorRar.IndexOf(a))
                            {
                                foreach (var d in c.ClassCodes)
                                {
                                    if (!EntropiaCuvantExistent.ContainsKey(d))
                                    {
                                        EntropiaCuvantExistent.Add(d, 1);
                                    }
                                    else
                                    {
                                        EntropiaCuvantExistent[d]++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            rezEntropieCuvantExistent = Entropie(EntropiaCuvantExistent, nrArticoleNrCuvant);
            return rezEntropieCuvantExistent;
        }
        public double EntropieCuvantCareNuExista(List<Article> listaArticole, int NrCuvant)
        {
            int nrArticoleNrCuvant = 0;
            foreach (var VectorRar in ListVectorRar)
            {
                bool ok = true;
                foreach (var b in VectorRar)
                {
                    if (b.Key == NrCuvant)
                    {
                        ok = false;
                    }
                }
                if (ok == true)
                {
                    nrArticoleNrCuvant++;
                    foreach (var c in listaArticole)
                    {
                        if (listaArticole.IndexOf(c) == ListVectorRar.IndexOf(VectorRar))
                        {
                            foreach (var d in c.ClassCodes)
                            {
                                if (!EntropiaCuvantCareNuExista.ContainsKey(d))
                                {
                                    EntropiaCuvantCareNuExista.Add(d, 1);
                                }
                                else
                                {
                                    EntropiaCuvantCareNuExista[d]++;
                                }
                            }
                        }
                    }
                }

            }
            rezEntropieCuvantCareNuExista = Entropie(EntropiaCuvantCareNuExista, nrArticoleNrCuvant);
            return rezEntropieCuvantCareNuExista;
        }


        public void CastigInformational()
        {
            Dictionary<int, int> Sv = new Dictionary<int, int>();
            double castigInform = 0.0;
            int totalValori = VectorGlobal.Count;
            var Entropie = EntropieGlobala(listToReturn);

            foreach (var dic in ListVectorRar) 
            {
                foreach (var item in dic) 
                {
                    if (Sv.ContainsKey(item.Key))
                    {
                        Sv[item.Key] += item.Value;
                    }
                    else
                    {
                        Sv.Add(item.Key,item.Value);
                    }
                }
            }


            for (int i = 0; i < VectorGlobal.Count; i++)
            {
                //foreach (var index in Sv)
                //{
                //int diferentaValori = totalValori - index.Value;
                //castigInform = Entropie - index.Value / totalValori * rezEntropieCuvantExistent.ElementAt(i) - diferentaValori / totalValori * rezEntropieCuvantCareNuExista.ElementAt(i);
                CstInformational.Add(castigInform);
                // }
            }


        }

        public double DistantaEuclidiana(Dictionary<int, int> VectorRar1, Dictionary<int, int> VectorRar2, int n/*numarul de trasaturi caracteristice*/)
        {
            double rezDE;
            double sumaelem = 0.0;
            for (int i = 0; i < n; i++)
            {
                sumaelem += Math.Pow(VectorRar1.ElementAt(i).Key - VectorRar2.ElementAt(i).Key, 2);
            }
            rezDE = Math.Sqrt(sumaelem);
            return rezDE;
        }
        public double DistantaManhatan(Dictionary<int, int> VectorRar1, Dictionary<int, int> VectorRar2, int n)
        {
            double rezDM;
            double sumaelem = 0.0;
            for (int i = 0; i < n; i++)
            {

                sumaelem += Math.Abs(VectorRar1.ElementAt(i).Key - VectorRar2.ElementAt(i).Key);
            }
            rezDM = sumaelem;
            return rezDM;
        }

        public Dictionary<int, double> NormalizareCornellSmart(Dictionary<int, int> VectorRar)
        {
            Dictionary<int, double> normCornellSmart = new Dictionary<int, double>();
            foreach (var item in VectorRar)
            {
                if (item.Value == 0)
                {
                    normCornellSmart.Add(item.Key, 0);
                }
                else
                {
                    double TF = 0;
                    TF = 1 + Math.Log10(1 + Math.Log10(item.Value));
                    if (TF > 2)
                    {
                        TF = 2;
                    }
                    normCornellSmart.Add(item.Key, TF);
                }
            }
            return normCornellSmart;

        }
        /// <summary>
        /// NormalizareCornellSmart returneaza int 
        /// </summary>
        /// <param name="VectorRar"></param>
        /// <returns></returns>
     /*   public Dictionary<int, int> NormalizareCornellSmart(Dictionary<int, int> VectorRar)
        {
            Dictionary<int, int> normCornellSmart = new Dictionary<int, int>();
            foreach (var item in VectorRar)
            {
                if (item.Value == 0)
                {
                    normCornellSmart.Add(item.Key, 0);
                }
                else
                {
                    double TF = 0;
                    TF = 1 + Math.Log10(1 + Math.Log10(item.Value));
                    if(TF > 2)
                    {
                        TF = 2;
                    }

                    normCornellSmart.Add(item.Key,  Convert.ToInt32( TF));
                }
            }
            return normCornellSmart;

        }
     */

        public Dictionary<int, int> NormalizareBinara(Dictionary<int, int> vectorRar)
        {
            Dictionary<int, int> normBinara = new Dictionary<int, int>();

            foreach (var item in vectorRar)
            {
                if (item.Value > 0)
                {
                    normBinara.Add(item.Key, 1);
                }
                else if (item.Value == 0)

                {
                    normBinara.Add(item.Key, 0);
                }

            }

            return normBinara;
        }


        public Dictionary<int, float> NormalizareNominala(Dictionary<int, int> vectorRar)
        {
            float maxValueDict = vectorRar.Values.Max();
            Dictionary<int, float> vectorRarNormalizat = new Dictionary<int, float>();
            foreach (var value in vectorRar)
            {
                vectorRarNormalizat.Add(value.Key, value.Value / maxValueDict);
            }

            return vectorRarNormalizat;

        }

        public Dictionary<int, float> NormalizareSuma1(Dictionary<int, int> VectorRar)
        {
            Dictionary<int, float> VectorRarNormalizat = new Dictionary<int, float>();
            int suma1 = 0;
            foreach (var elemvector in VectorRar)
            {
                suma1 += elemvector.Value;
            }
            foreach (var vector in VectorRar)
            {
                VectorRarNormalizat.Add(vector.Key, vector.Value / suma1);
            }
            return VectorRarNormalizat;
        }

        private void btnExtTras_Click(object sender, EventArgs e)
        {
            ListToReturn("..\\..\\..\\Reuters_34");
            CreateVectors(listToReturn);
            string Filename = "..\\..\\..\\Input\\rezultat.txt";
            StreamWriter sw = new StreamWriter(Filename);
            foreach (var indexListVectorRar in ListVectorRar)
            {
                foreach (var indexElementeLista in indexListVectorRar)
                {
                    sw.Write("{0}:{1}", indexElementeLista.Key, indexElementeLista.Value + " ");
                }
                foreach (var indexListToReturn in listToReturn)
                {
                    if (listToReturn.IndexOf(indexListToReturn) == ListVectorRar.IndexOf(indexListVectorRar))
                    {
                        sw.Write(" # ");
                        foreach (var indexElementeClassCodes in indexListToReturn.ClassCodes)
                        {
                            sw.Write(indexElementeClassCodes + " ");
                        }
                        sw.Write("# " + indexListToReturn.Data_Set + " ");
                    }
                }
                sw.WriteLine("\r\n");
            }
            sw.Close();
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void selectieTrasaturiBtn_Click(object sender, EventArgs e)
        {
            float prag = (float)pragForm.Value;
            for (int i = 0; i < CstInformational.Count; i++)
            {
                if (CstInformational.ElementAt(i) < 0.5)
                {
                    indexCuvSubPrag.Add(i);

                }
            }
            for (int i = 0; i < indexCuvSubPrag.Count; i++)
            {
                CstInformational.RemoveAt(indexCuvSubPrag[i]);
                VectorGlobal.RemoveAt(indexCuvSubPrag[i]);
            }

            foreach (var vectorRar in ListVectorRar)
            {

                for (int i = 0; i < indexCuvSubPrag.Count; i++)
                {
                    if (vectorRar.ContainsKey(indexCuvSubPrag[i]))
                    {
                        vectorRar.Remove(indexCuvSubPrag[i]);
                    }

                }
            }

            string path = @"..\..\..\SelectiaTrasaturilor.txt"; // path to file
            using (FileStream fs = File.Create(path))
            {

                for (int i = 0; i < VectorGlobal.Count; i++)
                {
                    string scrie = "@attribute " + VectorGlobal[i] + " " + CstInformational[i] + "\r\n";
                    AddText(fs, scrie);
                }
                AddText(fs, "\r\n@data\r\n");

                int j = 0;
                foreach (Dictionary<int, int> dict in ListVectorRar)
                {
                    foreach (var value in dict)
                    {
                        AddText(fs, value.Key + ":" + value.Value + " ");
                    }
                    AddText(fs, "# ");
                    AddText(fs, listToReturn.ElementAt(j).ClassCodes.First());
                    AddText(fs, "\r\n");
                    j++;
                }

            }
        }

        
        public void ImpartireaSetuluiDeDate() 
        {
            foreach (var article in listToReturn)
            {
                if (article.Data_Set == "Training")
                {
                    listTraining.Add(article);
                }
                else if (article.Data_Set == "Testing")
                {
                    listTesting.Add(article);
                }

            }
        }


		private void btnSelect_Click(object sender, EventArgs e)
		{

            foreach (var vectorRar in ListVectorRar)
            {
                if (radioBtbBinara.Checked)
                {
                    NormalizareBinara(vectorRar);
                }

                if (radioBtnNominala.Checked)
                {
                    NormalizareNominala(vectorRar);
                }

                if (radioBtnSuma1.Checked)
                {
                    NormalizareSuma1(vectorRar);
                }

                if (radioBtnCornellSmart.Checked)
                {
                    NormalizareCornellSmart(vectorRar);
                }

            }
        }
	}
}