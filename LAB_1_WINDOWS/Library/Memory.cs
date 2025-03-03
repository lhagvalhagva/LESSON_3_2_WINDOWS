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
            List<MemoryItem> allMemoryItems = new List<MemoryItem>();

            for (int i = 0; i < memoryItems.Count; i++)
            {
                allMemoryItems.Add(memoryItems[i]);
            }

            return allMemoryItems;
        }

        public int GetLast()
        {
            return memoryItems.Last().Value;
        }
        public void Save(int result)
        {
            memoryItems.Add(new MemoryItem(result));
        }

        public void Clear()
        {
            memoryItems.Clear();
        }
    }
}
