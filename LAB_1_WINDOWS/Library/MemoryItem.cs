using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.Memory
{
    public class MemoryItem
    {
        public int Value { get; set; }
        public MemoryItem( int value) {
            Value = value;
        }
    }
}
