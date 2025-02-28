using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    interface IOperator
    {
        public int Add(int a, int b);
        public int Subtract(int a, int b);
    }
}
