namespace mri.Functions;

public class MkHtml : IFunction
{
    public static object? Invoke(object?[] args, HtmlCreator htmlCreator)
    {
        var path = args[0] as string + $"/{args[1] as string}.html";
        var index = htmlCreator.Make();
        File.WriteAllText(path, index);
        return null;
    }
}