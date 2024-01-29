using System;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a photo and a caption. 
    ///</summary>
    /// <author>
    /// Husnain Ateeq
    /// @version 0.1 
    /// </author>
    public class PhotoPost : Post
    {
        
        public String Filename { get; set; }

        
        public String Caption { get; set; }

        
        public PhotoPost(String author, String filename, String caption) : base(author)
        {
            this.Filename = filename;
            this.Caption = caption;
        }
        
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t Photo Post Display");
            Console.WriteLine($"\t\tFilename: [{Filename}]");
            Console.WriteLine($"\t\tCaption: [{Caption}]");
            base.Display();
        }
    }
}