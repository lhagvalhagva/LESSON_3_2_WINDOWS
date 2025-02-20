using 7166_labs;


[TestClass()]
public sealed class  TestMemory
{
    private Calculator calculator;

    [TestInitialize]
    public void Setup()
    {
        calculator = new Calculator();
    }

    [TestMethod]
    public void Test_Memory_GetLast_AfterMultipleOperations()
    {
        calculator.Add(5, 3);
        calculator.Sub(10, 4);
        Assert.AreEqual(6, calculator.memory.GetLast().value);
    }

    [TestMethod]
    public void Test_Memory_GetAll()
    {
        calculator.Add(5, 3);
        calculator.Sub(10, 4);
        var allItems = calculator.memory.GetAll();
        Assert.AreEqual(2, allItems.Count);
        Assert.AreEqual(8, allItems[0].value);
        Assert.AreEqual(6, allItems[1].value);
    }

    [TestMethod]
    public void Test_Memory_Clear()
    {
        calculator.Add(5, 3);
        calculator.Sub(10, 4);
        calculator.memory.Clear();
        var allItems = calculator.memory.GetAll();
        Assert.AreEqual(0, allItems.Count);
    }
}