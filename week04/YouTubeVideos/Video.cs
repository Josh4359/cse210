public class Video
{
    List<Comment> _comments;
    public void AddComment(string author, string text) => AddComment(new(author, text));
    public void AddComment(Comment comment) => _comments.Add(comment);
    public List<Comment> GetComments() => _comments;
    public int GetCommentCount() => _comments.Count;

    string _title;
    public string GetTitle() => _title;

    string _author;
    public string GetAuthor() => _author;

    float _length;
    public float GetLength() => _length;

    public Video(string title, string author, float length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public Video(string title, string author, float length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }
}