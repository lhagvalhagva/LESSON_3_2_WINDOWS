using LAB__1.Models;
using System;

namespace LAB__1
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicCalculator calculator = new BasicCalculator();

            calculator.Add(5, 3);
            Console.WriteLine($"5 + 3 = {calculator.Result}");
            
            calculator.Subtract(10, 4);
            Console.WriteLine($"10 - 4 = {calculator.Result}");
        }
    }
} 