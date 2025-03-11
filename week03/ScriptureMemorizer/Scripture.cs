public class Scripture
{
    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    public Scripture(Reference reference, List<string> strings)
    {
        _reference = reference;
        _words = Word.FromStringList(strings);
    }

    Reference _reference;

    public string GetReferenceString() => _reference.GetReferenceString();

    List<Word> _words;

    List<Word> GetVisibleWords() => _words.Where(x => x.GetVisible()).ToList();

    public int GetVisibleWordCount() => GetVisibleWords().Count;

    Random _random = new();

    public void HideRandomWord()
    {
        List<Word> visibleWords = GetVisibleWords();

        int index = _random.Next(0, visibleWords.Count - 1);

        visibleWords[index].Hide();
    }

    public void HideRandomWords(int number = 1)
    {
        number = Math.Clamp(number, 1, GetVisibleWordCount());

        for (int i = 0; i < number; i++)
            HideRandomWord();
    }

    public void ResetHidden()
    {
        foreach (Word word in _words)
            word.Show();
    }

    public string GetScriptureString()
    {
        string str = default;

        int i = 0;

        foreach (Word word in _words)
        {
            if (i != 0)
                str += ' ';

            str += word.GetWord();

            i++;
        }
        
        return $"{GetReferenceString()} {str}";
    }
}