using System;

public class Startup
{
    public static void Main()
    {
        var database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

        Console.WriteLine(string.Join(" ", database.Fetch()));
    }
}