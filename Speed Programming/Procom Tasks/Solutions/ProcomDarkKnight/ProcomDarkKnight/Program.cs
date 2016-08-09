using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcomDarkKnight
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader Reader = new System.IO.StreamReader("Input.txt");
            string OneLine = Reader.ReadLine();

            int NoOfTestCase =  int.Parse(OneLine);

            for (int i = 0; i < NoOfTestCase; i++)
            {
                int n = int.Parse(Reader.ReadLine());
                string[] rows = new string[n];
                for (int j = 0; j < n; j++)
                {
                    rows[j] = Reader.ReadLine();
                }

                if( IsValidBoard(rows))
                {
                    Console.WriteLine("Valid");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }


        public static bool IsValidBoard(string[] Rows)
        {

            for (int i = 0; i < Rows.Length; i++)
            {
                for (int j = 0; j < Rows[i].Length; j++)
                {
                    #region  checking all possibilities
                    if (Rows[i][j] == '1')
                    {
                        if (i - 2 >= 0 && j - 1 >= 0)
                        {
                            if(Rows[i-2][j-1] == '1')
                            {
                                return false;
                            }
                        }

                        else if (i - 2 >= 0 && j + 1 <= Rows.Length)
                        {
                            if (Rows[i - 2][j + 1] == '1')
                            {
                                return false;
                            }
                        }

                        else if (i + 2 <= Rows.Length && j - 1 >= 0)
                        {
                            if (Rows[i + 2][j - 1] == '1')
                            {
                                return false;
                            }
                        }

                        else if (i + 2 <= Rows.Length && j + 1 <= Rows.Length)
                        {
                            if (Rows[i + 2][j + 1] == '1')
                            {
                                return false;
                            }
                        }
                        else if (i + 1 <= Rows.Length && j + 2 <= Rows.Length)
                        {
                            if (Rows[i + 1][j + 2] == '1')
                            {
                                return false;
                            }
                        }

                        else if (i + 1 <= Rows.Length && j - 2 >= 0)
                        {
                            if (Rows[i + 1][j - 2] == '1')
                            {
                                return false;
                            }
                        }

                        else if (i - 1 >= 0 && j + 2 <= Rows.Length)
                        {
                            if (Rows[i - 1][j + 2] == '1')
                            {
                                return false;
                            }
                        }
                        else if (i - 1 >= 0 && j - 2 <= 0)
                        {
                            if (Rows[i - 1][j - 2] == '1')
                            {
                                return false;
                            }
                        }
                    }
                    #endregion
                }
            }

            return true;
        }
    }
}
