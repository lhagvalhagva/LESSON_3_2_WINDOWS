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
        /// Хоёр тоог нэмэх үйлдэл
        /// </summary>
        /// <param name="a">Эхний тоо</param>
        /// <param name="b">Хоёр дахь тоо</param>
        /// <returns>Нэмэх үйлдлийн үр дүн</returns>
        public int Add(int a, int b);

        /// <summary>
        /// Хоёр тооны ялгаврыг олох үйлдэл
        /// </summary>
        /// <param name="a">Эхний тоо</param>
        /// <param name="b">Хасах тоо</param>
        /// <returns>Хасах үйлдлийн үр дүн</returns>
        public int Subtract(int a, int b);
    }
}
