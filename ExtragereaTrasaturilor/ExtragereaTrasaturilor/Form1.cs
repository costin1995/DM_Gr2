﻿using System;
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

        List<int> indexCuvPestePrag = new List<int>();
        List<string> VectorGlobal = new List<string>();
        List<string> StopWords = new List<string>();
        List<Dictionary<int, int>> ListVectorRar = new List<Dictionary<int, int>>();
        List<Article> listToReturn = new List<Article>();
        Dictionary<string, int> EntropiaCuvantExistent = new Dictionary<string, int>();
        List<double> rezEntropieCuvantExistent = new List<double>();
        Dictionary<string, int> EntropiaCuvantCareNuExista = new Dictionary<string, int>();
        List<double> rezEntropieCuvantCareNuExista = new List<double>();
        List<double> CstInformational = new List<double>();
        List<Dictionary<int, double>> listTraining = new List<Dictionary<int, double>>();
        List<Dictionary<int, double>> listTesting = new List<Dictionary<int, double>>();
        List<Dictionary<int, double>> ListVectorRarNormalizat = new List<Dictionary<int, double>>();
        Dictionary<int, string> listaArticoleClasaPredictionata = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
            string Location = ("..\\..\\..\\Reuters_34");
            CreateVectors(ListToReturn(Location));

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
            List<string> listWords = new List<string>();
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            foreach (var word in words)
            {
                if (word.Length > 1)
                {
                    listWords.Add(word);
                }
            }

            return listWords.ToArray();
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
            Dictionary<int, int> dictToReturn = new Dictionary<int, int>();
            List<int> sortareDict = VectorRar.Keys.ToList();
            sortareDict.Sort();
            foreach (var key in sortareDict)
            {
                dictToReturn.Add(key, VectorRar[key]);
            }
            return dictToReturn;

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
                    if (!VectorGlobal.Contains(root))
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

        public List<double> EntropieCuvantExistent()
        {
            foreach (var cuvant in VectorGlobal) //string urile cu cuvinte
            {
                Dictionary<string, int> DictRepartitieClasa = new Dictionary<string, int>();
                foreach (var vectorRar in ListVectorRar)
                {
                    if (vectorRar.ContainsKey(VectorGlobal.IndexOf(cuvant)))
                    {
                        string clasa = listToReturn.ElementAt(ListVectorRar.IndexOf(vectorRar)).ClassCodes.First();

                        if (DictRepartitieClasa.ContainsKey(clasa))
                        {
                            DictRepartitieClasa[clasa]++;
                        }

                        else
                        {
                            DictRepartitieClasa.Add(clasa, 1);
                        }

                    }

                }

                rezEntropieCuvantExistent.Add(Entropie(DictRepartitieClasa, listToReturn.Count));

            }


            return rezEntropieCuvantExistent;

        }
        public List<double> EntropieCuvantNeexistent()
        {
            foreach (var cuvant in VectorGlobal) //string urile cu cuvinte
            {
                Dictionary<string, int> DictRepartitieClasa = new Dictionary<string, int>();
                foreach (var vectorRar in ListVectorRar)
                {
                    if (!vectorRar.ContainsKey(VectorGlobal.IndexOf(cuvant)))
                    {
                        string clasa = listToReturn.ElementAt(ListVectorRar.IndexOf(vectorRar)).ClassCodes.First();

                        if (DictRepartitieClasa.ContainsKey(clasa))
                        {
                            DictRepartitieClasa[clasa]++;
                        }

                        else
                        {
                            DictRepartitieClasa.Add(clasa, 1);
                        }

                    }


                }
                int frecventaCuvant = 0;
                foreach (var aparitieClasa in DictRepartitieClasa)
                {
                    frecventaCuvant += aparitieClasa.Value;
                }
                rezEntropieCuvantCareNuExista.Add(Entropie(DictRepartitieClasa, frecventaCuvant));

            }


            return rezEntropieCuvantCareNuExista;

        }


        public void CastigInformational()
        {
            Dictionary<int, int> dictAparitie = new Dictionary<int, int>();
            Dictionary<int, int> dictNonAparitie = new Dictionary<int, int>();
            double castigInform = 0.0;
            int totalValori = listToReturn.Count;
            var Entropie = EntropieGlobala(listToReturn);


            foreach (var cuvant in VectorGlobal)
            {
                dictAparitie.Add(VectorGlobal.IndexOf(cuvant), 0);
                dictNonAparitie.Add(VectorGlobal.IndexOf(cuvant), 0);
                foreach (var dic in ListVectorRar)
                {
                    if (dic.ContainsKey(VectorGlobal.IndexOf(cuvant)))
                    {
                        dictAparitie[VectorGlobal.IndexOf(cuvant)]++;

                    }
                    else
                    {
                        dictNonAparitie[VectorGlobal.IndexOf(cuvant)]++;
                    }
                }

            }

            foreach (var cuvant in VectorGlobal)
            {
                int index = VectorGlobal.IndexOf(cuvant);
                int totalArticole = listToReturn.Count;
                castigInform = Entropie - (double)((double)dictAparitie.ElementAt(index).Value / (double)totalArticole) * (double)rezEntropieCuvantExistent.ElementAt(index) - ((double)dictNonAparitie.ElementAt(index).Value / (double)totalArticole) * (double)rezEntropieCuvantCareNuExista.ElementAt(index);
                CstInformational.Add(castigInform);
            }

        }


        public double DistantaEuclidiana(Dictionary<int, double> VectorRar1, Dictionary<int, double> VectorRar2, int n/*numarul de trasaturi caracteristice*/)
        {
            double rezDE;
            double sumaelem = 0.0;
            for (int i = 0; i < n; i++)
            {
                if (VectorRar1.ContainsKey(i) && VectorRar2.ContainsKey(i))
                {
                    sumaelem += Math.Pow(VectorRar1[i] - VectorRar2[i], 2);
                }
                else if (VectorRar1.ContainsKey(i) && !VectorRar2.ContainsKey(i))
                {
                    sumaelem += Math.Pow(VectorRar1[i], 2);
                }

                else if (!VectorRar1.ContainsKey(i) && VectorRar2.ContainsKey(i))
                {
                    sumaelem += Math.Pow(VectorRar2[i], 2);
                }
            }
            rezDE = Math.Sqrt(sumaelem);
            return rezDE;
        }
        public double DistantaManhatan(Dictionary<int, double> VectorRar1, Dictionary<int, double> VectorRar2, int n)
        {
            double rezDM;
            double sumaelem = 0.0;
            for (int i = 0; i < n; i++)
            {

                if (VectorRar1.ContainsKey(i) && VectorRar2.ContainsKey(i))
                {
                    sumaelem += Math.Abs(VectorRar1[i] - VectorRar2[i]);
                }
                else if (VectorRar1.ContainsKey(i) && !VectorRar2.ContainsKey(i))
                {
                    sumaelem += Math.Abs(VectorRar1[i]);
                }

                else if (!VectorRar1.ContainsKey(i) && VectorRar2.ContainsKey(i))
                {
                    sumaelem += Math.Abs(VectorRar2[i]);
                }
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

        public Dictionary<int, double> NormalizareBinara(Dictionary<int, int> vectorRar)
        {
            Dictionary<int, double> normBinara = new Dictionary<int, double>();

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


        public Dictionary<int, double> NormalizareNominala(Dictionary<int, int> vectorRar)
        {
            float maxValueDict = vectorRar.Values.Max();
            Dictionary<int, double> vectorRarNormalizat = new Dictionary<int, double>();
            foreach (var value in vectorRar)
            {
                vectorRarNormalizat.Add(value.Key, value.Value / maxValueDict);
            }

            return vectorRarNormalizat;

        }

        public Dictionary<int, double> NormalizareSuma1(Dictionary<int, int> VectorRar)
        {
            Dictionary<int, double> VectorRarNormalizat = new Dictionary<int, double>();
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
                if (CstInformational.ElementAt(i) > prag)
                {
                    indexCuvPestePrag.Add(i);

                }
            }
            List<double> newCastigInformational = new List<double>();
            List<string> newVectorGlobal = new List<string>();
            for (int i = 0; i < indexCuvPestePrag.Count; i++)
            {

                newCastigInformational.Add(CstInformational.ElementAt(indexCuvPestePrag.ElementAt(i)));
                newVectorGlobal.Add(VectorGlobal.ElementAt(indexCuvPestePrag.ElementAt(i)));
            }
            CstInformational = newCastigInformational;
            VectorGlobal = newVectorGlobal;

            List<Dictionary<int, int>> newListVectorRar = new List<Dictionary<int, int>>();
            foreach (var vectorRar in ListVectorRar)
            {
                Dictionary<int, int> newVectorRar = new Dictionary<int, int>();

                for (int i = 0; i < indexCuvPestePrag.Count; i++)
                {
                    if (vectorRar.ContainsKey(indexCuvPestePrag[i]))
                    {
                        newVectorRar.Add(indexCuvPestePrag[i], vectorRar[indexCuvPestePrag[i]]);

                    }

                }
                newListVectorRar.Add(newVectorRar);
            }
            ListVectorRar = newListVectorRar;
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
                    if (j < 7)
                    {
                        AddText(fs, "  # testing");
                    }
                    else
                    {
                        AddText(fs, "  # training");
                    }
                    AddText(fs, "\r\n");
                    j++;
                }

            }
        }

        public void ImpartireaSetuluiDeDate()
        {

            foreach (var articol in listToReturn)
            {
                int index = listToReturn.IndexOf(articol);
                if (articol.Data_Set == "Training")
                {
                    listTraining.Add(ListVectorRarNormalizat.ElementAt(index));
                }
                else if (articol.Data_Set == "Testing")
                {
                    listTesting.Add(ListVectorRarNormalizat.ElementAt(index));
                }

            }

        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (var vectorRar in ListVectorRar)
            {

                if (radioBtbBinara.Checked)
                {
                    ListVectorRarNormalizat.Add(NormalizareBinara(vectorRar));
                }

                if (radioBtnNominala.Checked)
                {
                    ListVectorRarNormalizat.Add(NormalizareNominala(vectorRar));
                }

                if (radioBtnSuma1.Checked)
                {
                    ListVectorRarNormalizat.Add(NormalizareSuma1(vectorRar));
                }

                if (radioBtnCornellSmart.Checked)
                {
                    ListVectorRarNormalizat.Add(NormalizareCornellSmart(vectorRar));
                }

            }
        }


        public Dictionary<int, string> KNN()
        {
            int k = (int)kVal.Value;
            Dictionary<int, Dictionary<int, double>> distanta = new Dictionary<int, Dictionary<int, double>>();

            foreach (var testing in listTesting)
            {
                Dictionary<int, double> dictDistanta = new Dictionary<int, double>();
                int indexTesting = listTesting.IndexOf(testing);
                foreach (var training in listTraining)
                {
                    int indexTraining = listTraining.IndexOf(training);
                    if (RBEuclidiana.Checked)
                    {
                        dictDistanta[indexTraining] = (DistantaEuclidiana(testing, training, VectorGlobal.Count));
                    }
                    if (RBManhattan.Checked)
                    {
                        dictDistanta[indexTraining] = (DistantaManhatan(testing, training, VectorGlobal.Count));
                    }
                }
                var ordered = dictDistanta.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                distanta[indexTesting] = ordered.Take(k).ToDictionary(x => x.Key, x => x.Value);
            }
            int indexTest = 0;
            foreach (var dictDistanta in distanta)
            {
                List<string> clase = new List<string>();
                foreach (var elem in dictDistanta.Value)
                {
                    clase.Add(listToReturn.ElementAt(elem.Key).ClassCodes.First());
                }
                listaArticoleClasaPredictionata.Add(indexTest, MostSignificantClass(clase));
                indexTest++;
            }

            return listaArticoleClasaPredictionata;
        }


        public string MostSignificantClass(List<string> listClases)
        {
            Dictionary<string, int> freqClasses = new Dictionary<string, int>();

            foreach (string cls in listClases)
            {
                if (freqClasses.ContainsKey(cls))
                {
                    freqClasses[cls]++;
                }
                else
                {
                    freqClasses.Add(cls, 1);
                }
            }
            return freqClasses.OrderByDescending(x => x.Value).First().Key;
        }


        private void knnBtn_Click(object sender, EventArgs e)
        {
            KNN();
        }

        private void castigInformatioalBtn_Click(object sender, EventArgs e)
        {
            EntropieCuvantExistent();
            EntropieCuvantNeexistent();
            CastigInformational();
        }

        private void ImpartireDateBtn_Click(object sender, EventArgs e)
        {
            ImpartireaSetuluiDeDate();
        }

        private void btnEvKNN_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> frecvclase = new Dictionary<string, int>();
            foreach(var a in listaArticoleClasaPredictionata)
            {
                if (!frecvclase.ContainsKey(a.Value))
                {
                    frecvclase.Add(a.Value, 1);
                }
                else
                {
                    frecvclase[a.Value]++;
                }
            }
            frecvclase.OrderBy(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);
            float AcurateteAlg = 0;
            float PrecizieAlg = 0;
            foreach(var a in listToReturn)
            {
                if (a.Data_Set == "Testing")
                {
                    string clasa = listToReturn.ElementAt(listToReturn.IndexOf(a)).ClassCodes.First();
                    if (frecvclase.ElementAt(0).Key == clasa)
                    {
                        AcurateteAlg++;
                        PrecizieAlg++;
                    }
                }
            }
            AcurateteAlg = AcurateteAlg / listaArticoleClasaPredictionata.Count;
            PrecizieAlg = PrecizieAlg / frecvclase.ElementAt(0).Value;
            textBox1.Text += "Acuratetea algoritmului este: " + String.Format("{0:0.00}", AcurateteAlg * 100) + "%";
            textBox1.Text += "\r\nPrecizia algoritmului este: " + String.Format("{0:0.00}", PrecizieAlg * 100) + "%";
        }
    }
}