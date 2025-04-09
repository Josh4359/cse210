using System.Globalization;
using static System.Console;

public static class Utility
{
    public static string Input(string prompt = "")
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

    public static bool CompareResponse(string response, string[] responses)
    {
        foreach (string thisResponse in responses)
            if (thisResponse.ToLower() == response.ToLower())
                return true;
        
        return false;
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

    public static void Write(string value) => Console.Write(value);

    public static void Clear() => Console.Clear();

    public static void ClearLine() {

        ResetCursor();
        Write(new string(' ', WindowWidth));
        ResetCursor();
    }

    public static void MoveCursorUp() => SetCursorPosition(0, CursorTop - 1);

    public static void ResetCursor() => SetCursorPosition(0, CursorTop);

    public static void WaitForConfirm(string prompt)
    {
        Input($"{prompt} ");
        MoveCursorUp();
        ClearLine();
        Print(prompt);
    }

    public static void Wait(float seconds) => Thread.Sleep((int)Math.Round(seconds * 1000));

    public static void AnimateText(float time, string text = "-\\|/", float interval = 0.2f)
    {
        CursorVisible = false;
        float timer = 0;
        while (true)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Write($"{text[i]}");
                Wait(interval);
                timer += interval;
                Write("\b \b");
                if (timer >= time)
                {
                    CursorVisible = true;
                    return;
                }
            }
        }
    }

    public static void DisplayCountdown(int seconds, string messageStart = "", string messageEnd = "", string endMessage = "")
    {
        CursorVisible = false;
        for (int i = seconds; i > 0; i--)
        {
            ClearLine();
            Write($"{messageStart}{i}{messageEnd}");
            Wait(1);
        }
        ClearLine();
        if (endMessage.Length > 0)
            Write(endMessage);
        else
            Write($"{messageStart}0{messageEnd}");
        Print();
        CursorVisible = true;
    }

    static Random _random;

    public static Random Random()
    {
        if (_random == null)
            _random = new();
        
        return _random;
    }
}