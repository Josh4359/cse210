using static CSVUtility;

public class ChecklistGoal : Goal
{
    public override int GetPoints() => GetProgress() == GetTimes() ? base.GetPoints() + GetBonus() : base.GetPoints();

    int _times;
    public int GetTimes() => _times;

    int _bonus;
    public int GetBonus() => _bonus;
    
    public ChecklistGoal(string name, string description, int points, int times, int bonus) : base(name, description, points)
    {
        _times = times;
        _bonus = bonus;
    }

    int _progress;
    public int GetProgress() => _progress;
    public void AddProgress() => _progress++;

    protected ChecklistGoal(string name, string description, int points, bool completed, int times, int bonus, int progress) : base(name, description, points, completed)
    {
        _times = times;
        _bonus = bonus;
        _progress = progress;
    }

    public override string GetDisplay() => $"{base.GetDisplay()} -- Currently completed: {_progress}/{_times}";

    public override string PackCSV() => ToCSV([GetType().Name, GetName(), GetDescription(), GetPoints().ToString(), GetCompleted().ToString(), GetTimes().ToString(), GetBonus().ToString(), GetProgress().ToString()]);

    public static Goal UnpackCSV(string[] items) => new ChecklistGoal(items[1], items[2], int.Parse(items[3]), bool.Parse(items[4]), int.Parse(items[5]), int.Parse(items[6]), int.Parse(items[7]));

    public override void Record()
    {
        AddProgress();

        if (GetProgress() == GetTimes())
            Complete();
    }
}