using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;
using Newtonsoft.Json;

namespace CodingAssignmentTests;

public class JsonContentParserTests
{
    private JsonContentParser _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new JsonContentParser();
    }

    [Test]
    public void Parse_ReturnsData()
    {
        List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>> {
            new KeyValuePair<string, string>("a", "b"),
            new KeyValuePair<string, string>("c", "d")
        };
        
        var content = JsonConvert.SerializeObject(data);
        var dataList = _sut.Parse(content).ToList();
        CollectionAssert.AreEqual(new List<Data>
        {
            new("a", "b"),
            new("c", "d")
        }, dataList);
    }
}