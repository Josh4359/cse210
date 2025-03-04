using static Utility;

public class Resume
{
    public string _name;

    public List<Job> _jobs = new();

    public void Display()
    {
        Print($"Name: {_name}");

        Print($"Jobs:");

        foreach (Job job in _jobs)
            job.Display();
    }
}