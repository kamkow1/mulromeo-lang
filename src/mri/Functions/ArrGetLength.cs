using Newtonsoft.Json;

namespace mri.Functions;

public class ArrGetLength : IFunction
{
    public static object? Invoke(object?[] args, Dictionary<string, object?> variables) 
        => (variables[(args[0] as string)!] as Array)!.Length;
}