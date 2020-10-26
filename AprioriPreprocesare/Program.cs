using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AprioriPreprocesare
{
    class Program
    {
        static void Main(string[] args)
        {


            Program obj = new Program();

            obj.MatrixToReturn();

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
                        Console.Write(matrice[i, j] + "\t");
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine();

                }

               

            }
            return matrice;
        }


    }
}
