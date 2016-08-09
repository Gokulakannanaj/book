using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJamProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Reader = new StreamReader("A-small-attempt0.in");
            StreamWriter Writer = new StreamWriter("Output.txt");

            string oneLine = Reader.ReadLine();
            byte NoOfTestCases = Byte.Parse(oneLine);

            for (int i = 1; i <= NoOfTestCases; i++)
            {
                int[,] FirstArrangement;
                int[,] SecondArrangement;
                byte FirstRowPicked, SecondRowPicked;
                TakeInput(out FirstRowPicked, out FirstArrangement, Reader);
                TakeInput(out SecondRowPicked, out SecondArrangement, Reader);
                int selected;
                int Occurence = SelectedCard(FirstRowPicked, SecondRowPicked, FirstArrangement, SecondArrangement, out selected);
                if (Occurence == 1)
                {
                    Writer.Write("Case #{0}: {1}\n", i, selected);
                }
                else if( Occurence == 0)
                {
                    Writer.Write("Case #{0}: Volunteer cheated!\n", i);
                }
                else if( Occurence > 1)
                {
                    Writer.Write("Case #{0}: Bad magician!\n", i);
                }
            }
            Reader.Close();
            Writer.Close();
        }


        public static void TakeInput(out byte rowPicked,out int[,] Arrangement,StreamReader Reader)
        {
            rowPicked = byte.Parse(Reader.ReadLine());
            rowPicked--;
            Arrangement = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                string oneLine = Reader.ReadLine();
                string[] Bits = oneLine.Split(' ');
                for (int j = 0; j < Bits.Length; j++)
                {
                    Arrangement[i, j] = int.Parse(Bits[j]);
                }
            }
        }

        public static int SelectedCard(byte FirstRowPicked,byte SecondRowPicked, int[,] FirstArrangement,int[,] SecondArrangement,out int selectedCard)
        {
            int count = 0;
            selectedCard = -1;
            for (int i = 0; i < FirstArrangement.GetLength(1) ; i++)
            {
                for (int j = 0; j < SecondArrangement.GetLength(1); j++)
                {
                    if(FirstArrangement[FirstRowPicked,i] == SecondArrangement[SecondRowPicked,j])
                    {
                        selectedCard = FirstArrangement[FirstRowPicked, i];
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
