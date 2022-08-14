using Microsoft.AspNetCore.Mvc;
using TspeaNpdcl3.Models;

namespace TspeaNpdcl3.Controllers
{
    public class FileController : Controller
    {
        IWebHostEnvironment _webHostEnvironment = null;

        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet]
        public IActionResult Index(string fileName = "")
        {
            FileClass fileObj = new FileClass();
            fileObj.name = fileName;
            string path = $"{_webHostEnvironment.WebRootPath}\\files\\";
            int nid = 1;
            foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                fileObj.file.Add(new FileClass()
                {
                    Fileid = nid++,
                    name = Path.GetFileName(pdfPath),
                    path = pdfPath
                });

            }
            return View(fileObj);

        }
        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            string fileName = $"{webHostEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();

            }
                return Index();

        }
        public IActionResult PDFviewNewTab (string fileName)
        {
            string path = _webHostEnvironment.WebRootPath+"\\files\\"+ fileName;

            return File(System.IO.File.ReadAllBytes(path),"application/pdf");


        }
    }
}
