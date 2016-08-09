using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBrainTest1ForNewLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string ExactChange,oneLine="";
            
            string ToPayStr = "";
            
            uint  lineCounter;

            List<uint> ToPay = new List<uint>();
            List<uint> Note = new List<uint>();

            System.IO.StreamReader abc = new System.IO.StreamReader("ExactChange.txt");

            oneLine = abc.ReadLine();
            lineCounter = uint.Parse(oneLine);

            while( oneLine!=null)
			{
                for (int i = 0; i < lineCounter; i++)
                {
                    oneLine = abc.ReadLine();
                    ToPay.Add(uint.Parse(oneLine));
                }

                oneLine = abc.ReadLine();
                lineCounter = uint.Parse(oneLine);

                for (int i = 0; i < lineCounter; i++)
                {
                    oneLine = abc.ReadLine();
                    Note.Add(uint.Parse(oneLine));
                }

                oneLine = abc.ReadLine();
			}

            uint Amount = 0;
            foreach (var bill in ToPay)
            {
                Amount += bill;
            }

            ushort counts=0;
            uint minDif=Amount;
            int total=0,last=Note.Count-1;
            for (int i =Note.Count-1 ; i > 0; i--)
            {
                if (Amount - Note.ElementAt<uint>(i) < minDif)
                {
                    total += (int)Note.ElementAt<uint>(i);

                    last = i;

                    counts++;
                    Amount -= Note.ElementAt<uint>(i);
                }
            }

            if (Amount > 0)
            {
                total += (int)Note.ElementAt<uint>(last - 1);
                counts++;
            }
            Console.WriteLine(total + " " + counts);
            Console.ReadLine();
            abc.Close();
        }
    }
}
