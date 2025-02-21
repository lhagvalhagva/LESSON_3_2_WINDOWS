using LAB__1.Interfaces;
using LAB__1.Models;

namespace LAB__1.Models
{
    public class BasicCalculator : IBasicOperations
    {
        private double result = 0;
        
        public double Result
        {
            get { return result; }
            set { result = value; }
        }
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

        public double Add(double a)
        {
            Result += a;
            return memory.Save(Result);
        }

        public double Subtract(double a)
        {
            Result -= a;
            return memory.Save(Result);
        }
    }
}