using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AprioriPreprocesare
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] matrix;
            Program obj = new Program();
            matrix = obj.MatrixToReturn();
            obj.ModifiedMatrix(matrix);
            string itemset1 = obj.Itemset1(obj.ModifiedMatrix(matrix));
            Console.WriteLine(itemset1);
            Console.ReadKey();
        }

        public string[,] MatrixToReturn()
        {

            string[,] matrice = new string[60, 60];
            using (StreamReader reader = new StreamReader(".//..//..//test_59_2.csv"))
            {
                //"C:\Users\Alina\Desktop\DMlab\AprioriPreprocesare\test_59_2.csv"
                string[] cols = new string[60];
                int row = 0;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    cols = line.Split(',');
                    for (int i = 0; i < cols.Length; i++)
                    {
                        matrice[row, i] = cols[i];
                    }
                    row++;


                }



                for (int i = 0; i < 59; i++)
                {

                    for (int j = 0; j < 59; j++)
                    {
                        //Console.Write(matrice[i, j] + "\t");
                    }

                   // Console.WriteLine();
                   // Console.WriteLine("-----------------------------------------------------------------------------------------");
                   // Console.WriteLine();

                }



            }
            return matrice;
        }
        public string[,] ModifiedMatrix(string[,] matrice)
        {
            string[,] MatrixToReturn = new string[matrice.GetLength(0) - 1, matrice.GetLength(1) - 1];
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    if (matrice[i, j] == "?")
                    {
                        matrice[i, j] = "-";
                    }
                }
            }
            for (int i = 0; i < MatrixToReturn.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixToReturn.GetLength(1); j++)
                {
                    MatrixToReturn[i, j] = matrice[i + 1, j + 1];
                    Console.Write(MatrixToReturn[i, j]);
                }
                Console.WriteLine();

            }
            return MatrixToReturn;
        }
        List<(string Produs, string Frecventa)> lista = new List<(string, string)>();
        private string Itemset1(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != "-")
                    {
                        lista.Add((matrix[i, j], null));
                    }
                }
            }

            lista = lista.OrderBy(o => o.Produs).ToList();

            string produseTemp = "";               
            foreach (var i in lista)
            { 
                produseTemp += i.Produs + " ";
            }

            string[] vecProduse = produseTemp.Split(' ');

            vecProduse = vecProduse.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            int[] Frecventa = new int[256];

            for (int i = 1; i < vecProduse.Length; i++)
            {
                if (vecProduse[i - 1] == vecProduse[i])
                {
                    Frecventa[Convert.ToInt32(vecProduse[i].Substring(1))]++;
                }
            }

            vecProduse = vecProduse.Distinct().ToArray();
            Frecventa = Frecventa.Where(x => x != 0).ToArray();

            Dictionary<string , int> dictionar = new Dictionary<string , int>{ };

            for (int i = 0; i < vecProduse.Length; i++)
            {
                dictionar.Add(vecProduse[i], Frecventa[i]);
            }
            string afisare = "";

            foreach (var i in dictionar)
            {
                afisare += i.Key + " - " + i.Value + "\n";
            }

            return afisare;
        }
    }
}
