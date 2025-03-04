using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            float grade = float.Parse(Input("Enter grade: "));

            string letterGrade = GetLetterGrade(grade);

            string gradeSign = GetGradeSign(grade);

            Print($"Your grade is {letterGrade}{gradeSign}");

            bool passed = grade >= 70;

            if (passed)
                Print("Congradulations! You passed.");
            else
                Print("You failed. Try again next time!");

            Input("Press enter to start over. ");

            Print();
        }
    }

    static string GetLetterGrade(float grade)
    {
        if (grade >= 90)
            return "A";
        else if (grade >= 80)
            return "B";
        else if (grade >= 70)
            return "C";
        else if (grade >= 60)
            return "D";
        else
            return "F";
    }

    static string GetGradeSign(float grade)
    {
        if (grade >= 60 && grade < 97)
        {
            float remainder = grade % 10;

            Print("remainder: " + remainder);

            if (remainder >= 7)
                return "+";
            
            if (remainder < 3)
                return "-";
        }
        
        return default;
    }

    static string Input(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine();
    }

    static void Print(string value = "") => Console.WriteLine(value);
}