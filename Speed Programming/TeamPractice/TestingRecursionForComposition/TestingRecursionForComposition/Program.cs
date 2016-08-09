using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingRecursionForComposition
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompositionBooleans(string.Empty, 3);
            BooleanCompositions(2);
        }

        //public static void CompositionBooleans(string result, int counter)
        //{
        //    if (counter == 0)
        //        return;

        //    bool[] booleans = new bool[2] { true, false };

        //    for (int j = 0; j < 2; j++)
        //    {
        //        StringBuilder stringBuilder = new StringBuilder(result);
        //        stringBuilder.Append(string.Format("{0} ", booleans[j].ToString())).ToString();

        //        if (counter == 1)
        //            Console.WriteLine(stringBuilder.ToString());

        //        CompositionBooleans(stringBuilder.ToString(), counter - 1);
        //    }
        //}

        private static void BooleanCompositions(int counter, string partialOutput="")
        {
            if (counter <= 0)
                Console.WriteLine(partialOutput);
            else
            {
                BooleanCompositions(counter - 1, partialOutput + " true ");
                BooleanCompositions(counter - 1, partialOutput + " false ");
            }
        }
    }
}
