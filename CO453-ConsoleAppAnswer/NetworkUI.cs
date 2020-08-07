using CO453_ConsoleAppAnswer.Week04;
using System;

namespace CO453_ConsoleAppAnswer
{
    /// <summary>
    /// This class provides a user interface for the Network
    /// example whereby users can post messages and photos.
    /// Users can also add comments and like/unlike posts.
    /// </summary>
    public class NetworkUI
    {
        private readonly NewsFeed news = new NewsFeed();

        public void Run()
        {
            bool quit = false;

            UserLib.OutputHeading("      Derek's News Daily");

            string[] choices = new string[]
                { "Add Message", "Add Photo", "Display All", "Quit" };

            do
            {
                int choice = UserLib.SelectChoice(choices);

                switch (choice)
                {
                    case 1: AddMessage(); break;
                    case 2: AddPhoto(); break;
                    case 3: Display(); break;
                    case 4: quit = true; break;

                    default:
                        break;
                }

            } while (!quit);
        }

        private void AddPhoto()
        {
            Console.WriteLine("\n Adding a Photo");
            Console.WriteLine("---------------");
            Console.WriteLine();

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
            Console.WriteLine("\n Adding a Message");
            Console.WriteLine(" ----------------");
            Console.WriteLine();

            Console.Write(" Enter your name > ");
            string name = Console.ReadLine();

            Console.Write(" Enter your message > ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(name, message);
            news.AddPost(post);
        }

        private void Display()
        {
            news.Display();
        }
    }
}
