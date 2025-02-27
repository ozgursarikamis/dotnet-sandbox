using System.ComponentModel.DataAnnotations;

namespace ExpressionTrees.DynamicSearch.API.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}