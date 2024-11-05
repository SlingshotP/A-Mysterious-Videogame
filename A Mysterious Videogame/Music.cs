using ManagedBass;

namespace A_Mysterious_Videogame;

public static class Music
{
    private static readonly MediaPlayer mp = new() { Loop = true };

    public static bool Playing { get; private set; } = false;

    public static double Volume { get => mp.Volume; set => mp.Volume = value; }

    public static async Task Play(string filePath, double volume = 1)
    {
        mp.Stop();
        await mp.LoadAsync("Music/" + filePath);
        mp.Volume = volume;
        mp.Play();
        Playing = true;
    }

    private const int msPerFadeTick = 10;

    public static async Task FadeOut(int milliseconds = 1000)
    {
        await FadeTo(0, milliseconds);
        Pause();
    }

    public static async Task FadeTo(double volume, int milliseconds = 1000)
    {
        if (!Playing) return;

        var totalVolumeChange = (mp.Volume - volume) * msPerFadeTick;
        var volChangePerTick = totalVolumeChange / milliseconds;
        var loops = milliseconds / msPerFadeTick;
        for (int i = 0; i < loops; i++)
        {
            mp.Volume -= volChangePerTick;
            await Task.Delay(msPerFadeTick);
        }
        mp.Volume = volume;
    }

    public static void Play()
    {
        mp.Play();
        Playing = true;
    }

    public static void Pause()
    {
        mp.Pause();
        Playing = false;
    }

    public static void Restart() => mp.Position = TimeSpan.Zero;

    public static void Dispose() => mp.Dispose();
}