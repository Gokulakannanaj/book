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
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string oneLine = Console.ReadLine();
            int noOfCases = int.Parse(oneLine);
            List<Building> allBuildings = new List<Building>();
            var output = "";
            for (int x = 0; x < noOfCases; x++)
            {
                int NoOfTunnels = 0;
                try
                {
                    NoOfTunnels = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please Number enter karein");
                }

                var tunnels = new List<string>();
                for (int tunnelNo = 0; tunnelNo < NoOfTunnels; tunnelNo++)
                {
                    string input = Console.ReadLine();
                    tunnels.Add(input);
                }

                foreach (var tunnel in tunnels)
                {
                    string[] Names = tunnel.Split(' ');
                    Building b1 = new Building(Names[0]);
                    Building b2 = new Building(Names[1], b1);
                    allBuildings.Add(b1);
                    allBuildings.Add(b2);
                    output += (b1.getCount() + 1).ToString() + "\n";
                }
            }
            Console.WriteLine(output);

        }
    }
}
