namespace CroakGames
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance = null;

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
                if (_instance == null)
                {
                    _instance = new T();
                    _instance.Initialize();
                }
                return _instance;
            }
        }
    }
}