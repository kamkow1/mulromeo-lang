using System.Net;
using Newtonsoft.Json;

namespace mri.Functions;

public class Get : IFunction
{
    public static object? Invoke(object?[] args)
    {
        using var client = new WebClient();
        var file = client.DownloadData((args[0] as string)!/*JsonConvert.SerializeObject(args[0])
            .Replace("[", "")
            .Replace("]", "")
            .Replace("\"", "")*/
        );
        return file;
    }
}