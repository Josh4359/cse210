public class Assignment
{
    string _studentName;
    public string GetStudentName() => _studentName;

    string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}