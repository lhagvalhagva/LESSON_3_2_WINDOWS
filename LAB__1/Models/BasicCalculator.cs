using LAB__1.Interfaces;
using LAB__1.Models;

namespace LAB__1.Models
{
    public class BasicCalculator : AbstractCalculator, IBasicOperations
    {
        public Memory memory = new Memory();

        public double Add(double a, double b)
        {
            Result = a + b;
            return memory.Save(Result);
        }

        public double Subtract(double a, double b)
        {
            Result = a - b;
            return memory.Save(Result);
        }

        public double Multiply(double a, double b)
        {
            Result = a * b;
            return memory.Save(Result);
        }
        public double Divide(double a, double b)
        {
            Result = a / b;
            return memory.Save(Result);
        }
    }
}