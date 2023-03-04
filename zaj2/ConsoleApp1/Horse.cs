namespace ConsoleApp1;

public class Horse
{
    public int ID { get; private set; }
    private readonly float _speed;
    private static int lastId = 0;
    public long finishTime { get; private set; }

    public Horse(float speed)
    {
        ID = lastId++;
        _speed = speed;
    }

    public void DoRace(Race race, Barrier startBarrier, Barrier endBarrier)
    {
        Console.WriteLine($"Approaching start line {ID}");
        var distance = 0.0f;
        startBarrier.SignalAndWait();
        while (distance < Race.Distance)
        {
            distance += _speed;
        }

        finishTime = DateTime.Now.Ticks;
        endBarrier.SignalAndWait();
        race.HorseFinished(this);
        // Console.WriteLine($"Horse {ID} ended Race");
    }
}
