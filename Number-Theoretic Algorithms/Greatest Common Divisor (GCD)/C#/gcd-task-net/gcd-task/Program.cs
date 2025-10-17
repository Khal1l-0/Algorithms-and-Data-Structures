using System;

namespace gcd_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== GCD / LCM / Extended Euclid Demo ===");

            // Example for LCM
            int a1 = 42, b1 = 35;
            int lcm = Solution.FindLcm(a1, b1);
            Console.WriteLine($"LCM({a1}, {b1}) = {lcm}");

            // Another LCM example
            int a2 = 18, b2 = 42;
            Console.WriteLine($"LCM({a2}, {b2}) = {Solution.FindLcm(a2, b2)}");

            // Example for Extended Euclid
            int a3 = 24, b3 = 18;
            var result1 = Solution.ExtendedEuclid(a3, b3);
            Console.WriteLine($"ExtendedEuclid({a3}, {b3}) = {result1}");

            // Another Extended Euclid example
            int a4 = 10, b4 = 35;
            var result2 = Solution.ExtendedEuclid(a4, b4);
            Console.WriteLine($"ExtendedEuclid({a4}, {b4}) = {result2}");

            // Custom input from user
            Console.WriteLine("\nEnter two integers separated by space:");
            var parts = Console.ReadLine()?.Split(' ');
            if (parts != null && parts.Length == 2 &&
                int.TryParse(parts[0], out int a) &&
                int.TryParse(parts[1], out int b))
            {
                Console.WriteLine($"LCM({a}, {b}) = {Solution.FindLcm(a, b)}");
                Console.WriteLine($"ExtendedEuclid({a}, {b}) = {Solution.ExtendedEuclid(a, b)}");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
