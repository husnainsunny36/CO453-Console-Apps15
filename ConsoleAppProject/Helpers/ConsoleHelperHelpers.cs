using System;

internal static class ConsoleHelperHelpers
{

    /// <summary>
    /// This method will display a yellow title underlined
    /// by dashes.
    /// </summary>
   /* public static void OutputTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine($"\n {title}");
        Console.Write(" ");

        for (int count = 0; count <= title.Length; count++)
        {
            Console.Write("-");
        }

        Console.WriteLine("\n");
        Console.ResetColor();
    }*/

    /// <summary>
    /// This method will display a green title underlined
    /// by dashes.
    /// </summary>
    public static void OutputTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"                {title}");
        Console.WriteLine("---------------------------------------------------\n");

        // Console.Write(" ");

        //for (int count = 0; count <= title.Length; count++)
        //{
        //    Console.Write("-");
        //}

        Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("\n");
        // Console.ResetColor();
    }
}