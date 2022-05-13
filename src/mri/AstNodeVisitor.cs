﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using mri.HtmlGenerators;
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
    private readonly IndexCreator _indexCreator = new();

    public AstNodeVisitor()
    {
        _variables["get_img"]   = new Func<object?[], object?>(GetImg);
        _variables["print"]     = new Func<object?[], object?>(Print);
        _variables["save"]      = new Func<object?[], object?>(Save);
        _variables["mkdir"]     = new Func<object?[], object?>(MkDir);
        _variables["mkindex"]   = new Func<object?[], object?>(MkIndex);
    }

    private object? MkIndex(object?[] args)
    {
        var path = args[0] as string + "/index.html";
        var index = _indexCreator.Make();
        File.WriteAllText(path, index);
        return null;
    }

    private object? MkDir(object?[] args)
    {
        Directory.CreateDirectory(args[0] as string);
        return null;
    }

    private object? Save(object?[] args)
    {
        var path = args[0] as string;
        var content = args[1] as byte[];

        File.WriteAllBytes(path, content);
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

    public override object? VisitBlock(ParserDefinition.BlockContext context)
    {
        foreach (var statement in context.statement())
            Visit(statement);

        return null;
    }

    public override object? VisitRange_loop(ParserDefinition.Range_loopContext context)
    {
        var left = Visit(context.expression(0))       as int?;
        var right = Visit(context.expression(1))      as int?;
        var iter = context.IDENTIFIER().GetText();
        Console.WriteLine(iter);

        if (left is null || right is null)
            throw new Exception("loop expressions cannot be null");
        
        _variables.Add(iter, 0);

        var count = right - left;

        for (var i = 0; i < count; i++)
        {
            _variables[iter] = (int)_variables[iter] + 1;
            Visit(context.block());
        }
            

        return null;
    }

    public override object? VisitReference(ParserDefinition.ReferenceContext context)
    {
        if (_variables.TryGetValue(context.IDENTIFIER().GetText(), out var result))
            return result;
        throw new Exception($"{context.IDENTIFIER().GetText()} does not exist");
    }

    public override object? VisitHtml_output_type(ParserDefinition.Html_output_typeContext context)
    {
        if (context.AUDIO() is { } audio)
            return audio.GetText();
        
        if (context.VIDEO() is { } video)
            return video.GetText();

        if (context.IMAGE() is { } image)
            return image.GetText();

        throw new Exception($"unknown type");
    }

    public override object? VisitAdd_element(ParserDefinition.Add_elementContext context)
    {
        var type = Visit(context.html_output_type()) as string;
        var src = Visit(context.expression()) as string;

        switch (type)
        {
            case "image":
            {
                _indexCreator.AddImgElement(src);
                return null;
            }
            default: throw new Exception("unimplemented");
        }
    }
}