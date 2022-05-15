using Newtonsoft.Json;

namespace mri.Functions;

public class Print : IFunction
{
    public static object? Invoke(object?[] args, Dictionary<string, object?> variables)
    {
        foreach (var arg in args)
        {
            Console.WriteLine(variables.ContainsKey(arg as string ?? "")
                ? JsonConvert.SerializeObject(variables[(arg as string)!], Formatting.Indented)
                : JsonConvert.SerializeObject(arg, Formatting.Indented));
        }
            
        return null;
    }
}