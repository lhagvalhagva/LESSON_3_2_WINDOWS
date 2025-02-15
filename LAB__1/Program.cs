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
            Console.WriteLine($"5 + 3 = {calculator.memory.GetLast().value}");
            
            calculator.Subtract(10, 4);
            Console.WriteLine($"10 - 4 = {calculator.memory.GetLast().value}");
            
            calculator.memory.Clear();
            Console.WriteLine("Memory history after clearing:");

            calculator.Subtract(20, 10);
            Console.WriteLine($"20 - 10 = {calculator.memory.GetLast().value}");

            Console.WriteLine("Memory history:");
            foreach (var item in calculator.memory.GetAll())
            {
                Console.WriteLine(item.value);
            }
        }
    }
}