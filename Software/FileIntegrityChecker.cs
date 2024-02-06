using System.Text;
using Newtonsoft.Json.Linq;

namespace FileIntegrityChecker
{
    class Program

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу описания:");
            string filePath = Console.ReadLine();

            try
            {
                // Чтение файла
                string jsonString = File.ReadAllText(filePath, Encoding.UTF8);

                // Проверка целостности файла
                JToken.Parse(jsonString);

                // Проверка наличия ссылок на удаленные элементы
                CheckReferenses(jsonString);

                Console.WriteLine("Проверка файла успешно завершена. Файл целостный.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при загрузке файла :");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        static void CheckReferences(string jsonString)
        {
            JObject jsonObject = JObject.Parse(jsonString);

            // Проверка каждого элемента на наличие ссылок на удаленные элементы
            foreach (var property in jsonObject.Properties())
            {
                JToken value = property.Value;

                if (value.Type == JTokenType.Object)
                {
                    // Рекурсивная проверка подобъектов
                    CheckReferenses(value.ToString());
                }
                else if (value.Type == JTokenType.String)
                {
                    // Проверка наличия ссылки на удаленный элемент
                    string reference = value.ToString();
                    if (!jsonObject.ContainsKey(reference))
                    {
                        Console.WriteLine($"Ошибочная ссылка на элемент: {reference}");
                    }
                }
            }
        }

        private static void CheckReferenses(string v)
        {
            throw new NotImplementedException();
        }
    }
}


