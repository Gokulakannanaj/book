using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPracticeAgainPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Reader = new StreamReader("Input.txt");
            int NoOfCases = int.Parse(Reader.ReadLine());
            string OneLine;
            int count = 0;
            for (int i = 0; i < NoOfCases; i++)
            {
                OneLine = Reader.ReadLine();


                List<string> Combinations = PowerSet(OneLine) ;
                
                foreach (var item in Combinations)
                {
                    if(IsPalindrome(item))
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
                Combinations.Clear();
                count = 0;
            }
        }


        public static bool IsPalindrome(string ToCheck)
        {
            bool result = true;
            if (ToCheck.Length == 1)
            {
                return true;
            }
            else if (ToCheck.Length == 0)
            {
                return false;
            }
            char[] bits = ToCheck.ToCharArray();
            for (int i = 0; i < bits.Length/2 ; i++)
            {
                if ( bits[i] != bits[bits.Length-1-i])
                {
                    return false;
                }
            }
            return result;
        }

        private static List<string> PowerSet(string input)
        {
            int n = input.Length;
            // Power set contains 2^N subsets.
            int powerSetCount = 1 << n;
            var ans = new List<string>();

            for (int setMask = 0; setMask < powerSetCount; setMask++)
            {
                var s = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    // Checking whether i'th element of input collection should go to the current subset.
                    if ((setMask & (1 << i)) > 0)
                    {
                        s.Append(input[i]);
                    }
                }
                ans.Add(s.ToString());
            }

            return ans;
        }
    }
}
