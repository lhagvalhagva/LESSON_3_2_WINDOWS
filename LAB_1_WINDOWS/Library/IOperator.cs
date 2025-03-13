using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    /// <summary>
    /// Тооны машины үндсэн үйлдлүүдийн interface
    /// </summary>
    interface IOperator
    {
        /// <summary>
        /// Нэг тоог нэмэх үйлдэл
        /// </summary>
        /// <param name="a">Нэмэх тоо</param>
        /// <returns>Нэмэх үйлдлийн үр дүн</returns>
        public int Add(int a);

        /// <summary>
        /// Нэг тоог хасах үйлдэл
        /// </summary>
        /// <param name="a">Хасах тоо</param>
        /// <returns>Хасах үйлдлийн үр дүн</returns>
        public int Subtract(int a);
    }
}
