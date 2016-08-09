using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FleaChess
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("input.txt");
            //StreamWriter outputFile = new StreamWriter("output.txt");
            string oneLine;
            //int noOfCase = int.Parse(inputFile.ReadLine());
            oneLine = inputFile.ReadLine();
            while (!oneLine.Contains("0 0 0 0 0"))
            {
                string[] nums = oneLine.Split(' ');
                int S = int.Parse(nums[0]), x = int.Parse(nums[1]), y = int.Parse(nums[2]),
                    dx = int.Parse(nums[3]), dy = int.Parse(nums[4]);

                if (dx % S == 0 || dy % S == 0)
                {
                    Console.WriteLine("The flea cannot escape from black squares.");
                    oneLine = inputFile.ReadLine();
                    continue;
                }
                int jump = 0;
                while (true)
                {
                    // even
                    if ((x / S) %2 == 0)
                    {
                        
                        //odd
                        if ( (y/S) % 2 == 1)
                        {
                            if (x % S != 0 && y%S != 0)
                            {
                                Console.WriteLine("After {0} jumps the flea lands at ({1}, {2}).", jump, x, y);
                                break;
                            }
                        }
                    }

                    // odd
                    else if ((x/S) % 2 == 1)
                    {
                        //even
                        if ( (y/S) % 2 == 0)
                        {
                            if (y % S != 0 && x % S != 0)
                            {
                                Console.WriteLine("After {0} jumps the flea lands at ({1}, {2}).", jump, x, y);
                                break;
                            }
                        }
                    }

                    // position update
                    x += dx; y += dy; jump++;
                    
                }
                oneLine = inputFile.ReadLine();
            }


            inputFile.Close();
            //outputFile.Close();
        }
    }
}
