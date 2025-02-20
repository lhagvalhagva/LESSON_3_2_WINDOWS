using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary;

namespace _7166_labs
{
    public class Calculator : IOperator
    {
        public Memory memory = new Memory();
        int _result = 0;
        public int Result{ get; set; }

        public int Add(int a , int b) {
            Result = a + b;
            return memory.Save(Result);
        }
        public int Sub(int a , int b){
            Result = a -b;
            return memory.Save(Result);
        }
      
    }
}


