using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJamProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Reader = new StreamReader("B-small-attempt0.in");
            StreamWriter Writer = new StreamWriter("Output.txt");

            string oneLine = Reader.ReadLine();
            byte NoOfTestCases = Byte.Parse(oneLine);

            for (int i = 1; i <= NoOfTestCases; i++)
            {
                decimal CostOfFarm, CookieRateOnFarm, WinningPoint;
                oneLine = Reader.ReadLine();
                string[] Bits = oneLine.Split(' ');

                CostOfFarm = decimal.Parse(Bits[0]);
                CookieRateOnFarm = decimal.Parse(Bits[1]);
                WinningPoint = decimal.Parse(Bits[2]);
                string Output = "";
                MinimumTime(CostOfFarm, CookieRateOnFarm, WinningPoint, out Output);
                Writer.Write("Case #{0}: {1}\n",i,Output);
            }

            Writer.Close();
            Reader.Close();
        }

        public static void MinimumTime(decimal CostOfFarm, decimal CookieRateOnFarm, decimal WinningPoint, out string output, decimal CurrentCookieRate=2, decimal currentTime = 0)
        {
            decimal TimeBeforeBuying, TimeAfterBuying;
            TimeBeforeBuying = currentTime + (WinningPoint / CurrentCookieRate);
            TimeAfterBuying = currentTime + (CostOfFarm / CurrentCookieRate) + (WinningPoint / (CurrentCookieRate+CookieRateOnFarm));
 
            if( TimeAfterBuying < TimeBeforeBuying)
            {
                MinimumTime(CostOfFarm, CookieRateOnFarm, WinningPoint, out output, CurrentCookieRate + CookieRateOnFarm, currentTime + (CostOfFarm / CurrentCookieRate));
            }
            else
            {
                output = (currentTime + (WinningPoint / CurrentCookieRate)).ToString(".#######");
                
            }
            return;
        }
    }
}
