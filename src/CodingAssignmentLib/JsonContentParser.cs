using CodingAssignmentLib.Abstractions;
using System.Text.Json;


namespace CodingAssignmentLib;

public class JsonContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        var output = new List<Data>();
        List<KeyValuePair<string, string>> array = JsonSerializer.Deserialize<List<KeyValuePair<string, string>>>(content);

        foreach (var o in array)
        {
            string key = o.Key.ToString();
            string value = o.Value.ToString();
            output.Add(new Data(key, value));
        }
        return output;
    }
}