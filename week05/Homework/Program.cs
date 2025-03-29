using System;
using static Utility;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new("Samuel Bennett", "Multiplication");
        Print(assignment.GetSummary());

        Print();

        MathAssignment mathAssignment = new("Roberto Rodrigues", "Fractions", "7.3", "8-19");
        Print(mathAssignment.GetSummary());
        Print(mathAssignment.GetHomeworkList());

        Print();

        WritingAssignment writingAssignment = new("Mary Waters", "European History", "The Causes of World War II");
        Print(writingAssignment.GetSummary());
        Print(writingAssignment.GetWritingInformation());
    }
}