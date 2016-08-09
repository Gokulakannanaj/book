using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgesAndTunnel
{
    class Building
    {
        public string name;
        public List<Building> connectedTo = new List<Building>();
        public int getCount()
        {
            return connectedTo.Count;
        }
        public Building()
        {

        }
        public Building(string n)
        {
            name = n;
        }
        public Building(string n, Building b)
        {
            name = n;
            connectedTo.Add(b);
            b.AddBuilding(this);
            this.Connect(b);
        }

        public void AddBuilding(Building B) 
        {
            this.connectedTo.Add(B);
        }

        public void Connect (Building to)
        {
            for (int i = 0; i < to.getCount(); i++)
            {
                bool isInList = false;
                for (int j = 0; j < this.getCount(); j++)
                {
                    if (to.connectedTo[i].name == this.connectedTo[j].name)
                    {
                        isInList = true;
                        break;
                    }
                }

                if (isInList == false && this.name != to.connectedTo[i].name)
                {
                    this.AddBuilding(to.connectedTo[i]);
                    to.AddBuilding(this);
                    this.Connect(to.connectedTo[i]);
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
            System.IO.StreamReader InputFile = new System.IO.StreamReader("Input.txt");
            int noOfCases = int.Parse(InputFile.ReadLine());
            List<Building> allBuildings = new List<Building>();
            var output = "";
            for (int x = 0; x < noOfCases; x++)
            {
                int NoOfTunnels = 0;
                try
                {
                    NoOfTunnels = int.Parse(InputFile.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please Number enter karein");
                }

                var tunnels = new List<string>();
                for (int tunnelNo = 0; tunnelNo < NoOfTunnels; tunnelNo++)
                {
                    string input = InputFile.ReadLine();
                    tunnels.Add(input);
                }

                foreach (var tunnel in tunnels)
                {
                    string[] Names = tunnel.Split(' ');
                    Building b1 = new Building(), b2 = new Building();
                    bool RegisteredB1 = false;
                    bool RegisteredB2 = false;
                    foreach (var building in allBuildings)
                    {
                        if (building.name == Names[0])
                        {
                            b1 = building;
                            RegisteredB1 = true;
                        }
                        else if (building.name == Names[1])
                        {
                            b2 = building;
                            RegisteredB2 = true;
                        }
                    }
                    if ( RegisteredB1 == false && RegisteredB2 == false)
                    {
                        b1 = new Building(Names[0]);
                        b2 = new Building(Names[1], b1);
                        allBuildings.Add(b2);
                        allBuildings.Add(b1);

                    }
                    else if ( RegisteredB1  && !RegisteredB2)
                    {
                        b2 = new Building(Names[1], b1);
                        allBuildings.Add(b2);
                    }
                    else if (RegisteredB2 && RegisteredB1 == false)
                    {
                        b1 = new Building(Names[0], b2);
                        allBuildings.Add(b1);

                    }
                    
                    output += (b1.getCount() + 1).ToString() + "\n";
                }
            }
            Console.WriteLine(output);

        }
    }
}
