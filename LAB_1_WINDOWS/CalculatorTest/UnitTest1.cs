using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CalculatorLibrary.Memory;


namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Тест хийх Calculator объект
        /// </summary>
        private Calculator calculator;

        /// <summary>
        /// Тест бүрийн өмнө ажиллах setup функц
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        /// <summary>
        /// Нэмэх үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void NemehVildel()
        {
            calculator.Add(2);
            calculator.Add(3);
            Assert.AreEqual(5, calculator.result);
        }

        /// <summary>
        /// Тоо нэмж хасах товч 
        /// Нэг параметртэй нэмэх үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void NemehVildelNegParametr()
        {
            calculator.Add(5);      
            calculator.Add(-4);       
            Assert.AreEqual(1, calculator.result);
        }

        /// <summary>
        /// Хасах үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void HasahVildel()
        {
            calculator.Add(5);
            calculator.Subtract(-3);
            Assert.AreEqual(8, calculator.result);
        }

        /// <summary>
        /// Нэг параметртэй хасах үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void HasahVildelNegParametr()
        {
            calculator.Add(15);  
            calculator.Subtract(7);  
            Assert.AreEqual(8, calculator.result);
        }

        /// <summary>
        /// Цэвэрлэх үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void ClearVildel()
        {
            calculator.Add(5);
            calculator.Add(3);
            Assert.AreEqual(8, calculator.result);

            calculator.result = 0;
            calculator.memory.Clear();
            Assert.AreEqual(0, calculator.result);
            Assert.AreEqual(0, calculator.memory.AllMemoryItems.Count);
        }

        /// <summary>
        /// Санах ойг цэвэрлэх үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void ClearVildel2()
        {
            calculator.Add(2);
            calculator.Add(3);
            calculator.memory.Clear();
            Assert.AreEqual(0, calculator.memory.AllMemoryItems.Count);
            // Memory цэвэрлэгдсэн ч result хэвээр байх ёстой
            Assert.AreEqual(5, calculator.result);
        }

        /// <summary>
        /// Сүүлийн утгыг авах үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void LastVildel()
        {
            calculator.Add(2);
            calculator.Add(3);
            calculator.Add(3);
            Assert.AreEqual(8, calculator.result);
        }

        /// <summary>
        /// Утга хадгалах үйлдлийг шалгах тест
        /// </summary>
        [TestMethod]
        public void SaveVildel()
        {
            calculator.memory.Save(3);
            Assert.AreEqual(3, calculator.memory.GetLast());
            Assert.AreEqual(0, calculator.result);
        }


        /// <summary>
        /// CalculatorProgram-ын түүх хадгалах функционалыг шалгах тест.
        /// Энэ тест нь хоёр тооцоолол хийсний дараа түүхэд зөв утгууд хадгалагдсан эсэхийг шалгана.
        /// </summary>
        [TestMethod]
        public void GetAllHistory()
        {
            Calculator calc = new Calculator();

            calc.Add(2);
            calc.Add(3);
            calc.Subtract(3);
            var history = calc.memory.AllMemoryItems;

            Assert.AreEqual(3, history.Count);
            Assert.AreEqual(2, history[0].Value);
            Assert.AreEqual(5, history[1].Value);
            Assert.AreEqual(2, history[2].Value);
            Assert.AreEqual(2, calc.result);
        }

        /// <summary>
        /// CalculatorProgram-ын түүх цэвэрлэх функционалыг шалгах тест.
        /// Энэ тест нь хэд хэдэн тооцоолол хийсний дараа түүхийг цэвэрлэхэд
        /// бүх утга устаж байгааг шалгана.
        /// </summary>
        [TestMethod]
        public void ClearVildel3()
        {
            Calculator calc = new Calculator();

            calc.Add(2);
            calc.Add(3);
            calc.Subtract(3);
            calc.memory.Clear();
            var history = calc.memory.AllMemoryItems;

            Assert.AreEqual(0, history.Count);
            Assert.AreEqual(2, calc.result);
        }
    }
}
