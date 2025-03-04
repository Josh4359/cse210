using static Utility;

public class Journal
{
    public List<Entry> _entries = new();

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Print("No entries to display!");

            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            if (i != 0)
                Print();

            Entry entry = _entries[i];

            entry.Display();
        }
    }
}