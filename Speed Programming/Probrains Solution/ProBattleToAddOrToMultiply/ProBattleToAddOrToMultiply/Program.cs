using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBattleToAddOrToMultiply
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader File = new System.IO.StreamReader("Input.txt");
            string OneLine= File.ReadLine();

            while (OneLine != null)
            {
                string[] Bits = OneLine.Split(' ');
                int Adder = int.Parse(Bits[0]);
                int Multiplier = int.Parse(Bits[1]);
                int Input1 = int.Parse(Bits[2]);
                int Input2 = int.Parse(Bits[3]);
                int Min = int.Parse(Bits[4]);
                int Max = int.Parse(Bits[5]);

                List<string> Answers = AllPossibility(Input1, Input2, Multiplier, Adder, Min, Max);
                //foreach (var item in Answers)
                //{
                //    Console.WriteLine(item);
                //}
                
                var one = from Answer in Answers
                          orderby Answer.Length
                          select Answer;

                Console.WriteLine(one.ElementAt(0));

                OneLine = File.ReadLine();
            }

            File.Close();
        }



        public static List<string> AllPossibility(int Input1, int Input2, int Multiplier, int Adder, int Min, int Max)
        {
            List<string> PossibleAnswer = new List<string>();

            Possibilities(Input1, Adder, Multiplier, "", Min, Max, ref PossibleAnswer);
            Possibilities(Input2, Adder, Multiplier, "", Min, Max, ref PossibleAnswer);



            return PossibleAnswer;
        }

        public static void Possibilities(int Number,int Adder, int Multiplier, string Prev, int Min, int Max,ref List<string> PossibleAnswers)
        {
            if (Number <= Max && Number >= Min)
            {
                PossibleAnswers.Add(Prev);
                return;
            }
            else if (Number> Max)
            {
                return;
            }

            else 
            {
                Possibilities(Number + Adder, Adder, Multiplier, Prev + "A", Min, Max, ref PossibleAnswers);
                Possibilities(Number * Multiplier, Adder, Multiplier, Prev + "M", Min, Max, ref PossibleAnswers);
            }
        }
    }
}
