using System;
using System.Collections.Generic;

namespace CO453_ConsoleAppAnswer.Week04
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
    */
    public class NewsFeed
    {
        private List<Post> Posts { get; }

        public NewsFeed()
        {
            Posts = new List<Post>();
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
        public void Display()
        {
            foreach (Post post in Posts)
            {
                post.Display();
                Console.WriteLine();   
            }

        }

    }
}
