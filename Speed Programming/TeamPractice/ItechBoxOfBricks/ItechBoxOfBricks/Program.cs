using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechBoxOfBricks
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader FileReader = new System.IO.StreamReader("BoxofBricks.txt");
            string OneLine = FileReader.ReadLine();
            int Moves = 0;
            List<int> Blocks = new List<int>();
            int NoOfBlocks;
            while ( (NoOfBlocks = int.Parse(OneLine)) != 0)
            {
                OneLine = FileReader.ReadLine();
                string[] StringBlocks = OneLine.Split(' ');

                foreach (var strBlock in StringBlocks)
                {
                    Blocks.Add(int.Parse(strBlock));
                }


                while ( !AllAreEqual(Blocks) )
                {
                    Moves++;
                    int MaxValueIndex = Blocks.IndexOf(Blocks.Max());
                    int MinValueIndex = Blocks.IndexOf(Blocks.Min());
                    Blocks[MaxValueIndex]--; 
                    Blocks[MinValueIndex]++;
                }

                Console.WriteLine(Moves);
                OneLine = FileReader.ReadLine();
            }    
        }

        public static bool AllAreEqual(List<int> AllBLocks)
        {
            bool result = true;
            for (int i = 0; i < AllBLocks.Count-1; i++)
            {
                if ( AllBLocks.ElementAt(i) != AllBLocks.ElementAt(i+1))
                {
                    return false;
                }
            }

            return result;

        }
    }
}
