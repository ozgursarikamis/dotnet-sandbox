namespace Events_Delegates_Action_Func;

public static class AdvancedUseCasesDependencyInjection
{

    public static void Run()
    {
        Func<DatabaseService> dbFactory = () => new DatabaseService();
        DatabaseManager manager = new DatabaseManager(dbFactory);
        
        manager.LoadData();
        
        // 2nd call reuses the existing instance:
        manager.LoadData();
    }
}

class DatabaseService
{
    public DatabaseService()
    {
        Console.WriteLine("DatabaseService is created.");
    }

    public void FetchData()
    {
        Console.WriteLine("Fetching data from the database...");
    }
}

class DatabaseManager
{
    private readonly Func<DatabaseService> _databaseServiceFactory;
    private DatabaseService _databaseService;

    public DatabaseManager(Func<DatabaseService> databaseServiceFactory)
    {
        _databaseServiceFactory = databaseServiceFactory;
    }

    public void LoadData()
    {
        if (_databaseService == null)
        {
            Console.WriteLine("Creating DatabaseService instance...");
            _databaseService = _databaseServiceFactory();
        }
        
        _databaseService.FetchData();
    }
}