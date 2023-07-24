public class Singleton<T> where T : Singleton<T>, new()
{
    private static T instance = null;

    private protected Singleton()
    {
    }

    protected virtual void Initialize()
    {
    }

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
                instance.Initialize();
            }
            return instance;
        }
    }
}