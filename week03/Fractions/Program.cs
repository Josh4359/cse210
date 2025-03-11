using System;
using static Utility;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new();
        Print(fraction1.GetFractionString());
        Print(fraction1.GetDecimalValue().ToString());

        Fraction fraction2 = new(5);
        Print(fraction2.GetFractionString());
        Print(fraction2.GetDecimalValue().ToString());

        Fraction fraction3 = new(3, 4);
        Print(fraction3.GetFractionString());
        Print(fraction3.GetDecimalValue().ToString());

        Fraction fraction4 = new(1, 3);
        Print(fraction4.GetFractionString());
        Print(fraction4.GetDecimalValue().ToString());
    }
}