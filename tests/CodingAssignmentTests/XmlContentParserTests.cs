using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentTests;

public class XmlContentParserTests
{
    private XmlContentParser _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new XmlContentParser();
    }

    [Test]
    public void Parse_ReturnsData()
    {


        var content = @"<Datas>
                            <Data>
                                <Key>a</Key>
                                <Value>b</Value>
                            </Data>
                            <Data>
                                <Key>c</Key>
                                <Value>d</Value>
                            </Data>
                        </Datas>";
        var dataList = _sut.Parse(content).ToList();
        CollectionAssert.AreEqual(new List<Data>
        {
            new("a", "b"),
            new("c", "d")
        }, dataList);
    }
}