using System.Linq.Expressions;
using ExpressionTrees.DynamicSearch.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpressionTrees.DynamicSearch.API.Controller;

[ApiController, Route("api/[controller]")]
public class EmployeeController(ApplicationDbContext context) : ControllerBase
{
    private ApplicationDbContext Context { get; } = context;

    [HttpGet("search")]
    public async Task<IActionResult> SearchEmployees([FromQuery] Dictionary<string, string> filters)
    {
        var query = Context.Employees.AsQueryable();

        // Build the dynamic query using filters
        var result = await ApplyFilters(query, filters).ToListAsync();

        return Ok(result);
    }

    private IQueryable<Employee> ApplyFilters(IQueryable<Employee> query, Dictionary<string, string> filters)
    {
        foreach (var filter in filters)
            query = ApplyFilter(query, filter.Key, filter.Value);

        return query;
    }

    // This method applies a single filter dynamically
    private static IQueryable<Employee> ApplyFilter(IQueryable<Employee> query, string propertyName, string filterValue)
    {
        // Split the filter (e.g. "Age > 25")
        var parts = filterValue.Split(' ');
        if (parts.Length != 2) throw new ArgumentException("Invalid filter format.");

        string comparisonOperator = parts[0];
        var value = parts[1];

        // Build the dynamic expression tree for this filter
        var parameter = Expression.Parameter(typeof(Employee), "emp");
        var property = Expression.Property(parameter, propertyName);
        var constant = Expression.Constant(Convert.ChangeType(value, property.Type));

        // Map the operator to the appropriate Expression Tree operation
        Expression body = comparisonOperator switch
        {
            ">" => Expression.GreaterThan(property, constant),
            "<" => Expression.LessThan(property, constant),
            ">=" => Expression.GreaterThanOrEqual(property, constant),
            "<=" => Expression.LessThanOrEqual(property, constant),
            "=" => Expression.Equal(property, constant),
            _ => throw new ArgumentException($"Unsupported operator: {comparisonOperator}")
        };

        var lambda = Expression.Lambda<Func<Employee, bool>>(body, parameter);

        // Apply the expression to the IQueryable
        return query.Where(lambda);
    }
}