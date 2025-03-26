public class Comment
{
    string _author;
    public string GetAuthor() => _author;

    string _text;
    public string GetText() => _text;

    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }
}