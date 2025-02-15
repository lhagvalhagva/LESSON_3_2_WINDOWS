namespace LAB__1.Models
{
    public abstract class AbstractCalculator
    {
        private double result;

        public double Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}