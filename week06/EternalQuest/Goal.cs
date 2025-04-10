public abstract class Goal
{
    string _name;
    public string GetName() => _name;

    string _description;
    public string GetDescription() => _description;

    int _points;
    public virtual int GetPoints() => _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    bool _completed;
    public bool GetCompleted() => _completed;
    protected void Complete() => _completed = true;

    protected Goal(string name, string description, int points, bool completed) : this(name, description, points)
    {
        _completed = completed;
    }

    public virtual string GetDisplay() => $"{(_completed ? "[X]" : "[ ]")} {GetName()} ({GetDescription()})";

    public abstract string PackCSV();

    public virtual void Record() { }
}