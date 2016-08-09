using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBRain2ndWorkReduction
{
    class Agency
    {
        public string Name;
        public ushort A , B;
        public int cost;

        public Agency(string readLine)
        {
            //string a = "ASFAND:1,10";
            int st, nd;
            //Console.Write(a.IndexOf('c'));
            this.Name = readLine.Substring(0, readLine.IndexOf(':'));

            st = readLine.IndexOf(':');
            nd = readLine.IndexOf(',');

            this.A = ushort.Parse(readLine.Substring(st + 1, nd - st-1));
            //Console.WriteLine(temp);
            st = readLine.IndexOf(',') + 1;
            //nd = readLine.Length - 1;
            B = ushort.Parse(readLine.Substring(st));
            //temp = readLine.Substring(st);
            //Console.WriteLine(temp);
            cost = 0;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string a = "ASFAND:1,10";
            int st, nd;
            //Console.Write(a.IndexOf('c'));
            Console.WriteLine(a.Substring(0,a.IndexOf(':')));

            st = a.IndexOf(':');
            nd = a.IndexOf(',');
            try
            {
                string temp = a.Substring(a.IndexOf(':')+1,1);
                Console.WriteLine(temp);
                st = a.IndexOf(',') +1;
                nd = a.Length - 1;
                temp = a.Substring(st);
                Console.WriteLine(temp);
            }

            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            */


            StreamReader reader = new StreamReader("WorkReduction.txt");
            int M, N,m,n, WorkToDo, workDoneByAgency;
            ushort NoOfCases, L;
            string oneLine;
            ushort firstSpace,multipleOf2 = 1;
            List<Agency> agencies = new List<Agency>();
            List<Agency> sortedAgencies = new List<Agency>();
            NoOfCases =  ushort.Parse(reader.ReadLine());
            for (int i = 0; i < NoOfCases; i++)
            {
                
                oneLine = reader.ReadLine();
                firstSpace = (ushort)oneLine.IndexOf(' ');
                n = int.Parse(oneLine.Substring(0,firstSpace));
                m = int.Parse(oneLine.Substring(firstSpace,oneLine.LastIndexOf(' ')-firstSpace));
                L = ushort.Parse(oneLine.Substring(oneLine.LastIndexOf(' '),oneLine.Length-  oneLine.LastIndexOf(' ')));
                //n = N;
                //m = M;
                for (int j = 0; j < L; j++)
                {
                    oneLine = reader.ReadLine();
                    agencies.Add(new Agency(oneLine));

                }

                WorkToDo = (n - m);
                // working starts here
                if (WorkToDo >= (n / Math.Pow(2,multipleOf2)))
                {
                    workDoneByAgency = (int)(n / Math.Pow(2, multipleOf2));

                    foreach (var Agn in agencies)
                    {
                        Agn.cost += Agn.B;
                    }

                    multipleOf2++;
                }

                else
                {
                    workDoneByAgency = --n;
                    foreach (var Agn in agencies)
                    {
                        Agn.cost += Agn.A;
                    }
                    multipleOf2++;
                }

                while (workDoneByAgency < WorkToDo)
                {
                    if (WorkToDo >= ((workDoneByAgency)+(n / Math.Pow(2,multipleOf2))))
                    {
                        workDoneByAgency += (int)(n / Math.Pow(2, multipleOf2));

                        foreach (var Agn in agencies)
                        {
                            Agn.cost += Agn.B;
                        }
                        multipleOf2++;
                    }

                    else
                    {
                        workDoneByAgency++;
                        foreach (var Agn in agencies)
                        {
                            Agn.cost += Agn.A;
                        }
                    }

                }
                var sorted = from Agn in agencies
                             orderby Agn.cost
                             select Agn;

                foreach (var item in sorted)
                {
                    Console.WriteLine("{0} {1}", item.Name, item.cost);
                }
                multipleOf2 = 1;
                Console.WriteLine();
                agencies.Clear();
            

            }

            

            reader.Close();
            Console.ReadLine();
        }
    }
}
