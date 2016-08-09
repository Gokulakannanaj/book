using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPractice10TrainSorting_By_Kamran_
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader MyReader = new StreamReader("TrainSorting.txt");
            List<int> QueuedCars = new List<int>();

            int NoOfTestCases = int.Parse(MyReader.ReadLine());
            for (int CaseNo = 0; CaseNo < NoOfTestCases; CaseNo++)
            {

                int NoOfCars = int.Parse(MyReader.ReadLine());
                int[] CarsWeight = new int[NoOfCars];
                for (int car = 0; car < NoOfCars; car++)
                {
                    CarsWeight[car] = int.Parse(MyReader.ReadLine());
                }

                QueuedCars.Add(CarsWeight[0]);

                for (int CarNo = 1; CarNo < CarsWeight.Length; CarNo++)
                {
                    if ( CarsWeight[CarNo] > QueuedCars[0])
                    {
                        QueuedCars.Insert(0,CarsWeight[CarNo]);
                    }

                    else if ( CarsWeight[CarNo] < QueuedCars[QueuedCars.Count-1])
                    {
                        QueuedCars.Insert(QueuedCars.Count-1,CarsWeight[CarNo]);

                    }
                }

                Console.WriteLine(QueuedCars.Count);
                QueuedCars.Clear();

            }

            //MyReader.Close();
        }
    }
}
