using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBrainRound2Catenyms
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("Catenyms.txt");
            ushort NoOfCases;
            string oneLine;
            List<string> words = new List<string>();

            NoOfCases = ushort.Parse(reader.ReadLine());

            for (int i = 0; i < NoOfCases; i++)
            {
                uint NoOfWords;
                NoOfWords = uint.Parse(reader.ReadLine());
                for (int j = 0; j < NoOfWords; j++)
                {
                    words.Add(reader.ReadLine());
                }
                words.Sort();
                string firstWord = words.ElementAt(0);
                string outputString = firstWord;
                words.Remove( words.ElementAt(0));
                while (words.Count >0  && NoOfWords > 0)
                {
                    int k = 0;
                    char lc, fc = fc = words.ElementAt(k)[0]; ;
                    
                    do 
                    {
                        lc = firstWord[firstWord.Length - 1];
                        if (words.Count != 0)
                        {
                            fc = words.ElementAt(k)[0];
                        }
                        
                        if (fc == lc)
                        {
                            outputString += "." + words.ElementAt(k);
                            firstWord = words.ElementAt(k);
                            words.Remove(words.ElementAt(k));
                            
                        }
                        else
                        {
                            if ( k < words.Count-1 )
                                k++;
                            NoOfWords--;
                            
                        }
                    } while (NoOfWords > 0 );

                    if (NoOfWords != words.Count)
                    {
                        outputString = "***";
                        words.Clear();
                    }
                    Console.WriteLine(outputString);
                }
            }
            

        }
    }
}
