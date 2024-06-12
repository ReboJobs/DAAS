namespace BlazorDataAnalytics.Models
{
    public class FileUploadModel
    {
        public string FileName { get; set; }
        public byte[] FileByte { get; set; }
        public string FileMimeType { get; set; }
        public string Container { get; set; }
        public string SubDirectory { get; set; }
    }
}
