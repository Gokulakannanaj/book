using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBrain3rdPerfectPthPower
{
    class Program
    {
        static void Main(string[] args)
        {
            int ToCheck,last, p = 1;
            string x;

            StreamReader str = new StreamReader("PerfectPthPowers.txt");
            x = str.ReadLine();
            //ToCheck = int.Parse(x);

            while (x != null)
            {
                ToCheck = int.Parse(x);
                for (int i = 2; i <= ToCheck; i++)
                {
                    if (ToCheck % i == 0)
                    {
                        int no,Power=1;
                        do
                        {
                            no = (int)Math.Pow(i,Power);
                            Power++;

                        
                        } while ( no < ToCheck);

                        //no = ToCheck /i;
                        if (no == ToCheck)
                        {
                            Console.WriteLine(Power-1);
                            break;
                        }

                    }
                }
                x = str.ReadLine();
            }

            str.Close();
        }
    }
}
