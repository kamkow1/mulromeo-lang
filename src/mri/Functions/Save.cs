namespace mri.Functions;

public class Save : IFunction
{
    public static object? Invoke(object?[] args)
    {
        var path = args[0] as string;
        var content = args[1] as byte[];

        File.WriteAllBytes(
            path ?? throw new InvalidOperationException(), 
            content ?? throw new InvalidOperationException());
        return null;
    }
}