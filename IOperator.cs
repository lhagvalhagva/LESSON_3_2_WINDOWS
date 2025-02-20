using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public interface IOperator
    {
        public int Add(int a, int b);
        public int Sub(int a, int b);
    }
}
