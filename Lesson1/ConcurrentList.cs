namespace Lesson1;

public class ConcurrentList<T> : List<T>
{
    public void AddAsync(T item)
    {
        lock (this)
        {
            Add(item);
        }
    }

    public void AddRangeAsync(IEnumerable<T> collection)
    {
        var isLocked = false;

        try
        {
            Monitor.Enter(this, ref isLocked);
            AddRange(collection);
        }
        finally
        {
            if (isLocked)
            {
                Monitor.Exit(this);
            }
        }
    }

    public bool RemoveAsync(T item)
    {
        var isLocked = false;

        try
        {
            Monitor.Enter(this, ref isLocked);
            return Remove(item);
        }
        finally
        {
            if (isLocked)
            {
                Monitor.Exit(this);
            }   
        }
    }
}