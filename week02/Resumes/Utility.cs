public static class Utility
{
    public static string Input(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine();
    }

    public static void Print(string value = "") => Console.WriteLine(value);
}