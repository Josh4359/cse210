using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            DisplayWelcome();

            string name = PromptUserName();

            float favoriteNumber = PromptUserNumber();

            float squareNumber = SquareNumber(favoriteNumber);

            DisplayResult(name, squareNumber);

            Input("Press enter to start over");

            Print();
        }
    }

    static void DisplayWelcome() => Print("Welcome to the program!");

    static string PromptUserName() => Input("Please enter your name: ");

    static float PromptUserNumber() => float.Parse(Input("Please enter your favorite number: "));

    static float SquareNumber(float number) => (float)Math.Pow(number, 2);

    static void DisplayResult(string name, float squareNumber) => Print($"{name}, the square of your number is {squareNumber}");

    static string Input(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine();
    }

    static void Print(string value = "") => Console.WriteLine(value);
}