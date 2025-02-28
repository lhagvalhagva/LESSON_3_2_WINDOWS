using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculatorLibrary.Memory
{
    public class Memory
    {
        private List<MemoryItem> memoryItems;
        public Memory()
        {
            memoryItems = new List<MemoryItem>();
        }

        public List<MemoryItem> GetAll()
        {
            return memoryItems;
        }
        public MemoryItem GetLast()
        {
            return memoryItems.Last();
        }
        public void Save(MemoryItem memoryItem)
        {
            memoryItems.Add(memoryItem);
        }
        public void Clear()
        {
            memoryItems.Clear();
        }
    }
}
