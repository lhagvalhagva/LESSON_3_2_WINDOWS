using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.Memory
{
    /// <summary>
    /// Тооны машины тооцооны үр дүнг хадгалах санах ойн класс
    /// </summary>
    public class Memory
    {
        /// <summary>
        /// Санах ойд хадгалагдсан утгуудын жагсаалт
        /// </summary>
        private List<MemoryItem> memoryItems;

        /// <summary>
        /// Memory классын байгуулагч функц
        /// </summary>
        public Memory()
        {
            memoryItems = new List<MemoryItem>();
        }

        /// <summary>
        /// Санах ойд хадгалагдсан бүх утгыг авах
        /// </summary>
        /// <returns>Хадгалагдсан бүх утгын жагсаалт</returns>
        public List<MemoryItem> GetAll()
        {
            List<MemoryItem> allMemoryItems = new List<MemoryItem>();

            for (int i = 0; i < memoryItems.Count; i++)
            {
                allMemoryItems.Add(memoryItems[i]);
            }

            return allMemoryItems;
        }

        /// <summary>
        /// Сүүлд хадгалагдсан утгыг авах
        /// </summary>
        /// <returns>Сүүлийн утга</returns>
        public int GetLast()
        {
            return memoryItems.Last().Value;
        }

        /// <summary>
        /// Шинэ утга хадгалах
        /// </summary>
        /// <param name="result">Хадгалах утга</param>
        public void Save(int result)
        {
            memoryItems.Add(new MemoryItem(result));
        }

        /// <summary>
        /// Санах ойг цэвэрлэх
        /// </summary>
        public void Clear()
        {
            memoryItems.Clear();
        }
    }
}
