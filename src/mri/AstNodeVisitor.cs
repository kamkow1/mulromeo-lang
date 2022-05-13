using System.Net;
using Newtonsoft.Json;

namespace mri;

/*
 * build-in functions   : 21
 * var_assign           : 54
 * func_invoke          : 67
 * math expressions     : 81-162
 * constant             : 165
* identifier            : 179
 */

public class AstNodeVisitor : ParserDefinitionBaseVisitor<object?>
{
    private readonly Dictionary<string, object?> _variables = new();

    public AstNodeVisitor()
    {
        _variables["get_img"]   = new Func<object?[], object?>(GetImg);
        _variables["print"]     = new Func<object?[], object?>(Print);
        _variables["save"] = new Func<object?[], object?>(Save);
    }

    private object? Save(object?[] data)
    {
        var path = data[0];
        var content = _variables[data[1] as string];
        
        File.WriteAllBytes(path as string, content as byte[]);
        return null;
    }

    private object? Print(object?[] inputs)
    {
        foreach (var input  in inputs)
        {
            Console.WriteLine(_variables.ContainsKey(input as string)
                ? JsonConvert.SerializeObject(_variables[input as string], Formatting.Indented)
                : JsonConvert.SerializeObject(input, Formatting.Indented));
        }
            
        return null;
    }

    private object? GetImg(object? url)
    {
        using var client = new WebClient();
        var file = client.DownloadData(JsonConvert.SerializeObject(url)
                                                    .Replace("[", "")
                                                    .Replace("]", "")
                                                    .Replace("\"", "")
        );
        return file;
    }

    public override object? VisitVar_assign(ParserDefinition.Var_assignContext context)
    {
        var name = context.IDENTIFIER().GetText();
        var value = Visit(context.expression());

        if (!_variables.ContainsKey(name))
            _variables.Add(name, value);
        else
            _variables[name] = value;
        return null;
    }

    public override object? VisitFunc_invoke(ParserDefinition.Func_invokeContext context)
    {
        var name = context.IDENTIFIER().GetText();
        var args = context.expression().Select(Visit).ToArray();

        if (!_variables.ContainsKey(name))
            throw new Exception($"{name} is not defined");

        var func = (Func<dynamic[], dynamic>)_variables[name]!;
        
        return func(args);
    }

    public override object? VisitAddExpression(ParserDefinition.AddExpressionContext context)
    {
        var leftExpr = Visit(context.expression(0));
        var rightExpr = Visit(context.expression(1));
        
        if (leftExpr.GetType() == typeof(string) || rightExpr.GetType() == typeof(string))
            return $"{leftExpr}{rightExpr}";

        if ((leftExpr is int || rightExpr is int) ||
            (leftExpr is float || rightExpr is int) ||
            (leftExpr is int || rightExpr is float) ||
            (leftExpr is float || rightExpr is float))
            return double.Parse(leftExpr.ToString()!) + double.Parse(rightExpr.ToString()!);

        throw new Exception($"cannot add type {leftExpr?.GetType()} and {rightExpr?.GetType()}");
    }

    public override object? VisitSubExpression(ParserDefinition.SubExpressionContext context)
    {
        var leftExpr = Visit(context.expression(0));
        var rightExpr = Visit(context.expression(1));
        
        if (leftExpr.GetType() == typeof(string) || rightExpr.GetType() == typeof(string))
            return $"{leftExpr.ToString().Replace(rightExpr.ToString(), string.Empty)}";

        if ((leftExpr is int || rightExpr is int) ||
            (leftExpr is float || rightExpr is int) ||
            (leftExpr is int || rightExpr is float) ||
            (leftExpr is float || rightExpr is float))
            return double.Parse(leftExpr.ToString()!) - double.Parse(rightExpr.ToString()!);

        throw new Exception($"cannot subtract type {leftExpr?.GetType()} and {rightExpr?.GetType()}");
    }

    public override object? VisitMulExpression(ParserDefinition.MulExpressionContext context)
    {
        var leftExpr = Visit(context.expression(0));
        var rightExpr = Visit(context.expression(1));

        if (leftExpr.GetType() == typeof(string) && rightExpr.GetType() == typeof(string))
        {
            var intersectingElements = leftExpr.ToString().Intersect(rightExpr.ToString());
            return string.Concat(intersectingElements.Where(c => intersectingElements.Contains(c)));
        }

        if (leftExpr.GetType() == typeof(string) || rightExpr.GetType() == typeof(int))
        {
            var buffer = string.Empty;
            for (var i = 0; i < int.Parse(rightExpr.ToString()); i++)
                buffer += leftExpr;

            return buffer;
        }

        if ((leftExpr is int || rightExpr is int) ||
            (leftExpr is float || rightExpr is int) ||
            (leftExpr is int || rightExpr is float) ||
            (leftExpr is float || rightExpr is float))
            return double.Parse(leftExpr.ToString()!) * double.Parse(rightExpr.ToString()!);

        throw new Exception($"cannot multiply type {leftExpr?.GetType()} and {rightExpr?.GetType()}");
    }

    public override object? VisitDivExpression(ParserDefinition.DivExpressionContext context)
    {
        var leftExpr = Visit(context.expression(0));
        var rightExpr = Visit(context.expression(1));

        if (leftExpr.GetType() == typeof(string) && rightExpr.GetType() == typeof(string))
        {
            var difference = leftExpr.ToString().Except(rightExpr.ToString());
            return string.Concat(difference.Where(c => difference.Contains(c)));
        }

        if ((leftExpr is int || rightExpr is int) ||
            (leftExpr is float || rightExpr is int) ||
            (leftExpr is int || rightExpr is float) ||
            (leftExpr is float || rightExpr is float))
            return float.Parse(leftExpr.ToString()!) / float.Parse(rightExpr.ToString()!);

        throw new Exception($"cannot divide type {leftExpr?.GetType()} and {rightExpr?.GetType()}");
    }

    public override object? VisitConstant(ParserDefinition.ConstantContext context)
    {
        if (context.INT_VAL() is { } integerVal)
            return int.Parse(integerVal.GetText());
        
        if (context.FLT_VAL() is { } floatVal)
            return float.Parse(floatVal.GetText());

        if (context.STR_VAL() is { } stringVal)
            return stringVal.GetText()[1..^1];
        
        return new NotImplementedException("unknown value type");
    }

    public override object? VisitIdentifierExpression(ParserDefinition.IdentifierExpressionContext context)
    {
        return context.IDENTIFIER().GetText();
    }
}