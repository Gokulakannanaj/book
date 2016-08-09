using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPractice10BrowniePointsII
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fs = new StreamReader("Brownie.txt");
            string f = fs.ReadLine();
            ushort NoOfTestCases = ushort.Parse(f);
            for (int i = 0; i < NoOfTestCases; i++)
            {
                string fsr = fs.ReadLine();
                Brownie ob = new Brownie(fsr);
                
            }


        }
    }


    class Brownie
    {
        public short x, y;
        public static byte Stan = 0, Ollie = 0;
        public Brownie(string S)
        {
            string[] Cordinates = S.Split(' ');
            this.x = short.Parse(Cordinates[0]);
            this.y = short.Parse(Cordinates[1]);
            if (this.x > 0 && this.y > 0 || this.x<0 && this.y <0)
            { Stan++; }
            if (this.x > 0 && this.y < 0 || this.x < 0 && this.y > 0)
            { Ollie++; }

        }



    }
}
