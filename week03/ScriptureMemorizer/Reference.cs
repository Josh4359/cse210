public class Reference
{
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    string _book;

    int _chapter;

    int _verseStart;

    int _verseEnd;

    public string GetReferenceString() => $"{_book} {_chapter}:{_verseStart}" + (_verseEnd == _verseStart ? string.Empty : $"-{_verseEnd}");
}