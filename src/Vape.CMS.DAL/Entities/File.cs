namespace Vape.CMS.DAL.Entities
{
    public class File
    {
        public int? FileId { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public int FileSize { get; set; }
        public byte[] FileBytes { get; set; }
        public bool Deleted { get; set; }
    }
}