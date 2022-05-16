namespace mri.Functions;

public class ClearAssets
{
    public static object? Invoke(string path)
    {
        Directory.Delete(path, true);
        return null;
    }
}