using CalculatorLibrary.Memory;

namespace CalculatorLibrary.Memory
{
    /// <summary>
    /// Энгийн тооны машины үндсэн үйлдлүүдийг гүйцэтгэх класс
    /// </summary>
    public class Calculator : IOperator 
    {
        /// <summary>
        /// Calculator классын байгуулагч функц
        /// </summary>
        public Calculator() { 
            result = 0;
        }
        /// <summary>
        /// Тооцооны үр дүнг хадгалах санах ой
        /// </summary>
        public Memory memory = new Memory();
        
        /// <summary>
        /// Сүүлийн тооцооны үр дүн
        /// </summary>
        public int result { get; set; }

        /// <summary>
        /// Хоёр тоог нэмэх үйлдэл
        /// </summary>
        /// <param name="a">Эхний тоо</param>
        /// <param name="b">Хоёр дахь тоо</param>
        /// <returns>Нэмэх үйлдлийн үр дүн</returns>
        public int Add(int a, int b)
        {
            result = a + b;
            return result;
        }

        /// <summary>
        /// Нэг тоог нэмэх үйлдэл
        /// </summary>
        /// <param name="a">Нэмэх тоо</param>
        /// <returns>Нэмэх үйлдлийн үр дүн</returns>
        public int Add(int a)
        {
            result = result + a;
            return result;
        }

        /// <summary>
        /// Хоёр тооны ялгаврыг олох үйлдэл
        /// </summary>
        /// <param name="a">Эхний тоо</param>
        /// <param name="b">Хасах тоо</param>
        /// <returns>Хасах үйлдлийн үр дүн</returns>
        public int Subtract(int a, int b)
        {
            result = a - b;
            return result;
        }

        /// <summary>
        /// Нэг тоог хасах үйлдэл
        /// </summary>
        /// <param name="a">Хасах тоо</param>
        /// <returns>Хасах үйлдлийн үр дүн</returns>
        public int Subtract(int a)
        {
            result = result - a;
            return result;
        }
    }
}
