using System

using LAB_1.Product;

namespace LAB_1.Receipt;

internal class Talon{
    public int GrandTotal{get; set;}
    public int itemCount{get; set;}

    public List<TalonMur> Murs{get; set;}

    public void addItem(Baraa baraa){
        var mur = new TalonMur(baraa);
        Murs.Add(mur);
        GrandTotal += mur.Total;
        itemCount++;
    }

    public void removeItem(Baraa baraa){
        Murs.Remove(baraa);
        GrandTotal -= baraa.Total;
        itemCount--;
    }

    public void Pay(){
        Console.WriteLine("Paying...");
    }   
}
