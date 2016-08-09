using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace compressed_words
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("input.txt");
           
            string compressedStr = "";
            string uncompressedStr = "";

            while(compressedStr!="$")
            {
                compressedStr = inputFile.ReadLine().Trim();
                uncompressedStr = findUncompressedStr(compressedStr);
                Console.WriteLine(uncompressedStr);
            }

        }

        public static string findUncompressedStr(string compressedStr)
        {
            int scope = 0;
            Stack<int> bOIndex = new Stack<int>();
            string uncompressedStr = "", currentScopeStr = "";
            int num = 0;
            bool bracketFound = false;

            for (int i = 0; i < compressedStr.Length; i++)
            {
                if (compressedStr[i] == ' ')
                {
                    continue;
                }
                else if (compressedStr[i] == '$')
                {
                    if (bracketFound == false)
                    {
                        uncompressedStr = currentScopeStr;
                    }

                    break;
                }
                else if (compressedStr[i] == '(')
                {
                    bracketFound = true;
                    scope++; bOIndex.Push(i);
                    uncompressedStr += currentScopeStr;
                    currentScopeStr = "";
                }
                else if (compressedStr[i] == ')')
                {
                    scope--; bOIndex.Pop();
                    if (scope == 0)
                    {
                        uncompressedStr = currentScopeStr;
                    }
                    else
                    {
                        uncompressedStr += currentScopeStr;
                    }
                    currentScopeStr = uncompressedStr;
                }
                else if (int.TryParse(compressedStr[i].ToString(), out num))
                {
                    string cSS2 = currentScopeStr;
                    for (int k = 1; k < num; k++)
                    {
                        currentScopeStr += cSS2;
                    }
                }
                else
                {
                    currentScopeStr += compressedStr[i];
                }

            }
            return uncompressedStr;
        }
    }
}
