using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{   /// <summary>
    /// The post class is the the super/base class or parent
    /// has as sub child Massagepost and PhotoPost
    /// </summary>
    /// <author>
    /// Husnain Ateeq 
    /// </author>
    public class Post
    {
        // Properties to store the ID, username, and timestamp of the post.
        public int PostId { get; }
        public String Username { get; set; }
        public DateTime Timestamp { get; }

        // Static variable to track the number of instances (posts) created.
        public static int instances = 0;

        // A private variable to count likes on the post.
        private int likes;

        // A private list to hold comments made on the post.
        private readonly List<String> comments;

        /// <summary>
        /// Constructor to create a new post and initialize it with the author's username.
        /// </summary>
        public Post(String author)
        {
            instances++;
            PostId = instances; // Unique ID based on the number of instances.

            this.Username = author; // Set the author's username.
            Timestamp = DateTime.Now; // Set the timestamp to the current time.

            likes = 0; // Initialize likes to zero.
            comments = new List<String>(); // Initialize the list of comments.
        }

        /// <summary>
        /// Method to increase the like count of the post.
        /// </summary>
        public void Like()
        {
            likes++;
        }

        /// <summary>
        /// Method to decrease the like count of the post if there are any likes.
        /// </summary>
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        /// <summary>
        /// Method to add a comment to the post.
        /// </summary>
        public void AddComment(String text)
        {
            comments.Add(text);
        }

        /// <summary>
        /// Virtual method to display the details of the post, which can be overridden in derived classes.
        /// </summary>
        public virtual void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"\tPost ID:\t {PostId}");
            Console.WriteLine($"\tAuthor:\t\t {Username}");
            Console.WriteLine($"\tTime Elapsed:\t {FormatElapsedTime(Timestamp)}");
            Console.WriteLine($"\tDate Posted:\t {Timestamp.ToLongDateString()}");
            Console.WriteLine($"\tTime Posted:\t {Timestamp.ToLongTimeString()}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===================================================");
            Console.WriteLine();

            // Display the number of likes if there are any.
            if (likes > 0)
            {
                Console.WriteLine($"    Likes: -  {likes}  people like this.");
            }
            else
            {
                Console.WriteLine();
            }

            // Display comments or a message if there are no comments.
            if (comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
                Console.WriteLine("===================================================");
            }
            else
            {
                Console.WriteLine($"    Comment(s): {comments.Count}  Click here to view.");
                foreach (string comment in comments)
                {
                    Console.WriteLine($"\tComment: {comment}");
                    Console.WriteLine("===================================================");
                }
            }
        }

        /// <summary>
        /// Static method to retrieve the number of posts created.
        /// </summary>
        public static int GetNumberOfPosts()
        {
            return instances;
        }

        /// <summary>
        /// Private helper method to format the elapsed time since the post was created.
        /// </summary>
        private String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }
    }
