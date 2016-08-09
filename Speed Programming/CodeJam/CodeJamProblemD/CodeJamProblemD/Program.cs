using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJamProblemD
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Reader = new StreamReader("D-large.in");
            StreamWriter Writer = new StreamWriter("Output.txt");

            string oneLine = Reader.ReadLine();
            byte NoOfTestCases = Byte.Parse(oneLine);

            for (int i = 1; i <= NoOfTestCases; i++)
            {
                List<decimal> KenPlanks;
                List<decimal> KenPlanks2 = new List<decimal>();
                

                List<decimal> NaomiPlanks;
                List<decimal> NaomiPlanks2 = new List<decimal>();
                
                Reader.ReadLine();
                NaomiPlanks = TakeInput(Reader);
                KenPlanks = TakeInput(Reader);

                foreach (var item in KenPlanks)
                {
                    KenPlanks2.Add(item);
                }

                foreach (var item in NaomiPlanks)
                {
                    NaomiPlanks2.Add(item);
                }

                int nWar = NaomiWarScore(KenPlanks, NaomiPlanks);
                int dWar = NaomiDefielWar(KenPlanks2, NaomiPlanks2);
                Console.Write("Case #{0}: {1} {2}\n", i, dWar, nWar);
                Writer.Write("Case #{0}: {1} {2}\n",i,dWar,nWar);
            }

            Writer.Close();
            Reader.Close();
        }

        public static  List<decimal> TakeInput(StreamReader Reader )
        {
            string temp = Reader.ReadLine();
            string[] Bits = temp.Split(' ');
            List<decimal> Planks = new List<decimal>();
            for (int i = 0; i < Bits.Length; i++)
            {
                Planks.Add(decimal.Parse(Bits[i]));
            }

            return Planks;
        }

        public static int NaomiWarScore(List<decimal> Kens, List<decimal> Naomis)
        {
            int score = 0;
            while( Kens.Count > 0 && Naomis.Count > 0)
            {
                decimal KensPicked;
                decimal NaomisPicked = Naomis.Max(); 
                if (Kens.Max() < Naomis.Max())
                {
                    KensPicked = Kens.Min();
                    Kens.Remove(KensPicked);
                    Naomis.Remove(NaomisPicked);
                    score++;
                }
                else
                {
                    Kens.Remove(Kens.Max());
                    Naomis.Remove(Naomis.Max());
                }
            }
            return score;
        }

        public static int NaomiDefielWar(List<decimal> Kens, List<decimal> Naomis)
        {
            int score = 0;
            Random gen = new Random();

            decimal NaomiPicked;
            decimal? NaomisTold;
            decimal KensPicked;

            while (Naomis.Count > 0 && Kens.Count > 0)
            {
                if (Kens.Max() < Naomis.Min())
                {
                    score += Naomis.Count;
                    Naomis.Clear();
                }
                else if (Kens.Max() > Naomis.Max())
                {
                    NaomiPicked = Naomis.Min();
                    decimal? second = SecondHighest(Kens);

                    if (second != null)
                    {
                    back:
                        NaomisTold = (SecondHighest(Kens) + (decimal)gen.NextDouble()) % Kens.Max();
                        if (Kens.Contains((decimal)NaomisTold))
                        {
                            goto back;
                        }
                        if (NaomisTold > second && NaomisTold < Kens.Max())
                        {
                            KensPicked = Kens.Max();
                            Kens.Remove(KensPicked);
                            Naomis.Remove(NaomiPicked);
                        }
                    }

                    else
                    {
                        if (Kens.Max() < Naomis.Max() )
                        {
                            score++;
                            Kens.Remove(Kens.Max());
                            Naomis.Remove(Naomis.Max());
                        }
                        else
                        {
                            Kens.Remove(Kens.Max());
                            Naomis.Remove(Naomis.Max());
                        }
                    }
                }
                else if (Naomis.Max() > Kens.Max())
                {
                    NaomiPicked = Naomis.Max();
                backagain:
                    NaomisTold = Kens.Max() + (decimal)gen.NextDouble()% Naomis.Max();
                    if (NaomisTold <= Kens.Max())
                    {
                        goto backagain;
                    }
                    else if ( Naomis.Min() > Kens.Min())
                    {
                        KensPicked = Kens.Min();
                        NaomiPicked = Naomis.Min();
                        score++;
                        Kens.Remove(KensPicked);
                        Naomis.Remove(NaomiPicked);
                    }
                    else
                    {
                        NaomiPicked = SecondMin(Kens.Min(), Naomis);
                        KensPicked = Kens.Min();
                        score++;
                        Naomis.Remove(NaomiPicked);
                        Kens.Remove(KensPicked);
                    }
                }
                

            }
            return score;
        }
        public static decimal? SecondHighest(List<decimal> Planks)
        {
            if (Planks.Count <= 1)
            {
                return null;
            }
            if (Planks.Count == 2)
            {
                return Planks.Min();
            }
            else
            {

                decimal max = Planks.Max(); 
                decimal secondMax;
                if (Planks.Max()  != Planks[0])
                { 
                    secondMax = Planks[0];
                }
                else
                {
                    secondMax = Planks[1];
                }
                foreach (var item in Planks)
                {
                    if ( item > secondMax && item < Planks.Max())
                    {
                        secondMax = item;
                    }
                }

                return secondMax;
            }

        }

        public static decimal SecondMin(decimal moreThan,List<decimal> Naomi)
        {

            decimal NaomiMiniest = Naomi.Max();

            foreach (var item in Naomi)
            {
                if ( item > moreThan && NaomiMiniest > item)
                {
                    NaomiMiniest = item;
                }
            }
            return NaomiMiniest;
        }
        
    }
}
