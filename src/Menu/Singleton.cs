namespace sandwichshop.Menu;

public class Singleton<T> where T : new()
{
    private static T _instance;
    private static readonly object _lock = new();
    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
            }

            return _instance;
        }
    }
}