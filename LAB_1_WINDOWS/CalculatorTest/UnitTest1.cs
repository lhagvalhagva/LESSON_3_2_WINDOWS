using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CalculatorLibrary.Memory;


namespace CalculatorTest
{
    /// <summary>
    /// Тооны машины програмын нэгж тестүүд
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Тест хийх Calculator объект
        /// </summary>
        private Calculator calculator;

        /// <summary>
        /// Console output-г барих StringWriter объект
        /// </summary>
        private StringWriter stringWriter;

        /// <summary>
        /// Анхны Console output-г хадгалах хувьсагч
        /// </summary>
        private TextWriter originalOutput;

        /// <summary>
        /// Тест бүрийн өмнө ажиллах setup функц
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
            // Console output-г барихын тулд StringWriter ашиглана
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        /// <summary>
        /// Тест бүрийн дараа ажиллах cleanup функц
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            // Console output-г буцаан хэвийн төлөвт оруулна
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }

        /// <summary>
        /// Нэмэх үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void NemehVildel()
        {
            calculator.Add(2, 3);
            Assert.AreEqual(5, calculator.memory.GetLast());
        }

        /// <summary>
        /// Хасах үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void HasahVildel()
        {
            calculator.Subtract(5, 3);
            Assert.AreEqual(2, calculator.memory.GetLast());
        }

        /// <summary>
        /// Санах ойг цэвэрлэх үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void ClearVildel2()
        {
            calculator.Add(2, 3);
            calculator.memory.Clear();
            Assert.AreEqual(0, calculator.memory.GetAll().Count);
        }

        /// <summary>
        /// Сүүлийн утгыг авах үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void LastVildel()
        {
            calculator.Add(2, 3);
            calculator.Add(5, 3);
            Assert.AreEqual(8, calculator.memory.GetLast());
        }

        /// <summary>
        /// Утга хадгалах үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void SaveVildel()
        {
            calculator.memory.Save(3);
            Assert.AreEqual(3, calculator.memory.GetLast());
        }


        /// <summary>
        /// CalculatorProgram-ын түүх хадгалах функционалыг шалгах тест.
        /// Энэ тест нь хоёр тооцоолол хийсний дараа түүхэд зөв утгууд хадгалагдсан эсэхийг шалгана.
        /// </summary>
        [TestMethod]
        public void GetAllHistory()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            calc.Add(2, 3);
            calc.Subtract(5, 3);
            var history = calc.memory.GetAll();

            // Assert
            Assert.AreEqual(2, history.Count);
            Assert.AreEqual(5, history[0].Value);
            Assert.AreEqual(2, history[1].Value);
        }

        /// <summary>
        /// CalculatorProgram-ын түүх цэвэрлэх функционалыг шалгах тест.
        /// Энэ тест нь хэд хэдэн тооцоолол хийсний дараа түүхийг цэвэрлэхэд
        /// бүх утга устаж байгааг шалгана.
        /// </summary>
        [TestMethod]
        public void ClearVildel3()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            calc.Add(2, 3);
            calc.Subtract(5, 3);
            calc.memory.Clear();
            var history = calc.memory.GetAll();

            // Assert
            Assert.AreEqual(0, history.Count);
        }
    }
}
