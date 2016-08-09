using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBrainRound3CombinationLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("CombinationLock.txt");
            ushort starter, first, second, third;
            string oneLine;
            string[] bits;

            //oneLine = reader.ReadLine();
            while ((oneLine = reader.ReadLine()) != null)
            {
               bits = oneLine.Split(' ');
               starter = ushort.Parse(bits[0]);
               first = ushort.Parse(bits[1]);
               second = ushort.Parse(bits[2]);
               third = ushort.Parse(bits[3]);
               if (first == second && second == third)
               {
                   continue;
               }

               first -= starter;
               second -= starter;
               third -= starter;

               starter = 720;
               starter += (ushort)(360 - (first * 9));
               starter += 360;
               starter += (ushort)(360 - (first * 9));
               starter += (ushort)(360 - (third * 9));
               Console.WriteLine(starter);
            }


            reader.Close();
        }
    }
}
