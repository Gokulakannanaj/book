using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int m, n;
            StreamReader file = new StreamReader("task4.txt");
            do
            {
                line = file.ReadLine();
                if (line.Contains('0'))
                    break;
                string[] bits = line.Split(' ');
                m = int.Parse(bits[0]);
                n = int.Parse(bits[1]);
                new Array().Read(file, m, n);
                
            } while (true);
            Console.ReadLine();
        }
    }
    class Array
    {
        char[,] arr;
        char[] array;
        string line;
        public void Read(StreamReader file, int m, int n)
        {
            arr=new char[m,n];
            for(int i=0;i<m;i++)
            {
                line=file.ReadLine();
                array=line.ToCharArray();
               for(int j=0;j<n;j++)
                    arr[i,j]=array[j];
                }
            Out(m, n);
        }
        private void Out(int m,int n)
        {
            int LC = 0;
            int i = 0;
            int j = 0;
            int noi = m * n;
            int check = 0;
            bool limit = false;
            do
            {
                for (; j < n; j++)
                {
                    Console.Write(arr[i, j]);
                    check++;
                    if (check == noi)
                    {
                        limit = true;
                        break;
                    }
                    if (limit == true)
                        break;
                        
                }
                for (j--, i++; i < m; i++)
                {

                    Console.Write(arr[i, j]);
                    check++;
                    if (check == noi)
                    {
                        limit = true;
                        break;
                    }
                }
                if (limit == true)
                    break;
                for (j--, i--; j >= LC; j--)
                {
                    Console.Write(arr[i, j]);
                    check++;
                    if (check == noi)
                    {
                        limit = true;
                        break;
                    }
                }
                if (limit == true)
                    break;
                LC++;
                for (i--, j++; i > LC; i--)
                {
                    Console.Write(arr[i, j]);
                    check++;
                    if (check == noi)
                    {
                        limit = true;
                        break;
                    }
                }
                if (limit == true)
                    break;
                m--;
                n--;
             
            } while (true);
            Console.WriteLine();
        }
    }
}
