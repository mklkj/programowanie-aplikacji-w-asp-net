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

        var startBarrier = new Barrier(_horses.Count, (b) =>
        {
            Console.WriteLine("START !!!!");
            startTime = DateTime.Now.Ticks;
        });
        var endBarrier = new Barrier(_horses.Count, (b) =>
        {
            Console.WriteLine("END !!!");
            printFinalResults();
        });
        foreach (var hin in _horses)
        {
            var t = new Thread(() => hin.DoRace(this, startBarrier, endBarrier));
            t.Start();
        }
    }

    public void HorseFinished(Horse horse)
    {
        // var raceTime = horse.finishTime - startTime;
        // Console.WriteLine($"Horse {horse.ID} finished Race in {raceTime} tics");
    }

    private void printFinalResults()
    {
        _horses.Sort((h1, h2) => (int)(h1.finishTime - h2.finishTime));
        var i = 0;
        foreach (var horse in _horses)
        {
            Console.WriteLine($"Place {++i} Horse {horse.ID} finished Race in {horse.finishTime - startTime}");
        }
    }
}
