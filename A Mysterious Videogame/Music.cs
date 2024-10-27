using ManagedBass;

namespace A_Mysterious_Videogame;

public static class Music
{
    private static readonly MediaPlayer mp = new() { Loop = true };

    public static double Volume { get => mp.Volume; set => mp.Volume = value; }

    public static async Task Play(string filePath, double volume = 1)
    {
        mp.Stop();
        await mp.LoadAsync("Music/" + filePath);
        mp.Volume = volume;
        mp.Play();
    }

    private const int msPerFadeTick = 10;

    public static async Task FadeOut(int milliseconds = 1000)
    {
        await FadeTo(0, milliseconds);
        Pause();
    }

    public static async Task FadeTo(double volume, int milliseconds = 1000)
    {
        var diff = mp.Volume - volume;
        while ((diff > 0) ? (mp.Volume > volume) : (mp.Volume < volume))
        {
            mp.Volume -= diff / milliseconds * msPerFadeTick;
            await Task.Delay(msPerFadeTick);
        }
        mp.Volume = volume;
    }

    public static void Play() => mp.Play();

    public static void Pause() => mp.Pause();

    public static void Restart() => mp.Position = TimeSpan.Zero;

    public static void Dispose() => mp.Dispose();
}