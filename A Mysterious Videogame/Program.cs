namespace A_Mysterious_Videogame;

internal class Program
{
    static async Task Main(string[] args)
    {
        int gamesPlayed = 0;
        int wins = 0;

        while (true)
        {
            await Music.Play("Low Hum Tunes.mp3");

            if (!StartScreen(gamesPlayed, wins))
                break;

            gamesPlayed++;
            if (await NewGame())
                wins++;
        }

        Music.Dispose();
    }

    static bool StartScreen(int gamesPlayed, int wins)
    {
        string[] title = @"                                                                                                    

     █████╗     ███╗   ███╗██╗   ██╗███████╗████████╗███████╗██████╗ ██╗ ██████╗ ██╗   ██╗███████╗
    ██╔══██╗    ████╗ ████║╚██╗ ██╔╝██╔════╝╚══██╔══╝██╔════╝██╔══██╗██║██╔═══██╗██║   ██║██╔════╝
    ███████║    ██╔████╔██║ ╚████╔╝ ███████╗   ██║   █████╗  ██████╔╝██║██║   ██║██║   ██║███████╗
    ██╔══██║    ██║╚██╔╝██║  ╚██╔╝  ╚════██║   ██║   ██╔══╝  ██╔══██╗██║██║   ██║██║   ██║╚════██║
    ██║  ██║    ██║ ╚═╝ ██║   ██║   ███████║   ██║   ███████╗██║  ██║██║╚██████╔╝╚██████╔╝███████║
    ╚═╝  ╚═╝    ╚═╝     ╚═╝   ╚═╝   ╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝ ╚═════╝  ╚═════╝ ╚══════╝
             ██╗   ██╗██╗██████╗ ███████╗ ██████╗  ██████╗  █████╗ ███╗   ███╗███████╗            
             ██║   ██║██║██╔══██╗██╔════╝██╔═══██╗██╔════╝ ██╔══██╗████╗ ████║██╔════╝            
             ██║   ██║██║██║  ██║█████╗  ██║   ██║██║  ███╗███████║██╔████╔██║█████╗              
             ╚██╗ ██╔╝██║██║  ██║██╔══╝  ██║   ██║██║   ██║██╔══██║██║╚██╔╝██║██╔══╝              
              ╚████╔╝ ██║██████╔╝███████╗╚██████╔╝╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗            
               ╚═══╝  ╚═╝╚═════╝ ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝            

".Trim('\r', '\n').Split(Environment.NewLine);

        bool @continue = true;
        bool finished = false;
        while (!finished)
        {
            Console.Clear();

            foreach (string line in title)
            {
                Console.CursorLeft = (Console.WindowWidth - line.Length) / 2;
                Console.WriteLine(line);
            }
            Console.WriteLine("1. New game");
            Console.WriteLine("2. Stats");
            Console.WriteLine("3. Skedurddle");

            switch (Console.ReadLine() ?? "3")
            {
                case "1": finished = true; break;
                case "2": StatsPage(wins, gamesPlayed); break;
                case "3": @continue = false; finished = true; break;
            }
        }

        return @continue;
    }

    static void StatsPage(int wins, int gamesPlayed)
    {
        Console.Clear();

        Console.WriteLine("Note: Stats reset when you close the software");
        Console.WriteLine($"Wins: {wins}");
        Console.WriteLine($"Games played: {gamesPlayed}");

        Console.WriteLine("Press ESC to go back");
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.Escape)
        {
            return;
        }
    }
    static async Task<bool> NewGame() 
    {
        Console.Clear();

        bool won = false;
        Person user = new("You", ConsoleColor.Yellow);
        Person joelheath24 = new("joelheath24", ConsoleColor.DarkYellow);
        await Music.Play("Quirky Dog.mp3");
        await Type("You are travelling through the wilderness.");
        await Type("You see a hole.");
        won = true;
        Console.ReadKey();
        return won;
    }

    static async Task Type(string msg, int delay = 50)
    {
        foreach (char c in msg)
        {
            Console.Write(c);
            await Task.Delay(delay);
        }
        Console.WriteLine();
    }

}
