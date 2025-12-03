using BelajarDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace ActionResultInASPNETCoreMVC.Controllers
{
    public class ActionResultController : Controller
    {
        //public ContentResult Index()
        //{
        //    string plainText = "This is plain text content.";
        //    return new ContentResult
        //    {
        //        ContentType = "text/plain",
        //        Content = plainText
        //    };
        //}

        public ViewResult Index()
        {
            return View();
        }

        public FileResult DownloadFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PDFFiles\\" + "Sample.pdf";
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileResult = File(fileBytes, "application/pdf");
            fileResult.FileDownloadName = "MySampleFile.pdf";
            fileResult.LastModified = new DateTimeOffset(System.IO.File.GetLastWriteTimeUtc(filePath));
            fileResult.EntityTag = new EntityTagHeaderValue("\"fileVersion1\"");
            fileResult.EnableRangeProcessing = true;
            return fileResult;
        }
    

        public ActionResult Details(string Category)
        {
            var options = new JsonSerializerOptions()
            {
                // Property names will remain as defined in the class
                PropertyNamingPolicy = null,

                // JSON will be formatted with indents for readability
                WriteIndented = true,
            };

            try
            {
                //Based on the Category Fetch the Data from the database 
                //Here, we have hard coded the data
                List<ProductAi> products = new List<ProductAi>
                {
                    new ProductAi{ Id = 1001, Name = "Laptop",  Description = "Dell Laptop" },
                    new ProductAi{ Id = 1002, Name = "Desktop", Description = "HP Desktop" },
                    new ProductAi{ Id = 1003, Name = "Mobile", Description = "Apple IPhone" }
                };

             
                return Json(products, options);
            }
            catch (Exception ex)
            {
                var errorObject = new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    ExceptionType = "Internal Server Error"
                };

                return new JsonResult(errorObject, options)
                {
                    StatusCode = StatusCodes.Status500InternalServerError                 };
            }
        }
    }
}