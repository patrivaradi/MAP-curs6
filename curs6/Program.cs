using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace curs6
{
    class Program
    {


        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\data.in");
            int n = int.Parse(load.ReadLine());
            int[,] na = new int[n, n];
            string buffer;
            while((buffer=load.ReadLine())!=null)
            {
                string[] local_data = buffer.Split(' ');
                int x = int.Parse(local_data[0]);
                int y = int.Parse(local_data[1]);

                na[x - 1, y - 1] = 1;
                na[y - 1, x - 1] = 1;

            }
            for (int i = 0; i <n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(na[i, j] + " ");
            }Console.WriteLine();

            bool hasisland = false;
            for (int i=0;i<n;i++)
            {
                bool local = true;
                for (int j = 0; j < n; j++)
                    if (na[i, j] == 1)
                    {
                        local = false;
                        break;
                    }
                if(local)
                {
                    hasisland = true;
                    break;
                }
            }
            if (hasisland)
                Console.WriteLine("DA");
            else
                Console.WriteLine("NU");


            bool hasimpar = false;
            bool iseulerian = true;
            int nrimp = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += na[i, j];
                }
                if ((sum % 2) == 1)
                {
                    nrimp++;
                    hasimpar = true;
                    if(nrimp>2)
                    {
                        iseulerian = false;
                        break;
                    }
                }
            }
            if (iseulerian)
                Console.WriteLine("eulerian:DA");
            else
                Console.WriteLine("eulerian:NU");
            if (hasimpar)
                Console.WriteLine("eulerian cycle detected");

                    Console.ReadKey();

        }
    }
}
