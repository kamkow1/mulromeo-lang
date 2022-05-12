using Newtonsoft.Json;

namespace mri;

public class AstNodeVisitor : ParserDefinitionBaseVisitor<object?>
{
    private readonly Dictionary<string, object?> _variables = new();

    public override object? VisitVar_assign(ParserDefinition.Var_assignContext context)
    {
        var name = context.IDENTIFIER().GetText();
        var value = Visit(context.expression());

        if (_variables.ContainsKey(name))
            _variables.Add(name, value);
        else
            _variables[name] = value;
        return null;
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
}