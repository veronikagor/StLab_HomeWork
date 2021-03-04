using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using PhoneShop.Entities;

namespace PhoneShop.Utils
{
    public static class FileReader
    {
        public static PhoneShops ReadTheFile(string fileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = $"{basePath}{Path.DirectorySeparatorChar}{fileName}";

            PhoneShops phoneShops;

            if (File.Exists(fullPathToFile))
            {
                var jsonAsString = File.ReadAllText(fileName);

                try
                {
                    phoneShops = JsonConvert.DeserializeObject<PhoneShops>(jsonAsString);
                }
                catch (JsonReaderException ex)
                {
                    throw new JsonReaderException($"Can't read the file: {fileName}\n" + ex);
                }
            }
            else
            {
                throw new FileNotFoundException($"Your file name is not correct or not exist: {fileName}");
            }

            return phoneShops;
        }
    }
}