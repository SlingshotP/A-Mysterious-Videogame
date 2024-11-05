using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;

namespace A_Mysterious_Videogame;

internal class Program
{
    static int gamesPlayed = 0;
    static int wins = 0;
    static bool treasureFound = false;
    static int losses = 0;

    static async Task Main(string[] args)
    {
        Random hacked = new();
        if (hacked.Next(0, 100) == 69)
        {
            Console.WriteLine("You got hacked");
            Console.WriteLine("Try again");
            await Task.Delay(int.MaxValue);
        }

        while (true)
        {
            if (!await StartScreen())
            {
                Console.Clear();
                break;
            }

            gamesPlayed++;
            if (await NewGame())
                wins++;
            else losses++;
        }

        Music.Dispose();
    }

    static async Task<bool> StartScreen()
    {
        if (Music.Playing) await Music.FadeOut();

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
        await Music.Play("Low Hum Tunes.mp3");
        bool @continue = true;
        bool finished = false;
        Console.ForegroundColor = ConsoleColor.Gray;
        while (!finished)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string line in title)
            {
                Console.CursorLeft = (Console.WindowWidth - line.Length) / 2;
                Console.WriteLine(line);
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            var choice = await Choose(["1. New game", "2. Stats/Info", "3. Dip"], maxChoice: 3, typing: false);

            switch (choice)
            {
                case 1: finished = true; break;
                case 2: StatsInfoPage(); break;
                case 3: @continue = false; finished = true; break;
            }
        }
        return @continue;
    }

    static async Task LostScreen(string msg)
    {
        await Music.FadeOut();
        Console.Clear();
        await Music.Play("Lost.mp3");
        string[] lostMsg = @"

▓██   ██▓ ▒█████   █    ██     ██▓     ▒█████    ██████ ▄▄▄█████▓
 ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▓██▒    ▒██▒  ██▒▒██    ▒ ▓  ██▒ ▓▒
  ▒██ ██░▒██░  ██▒▓██  ▒██░   ▒██░    ▒██░  ██▒░ ▓██▄   ▒ ▓██░ ▒░
  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ▒██░    ▒██   ██░  ▒   ██▒░ ▓██▓ ░ 
  ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░██████▒░ ████▓▒░▒██████▒▒  ▒██▒ ░ 
   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒    ░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░  ▒ ░░   
 ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░    ░ ░ ▒  ░  ░ ▒ ▒░ ░ ░▒  ░ ░    ░    
 ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░      ░ ░   ░ ░ ░ ▒  ░  ░  ░    ░      
 ░ ░         ░ ░     ░            ░  ░    ░ ░        ░            
 ░ ░                                                             
                                                                                                   
".Trim('\r', '\n').Split(Environment.NewLine);
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (string line in lostMsg)
        {
            Console.CursorLeft = (Console.WindowWidth - line.Length) / 2;
            Console.WriteLine(line);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(msg);
        Console.WriteLine("Press any key to continue");

        Console.ReadKey(true);
        await Music.FadeOut();
    }

    static async Task WinScreen(string msg)
    {
        await Music.FadeOut();
        Console.Clear();
        await Music.Play("Celebration.mp3");
        string[] winMsg = @"

██    ██  ██████  ██    ██     ██     ██  ██████  ███    ██ 
 ██  ██  ██    ██ ██    ██     ██     ██ ██    ██ ████   ██ 
  ████   ██    ██ ██    ██     ██  █  ██ ██    ██ ██ ██  ██ 
   ██    ██    ██ ██    ██     ██ ███ ██ ██    ██ ██  ██ ██ 
   ██     ██████   ██████       ███ ███   ██████  ██   ████ 
                                                                                                                        
".Trim('\r', '\n').Split(Environment.NewLine);
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (string line in winMsg)
        {
            Console.CursorLeft = (Console.WindowWidth - line.Length) / 2;
            Console.WriteLine(line);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(msg);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
        await Music.FadeOut();
    }

    static void StatsInfoPage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Note: Stats reset when you close the software");
        Console.ForegroundColor = ConsoleColor.Green;

        // Info
        Console.WriteLine("Name: Slingshot P.");
        Console.WriteLine("This game does have sound.");

        Console.ForegroundColor = ConsoleColor.Blue;

        // Stats
        Console.WriteLine($"Wins: {wins}");
        Console.WriteLine($"Losses: {losses}");
        Console.WriteLine($"Games played: {gamesPlayed}");
        if (treasureFound) Console.WriteLine("Treasure found: heaps");
        else Console.WriteLine("Treasure found: none");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("Press ESC to go back");
        bool @continue = true;
        while (@continue)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
                @continue = false;
        }
    }

    static async Task<bool> NewGame()
    {
        Console.Clear();

        // Intro
        bool won = false;
        
        Person User = new("You", ConsoleColor.DarkYellow);
        Person jh24 = new("joelheath24", ConsoleColor.Yellow);
        Person Guard = new("Security guard", ConsoleColor.Red);
        await Music.Play("Quirky Dog.mp3");
        await Type("You are travelling through the wilderness—well, you're really just lost.");
        await Type("You see a mysterious hole.");
        await Type("You decide that, after very careful consideration, you should:");
        var choice = await Choose(["1. Jump in the hole", "2. Walk away"], maxChoice: 2);

        if (choice == 1)
        {
            await Hole(User, jh24, won);
        }
        else if (choice == 2)
        {
            await MansionIntro(User, jh24, Guard, won);
        }
        //Console.ReadKey(true);
        //await Music.FadeOut();
        return won;
    }

    static async Task Hole(Person User, Person jh24, bool won)
    {
        Console.Clear();

        await Music.FadeOut();
        await Music.Play("Kool Kats.mp3");
        await Type("You jump in. The fall lasts longer than you expected.");
        await Type("Upon landing in a puddle of water to prevent fall damage, you find two different tunnels, leading to different rooms:");
        await Type("One room looks like a dining room, containing groups of friends or family having a roast dinner");
        await Type("The other room is hidden behind a (likely locked) door with a sign saying 'ESSENTIALS'.");
        await Type("Despite your lack of food or water and how hungry and thirsty you are, you:");
        var choice = await Choose(["1. Find a key to try and unlock the door while going unnoticed",
                                   "2. Socialise and make new friends",
                                   "3. Prank everyone by pulling the fire alarm and sneaking away"], maxChoice: 3);
        switch (choice)
        {
            case 1: await FindTreasure(User, jh24, won); break;
            case 2: await HoleWelcome(User, jh24, won); break;
            case 3: await HoleChase(User, jh24, won); break;
        }
    }

    static async Task FindTreasure(Person User, Person jh24, bool won)
    {
        bool typing = true;
        bool @continue = true;
        while (@continue)
        {
            Console.Clear();
            Random random = new();
            if (typing)
            {
                await Type("Where would you like to search?");
                typing = false;
                await Choose(["1. Behind the painting",
                                   "2. Under the doormat",
                                   "3. In the closet"], maxChoice: 3);
            }
            else
            {
                Console.WriteLine("Where would you like to search?");
                await Choose(["1. Behind the painting",
                                   "2. Under the doormat",
                                   "3. In the closet"], maxChoice: 3, typing: false);
            }
            @continue = await Searching(User, won, random);
        }

    }

    static async Task<bool> Searching(Person User, bool won, Random random)
    {
        Console.Clear();
        bool @continue = true;
        int number = random.Next(0, 3);
        switch (number) 
        {
            case 0: 
                await Type("You find free aura points. You'll take them, but you still don't have what you were looking for.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Aura increased by 300");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Press any key to continue");
                break;
            case 1:
                await Type("You find... A KEY! You unlock the door and find heaps of extremely valuable treasure.");
                await Type("You take all of it and escape before it's too late.");
                treasureFound = true;
                @continue = false;
                won = true;
                await WinScreen("You found heaps of treasure!");
                break;
            case 2:
                await Type("Hmm... There was nothing here. Keep searching!");
                break;
        }
        return @continue;
    }
    static async Task HoleWelcome(Person user, Person jh24, bool won)
    {
        Console.Clear();    
        await Type("They give you a warm welcome and offer you food and drinks, including a nice, warm hot chocolate.");
        await Type("Would you like to:");
        var choice = await Choose(["1. Get a girlfriend",
                                   "2. Talk to the guy who looks lonely, sitting in the corner"], maxChoice: 2);
        switch (choice)
        {
            case 1: await LostScreen("The people think you're a creep and kick you out"); break;
            case 2: won = true; await WinScreen("It was a social experiment. MrBeast appears out of nowhere and gives you $10 000"); break;
        }
    }

    static async Task HoleChase(Person user, Person jh24, bool won)
    {
        await Music.FadeOut();
        Console.Clear();
        await Music.Play("Chase.mp3");
        await jh24.Say("ATTACK!!!!");
        await Type("You were not slick. Everyone starts charging towards you with pitchforks.");
        await Type("You get tackled by The Rock and are taken to a maximum security prison");
        await LostScreen("You are in prison now.");
    }

    static async Task MansionIntro(Person user, Person jh24, Person guard, bool won)
    {
        Console.Clear();

        string longNoMessage = "NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" +
            "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" +
            "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" +
            "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" +
            "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" +
            "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO! :'(";
        await Type("You continue travelling, getting deeper and deeper into unknown territory");
        await Type("All of a sudden, you stumble across a mysterious mansion...");
        await Type("Your best option is to enter and hope for the best, as you are incredibly hungry and exhausted");
        await Music.FadeOut(200);
        await Music.Play("Sad.mp3");
        await guard.Say("Stop right there!");
        await user.Say("Bu-bu-bu-bu-");
        await guard.Say("ARGH! NO 'BUT'S! Just for that, you're getting NO food/water!");
        await user.Say(longNoMessage, speed: 5);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Aura decreased by 10");
        Console.ForegroundColor = ConsoleColor.Gray;
        await Type("After hearing this news, knowing the current situation you are in, you choose to:");
        int choice = await Choose(["1. Run past the security guard, break inside and steal some food and water",
                                   "2. Politely apologise and walk away",
                                   "3. Walk away, and once you've lost his sight, pull the fire alarm as a funny prank then sneak away"], maxChoice: 3);
         switch (choice)
         {
             case 1: await MansionChase(user, jh24, guard, won); break;
             case 2: await MansionWelcome(user, jh24, guard, won); break;
             case 3: await MansionChase(user, jh24, guard, won, alarmPulled: true); break;
         }
    }

    static async Task MansionChase(Person user, Person jh24, Person guard, bool won, bool alarmPulled = false)
    {
        Console.Clear();
        await Music.FadeOut();
        await Music.Play("Chase.mp3");
        if (alarmPulled)
        {
            await Type("You get caught, loser.");
            await Type("They start attacking you, but you can't escape because your hunger bar is too low.");
            await Task.Delay(100);
            await LostScreen("You got shot.");
        } 
        else
        {
            await Type("The people who live in the mansion see how brave you are.");
            await Type("They offer you a place to stay for the night and are willing to help you find your way home in the morning.");
            await Task.Delay(100);
            won = true;
            await WinScreen("You won by being naughty!");
        }

    }

    static async Task MansionWelcome(Person user, Person jh24, Person guard, bool won)
    {
        Console.Clear();
        await Type("The security guard feels bad and lets you back inside.");
        await Type("Inside, you see a group of people having beans on toast.");
        await Type("Would you like to:");
        var choice = await Choose(["1. Ask to join",
                                   "2. Beg for food"], maxChoice: 2);
        switch (choice)
        {
            case 1: won = true; await WinScreen("The people get so excited that they order you some pizza and drinks."); break;
            case 2: await LostScreen("Everyone hates you now. Don't beg for food."); break;
        }
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

    static async Task<int> Choose(IList<string> options, int maxChoice, bool typing = true)
    {
        foreach (string option in options)
        {
            if (typing) await Type(option);
            else Console.WriteLine(option);
        }

        int choice = -1;
        while (choice == -1)
        {
            string input = Console.ReadLine()!;
            if (int.TryParse(input, out int result) && result > 0 && result <= maxChoice)
            {
                choice = result;
            }
            else
            {
                Console.CursorLeft = 0;
                Console.CursorTop--;
                Console.Write(new string(' ', input.Length));
                Console.CursorLeft = 0;
            }
        }
        return choice;
    }
}