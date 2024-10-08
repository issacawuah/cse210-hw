using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("Understanding Abstraction", "Jane Doe", 300);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "I learned a lot from this."));
        video1.AddComment(new Comment("Charlie", "Thanks for the clear examples."));
        
        // Create Video 2
        Video video2 = new Video("Classes in C#", "John Smith", 240);
        video2.AddComment(new Comment("Dave", "Well explained!"));
        video2.AddComment(new Comment("Eve", "Really helpful."));
        video2.AddComment(new Comment("Frank", "Good job!"));

        // Create Video 3
        Video video3 = new Video("Object-Oriented Programming", "Emily Johnson", 600);
        video3.AddComment(new Comment("Grace", "This was very insightful."));
        video3.AddComment(new Comment("Heidi", "I appreciate the depth!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Commenter}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

public class Comment
{
    public string Commenter { get; private set; }
    public string Text { get; private set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}
