using static CSVUtility;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) {}

    protected EternalGoal(string name, string description, int points, bool completed) : base(name, description, points, completed) {}

    public override string PackCSV() => ToCSV([GetType().Name, GetName(), GetDescription(), GetPoints().ToString(), GetCompleted().ToString()]);

    public static Goal UnpackCSV(string[] items) => new EternalGoal(items[1], items[2], int.Parse(items[3]), bool.Parse(items[4]));
}