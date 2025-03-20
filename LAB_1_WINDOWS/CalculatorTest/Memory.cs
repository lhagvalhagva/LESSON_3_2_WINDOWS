using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorLibrary.Memory;

namespace CalculatorTest
{
	/// <summary>
	/// Summary description for MemoryTest
	/// </summary>
	[TestClass]
	public class MemoryTest
    {
		private Calculator calculator;

		[TestInitialize]
		public void Setup()
		{
			calculator = new Calculator();
		}

		/// <summary>
		/// Санах ойд утга нэмэх тест
		/// </summary>
		[TestMethod]
		public void MemoryAdd_Test()
		{
			calculator.Add(5);
			calculator.Add(3);
			Assert.AreEqual(8, calculator.result);
			Assert.AreEqual(2, calculator.memory.AllMemoryItems.Count);
			Assert.AreEqual(8, calculator.memory.GetLast());
		}

		/// <summary>
		/// Санах ойгоос утга хасах тест
		/// </summary>
		[TestMethod]
		public void MemorySubtract_Test()
		{
			calculator.Add(10);
			calculator.Subtract(3);
			Assert.AreEqual(7, calculator.result);
			Assert.AreEqual(2, calculator.memory.AllMemoryItems.Count);
			Assert.AreEqual(7, calculator.memory.GetLast());
		}

		/// <summary>
		/// Санах ойг цэвэрлэх тест
		/// </summary>
		[TestMethod]
		public void MemoryClear_Test()
		{
			calculator.Add(5);
			calculator.Add(3);
			calculator.memory.Clear();
			Assert.AreEqual(0, calculator.memory.AllMemoryItems.Count);
			Assert.AreEqual(8, calculator.result); 
		}

		/// <summary>
		/// Санах ойд шинэ утга хадгалах тест
		/// </summary>
		[TestMethod]
		public void MemorySave_Test()
		{
			calculator.memory.Save(10);
			Assert.AreEqual(1, calculator.memory.AllMemoryItems.Count);
			Assert.AreEqual(10, calculator.memory.GetLast());
			Assert.AreEqual(0, calculator.result);
		}

		/// <summary>
		/// Санах ойн сүүлийн утга авах тест
		/// </summary>
		[TestMethod]
		public void MemoryGetLast_Test()
		{
			calculator.Add(5);
			calculator.Add(3);
			Assert.AreEqual(8, calculator.memory.GetLast());
		}

		public MemoryTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestMethod1()
		{
			//
			// TODO: Add test logic here
			//
		}
	}
}
