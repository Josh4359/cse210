using System.Globalization;
using static System.Console;

public static class Utility
{
    public static string Input(string prompt)
    {
        Write(prompt);

        return ReadLine();
    }

    public static string InputList(string prompt, string[] responses)
    {
        for (int i = 0; i < responses.Length; i++)
            responses[i] = responses[i].ToLower();

        while (true)
        {
            string response = Input(prompt).ToLower();

            if (responses.Contains(response))
                return response;
            
            Print("Invalid response! Trying again...\n");
        }
    }

    public static T InputType<T>(string prompt)
    {
        while (true)
        {
            string response = Input(prompt);
            
            try
            {
                return (T)Convert.ChangeType(response, typeof(T), CultureInfo.InvariantCulture);
            }
            catch
            {
                Print("Invalid value! Please try again.");

                Print();
            }
        }
    }

    public static string InputYN(string prompt) => InputList(prompt, ["y", "yes", "n", "no"]);

    public static void Print(string value = "") => WriteLine(value);

    public static void Clear() => Console.Clear();
}