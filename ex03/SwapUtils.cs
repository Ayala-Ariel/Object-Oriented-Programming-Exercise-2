using System;

namespace ex03
{
    public static class SwapUtils
    {
        // Swap two elements in an int array
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // Generic swap for any type
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    class Program
    {
        static void Main()
        {
            // Example for int[] swap
            int[] arr = { 1, 2, 3 };
            Console.WriteLine($"Before swap: {arr[0]}, {arr[1]}");
            SwapUtils.Swap(arr, 0, 1);
            Console.WriteLine($"After swap: {arr[0]}, {arr[1]}");

            // Example for generic swap
            string x = "hello", y = "world";
            Console.WriteLine($"Before swap: {x}, {y}");
            SwapUtils.Swap(ref x, ref y);
            Console.WriteLine($"After swap: {x}, {y}");
        }
    }
}
