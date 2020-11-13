using System.IO;
using System.Text.Json;

using Z01.Models;
using Z01.Models.Data;

namespace Z01
{
    public static class DataStorage
    {
        private const string DataFileLocation = @"data.json";

        public static DataModel GetDataModel()
        {
            var jsonString = File.ReadAllText(DataFileLocation);
            return JsonSerializer.Deserialize<DataModel>(jsonString);
        }

        public static void SaveDataModel(DataModel dataModel)
        {
            var jsonString = JsonSerializer.Serialize(dataModel);
            File.WriteAllText(DataFileLocation, jsonString);
        }
    }
}
