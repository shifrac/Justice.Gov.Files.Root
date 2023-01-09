using Justice.Gov.Files.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Justice.Gov.Files.DAL
{
    public class FilesDAL
    {
        public static void SetFileData(FileModel fileData, string jsonFilePat)
        {
            WriteToJsonFile(fileData, jsonFilePat);
        }
       
        private static void WriteToJsonFile(FileModel fileData, string jsonFilePat)
        {           
            FileMode fileMode = (!System.IO.File.Exists(jsonFilePat)) ? FileMode.Create : FileMode.Append;
            using (StreamWriter writer = new StreamWriter(new FileStream(jsonFilePat, fileMode, FileAccess.Write)))
            {
                writer.WriteLine(JsonSerializer.Serialize(fileData));
            }
        }
    }
}
