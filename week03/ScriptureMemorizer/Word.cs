public class Word
{
    public Word(string word)
    {
        _word = word;
    }

    string _word;
    
    public string GetWord() => _visible ? _word : new('_', _word.Length);

    bool _visible = true;

    public bool GetVisible() => _visible;

    public void Hide() => _visible = false;

    public void Show() => _visible = true;

    public static List<Word> FromStringList(List<string> strings)
    {
        List<Word> words = new();

        foreach (string str in strings)
            words.Add(new(str));
        
        return words;
    }

    public static List<Word> FromString(string strings)
    {
        return FromStringList(strings.Split(' ').ToList());
    }
}