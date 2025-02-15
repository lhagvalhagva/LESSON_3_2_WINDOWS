using System.Collections.Generic;
using LAB__1.Models;

namespace LAB__1.Models
{
    public class Memory
    {
        public List<MemoryItem> memoryItems { get; set;}

        public Memory()
        {
            memoryItems = new List<MemoryItem>();
        }

        public double Save(double value)
        {
            memoryItems.Add(new MemoryItem(value));
            return value;
        }

        public List<MemoryItem> GetAll()
        {
            return memoryItems;
        }

        public MemoryItem GetLast()
        {
            return memoryItems.Last();
        }

        public void Clear()
        {
            memoryItems.Clear();
        }
    }
}