using CodingAssignmentLib.Abstractions;
using System.Xml;


namespace CodingAssignmentLib;

public class XmlContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        var output = new List<Data>();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(content);

        XmlNodeList dataNodes = doc.SelectNodes("/Datas/Data");

        foreach (XmlNode dataNode in dataNodes)
        {
            string key = dataNode.SelectSingleNode("Key").InnerText;
            string value = dataNode.SelectSingleNode("Value").InnerText;
            output.Add(new Data(key, value));
        }
        return output;
    }
}