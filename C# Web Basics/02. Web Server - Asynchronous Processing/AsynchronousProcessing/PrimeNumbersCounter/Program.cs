using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumbersCounter
{
    internal class Program
    {
        private static int Count;
        private static object lockObj = new object();

        // One thread 
        //  664579
        //  00:00:09.1601008

        // 4 threads
        //  664579
        //  00:00:03.5576738
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= 100; i++)
            {
                var task = Task.Run(() => DownloadAsync(i));

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine(sw.Elapsed);

            /*

            Thread thread = new Thread(() => PrintPrimeCount(2, 2_500_000));
            thread.Start(); 
            Thread thread2 = new Thread(() => PrintPrimeCount(2_500_001, 5_000_000));
            thread2.Start();
            Thread thread3 = new Thread(() => PrintPrimeCount(5_000_001, 7_500_000));
            thread3.Start();
            Thread thread4 = new Thread(() => PrintPrimeCount(7_500_001, 10_000_000));
            thread4.Start();

            thread.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }

            */
        }

        static async Task DownloadAsync(int i)
        {
            HttpClient httpClient = new HttpClient();
            var url = $"https://vicove.com/vic-{i}";
            var httpResponse = await httpClient.GetAsync(url);
            var vic = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine(vic.Length);
        }

        static void PrintPrimeCount(int start, int end)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = start; i <= end; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    lock (lockObj)
                    {
                        Count++;
                    }
                }
            }

            Console.WriteLine(Count);
            Console.WriteLine(sw.Elapsed);
        }
    }
}
