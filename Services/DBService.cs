using BotBustorDB.Models;
using System.Reflection;
using System.Text.Json;

namespace BotBustorDB.Services
{
    public static class DBService
    {
        private const string DBSubFolder = "CustData";
        public static readonly string DBFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DBSubFolder);

        public static string GetDataFolder()
        {
            var folder = DBFolder;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            return folder;
        }

        public static string GetDataFileName(int custId)
        {
            var folder = GetDataFolder();
            return Path.Combine(folder, custId.ToString());
        }

        public static void StoreCustDate(CustomerData value)
        {
            var fileName = GetDataFileName(value.CustomerId);
            var jsonString = ConvertToJson(value);
            System.IO.File.WriteAllText(fileName, jsonString);
        }

        public static int GenCustId(bool unique)
        {
            var id = 0;
            for (int i = 0; i < 20; i++)
            {
                id = Random.Shared.Next(1, 9999);
                var fileName = GetDataFileName(id);
                if (!unique || !System.IO.File.Exists(fileName))
                {
                    break;
                }
            }
            return id;
        }

        public static string ConvertToJson(CustomerData value)
        {
            return JsonSerializer.Serialize(value);
        }

        public static CustomerData LoadFromJson(string json)
        {
            var customerData = JsonSerializer.Deserialize<CustomerData>(json);
            return customerData;
        }

        public static CustomerData LoadFromFile(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return LoadFromJson(json);
        }

        private static string GetWorkingFolder(string subFolder)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, subFolder);
            return path;
        }

        public static void InitData()
        {

            DirectoryInfo di = new DirectoryInfo(GetWorkingFolder("InitData"));

            foreach (FileInfo file in di.GetFiles())
            {
                var customerData = LoadFromFile(file.FullName);
                if (customerData != null)
                {
                    StoreCustDate(customerData);
                }
            }
        }

        public static string ReadMeFileName()
        {
            return GetWorkingFolder("Readme.txt");
        }
    }
}
