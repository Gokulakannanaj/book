using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("input.txt");
            StreamWriter outputFile = new StreamWriter("output.txt");
            string output = "";
            int noOfCase = int.Parse(inputFile.ReadLine());
            
            for (int n = 0; n < noOfCase; n++)
            {
                string[] input = inputFile.ReadLine().Split(' ');
                int start = int.Parse(input[0]), end = int.Parse(input[1]);
                for (int i = start; i <= end; i++)
                {
                    if (isPrime(i))
                    {
                        if (isPalindrom(i.ToString()))
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
                Console.WriteLine("#");
            }


            inputFile.Close();
            outputFile.Close();
        }
        public static bool isPrime(int n)
        {
            for (int i = 2; i < n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool isPalindrom(string word)
        {
            if (word.Length == 1)
            {
                return true;
            }
            for (int i = 0; i < word.Length/2; i++)
            {
                if (word[i] != word[word.Length-1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
