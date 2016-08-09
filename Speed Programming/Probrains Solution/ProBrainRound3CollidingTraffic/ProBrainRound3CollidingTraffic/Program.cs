using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBrainRound3CollidingTraffic
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("CollidingTraffic.txt");
            int NoOFCases = int.Parse(reader.ReadLine());
            List<boat> boats = new List<boat>();
            
            for (int i = 0; i < NoOFCases; i++)
            {
                int[] time = new int[2];
                string oneLine = reader.ReadLine();
                string[] bits = oneLine.Split(' ');
                int n = int.Parse(bits[0]);
                int r = int.Parse(bits[1]);

                for (int j = 0; j < n; j++)
                {
                    
                    boats.Add(new boat(reader.ReadLine()));
                }

                for (int first = 0; first < n; first++)
                {
                    
                    time[0] = 0;
                    for (int k = first+1; k < n; k++)
                    {
                        double distance = boats.ElementAt(first).DistanceBetweenBoats(boats.ElementAt(k));
                        double anglesNow = 0;
                        decimal rounded=0;
                        while (distance>= r)
                        {
                            anglesNow=Math.Cos(boats.ElementAt(first).angle * Math.PI/180);
                            rounded = Decimal.Round((decimal)anglesNow, 6);
                            boats.ElementAt(first).x += (double)(rounded * boats.ElementAt(first).speed * 1);
                            
                            anglesNow = (Math.Sin(boats.ElementAt(first).angle *( Math.PI / 180)));
                            rounded = Decimal.Round((decimal)anglesNow, 6);
                            boats.ElementAt(first).y += (double)rounded * boats.ElementAt(first).speed * 1;
                            
                            anglesNow = Math.Cos(boats.ElementAt(k).angle * Math.PI / 180) ;
                            rounded = Decimal.Round((decimal)anglesNow, 6);
                            boats.ElementAt(k).x += (double)rounded * boats.ElementAt(k).speed * 1;

                            anglesNow = Math.Sin(boats.ElementAt(k).angle * Math.PI / 180);
                            rounded = Decimal.Round((decimal)anglesNow, 6);
                            boats.ElementAt(k).y += (double)rounded * boats.ElementAt(k).speed * 1;

                            distance = boats.ElementAt(first).DistanceBetweenBoats(boats.ElementAt(k));

                            if (distance < r)
                                break;
                            time[0]++;

                        }
                        if (first == k - 1)
                                time[1] = time[0];
                        else if ( time[0] < time [1])
                            time[1]=time.Min();

                    }
                }
                boats.Clear();
                Console.WriteLine(time[1]);
            } 

        }



    }

    class boat
    {
        public double x, y;
        public uint speed, angle;

        public boat(string input)
        {
            
            string[] bits = input.Split(' ');
            this.x = double.Parse(bits[0]);
            this.y = double.Parse(bits[1]);
            this.speed = uint.Parse(bits[3]);
            this.angle = uint.Parse(bits[2]);
        }

        public double DistanceBetweenBoats(boat a)
        {
            double result = 0;
            result = Math.Sqrt(Math.Pow((this.x - a.x), 2) + Math.Pow((this.y - a.y), 2));
            return result;
        }

    }
}
