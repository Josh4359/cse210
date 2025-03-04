using static Utility;
using static CSVUtility;

/**
~~Showing Creativity and Exceeding Requirements~~

In addition to the base requirements for this assignment, I also added the following:
- An option to add custom prompts to the list of prompts which can also be used in future sessions.
    I didn't get into too much detail for this feature as it doesn't include options such as removing
    custom prompts, but it's still something.
- An option to clear all journal entries in the current session. This does not clear custom prompts,
    and these journal entries can be restored using the save and load feature.
**/

class Program
{
    static string[] _allPrompts => _prompts.Concat(_customPrompts).ToArray();

    static string[] _prompts =
    [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    ];

    static List<string> _customPrompts = new();

    static string _promptFile = "prompts.txt";

    static Journal _journal = new();

    static Entry PromptRandom()
    {
        LoadPrompts();

        Random random = new();

        string prompt = _allPrompts[random.Next(0, _allPrompts.Length)];

        return new(DateTime.Now, prompt, Input($"{prompt}\n"));
    }

    static void Write()
    {
        Entry entry = PromptRandom();

        _journal._entries.Add(entry);
    }

    static void Display()
    {
        _journal.Display();
    }

    static void Load()
    {
        string fileName;

        while (true)
        {
            fileName = Input("Enter file name (or enter \".\" to cancel) (.csv will be appended to the file name): ");

            if (fileName == ".")
            {
                Print("Load aborted.");

                return;
            }

            fileName += ".csv";

            if (File.Exists(fileName))
                break;
            
            Print($"Couldn't find {fileName}! Trying again.");
        }

        Print("File found!");

        if (_journal._entries.Count > 0)
        {
            string prompt = "How would you like to load this journal? (Select index or title of response)";

            prompt += "\n1. Overwrite current session";

            prompt += "\n2. Append to current session";

            prompt += "\n";

            string[] responses = ["1", "overwrite", "o", "2", "append", "a"];

            string response = InputList(prompt, responses);

            switch (response)
            {
                case "1" or "overwrite" or "o":
                    _journal._entries.Clear();

                    break;
            }
        }
        
        string[] csv = File.ReadAllLines(fileName);

        foreach (List<string> line in ParseCSV(csv))
        {
            DateTime dateTime = DateTime.Parse(line[0].Replace("\\,", ","));

            string prompt1 = line[1].Replace("\\,", ",");

            string response1 = line[2].Replace("\\,", ",");

            Entry entry = new(dateTime, prompt1, response1);

            _journal._entries.Add(entry);
        }

        Print("Load successful.");
    }

    static void Save()
    {
        string fileName;

        while (true)
        {
            fileName = Input("Enter file name (or enter \".\" to cancel) (.csv will be appended to the file name): ");

            if (fileName == ".")
            {
                Print("Save aborted.");

                return;
            }

            fileName += ".csv";

            if (File.Exists(fileName))
            {
                string prompt = "An existing file with this name will be overwritten. Continue? (Y/N) ";

                string response = InputYN(prompt);

                switch (response)
                {
                    case "y" or "yes":
                        break;
                    default:
                        continue;
                }
            }

            goto Overwrite;
        }

        Overwrite:

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _journal._entries)
            {
                string dateTime = entry._dateTime.ToShortDateString().Replace(",", "\\,");

                string prompt = entry._prompt.Replace(",", "\\,");

                string response = entry._response.Replace(",", "\\,");

                outputFile.WriteLine($"{dateTime},{prompt},{response}");
            }
        }

        Print($"Saved to {fileName}.");
    }

    static void Clear()
    {
        string response = InputYN("Would you like to clear your current session? Any unsaved data will be lost. (Y/N) ");

        switch (response)
        {
            case "y" or "yes":
                break;
            default:
                Print("Clear aborted.");

                return;
        }

        _journal._entries.Clear();

        Print("Current session cleared.");
    }

    static void AddPrompt()
    {
        string response = Input("Type in a prompt to add to the random list (or enter \".\" to cancel) ");

        if (response == ".")
        {
            Print("Add prompt aborted.");

            return;
        }

        LoadPrompts();

        _customPrompts.Add(response);

        SavePrompts();

        Print($"Added prompt \"{response}\".");

        Print($"To remove your prompt, go to \"{_promptFile}\" in /bin/Debug/net8.0.");
    }

    static void LoadPrompts()
    {
        _customPrompts.Clear();

        if (!File.Exists(_promptFile)) return;

        string[] lines = File.ReadAllLines(_promptFile);

        foreach (string line in lines)
            _customPrompts.Add(line);
    }

    static void SavePrompts()
    {
        using (StreamWriter outputFile = new StreamWriter(_promptFile, false))
            foreach (string prompt in _customPrompts)
                outputFile.WriteLine(prompt);
    }

    static void Main(string[] args)
    {
        LoadPrompts();

        while (true)
        {
            string prompt = "What would you like to do? (Enter index or title of response)";

            prompt += "\n1. Write";

            prompt += "\n2. Display";

            prompt += "\n3. Load";

            prompt += "\n4. Save";

            prompt += "\n5. Clear";

            prompt += "\n6. Add Prompt";

            prompt += "\n7. Quit";

            prompt += "\n";

            string[] responses = ["1", "write", "2", "display", "3", "load", "4", "save", "5", "clear", "6", "add prompt", "7", "quit"];

            string response = InputList(prompt, responses);

            Print();

            switch (response)
            {
                case "1" or "write":
                    Write();
                    
                    break;
                case "2" or "display":
                    Display();

                    break;
                case "3" or "load":
                    Load();

                    break;
                case "4" or "save":
                    Save();

                    break;
                case "5" or "clear":
                    Clear();

                    break;
                case "6" or "add prompt":
                    AddPrompt();

                    break;
                case "7" or "quit":
                    Print("Quitting...");

                    return;
                default:
                    Print("Error! Failed to handle response.");

                    break;
            }

            Print();

            Input("Press enter to start over ");

            Print();
        }
    }
}