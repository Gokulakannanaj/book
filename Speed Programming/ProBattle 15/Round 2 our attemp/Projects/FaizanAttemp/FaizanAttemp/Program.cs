using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FaizanAttemp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("input.txt");

            string compressedStr = "";
            string uncompressedStr = "";
            compressedStr = inputFile.ReadLine().Trim();
            while (compressedStr != "$")
            {
                
                uncompressedStr = findCompresser(compressedStr);
                Console.WriteLine(uncompressedStr);
                compressedStr = inputFile.ReadLine().Trim();
            }
        }


        public static string findCompresser(string input)
        {
            int start, end;
            while (input.Contains('('))
            {
                start = input.LastIndexOf('(');
                end = input.IndexOf(')');
                var temp = returnUnCompressed(start, end, input);
                input = input.Substring(0, start+1) + temp + input.Substring(end);
            }
            return input;

        }
        public static string returnUnCompressed(int start, int end, string input)
        {
            string chunk = input.Substring(start+ 1, input.Length - end);
            string currentScopeStr = "";
            int num;

            for (int i = 0; i < chunk.Length; i++)
            {
                if (int.TryParse(chunk[i].ToString(), out num))
                {
                    string cSS2 = currentScopeStr;
                    for (int k = 1; k < num; k++)
                    {
                        currentScopeStr += cSS2;
                    }
                }
                else
                {
                    currentScopeStr += chunk[i];
                }
            }

            return currentScopeStr;

        }
    }
}
