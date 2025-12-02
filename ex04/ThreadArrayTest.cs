using System;
using System.Diagnostics;
using System.Threading;

namespace ex04
{
    class Program
    {
        static void Main()
        {
            int size = 20_000_000;
            int[] arr = new int[size];
            for (int i = 0; i < size; i++) arr[i] = i;

            // Scenario A: threads access different regions
            Stopwatch swA = Stopwatch.StartNew();
            Thread t1 = new Thread(() => SumRegion(arr, 0, size / 2));
            Thread t2 = new Thread(() => SumRegion(arr, size / 2, size));
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();
            swA.Stop();
            Console.WriteLine($"Scenario A (different regions): {swA.ElapsedMilliseconds} ms");

            // Scenario B: threads access the whole array
            Stopwatch swB = Stopwatch.StartNew();
            Thread t3 = new Thread(() => SumRegion(arr, 0, size));
            Thread t4 = new Thread(() => SumRegion(arr, 0, size));
            t3.Start(); t4.Start();
            t3.Join(); t4.Join();
            swB.Stop();
            Console.WriteLine($"Scenario B (whole array): {swB.ElapsedMilliseconds} ms");
        }

        static long SumRegion(int[] arr, int start, int end)
        {
            long sum = 0;
            for (int i = start; i < end; i++) sum += arr[i];
            return sum;
        }
    }
}
