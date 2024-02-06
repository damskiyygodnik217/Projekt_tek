using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

class Program
{
    static void Second (string[] args)
    {
        string jsonString = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";
        JObject json = JObject.Parse(jsonString);

        PrintJsonTree(json, 0); // Начинаем выводить дерево JSON

        Console.ReadKey();
    }

    static void PrintJsonTree(JToken token, int indentLevel)
    {
        if (token is JObject obj)
        {
            foreach (var property in obj.Properties())
            {
                PrintIndent(indentLevel);
                Console.WriteLine(property.Name);
                PrintJsonTree(property.Value, indentLevel + 1);
            }
        }
        else if (token is JArray arr)
        {
            foreach (var item in arr)
            {
                PrintJsonTree(item, indentLevel);
            }
        }
        else
        {
            PrintIndent(indentLevel);
            Console.WriteLine(token);
        }
    }

    static void PrintIndent(int indentLevel)
    {
        for (int i = 0; i < indentLevel; i++)
        {
            Console.Write("  "); // Два пробела на каждый уровень в дереве
        }
    }
}