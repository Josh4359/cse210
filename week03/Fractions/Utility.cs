public static class Utility
{
    public static string Input(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine();
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

    public static string InputYN(string prompt) => InputList(prompt, ["y", "yes", "n", "no"]);

    public static void Print(string value = "") => Console.WriteLine(value);
}