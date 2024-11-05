namespace A_Mysterious_Videogame;

public class Person(string name, ConsoleColor colour)
{
    private readonly string name = name;
    private readonly ConsoleColor colour = colour;

    public async Task Say(string msg, int speed = 50)
    {
        Console.ForegroundColor = colour;
        Console.Write(name);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(": ");
        foreach (char character in msg)
        {
            Console.Write(character);
            await Task.Delay(speed);
        }
        Console.WriteLine();
    }
}




























// Fortnite Battle Pass!