using System.Net;

namespace mri.Functions;

public class Get : IFunction
{
    public static object? Invoke(object?[] args)
    {
        using var client = new WebClient();
        var target = args[0] as string;
        var format = args[2] as string;
        var type = args[1] as string;
        var address = $"https://mult-dl-api.azurewebsites.net/api/{type}?target={target}&format={format}";
        Console.WriteLine(address);
        var file = client.DownloadData(address);
        return file;
    }
}