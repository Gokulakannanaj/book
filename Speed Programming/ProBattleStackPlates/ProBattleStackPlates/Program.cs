using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBattleStackPlates
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Reader = new StreamReader("Input.txt");
            List<Stack<int>> StackPlates = new List<Stack<int>>();
            Stack<int> TemporaryStack = new Stack<int>();
            
            string OneLine;
            StackPlates.Add(TemporaryStack);
            
            while ((OneLine= Reader.ReadLine()) != null)
            {
                ushort NoOfPlates = ushort.Parse(OneLine);

                for (int i = 0; i < NoOfPlates; i++)
                {
                    OneLine = Reader.ReadLine();
                    string[] Bits = OneLine.Split(' ');
                    Stack<int> Temp = new Stack<int>();

                    for (int j = 1; j < Bits.Length; j++)
                    {
                        Temp.Push(int.Parse(Bits[j]));
                    }
                    StackPlates.Add(Temp);
                }

                NoOfStepsOfPlates(StackPlates);
            }  
        }

        public static int NoOfStepsOfPlates(List<Stack<int>> StackPlates)
        {
            int count = 0;
            if (IsAllStackSame(StackPlates))
            {
                return StackPlates.Count - 1;
            }

            int max = 0, index = 0;
            for (int i = 1; i < StackPlates.Count; i++)
			{
                if (StackPlates[i].Max() > max)
                {
                    max = StackPlates[i].Max();
                    index = i;
                }
			}

            StackPlates[0].Push(StackPlates[index].Pop());
            count++;





            return 0;
        }

        public static bool IsAllStackSame(List<Stack<int>> StackPlates)
        {
            for (int i = 1; i < StackPlates.Count-1; i++)
            {
                if (StackPlates[i].Max() != StackPlates[i + 1].Max() && StackPlates[i].Max() != StackPlates[i].Min())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
