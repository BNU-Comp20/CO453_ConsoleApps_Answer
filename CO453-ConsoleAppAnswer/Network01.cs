using CO453_ConsoleAppAnswer.BlueJ_08;
using System;

namespace CO453_ConsoleAppAnswer
{
    public class Network01
    {
        private NewsFeed news = new NewsFeed();

        public NewsFeed NewsFeed
        {
            get => default;
            set
            {
            }
        }

        public void Run()
        {
            bool quit = false;

            UserLib.OutputHeading("      Derek's News Daily");

            string[] choices = new string[]
                { "Add Message", "Add Photo", "Quit" };

            do
            {
                int choice = UserLib.SelectChoice(choices);

                switch (choice)
                {
                    case 1: AddMessage(); break;
                    case 2: AddPhoto(); break;
                    case 3: quit = true; break;

                    default:
                        break;
                }

                news.Show();

            } while (!quit);
        }

        private void AddPhoto()
        {
            UserLib.OutputHeading("      Adding a Photo");

            Console.Write(" Enter your name > ");
            string name = Console.ReadLine();

            Console.Write(" Enter the photo filename > ");
            string filename = Console.ReadLine();

            Console.Write(" Enter the photo caption > ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(name, filename, caption);
            news.AddPhotoPost(post);
        }

        private void AddMessage()
        {
            UserLib.OutputHeading("      Adding a Message");

            Console.Write(" Enter your name > ");
            string name = Console.ReadLine();

            Console.Write(" Enter your message > ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(name, message);
            news.AddMessagePost(post);
        }
    }
}
