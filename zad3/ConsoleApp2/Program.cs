using ConsoleApp2;

var forks = new List<Fork>();
for (var i = 0; i < 5; i++)
{
    forks.Add(new Fork(i));
}

var philosophers = new List<Philosopher>();
for (var i = 0; i < 5; i++)
{
    philosophers.Add(new Philosopher(i, forks));
}

foreach (var philosopher in philosophers)
{
    var t = new Thread(() => philosopher.Run());
    t.Start();
}
