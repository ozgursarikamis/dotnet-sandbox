using System.Linq.Expressions;

namespace ExpressionTrees;

public class ModifyingExpressionTreeDynamically
{
    public static void Run()
    {
        // Define an ET:
        Expression<Func<Employee, bool>> expr = emp => emp.Age > 30;
        
        // Now, let’s replace the hardcoded 30 with a dynamic value (e.g., minAge):
        const int minAge = 40; // dynamic value

        var modifiedExpression = ModifyExpression(expr, minAge);
        
        // Compile and execute
        var compiledFunc = modifiedExpression.Compile();
        Console.WriteLine("Does an employee aged 45 pass? " + compiledFunc(new Employee { Age = 45 }));
        Console.WriteLine("Does an employee aged 35 pass? " + compiledFunc(new Employee { Age = 35 }));
    }

    private static Expression<Func<Employee, bool>> ModifyExpression(Expression<Func<Employee,bool>> expr, int newValue)
    {
        var parameter = expr.Parameters[0];
        var property = Expression.Property(parameter, "Age");
        var constant = Expression.Constant(newValue);
        var newBody = Expression.GreaterThan(property, constant);

        return Expression.Lambda<Func<Employee, bool>>(newBody, parameter);
    }
}

class Employee
{
    public int Age { get; set; }
}