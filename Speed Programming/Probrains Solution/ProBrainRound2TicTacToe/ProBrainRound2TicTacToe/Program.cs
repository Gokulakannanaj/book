using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBrainRound2TicTacToe
{
    class Program
    {
        public static List<string> rowsOfGrid = new List<string>();
        public static int GridSize;
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("TicTacToe.txt");
            bool IsValidMatch = false;
            int NoOfCases = int.Parse(reader.ReadLine());
            int XAppeared = 0,OAppeared = 0;
            for (int i = 0; i < NoOfCases; i++)
            {
                string oneLine = reader.ReadLine();
                string[] bits = oneLine.Split(' ');
                GridSize = int.Parse(bits[0]);

                for (int j = 0; j < GridSize; j++)
                {
                    rowsOfGrid.Add(reader.ReadLine());
                    OAppeared += StringAppeared(rowsOfGrid.ElementAt(j), "O");
                    XAppeared += StringAppeared(rowsOfGrid.ElementAt(j), "X");
                }
                if (XAppeared == OAppeared)
                {
                    IsValidMatch= CharAppearedInRow("X");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedInColumn("X");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedDiagonal("X");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedAntiDiagonal("X");

                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedInRow("O");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedInColumn("O");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedDiagonal("O");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedAntiDiagonal("O");

                }
                  

                else if (XAppeared == OAppeared + 1 )
                {
                    IsValidMatch = CharAppearedInRow("X");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedInColumn("X");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedDiagonal("X");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedAntiDiagonal("X");
                }

                else if (OAppeared == XAppeared + 1)
                {
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedInRow("O");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedInColumn("O");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedDiagonal("O");
                    if (IsValidMatch == false)
                        IsValidMatch = CharAppearedAntiDiagonal("O");

                }

                else if (XAppeared > OAppeared + 1 || OAppeared > XAppeared + 1)
                {
                    Console.WriteLine("ERROR");
                }

                else
                {
                    Console.WriteLine("Game In Progress");
                }
                IsValidMatch = false;
                rowsOfGrid.Clear();
                XAppeared = OAppeared = 0;
            }

        }


        public static int StringAppeared( string original, string value)
        {
            string test = original.Replace(value, "");
            return (original.Length - test.Length) / value.Length; 

        }

        public static bool CharAppearedInRow(string x)
        {
            bool result = false;
            int no;
            for (int i = 0; i < GridSize; i++)
            {
                no = StringAppeared(rowsOfGrid.ElementAt(i),x);
                if (no == GridSize)
                {
                    result = true;
                    Console.WriteLine("{0} WINS",x );
                    break;
                }
            }

            return result;
        }

        public static bool CharAppearedInColumn(string x)
        {
            bool result= false;
            int no=0;
            
            int IndexOfString = rowsOfGrid.ElementAt(0).IndexOf(x);
            for (int i = 0; i < GridSize; i++)
            {
                if (String.Equals(rowsOfGrid.ElementAt(0)[IndexOfString].ToString(),rowsOfGrid.ElementAt(i)[IndexOfString].ToString(),StringComparison.Ordinal))
                    no++;
            }

            if (no == GridSize)
            {
                result = true;
                Console.WriteLine("{0} WINS", x);
            }
            return result;
        }

        public static bool CharAppearedDiagonal(string x)
        {
            int no = 0;
            bool result = false;
            if (String.Equals(rowsOfGrid.ElementAt(0)[0].ToString(), x, StringComparison.Ordinal))
            {
                no++;
                for (int i = 1; i < GridSize ; i++)
                {
                    if (String.Equals(rowsOfGrid.ElementAt(i)[i].ToString(), x, StringComparison.Ordinal))
                        no++;
                }

                if (no >= GridSize)
                {
                    result = true;
                    Console.WriteLine("{0} WINS", x);
                }
            }
            return result;
        }

        public static bool CharAppearedAntiDiagonal(string x)
        {
            bool result = false;
            int no = 0;
            if ( String.Equals(rowsOfGrid.ElementAt(GridSize-1)[0].ToString(), x,StringComparison.Ordinal))
            {
                no++;
                for (int i = 1; i < GridSize; i++)
                {
                    if (String.Equals(rowsOfGrid.ElementAt(GridSize - i)[i].ToString(), x, StringComparison.Ordinal))
                    {
                        no++;
                    }
                }
            }
            if (no >= GridSize)
            {
                result = true;
                Console.WriteLine("{0} WINS", x); 
            }
            return result;
        }
    }
}
