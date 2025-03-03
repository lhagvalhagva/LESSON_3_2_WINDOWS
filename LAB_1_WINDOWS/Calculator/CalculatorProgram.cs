
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using CalculatorLibrary;
using CalculatorLibrary.Memory;

namespace CalculatorProgram
{
    class CalculatorProgram
    {
        static void Main(string[] args)
        {
        
            Calculator calculator = new Calculator();
            Console.WriteLine("Result: " + calculator.Add(2,3));
            Console.WriteLine("Result: " + calculator.Subtract(5, 3));
            var history = calculator.memory.GetAll();
            Console.WriteLine("History:");
            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine(history[i].Value);
            }
            Console.WriteLine("Last: " + calculator.memory.GetLast());
            calculator.memory.Clear();
            var history2 = calculator.memory.GetAll();
            Console.WriteLine("History-2:");
            for (int i = 0; i < history2.Count; i++)
            {
                Console.WriteLine(history[i].Value);
            }
        }
    }
}
