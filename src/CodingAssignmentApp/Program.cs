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

    var key = Console.ReadLine()!;
}