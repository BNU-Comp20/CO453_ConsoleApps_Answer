using System;
using System.Collections.Generic;

namespace CO453_ConsoleAppAnswer.App04
{
    /**
    * The NewsFeed class stores news posts for the news feed in a
    * social-network application (like FaceBook or Google+).
    *
    * Display of the posts is currently simulated by printing the
    * details to the terminal. (Later, this should display in a browser.)
    *
    * This version does not save the data to disk, and it does not
    * provide any search or ordering functions.
    *
    * @author Michael Kölling and David J. Barnes
    * @version 0.2
    * 
    * Extended by Derek Peacock version 0.3
    */
    public class NewsFeed
    {
        private List<Post> Posts { get; }

        /// <summary>
        /// Constructor creates a list of 3 posts to make testing 
        /// easier.
        /// </summary>
        public NewsFeed()
        {
            Posts = new List<Post>
            {
                new MessagePost("Veena", "Hello"),
                new PhotoPost("Veena", "photo.jpg", "My Cat"),
                new MessagePost("Sue", "Hi There!")
            };
        }

        ///<summary>
        /// Add a post to the news feed.
        /// 
        /// @param post  The post to be added.
        ///</summary>
        public void AddPost(Post post)
        {
            Posts.Add(post);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public void DisplayAll()
        {
            foreach (Post post in Posts)
            {
                post.Display();
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Display all the posts between the start and end
        /// dates includively
        /// </summary>
        public void DisplayByDate(DateTime start, DateTime end)
        {
            int count = 0;

            foreach (Post post in Posts)
            {
                if ((post.Timestamp >= start) && (post.Timestamp <= end))
                {
                    post.Display();
                    Console.WriteLine();
                    count++;
                }
            }

            if(count < 1)
            {
                Console.WriteLine(" " +
                    " There are no posts between those dates!\n");
            }
        }

        /// <summary>
        /// Display all the posts by the given author
        /// </summary>
        public void DisplayByAuthor(string author)
        {
            int count = 0;

            foreach (Post post in Posts)
            {
                if(post.Username.Equals(author))
                {
                    post.Display();
                    Console.WriteLine();
                }
            }
            
            if (count < 1)
            {
                Console.WriteLine(" " +
                    " There are no posts that match that name!\n");
            }
        }

        /// <summary>
        /// Display a one line summary of each post
        /// </summary>
        public void DisplaySummary()
        {
            foreach (Post post in Posts)
                Console.WriteLine(post.GetSummary());
        }

        /// <summary>
        /// Remove the supplied post from the list of posts
        /// </summary>
        public void RemovePost(Post post)
        {
            Posts.Remove(post);
        }

        /// <summary>
        /// List a one line summary of all the posts and
        /// allow the user to select one by position in
        /// the list. First position = 1
        /// </summary>
        public Post SelectPost()
        {
            string[] choices = new string[Posts.Count];

            int i = 0;

            foreach(Post post in Posts)
            {
                choices[i] = post.GetSummary();
                i++;
            }

            Console.WriteLine("\n Listing of all Posts");

            int choiceNo = UserLib.SelectChoice(choices);

            return Posts[choiceNo - 1];
        }
    }
}
