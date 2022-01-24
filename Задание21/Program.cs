using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Задание21
{
    internal class Program
    {
        const int n = 50;
        const int m = 50;
        static int[,] garten = new int[n, m];
        static void Main(string[] args)
        {
            garten = new int[n, m]; 
            Thread thread1 = new Thread(Gardener1);
            Thread thread2 = new Thread(Gardener2);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{garten[i,j]} ");
                }
            }
            Console.ReadKey();
        }
        static void Gardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (garten[i, j] == 0)
                    {
                        garten[i, j] = 1;
                    }
                }
            }
        }
        static void Gardener2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (garten[j, i] == 0)
                    {
                        garten[j, i] = 2;
                    }
                }
            }
        }
    }
}
