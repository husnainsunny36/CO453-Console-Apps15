using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;


namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    ///</summary>
    ///<author>
    ///  Husnain Ateeq
    ///  version 0.1
    ///</author> 
    public class NewsFeed
    {
        // A constant string to store the default author's name.
        public const string AUTHOR = "Husnain";

        // A private list to store all posts in the news feed.
        private readonly List<Post> posts;

        // Constructor initializes the news feed with predefined posts.
        public NewsFeed()
        {
            posts = new List<Post>();

            // Create a new message post and add it to the list.
            MessagePost post = new MessagePost(AUTHOR, "I Like Visual Studio 2024");
            AddMessagePost(post);
            post.AddComment("hello");

            // Create a new photo post and add it to the list.
            PhotoPost photoPost = new PhotoPost(AUTHOR, "Photo1.jpg", "Visual Studio 2024");
            AddPhotoPost(photoPost);
        }

        // A property to get or set a Post object.
        public Post Post
        {
            get => default;
            set { }
        }

        // Adds a message post to the news feed.
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        // Adds a photo post to the news feed.
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        // Displays all posts by a specific author.
        public void DisplayAuthorPost(string author)
        {
            foreach (Post post in posts)
            {
                if (post.Username == author)
                {
                    post.Display();
                }
            }
        }

        // Finds posts by a specific date and displays them.
        public void FindDate(string date)
        {
            foreach (Post post in posts)
            {
                if (post.Timestamp.ToLongDateString().Contains(date))
                {
                    post.Display();
                }
            }
        }

        // Adds a comment to a post by post ID.
        public void AddPostComment(int id, string text)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($"\nPost with ID: {id} does not exist!\n");
            }
            else
            {
                Console.WriteLine($"\nThe comment have been added to post {id}!\n");
                post.AddComment(text);
                post.Display();
            }
        }

        // Likes a post by ID.
        public void LikePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($"\nPost with ID: {id} does not exist!\n");
            }
            else
            {
                Console.WriteLine($"\nYou have liked the the post {id}!\n");
                post.Like();
                post.Display();
            }
        }

        // Unlikes a post by ID.
        public void UnlikePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($"\nPost with ID: {id} does not exist!\n");
            }
            else
            {
                Console.WriteLine($"\nYou have unliked the the post {id}!\n");
                post.Unlike();
                post.Display();
            }
        }

        // Removes a post from the news feed by ID.
        public void RemovePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine($" \nPost with ID: {id} does not exist!\n");
            }
            else
            {
                Console.WriteLine($" \nThe following Post {id} has been removed!\n");
                posts.Remove(post);
                post.Display();
            }
        }

        // Finds a post in the list by ID.
        public Post FindPost(int id)
        {
            foreach (Post post in posts)
            {
                if (post.PostId == id)
                {
                    return post;
                }
            }

            return null;
        }

        // Displays all posts in the news feed.
        public void Display()
        {
            ConsoleHelper.OutputTitle("Display All Posts");

            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine();
            }
        }
    }
