using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JimProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("input.txt");
            //StreamWriter outputFile = new StreamWriter("output.txt");
            string output = "";
            int noOfCase = int.Parse(inputFile.ReadLine());

            for (int n = 0; n < noOfCase; n++)
            {
                UInt64 answer = 1;
                string oneLine = inputFile.ReadLine();
                int numbers = int.Parse(oneLine);
                
                for (int i = 0; i < numbers; i++)
                {
                    // read numbers here
                    if (output == "")
                    {
                        output = (double.Parse(inputFile.ReadLine())/400).ToString();
                    }
                    else
                    {
                       output  = (double.Parse(output) * double.Parse(inputFile.ReadLine())).ToString();

                    }
                    

                }

                Console.WriteLine(double.Parse(output)*400);
            }
        }
    }
}
