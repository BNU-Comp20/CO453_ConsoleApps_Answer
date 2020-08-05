using System;
using System.Collections.Generic;


namespace CO453_ConsoleAppAnswer.BlueJ_08
{
    /**
     * This class stores information about a post in a social network. 
     * The main part of the post consists of a photo and a caption. 
     * Other data, such as author and time, are also stored.
     * 
     * @author Michael Kölling and David J. Barnes
     * @version 0.1
     */
    public class PhotoPost
    {
        private String username;  // username of the post's author
        private String filename;  // the name of the image file
        private String caption;   // a one line image caption
        
        private DateTime timestamp;
        private int likes;
        
        private List<String> comments;

        /**
         * Constructor for objects of class PhotoPost.
         * 
         * @param author    The username of the author of this post.
         * @param filename  The filename of the image in this post.
         * @param caption   A caption for the image.
         */
        public PhotoPost(String author, String filename, String caption)
        {
            username = author;
            this.filename = filename;
            this.caption = caption;
            timestamp = DateTime.Now;
            likes = 0;
            comments = new List<String>();
        }


        /**
         * Record one more 'Like' indication from a user.
         */
        public void Like()
        {
            likes++;
        }


        /**
         * Record that a user has withdrawn his/her 'Like' vote.
         */
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }


        /**
         * Add a comment to this post.
         * 
         * @param text  The new comment to add.
         */
        public void AddComment(String text)
        {
            comments.Add(text);
        }


        /**
         * Return the file name of the image in this post.
         * 
         * @return The post's image file name.
         */
        public String GetImageFile()
        {
            return filename;
        }


        /**
         * Return the caption of the image of this post.
         * 
         * @return The image's caption.
         */
        public String GetCaption()
        {
            return caption;
        }


        /**
         * Return the time of creation of this post.
         * 
         * @return The post's creation time, as a system time value.
         */
        public DateTime GetTimeStamp()
        {
            return timestamp;
        }


        /**
         * Display the details of this post.
         * 
         * (Currently: Print to the text terminal. This is simulating display 
         * in a web browser for now.)
         */
        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"    Author: {username}");
            Console.WriteLine($"    Filename: [{filename}]");
            Console.WriteLine($"    Caption: {caption}");
            Console.WriteLine($"    Time Elpased: {TimeString(timestamp)}");
            Console.WriteLine();

            if (likes > 0)
            {
                Console.WriteLine($"    Likes: -  {likes}  people like this.");
            }
            else
            {
                Console.WriteLine();
            }

            if (comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
            }
            else
            {
                Console.WriteLine($"    Comment(s): {comments.Count}  Click here to view.");
            }
        }


        /**
         * Create a string describing a time point in the past in terms 
         * relative to current time, such as "30 seconds ago" or "7 minutes ago".
         * Currently, only seconds and minutes are used for the string.
         * 
         * @param time  The time value to convert (in system milliseconds)
         * @return      A relative time string for the given time
         */
        private String TimeString(DateTime time)
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
}
