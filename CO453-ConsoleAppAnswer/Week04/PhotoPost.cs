using System;

namespace CO453_ConsoleAppAnswer.Week04
{
    public class PhotoPost : Post
    {
        // the name of the image file
        public String Filename { get; set; }

        // a one line image caption
        public String Caption { get; set; }

        ///<summary>
        /// Constructor for objects of class PhotoPost.
        ///</summary>
        /// <param name="author">
        /// The username of the author of this post.
        /// </param>
        /// <param name="caption">
        /// A caption for the image.
        /// </param>
        /// <param name="filename">
        /// The filename of the image in this post.
        /// </param>
        public PhotoPost(String author, 
            String filename, String caption):base(author)
        {
            this.Filename = filename;
            this.Caption = caption;
        }

        public override void Display()
        {
            Console.WriteLine(" PhotoPost Display Method");
            Console.WriteLine($"    Filename: [{Filename}]");
            Console.WriteLine($"    Caption: {Caption}");

            base.Display();
        }

    }
}
