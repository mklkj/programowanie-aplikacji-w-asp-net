namespace ConsoleApp1;

public class Race
{
    public const float Distance = 1000;
    private readonly List<Horse> _horses = new();
    private long startTime;

    public void SetUpRace()
    {
        var rand = new Random();
        for (var i = 0; i < 5; i++)
        {
            _horses.Add(new Horse((float)(rand.NextDouble() * 50 + 1)));
        }

        var barrier = new Barrier(_horses.Count, (b) =>
        {
            Console.WriteLine("START !!!!");
            startTime = DateTime.Now.Ticks;
        });
        foreach (var hin in _horses)
        {
            var t = new Thread(() => hin.DoRace(this, barrier));
            t.Start();
        }
    }

    public void HorseFinished(Horse horse)
    {
        var raceTime = DateTime.Now.Ticks - startTime;
        Console.WriteLine($"Horse {horse.ID} finished Race in {raceTime} tics");
    }
}
