namespace Justice.Gov.Files.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; } 
        public string FileType { get; set; }
        public int FileSize { get; set; }
        public DateTime CreatedDate { get; set; }   
        public string Author { get; set; }
        public bool IsEncrypted { get; set; }
    }
}
