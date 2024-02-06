using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class CsvContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        var output = new List<Data>();

        var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines) {
            var items = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            output.Add(new Data(items[0], items[1]));
        }
        return output;
    }
}