using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("using System;
using System.Collections.Generic;

namespace Foundation1
{
    // Comment class to represent a single comment
    public class Comment
    {
        public string CommenterName { get; private set; }
        public string Text { get; private set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    // Video class to represent a YouTube video
    public class Video
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Length { get; private set; } // Length in seconds
        private List<Comment> Comments { get; set; }

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

        public List<Comment> GetComments()
        {
            return Comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of videos
            List<Video> videos = new List<Video>();

            // Create and add Video instances
            Video video1 = new Video("Learn C# in 1 Hour", "John Doe", 3600);
            video1.AddComment(new Comment("Alice", "Great video! Very informative."));
            video1.AddComment(new Comment("Bob", "I learned a lot, thanks!"));
            video1.AddComment(new Comment("Charlie", "Well explained!"));

            Video video2 = new Video("Understanding Abstraction", "Jane Smith", 2400);
            video2.AddComment(new Comment("Dave", "Nice explanation of abstraction!"));
            video2.AddComment(new Comment("Eve", "This really helped me."));
            video2.AddComment(new Comment("Frank", "Good job!"));

            Video video3 = new Video("C# Advanced Topics", "Tom Brown", 4800);
            video3.AddComment(new Comment("Grace", "Can't wait to try this!"));
            video3.AddComment(new Comment("Hank", "Very detailed, thank you."));
            video3.AddComment(new Comment("Ivy", "Learned something new today."));

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

                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine();
            }
        }
    }
}
");
    }
}