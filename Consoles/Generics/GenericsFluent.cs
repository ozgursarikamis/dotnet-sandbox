namespace Generics;

public static class GenericsFluent
{
    public static void Run()
    {
        var query = new QueryBuilder<User>()
            .Select("*")
            .From("Users")
            .Where("Age > 18")
            .Build();

        Console.WriteLine(query);
    }
}

public class QueryBuilder<T>
{
    private string _query = "";

    public QueryBuilder<T> Select(string columns)
    {
        _query += $"SELECT {columns}";
        return this; // Enables method chaining
    }

    public QueryBuilder<T> From(string table)
    {
        _query += $" FROM {table} ";
        return this;
    }

    public QueryBuilder<T> Where(string condition)
    {
        _query += $"WHERE {condition} ";
        return this;
    }

    public string Build()
    {
        return _query;
    }
}