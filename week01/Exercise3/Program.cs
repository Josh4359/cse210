using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new();

        while (true)
        {
            float magicNumber = random.Next(1, 101);
            
            for (int i = 1; true; i++)
            {
                float guess = float.Parse(Input("What is your guess? "));

                if (guess == magicNumber)
                {
                    Print();
                    
                    Print($"You guessed it in {i} {(i == 1 ? "try" : "tries")}!");

                    break;
                }
                else if (magicNumber > guess)
                    Print("Higher");
                else
                    Print("Lower");
            }

            Input("Press enter to start over. ");

            Print();
        }
    }

    static string Input(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine();
    }

    static void Print(string value = "") => Console.WriteLine(value);
}