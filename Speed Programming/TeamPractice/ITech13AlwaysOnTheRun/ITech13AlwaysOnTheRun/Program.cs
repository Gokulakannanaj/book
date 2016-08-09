using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITech13AlwaysOnTheRun
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader Reader = new System.IO.StreamReader("OnTheFly.txt");
            string OneLine = Reader.ReadLine();

            while (OneLine != null)
            {
                // breaking the string to get number of cities and available flights
                string[] bits = OneLine.Split(' ');
                List<int> CitiesToTravel = new List<int>();
                int NoOfCitiesToGo = int.Parse(bits[0]); // here i'll store cities to visit
                AirLines.DaysToTravel = int.Parse(bits[1]); // Total number of days travelling
                List<AirLines> AllFlights = new List<AirLines>();

                for (int i = 0; i < AirLines.DaysToTravel; i++)
                {
                    OneLine = Reader.ReadLine();
                    AllFlights.Add(new AirLines(OneLine));
                }
                AirLines FlightWithLeastCost = AllFlights[0];

                for (int day = 0; day < AirLines.DaysToTravel; day++)
                {
                    foreach (var airline in AllFlights)
                    {
                        if (FlightWithLeastCost.Flights[day] > airline.Flights[day] && airline.Flights[day] != 0 && (CitiesToTravel.Count < NoOfCitiesToGo || CitiesToTravel.Contains(airline.City) ) && airline.City != Tresha.CurrentCity)
                        {
                            FlightWithLeastCost = airline;
                        }
                    }

                    Tresha.CostTillNow += FlightWithLeastCost.Flights[day];
                    Tresha.CurrentCity = FlightWithLeastCost.City;
                    if (CitiesToTravel.Count <= NoOfCitiesToGo && !CitiesToTravel.Contains(FlightWithLeastCost.City) )
                    {

                        if (FlightWithLeastCost == AllFlights[0] && AllFlights[0].Flights[day] == 0)
                        {
                            
                            break;
                        }
                        else
                        {
                            CitiesToTravel.Add(FlightWithLeastCost.City);
                        }
                    }

                    if (!(day < AirLines.DaysToTravel))
                    {
                        Console.WriteLine("She Cant Escape");
                        continue;
                    }
                    FlightWithLeastCost = AllFlights[0];
                }



                Console.WriteLine(Tresha.CostTillNow);
                CitiesToTravel.Clear();
                AllFlights.Clear();
            }


            Reader.Close();

        }
    }


    class AirLines
    {
        public int City;
        public List<int> Flights;
        public static int DaysToTravel;

        public AirLines(string LineOfData)
        {
            Flights = new List<int>();
            string[] Bits = LineOfData.Split(' ');
            City = int.Parse(Bits[0]);
            for (int i = 1, j = 0; j < DaysToTravel; j++,i++)
			{
                
                Flights.Add(int.Parse(Bits[i]));
                if (i == Bits.Length - 1)
                {
                    i = 0;
                }
			}
            
        }
    }

    class Tresha
    {
        public static int CurrentCity = 1;
        public static int CostTillNow = 0;
    }
}
