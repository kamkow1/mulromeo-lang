namespace mri.Functions;

public class MkDir : IFunction
{
    public static object? Invoke(object?[] args)
    {
        Directory.CreateDirectory(args[0] as string ?? throw new InvalidOperationException());
        return null;
    }
}