namespace ConsoleApp2;

public class Philosopher
{
    private readonly int _index;
    private readonly List<Fork> _forks;

    public Philosopher(int index, List<Fork> forks)
    {
        _index = index;
        _forks = forks;
    }

    public void Run()
    {
        while (true)
        {
            RunCycle();
        }
    }

    private void RunCycle()
    {
        Thread.Sleep(new Random().Next() % 100);

        var leftFork = GetLeft();
        Console.WriteLine($"Filozof {_index + 1} czeka na lewy widelec {leftFork.GetIndex() + 1}");
        lock (leftFork)
        {
            Console.WriteLine($"Filozof {_index + 1} wziął lewy widelec {leftFork.GetIndex() + 1}");
            var rightFork = GetRight();
            Console.WriteLine($"Filozof {_index + 1} czeka na prawy widelec {rightFork.GetIndex() + 1}");
            lock (rightFork)
            {
                Console.WriteLine($"Filozof {_index + 1} zaczął jeść ({leftFork.GetIndex() + 1} i {rightFork.GetIndex() + 1})");
                Thread.Sleep(new Random().Next() % 100);
                Console.WriteLine($"Filozof {_index + 1} skończył jeść ({leftFork.GetIndex() + 1} i {rightFork.GetIndex() + 1})");
            }
        }
    }

    private Fork GetLeft()
    {
        return _forks[_index];
    }

    private Fork GetRight()
    {
        return _index == 4 ? _forks.First() : _forks[_index + 1];
    }
}
