﻿using System;
using System.Transactions;

namespace CO453_ConsoleAppAnswer.Week04
{
    public class MessagePost : Post
    {
        // an arbitrarily long, multi-line message
        public String Message { get; }

        
        /// <summary>
        /// Constructor for objects of class MessagePost.
        /// </summary>
        /// <param name="author">
        /// The username of the author of this post.
        /// </param>
        /// <param name="text">
        /// The text of this post.
        /// </param>
        public MessagePost(String author, 
            String text): base(author)
        {
            Message = text;
        }

        public override void Display()
        {
            Console.WriteLine($"    Message: {Message}");
            base.Display();
        }

    }
}