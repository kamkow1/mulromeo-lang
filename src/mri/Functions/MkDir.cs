namespace mri.Functions;

public static class MkDir
{
    public static object? Invoke(object?[] args)
    {
        Directory.CreateDirectory(args[0] as string ?? throw new InvalidOperationException());
        return null;
    }
}