using CalculatorLibrary.Memory;

namespace CalculatorLibrary.Memory
{ 
    public class Calculator : IOperator 
    {
        public Calculator() { 
        
        }
        public Memory memory = new Memory();
        public int result { get; set; }

        public int Add(int a, int b)
        {
            result = a + b;
            return memory.Save(result);
        }
        public int Subtract(int a, int b)
        {
            result = a - b;
            return memory.Save(result);
        }
    }
}
