namespace ConsoleApp2;

public class Fork
{
    private readonly int _index;

    public Fork(int index)
    {
        _index = index;
    }

    public int GetIndex()
    {
        return _index;
    }
}
