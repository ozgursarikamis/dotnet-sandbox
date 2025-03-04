namespace Generics;

public static class GenericConstrains
{
    public static void Run()
    {
        BasicConstraints();
    }

    private static void BasicConstraints()
    {
        var userRepo = new EntityRepository<User>();
        userRepo.Add(new User{ Id = 1, Name = "John" });
    }
}


interface IEntity
{
    int Id { get; }
}

// where T : IEntity ensures T must implement IEntity.
class EntityRepository<T> where T : IEntity
{
    private List<T> _items = new();
    public void Add(T entity) => _items.Add(entity);
    public T GetById(int id) => _items.FirstOrDefault(x => x.Id == id);
}

class User : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}