using CO453_ConsoleAppAnswer.Week04;
using System;

namespace CO453_ConsoleAppAnswer
{
    /// <summary>
    /// This class provides a user interface for the Network
    /// example whereby users can post messages and photos.
    /// Users can also add comments and like/unlike posts.
    /// </summary>
    /// <author>
    /// Derek Peacock Version 1.1
    /// </author>
    public class NetworkUI
    {
        private readonly NewsFeed news = new NewsFeed();

        public void DisplayMenu2()
        {
            bool quit = false;

            UserLib.OutputHeading("      Derek's News Daily");

            string[] choices = new string[]
            { 
              "Add Message", "Add Photo",  "Display All", "Quit" 
            };

            do
            {
                int choice = UserLib.SelectChoice(choices);

                switch (choice)
                {
                    case 1: AddMessage(); break;
                    case 2: AddPhoto(); break;
                    case 3: Display(); break;
                    case 4: quit = true; break;
                }

            } while (!quit);
        }

        public void DisplayMenu()
        {
            bool quit = false;

            UserLib.OutputHeading("      Derek's News Daily");

            string[] choices = new string[]
                {
                  "Add Message", "Add Photo",   "Add Comment",
                  "Display All", "Display by Author", "Display by Date",
                  "Like/Unlike", "Remove Post", "Quit"
                };

            do
            {
                int choice = UserLib.SelectChoice(choices);

                switch (choice)
                {
                    case 1: AddMessage(); break;
                    case 2: AddPhoto(); break;
                    case 3: AddComment(); break;
                    case 4: Display(); break;
                    case 5: DisplayByAuthor(); break;
                    case 6: DisplayByDate(); break;
                    case 7: LikePost(); break;
                    case 8: RemovePost(); break;
                    case 9: quit = true; break;

                    default:
                        break;
                }

            } while (!quit);
        }

        /// <summary>
        /// Add a comment to a selected Post
        /// </summary>
        private void AddComment()
        {
            Post post = SelectPost();

            DisplayTitle("Adding a Comment");

            Console.Write("Enter a comment > ");
            string comment = Console.ReadLine();

            post.AddComment(comment);
            post.Display();

        }

        private void AddPhoto()
        {
            DisplayTitle("Adding a Photo");

            Console.Write(" Enter your name > ");
            string name = Console.ReadLine();

            Console.Write(" Enter the photo filename > ");
            string filename = Console.ReadLine();

            Console.Write(" Enter the photo caption > ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(name, filename, caption);
            news.AddPost(post);
        }

        private void AddMessage()
        {
            DisplayTitle("Adding a Message");

            Console.Write(" Enter your name > ");
            string name = Console.ReadLine();

            Console.Write(" Enter your message > ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(name, message);
            news.AddPost(post);
        }

        private void Display()
        {
            news.DisplayAll();
        }

        private void DisplayByAuthor()
        {
            DisplayTitle(" Display by Author");

            Console.Write(" Please enter author's name > ");
            string author = Console.ReadLine();

            news.DisplayByAuthor(author);
        }

        private void DisplayByDate()
        {
            DisplayTitle(" Display by Date");

            Console.Write(" Please enter start date > ");
            string value = Console.ReadLine();
            DateTime start = Convert.ToDateTime(value);


            Console.Write(" Please enter end date > ");
            value = Console.ReadLine();
            DateTime end = Convert.ToDateTime(value);

            news.DisplayByDate(start, end);
        }

        private void DisplayTitle(string title)
        {
            Console.WriteLine($"\n {title}");
            Console.WriteLine(" ----------------");
            Console.WriteLine();
        }

        private void LikePost()
        {
            DisplayTitle("Liking or Unliking Post");

            Post post = SelectPost();

            string[] choices = { "Like", "Unlike", "Quit" };
            int choiceNo = UserLib.SelectChoice(choices);

            if(choiceNo == 1)
            {
                post.Like();
            }
            else if(choiceNo == 2)
            {
                post.Unlike();
            }

            post.Display();
        }

        private void RemovePost()
        {
            DisplayTitle("Removing a Post");

            Post post = SelectPost();

            string[] choices = { "Remove", "Quit" };
            int choiceNo = UserLib.SelectChoice(choices);

            if (choiceNo == 1)
            {
               news.RemovePost(post);
            }

            news.DisplaySummary();
        }

        private Post SelectPost()
        {
            DisplayTitle(" Select a Post");

            Post post = news.SelectPost();

            Console.WriteLine();
            Console.WriteLine(" Your chosen post is:-");
            Console.WriteLine();

            post.Display();

            return post;
        }
    }
}
