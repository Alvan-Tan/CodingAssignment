// See https://aka.ms/new-console-template for more information

using System.IO.Abstractions;
using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

Console.WriteLine("Coding Assignment!");

do
{
    Console.WriteLine("\n---------------------------------------\n");
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\t1 - Display");
    Console.WriteLine("\t2 - Search");
    Console.WriteLine("\t3 - Exit");

    switch (Console.ReadLine())
    {
        case "1":
            Display();
            break;
        case "2":
            Search();
            break;
        case "3":
            return;
        default:
            return;
    }
} while (true);


void Display()
{
    Console.WriteLine("Enter the name of the file to display its content:");

    var fileName = Console.ReadLine()!;
    var fileUtility = new FileUtility(new FileSystem());
    IContentParser parser = null!;
    var dataList = Enumerable.Empty<Data>();
    if (fileUtility.GetExtension(fileName) == ".csv")
    {
        parser = new CsvContentParser();
    }
    else if (fileUtility.GetExtension(fileName) == ".json")
    {
        parser = new JsonContentParser();
    }
    else if (fileUtility.GetExtension(fileName) == ".xml")
    {
        parser = new XmlContentParser();
    }
    if (parser != null)
    {
        dataList = parser.Parse(fileUtility.GetContent(fileName));
    }


    Console.WriteLine("Data:");

    foreach (var data in dataList)
    {
        Console.WriteLine($"Key:{data.Key} Value:{data.Value}");
    }
}

void Search()
{
    Console.WriteLine("Enter the key to search.");
    var seen = false;

    var key = Console.ReadLine()!;

    if (key is null)
    {
        Console.WriteLine("Invalid input!");
        return;
    }

    key = key.ToLower();
    var fileUtility = new FileUtility(new FileSystem());

    CsvContentParser csvParser = new CsvContentParser();
    var csvDataList = Enumerable.Empty<Data>();
    csvDataList = csvParser.Parse(fileUtility.GetContent("data/data.csv"));
    foreach (Data data in csvDataList)
    {
        if (data.Key.ToLower() == key)
        {
            Console.WriteLine($"Key:{key} Value:{data.Value} FileName:data\\data.csv");
            seen = true;
        }
    }

    JsonContentParser jsonParser = new JsonContentParser();
    var jsonDataList = Enumerable.Empty<Data>();
    jsonDataList = jsonParser.Parse(fileUtility.GetContent("data/data.json"));
    foreach (Data data in jsonDataList)
    {
        if (data.Key.ToLower() == key)
        {
            Console.WriteLine($"Key:{key} Value:{data.Value} FileName:data\\data.json");
            seen = true;
        }
    }

    XmlContentParser xmlParser = new XmlContentParser();
    var xmlDataList = Enumerable.Empty<Data>();
    xmlDataList = xmlParser.Parse(fileUtility.GetContent("data/data.xml"));
    foreach (Data data in xmlDataList)
    {
        if (data.Key.ToLower() == key)
        {
            Console.WriteLine($"Key:{key} Value:{data.Value} FileName:data\\data.xml");
            seen = true;
        }
    }

    if (!seen)
    {
        Console.WriteLine("Key does not exists in any files, try again.");
    }
}