using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            List<String> inputs = new List<string>();

            
            //Console.WriteLine("> Input all casses till \"0 0\"");

            string oneLine;
            while ((oneLine = Console.ReadLine()) != "0 0")
            {
                inputs.Add(oneLine);
            }
            inputs.Add(oneLine);
           
            Console.Clear();

            whoWins(inputs);

            Console.ReadLine();
        }

        static void whoWins(List<string> inputs)
        {
            int firstNum;
            int secondNum;

            int toMultiply = 1, multiplier = 1, ans;
            bool isFirstLesser = true, stanTurn = true, endGame = false, caseEnd = false;

            int index = 0;

            while (!endGame)
            {
                string[] input = inputs[index++].Split(' ');

                firstNum = int.Parse(input[0]);
                secondNum = int.Parse(input[1]);


                if (firstNum == 0 && secondNum == 0)
                {
                    endGame = true;
                    break;
                }
                caseEnd = false;
                multiplier = 1; toMultiply = 1; isFirstLesser = true; stanTurn = true;

                while (caseEnd == false)
                {
                    if (firstNum < secondNum) { toMultiply = firstNum; isFirstLesser = true; }
                    else if (secondNum < firstNum) { toMultiply = secondNum; isFirstLesser = false; }

                    while (caseEnd == false)
                    {
                        if (isFirstLesser)
                        {
                            ans = secondNum - (toMultiply * multiplier);
                            if (ans < secondNum && ans >= 0) { multiplier++; continue; }
                            else
                            {
                                multiplier--;
                                ans = secondNum - (toMultiply * multiplier);
                                if (ans == 0)
                                {
                                    if (stanTurn)
                                    {
                                        Console.WriteLine("Stan wins"); caseEnd = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ollie wins"); caseEnd = true;
                                    }
                                }
                                else
                                {
                                    secondNum = ans;
                                    stanTurn = !stanTurn;
                                    multiplier = 1;
                                    break;
                                }
                            }
                        }
                        else if (!isFirstLesser)
                        {
                            ans = firstNum - (toMultiply * multiplier);
                            if (ans < firstNum && ans >= 0) { multiplier++; continue; }
                            else
                            {
                                multiplier--;
                                ans = firstNum - (toMultiply * multiplier);
                                if (ans == 0)
                                {
                                    if (stanTurn)
                                    {
                                        Console.WriteLine("Stan wins"); caseEnd = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ollie wins"); caseEnd = true;
                                    }
                                }
                                else
                                {
                                    firstNum = ans;
                                    stanTurn = !stanTurn;
                                    multiplier = 1;
                                    break;
                                }
                            }
                        }

                    }

                    // best multiplier check
                }

            }
        }

    }
}
