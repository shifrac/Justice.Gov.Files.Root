using Justice.Gov.Files.DAL;
using Justice.Gov.Files.Models;

namespace Justice.Gov.Files.BL
{
    public class FilesBL
    {
        public static void SetFileData(FileModel fileData, string jsonFilePat)
        {
            FilesDAL.SetFileData(fileData, jsonFilePat);
        }
    }
}
