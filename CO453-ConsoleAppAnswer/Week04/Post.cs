using System;
using System.Collections.Generic;
using System.Text;

namespace CO453_ConsoleAppAnswer.Week04
{
    ///<summary>
    /// This class stores general information about a post 
    /// in a social network. Posts can be added, liked, unliked
    /// and displayed
    ///</summary>
    /// <author>
    /// Michael Kölling and David J. Barnes
    /// @version 0.2
    /// </author>
    public class Post
    {
        // username of the post's author
        public String Username { get; set; }
        public DateTime Timestamp { get; }

        private int likes;

        private readonly List<String> comments;
        
        
        public Post(String author)
        {
            Username = author;
            Timestamp = DateTime.Now;

            likes = 0;
            comments = new List<String>();
        }

        ///<summary>
        /// Record one more 'Like' indication from a user.
        ///</summary>
        public void Like()
        {
            likes++;
        }

        ///<summary>
        /// Record that a user has withdrawn his/her 'Like' vote.
        ///</summary>
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        ///<summary>
        /// Add a comment to this post.
        /// </summary>
        /// <param name="text">
        /// The new comment to add.
        /// </param>        
        public void AddComment(String text)
        {
            comments.Add(text);
        }


        ///<summary>
        /// Display the details of this post.
        /// 
        /// (Currently: Print to the text terminal. This is simulating display 
        /// in a web browser for now.)
        ///</summary>
        public virtual void Display()
        {
            Console.WriteLine(ToString());
        }


        public virtual string GetSummary()
        {
            return $" {Timestamp}: {Username}";
        }


        ///<summary>
        /// Create a string describing a time point in the past in terms 
        /// relative to current time, such as "30 seconds ago" or "7 minutes ago".
        /// Currently, only seconds and minutes are used for the string.
        /// </summary>
        /// <param name="time">
        ///  The time value to convert (in system milliseconds)
        /// </param> 
        /// <returns>
        /// A relative time string for the given time
        /// </returns>      
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


        /// <summary>
        /// Return as text the author's name, the time elapsed,
        /// the number of likes and how many comments the post has
        /// </summary>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            
            builder.AppendLine($"    Author: {Username}");
            builder.AppendLine($"    Time Elpased: {FormatElapsedTime(Timestamp)} \n");

            if (likes > 0)
            {
                builder.AppendLine($"    Likes:  {likes}  people like this.");
            }
            else
            {
                builder.AppendLine();
            }

            if (comments.Count == 0)
            {
                builder.AppendLine("    No comments.");
            }
            else
            {
                builder.AppendLine($"    {comments.Count}  comment(s).\n");
                
                foreach(string comment in comments)
                {
                    builder.AppendLine($"    {comment}");
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
