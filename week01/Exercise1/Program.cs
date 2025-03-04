using System;

class Program
{
    static void Main(string[] args)
    {
        string firstName = Input("What is your first name? ");

        string lastName = Input("What is your last name? ");

        Print($"Your name is {lastName}, {firstName} {lastName}.");
    }

    static string Input(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine();
    }

    static void Print(string value = "") => Console.WriteLine(value);
}