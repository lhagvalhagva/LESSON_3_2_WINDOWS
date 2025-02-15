using System

namespace LAB_1.Receipt;

internal class TalonMur{
    public ulong totalPrice{get; set;}
    public int discount{get; set;}
    public int count{get; set;}
    public Baraa baraa{get; set;}

    public TalonMur(Baraa baraa , int count, int discount, ulong totalPrice){
        this.baraa = baraa;
        this.count = count;
        this.discount = discount;
        this.totalPrice = totalPrice;
    }
}