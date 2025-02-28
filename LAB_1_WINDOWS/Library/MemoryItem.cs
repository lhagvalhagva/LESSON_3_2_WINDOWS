using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.Memory
{
    public class MemoryItem
    {
        public int value { get; set; }
        public MemoryItem( int value) {
            this.value = value;
        }
    }
}
