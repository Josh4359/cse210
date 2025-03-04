using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            List<float> numbers = new();

            float total = 0;

            float largest = 0;

            float smallest = float.MaxValue;

            bool smallestInitialized = false;

            int i = 0;

            Print("Enter a list of numbers, type 0 when finished.");

            while (true)
            {
                float number = float.Parse(Input("Enter number: "));

                if (number == 0 && numbers.Count > 0)
                    break;

                numbers.Add(number);

                total += number;

                largest = Math.Max(largest, number);

                if (number > 0)
                {
                    smallest = Math.Min(smallest, number);

                    smallestInitialized = true;
                }

                i++;
            }

            smallest = smallestInitialized ? smallest : 0;

            float average = (float)Math.Round(total / i, 3);

            Print($"The sum is {total}");

            Print($"The average is {average}");

            Print($"The largest number is {largest}");

            Print($"The smallest positive number is {smallest}");

            Print($"The sorted list is:");

            numbers.Sort();

            foreach (float number in numbers)
                Print(number.ToString());
            
            Input("Press enter to start over ");

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