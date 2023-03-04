namespace ConsoleApp1;

public class Horse
{
    public int ID { get; private set; }
    private readonly float _speed;
    private static int lastId = 0;

    public Horse(float speed)
    {
        ID = lastId++;
        _speed = speed;
    }

    public void DoRace(Race race, Barrier barrier)
    {
        Console.WriteLine($"Approaching start line {ID}");
        var distance = 0.0f;
        barrier.SignalAndWait();
        while (distance < Race.Distance)
        {
            distance += _speed;
        }

        race.HorseFinished(this);
        Console.WriteLine($"Horse {ID} ended Race");
    }
}
