namespace CalculatorTest;
using _7166_labs;
[TestClass]
public class Arithmetic
{
    private Calculator calculator;

    [TestInitialize]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [TestMethod]
    public void Test_AddMethod_Pos()
    {
        int result = calculator.Add(2, 3);
        Assert.AreEqual(5, result);
        Assert.AreEqual(5, calculator.memory.GetLast().value);
    }

    [TestMethod]
    public void Test_AddMethod()
    {
        int result = calculator.Add(-2, -3);
        Assert.AreEqual(-5, result);
        Assert.AreEqual(-5, calculator.memory.GetLast().value);
    }

    [TestMethod]
    public void Test_AddMethod_Zero()
    {
        int result = calculator.Add(5, 0);
        Assert.AreEqual(5, result);
        Assert.AreEqual(5, calculator.memory.GetLast().value);
    }

    [TestMethod]
    public void Test_SubMethod()
    {
        int result = calculator.Sub(10, 4);
        Assert.AreEqual(6, result);
        Assert.AreEqual(6, calculator.memory.GetLast().value);
    }

    [TestMethod]
    public void Test_SubMethodNe()
    {
        int result = calculator.Sub(2, 5);
        Assert.AreEqual(-3, result);
        Assert.AreEqual(-3, calculator.memory.GetLast().value);
    }

    [TestMethod]
    public void Test_SubMethodZero()
    {
        int result = calculator.Sub(5, 0);
        Assert.AreEqual(5, result);
        Assert.AreEqual(5, calculator.memory.GetLast().value);
    }
}
