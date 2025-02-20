using System;
using System.Collections.Generic;
using System.Linq;
using CalculatorLibrary.Mitem;

namespace CalculatorLibrary
{
    public class Memory
    {
        private  List<MemoryItem> memoryItems;

        public Memory()
        {
            memoryItems = new List<MemoryItem>();
        }

        public int Save(int value)
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