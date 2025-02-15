using LAB__1.Interfaces;

namespace LAB__1.Models
{
    public class BasicCalculator : AbstractCalculator, IBasicOperations
    {

        public double Add(double a, double b)
        {
            Result = a + b;
            return Result;
        }

        public double Subtract(double a, double b)
        {
            Result = a - b;
            return Result;
        }

    }
} 