using System;
using LAB_1.Product;
using LAB_1.Receipt;

namespace LAB_1
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Hello World!");
      var talon = new Talon();
      var baraa = new Baraa();
      var mur = new Mur();
      var talonMur = new TalonMur();

      talon.addItem(baraa);
      talon.removeItem(baraa);
      talon.Pay();
      
      
    }
  }
}