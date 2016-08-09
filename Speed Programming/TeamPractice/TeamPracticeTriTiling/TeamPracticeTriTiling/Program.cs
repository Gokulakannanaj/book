using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPracticeTriTiling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(f(8));
        }


        public static int g(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else if (n == 0)
            {
                return 0;
            }
            else
                return f(n - 1) + g(n - 2);

        }

        public static int f(int n)
        {
            if (n == 1)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else
                return f(n - 2) + g(n - 1) + g(n - 1);
        }
    }
}
