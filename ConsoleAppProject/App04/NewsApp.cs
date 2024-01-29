using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// This Social Network app will allow the user to add messages and photos
    /// to a list of posts.  Users can also display those posts
    /// in a variety of ways.
    /// <author>
    /// Husnain Ateeq
    /// </author>
    /// </summary>
    public class NewsApp
    {

        private NewsFeed news = new NewsFeed();

        public NewsFeed NewsFeed
        {
            get => default;
            set
            {
            }
        }

        //Display Menu//
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("\t\t Husnain's News Feed");

            Console.ForegroundColor = ConsoleColor.Yellow;

            string[] choices = new string[]
            {
                "Post Message",
                "Post Image",
                "Remove Post",
                "Display All Posts",
                "Display Posts by Author",
                "Add Comment to Post",
                "Like/Unlike Post",
                "Quit"
            };

            bool wantToQuit = false;
            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);

                switch (choice)
                {
                    case 1:
                        PostMessage();
                        break;
                    case 2:
                        PostImage();
                        break;
                    case 3:
                        RemovePost();
                        break;
                    case 4:
                        DisplayAll();
                        break;
                    case 5:
                        DisplayByAuthor();
                        break;
                    case 6:
                        AddComment();
                        break;
                    case 7:
                        LikePosts();
                        break;
                    case 8:
                        wantToQuit = true;
                        break;
                }
            }
            while (!wantToQuit);
        }

        //Method for add like posts//
        private void LikePosts()
        {
            ConsoleHelper.OutputTitle("Like or Unlike a Post");
            int id = (int)ConsoleHelper.InputNumber("Please enter the post id > ", 1, Post.GetNumberOfPosts());

            Console.WriteLine("Do you want to (like) or (unlike) the post? > ");
            string choices = Console.ReadLine();

            switch (choices)
            {
                case "like":
                    Console.WriteLine("Like a post\n");
                    news.LikePost(id);
                    break;
                case "unlike":
                    Console.WriteLine("Unlike a post\n");
                    news.UnlikePost(id);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try Again.");
                    LikePosts();
                    break;
            }

        }

        //Add comments to the post//
        private void AddComment()
        {
            ConsoleHelper.OutputTitle("Add a comment to a Post");
            int id = (int)ConsoleHelper.InputNumber("Please enter the post id > ", 1, Post.GetNumberOfPosts());

            Console.WriteLine("Enter the comment you want to add > ");
            string comment = Console.ReadLine();
            news.AddPostComment(id, comment);
        }

        //post by author//
        private void DisplayByAuthor()
        {
            Console.WriteLine("Enter the name of user you want to display > ");
            string author = Console.ReadLine();

            ConsoleHelper.OutputTitle($"Posts by {author}");
            news.DisplayAuthorPost(author);
        }

        //display all post//
        private void DisplayAll()
        {
            news.Display();
        }

        //To remove posts from news feed//
        private void RemovePost()
        {
            ConsoleHelper.OutputTitle($"Removing a Post");

            int id = (int)ConsoleHelper.InputNumber("Please enter the post id > ", 1, Post.GetNumberOfPosts());

            news.RemovePost(id);
        }

        //Posting image in the news feed, asking for author and captio//
        private void PostImage()
        {
            ConsoleHelper.OutputTitle("Posting an Image/Photo");

            string author = InputName();

            Console.WriteLine("Please enter your image file name > ");
            string filename = Console.ReadLine();

            Console.WriteLine("Please enter your image caption > ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(author, filename, caption);
            news.AddPhotoPost(post);

            ConsoleHelper.OutputTitle("You have just posted this image:");
            post.Display();
        }

        //posting message in news feed, asking for author name and caption//
        private void PostMessage()
        {
            ConsoleHelper.OutputTitle("Posting an Message");

            string author = InputName();

            Console.WriteLine("Please enter your Message > ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(author, message);
            news.AddMessagePost(post);

            ConsoleHelper.OutputTitle("You have just posted this message:");
            post.Display();
        }

        //Input author name//
        private string InputName()
        {
            Console.Write("Please enter your name > ");
            string author = Console.ReadLine();

            return author;
        }

    }
}