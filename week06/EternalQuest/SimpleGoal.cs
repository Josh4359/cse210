using static CSVUtility;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) {}

    protected SimpleGoal(string name, string description, int points, bool completed) : base(name, description, points, completed) {}

    public override string PackCSV() => ToCSV([GetType().Name, GetName(), GetDescription(), GetPoints().ToString(), GetCompleted().ToString()]);

    public static Goal UnpackCSV(string[] items) => new SimpleGoal(items[1], items[2], int.Parse(items[3]), bool.Parse(items[4]));

    public override void Record() => Complete();
}