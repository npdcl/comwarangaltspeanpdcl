namespace TspeaNpdcl3.Models
{
    public class FileClass
    {
        public int Fileid { get; set; } = 0;
        public string name { get; set; } = "";
        public string path { get; set; } = "";

        public List<FileClass> file { get; set; } = new List<FileClass>();   

    }
}
