using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.Memory
{
    /// <summary>
    /// Санах ойд хадгалагдах нэг утгын класс
    /// </summary>
    public class MemoryItem
    {
        /// <summary>
        /// Хадгалагдсан тоон утга
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// MemoryItem классын байгуулагч функц
        /// </summary>
        /// <param name="value">Хадгалах утга</param>
        public MemoryItem(int value) {
            Value = value;

        }
    }
}
