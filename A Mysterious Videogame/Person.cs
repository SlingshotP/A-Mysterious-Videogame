namespace A_Mysterious_Videogame;

public class Person(string name, ConsoleColor colour)
{
    private readonly string name = name;
    private readonly ConsoleColor colour = colour;

    public async Task Say(string msg)
    {
        Console.ForegroundColor = colour;
        Console.Write(name);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(": ");
        foreach (char character in msg)
        {
            Console.Write(character);
            await Task.Delay(50);
        }
        Console.WriteLine();
    }
}




























// Fortnite Battle Pass!