using System.Net;
using Newtonsoft.Json;

namespace mri.Functions;

public static class Get
{
    public static object? Invoke(object? url)
    {
        using var client = new WebClient();
        var file = client.DownloadData(JsonConvert.SerializeObject(url)
            .Replace("[", "")
            .Replace("]", "")
            .Replace("\"", "")
        );
        return file;
    }
}