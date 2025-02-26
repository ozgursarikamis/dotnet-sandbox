using System.Linq.Expressions;

namespace ExpressionTrees;

public static class Definition
{
    public static void Run()
    {
        // f(x) = x * x + 2;

// Define the parameter x
        ParameterExpression x = Expression.Parameter(typeof(int), "x");

// Define x * x (multiplication)
        BinaryExpression multiply = Expression.Multiply(x, x);

// Define + 2 addition
        ConstantExpression plusTwo = Expression.Constant(2, typeof(int));
        BinaryExpression add = Expression.Add(multiply, plusTwo);

// Create the lambda expression x => x * x + 2
        Expression<Func<int, int>> addExpression = Expression.Lambda<Func<int, int>>(add, x);

// Print the expression tree:

        Console.WriteLine($"Expression Tree: {addExpression}");
        Console.WriteLine($"Body: {addExpression.Body}");
        Console.WriteLine($"Parameters: {addExpression.Parameters[0]}");

        var compiledFunction = addExpression.Compile();
        Console.WriteLine($"Compiled Function: {compiledFunction(3)}");
    }
}