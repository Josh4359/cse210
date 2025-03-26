using System;
using static Utility;

class Program
{
    static List<Video> _videos = new();

    static void Main(string[] args)
    {
        Video video1 = new("Video 1", "Author 1", 1);
        video1.AddComment("Commenter 1", "Hi, I'm Commenter 1 commenting on Video 1");
        video1.AddComment("Commenter 2", "Hi, I'm Commenter 2 commenting on Video 1");
        video1.AddComment("Commenter 3", "Hi, I'm Commenter 3 commenting on Video 1");
        _videos.Add(video1);

        Video video2 = new("Video 2", "Author 2", 1);
        video2.AddComment("Commenter 1", "Hi, I'm Commenter 1 commenting on Video 2");
        video2.AddComment("Commenter 2", "Hi, I'm Commenter 2 commenting on Video 2");
        video2.AddComment("Commenter 3", "Hi, I'm Commenter 3 commenting on Video 2");
        _videos.Add(video2);

        Video video3 = new("Video 3", "Author 3", 1);
        video3.AddComment("Commenter 1", "Hi, I'm Commenter 1 commenting on Video 3");
        video3.AddComment("Commenter 2", "Hi, I'm Commenter 2 commenting on Video 3");
        video3.AddComment("Commenter 3", "Hi, I'm Commenter 3 commenting on Video 3");
        _videos.Add(video3);
        
        string separator = new('-', 50);

        foreach (Video video in _videos)
        {
            Print(separator);
            Print($"Title: {video.GetTitle()}; Author: {video.GetAuthor()}; Length: {video.GetLength()}; Comments: {video.GetCommentCount()}");
            Print();
            Print("Comments:");
            foreach (Comment comment in video.GetComments())
                Print($"{comment.GetAuthor()}: {comment.GetText()}");
            Print(separator);
        }
    }
}

