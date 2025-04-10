using System;
using static Utility;
using static CSVUtility;

/*
~~Showing Creativity and Exceeding Requirements~~

In addition to the base requirements for this assignment, I also added the following:
- Made a proper CSV utility script for saving and loading goals (expanding on a similar script I had made for a previous assignment)
- One of the benefits of this is you can put commas in your goals and they'll still save and load as expected
*/

class Program
{
    static List<Goal> _goals = new();

    static int _points;

    static void CreateGoal()
    {
        while (true)
        {
            Print("The types of goals are:");
            Print("  1. Simple Goal");
            Print("  2. Eternal Goal");
            Print("  3. Checklist Goal");

            string[] a = ["1", "simple", "simple goal"];
            string[] b = ["2", "eternal", "eternal goal"];
            string[] c = ["3", "checklist", "checklist goal"];
            string[] responses = a.Concat(b).Concat(c).ToArray();

            string response = InputList("Which type of goal would you like to create? ", responses);

            if (!CompareResponse(response, responses))
            {
                Error();

                continue;
            }

            Goal goal;

            string name = Input("What is the name of your goal? ");
            string description = Input("What is a short description of it? ");
            int points = InputType<int>("What is the amount of points associated with this goal? ");

            if (CompareResponse(response, a))
            {
                goal = new SimpleGoal(name, description, points);
            }
            else if (CompareResponse(response, b))
            {
                goal = new EternalGoal(name, description, points);
            }
            else if (CompareResponse(response, c))
            {
                int times = InputType<int>("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = InputType<int>("What is the bonus for accomplishing it that many times? ");
                goal = new ChecklistGoal(name, description, points, times, bonus);
            }
            else
            {
                Error();

                continue;
            }

            _goals.Add(goal);

            break;
        }
    }

    static void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Print("No goals to display!");

            Print();

            WaitForConfirm("Press enter to continue");

            return;
        }

        Print("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Print($"{i + 1}. {goal.GetDisplay()}");
        }

        Print();

        WaitForConfirm("Press enter to continue");
    }

    static void SaveGoals()
    {
        string path = Input("Enter file path: ");

        using (StreamWriter output = new(path))
        {
            output.WriteLine(_points);

            foreach (Goal goal in _goals)
                output.WriteLine(goal.PackCSV());
        }

        Print($"Saved to {path}");

        Print();

        WaitForConfirm("Press enter to continue");
    }

    static void LoadGoals()
    {
        string path = Input("Enter file path: ");

        if (!File.Exists(path))
        {
            Print("No file found!");

            Print();

            WaitForConfirm("Press enter to continue");

            return;
        }
        
        List<List<string>> lines = ParseCSV(File.ReadAllLines(path));

        _goals.Clear();

        _points = int.Parse(lines[0][0]);

        for (int i = 1; i < lines.Count; i++)
        {
            string[] line = lines[i].ToArray();

            switch (line[0])
            {
                case "SimpleGoal":
                    _goals.Add(SimpleGoal.UnpackCSV(line.ToArray()));

                    break;
                case "EternalGoal":
                    _goals.Add(EternalGoal.UnpackCSV(line.ToArray()));

                    break;
                case "ChecklistGoal":
                    _goals.Add(ChecklistGoal.UnpackCSV(line.ToArray()));

                    break;
                default:
                    continue;
            }
        }

        Print($"Loaded from {path}");

        Print();

        WaitForConfirm("Press enter to continue");
    }

    static void RecordEvent()
    {
        List<string> responses = new();
        List<string[]> options = new();

        Print("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Print($"{i + 1}. {_goals[i].GetName()}");
            string[] option = {(i + 1).ToString(), _goals[i].GetName().ToLower()};
            responses.AddRange(option);
            options.Add(option);
        }

        string response = InputList("Which goal did you accomplish? ", responses.ToArray());

        for (int i = 0; i < _goals.Count; i++)
        {
            if (!CompareResponse(response, options[i])) continue;

            _goals[i].Record();

            int points = _goals[i].GetPoints();

            Print($"Congradulations! You have earned {points} points!");

            _points += points;
        }

        Print();

        WaitForConfirm("Press enter to continue");
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Clear();

            Print($"You have {_points} points.");

            Print();

            Print("Menu Options:");
            Print("  1. Create New Goal");
            Print("  2. List Goals");
            Print("  3. Save Goals");
            Print("  4. Load Goals");
            Print("  5. Record Event");
            Print("  6. Quit");

            string[] a = ["1", "create", "new", "create new", "new goal", "create new goal"];
            string[] b = ["2", "list", "list goals"];
            string[] c = ["3", "save", "save goals"];
            string[] d = ["4", "load", "load goals"];
            string[] e = ["5", "record", "record event"];
            string[] f = ["6", "quit"];
            string[] responses = a.Concat(b).Concat(c).Concat(d).Concat(e).Concat(f).ToArray();

            string response = InputList("Select a choice from the menu: ", responses);

            Print();

            if (CompareResponse(response, a))
                CreateGoal();
            else if (CompareResponse(response, b))
                ListGoals();
            else if (CompareResponse(response, c))
                SaveGoals();
            else if (CompareResponse(response, d))
                LoadGoals();
            else if (CompareResponse(response, e))
                RecordEvent();
            else if (CompareResponse(response, f))
            {
                Clear();
                Print("Quitting...");
                return;
            }
            else
            {
                Error();

                continue;
            }
        }
    }

    static void Error()
    {
        for (int i = 3; i > 0; i--)
        {
            Clear();
            Print($"Error! Trying again in {i}...");
            Wait(1);
        }
    }
}