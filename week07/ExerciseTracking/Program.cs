using System;
using static Utility;

class Program
{
    static void Main(string[] args)
    {
        Running running = new(12, 1.5f);
        Print(running.GetSummary());

        Cycling cycling = new(10, 20);
        Print(cycling.GetSummary());

        Swimming swimming = new(5, 10);
        Print(swimming.GetSummary());
    }
}