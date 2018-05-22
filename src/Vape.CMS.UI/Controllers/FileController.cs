using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Vape.CMS.DAL.Entities;
using Vape.CMS.DAL.Functions;

namespace Vape.CMS.UI.Controllers
{
    public class FileController : Controller
    {

        // GET: Files
        [HttpPost]
        public ActionResult UploadFiles()

        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    var fileIds = new List<int>();
                    //  Get all files from Request object  
                    var files = Request.Files;
                    for (var i = 0; i < files.Count; i++)
                    {
                        var file = Request.Files[0];

                        if (file == null || file.ContentLength <= 0) continue;
                        // Code to process image, resize, etc goes here
                        var image = new DAL.Entities.File
                        {
                            FileName = file.FileName,
                            FileContentType = file.ContentType,
                            FileBytes = new byte[file.ContentLength],
                            FileSize = file.ContentLength
                        };

                        file.InputStream.Read(image.FileBytes, 0, image.FileSize);
                        //add the id to the userProfileDto

                        fileIds.Add(FileFunctions.Create(image));

                    }
                    // Returns message that successfully uploaded  
                    return Json(fileIds.ToArray());
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        //[HttpPost]
        public ActionResult GetFile(File file)
        {
                var imageData = FileFunctions.Get(file);
                return File(imageData.FileBytes, imageData.FileContentType, imageData.FileName);
        }
    }



}