namespace ConsoleApp1;

public class Race
{
    public const float Distance = 1000;
    private List<Horse> horses = new();

    public void SetUpRace()
    {
        var rand = new Random();
        for (var i = 0; i < 5; i++)
        {
            horses.Add(new Horse((float)(rand.NextDouble() * 50 + 1)));
        }

        foreach (var hin in horses)
        {
            var t = new Thread(() => hin.DoRace(this));
            t.Start();
        }
    }

    public void HorseFinished(Horse horse)
    {
        Console.WriteLine($"Horse {horse.ID} finished Race");
    }
}
