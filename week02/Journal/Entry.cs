using static Utility;

public class Entry
{
    public Entry(DateTime dateTime, string prompt, string response)
    {
        _dateTime = dateTime;

        _prompt = prompt;

        _response = response;
    }

    public DateTime _dateTime;

    public string _prompt;

    public string _response;

    public void Display()
    {
        Print($"Date: {_dateTime.ToShortDateString()}\nPrompt: {_prompt}\nResponse: {_response}");
    }
}