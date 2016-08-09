using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPractice10TrainSorting_by_Hira_
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fs = new StreamReader("TrainSorting.txt");
            string f = fs.ReadLine();
            ushort NoOfTestCases = ushort.Parse(f);
            List<ushort> QueuedCars = new List<ushort>();

            for (int i = 0; i < NoOfTestCases; i++)
            {
                ushort NoOfCars = ushort.Parse(fs.ReadLine());
                ushort[] CarsWeight = new ushort[NoOfCars];
                for (int no = 0; no < NoOfCars; no++)
                {
                    CarsWeight[no] = ushort.Parse(fs.ReadLine());
                }
                QueuedCars.Add(CarsWeight[0]);

                for (int j = 1; j < CarsWeight.Length; j++)
                {
                    if ( CarsWeight[j] > QueuedCars[0] || CarsWeight[j] < QueuedCars[QueuedCars.Count-1])
                    {
                        QueuedCars.Add(CarsWeight[j]);
                        
                    }
                }

                Console.WriteLine(QueuedCars.Count);
                QueuedCars.Clear();
            }




        }
    }
}
