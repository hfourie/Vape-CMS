using System;
using System.Web.Mvc;
using Vape.CMS.DAL.Entities;
using Vape.CMS.DAL.Functions;

namespace Vape.CMS.UI.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Users()
        {
            var user = new User();
            return View(user);
        }
        // GET: Users
        public ActionResult GetUser(User user)
        {
            try
            {
                return Json(UserFunctions.Get(user));
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateUpdateUserProfile(User user)
        {
            try
            {
                if (user.UserId != null){
                    UserFunctions.Update(user);
                }
                else{
                    UserFunctions.Create(user);
                }

                return Json("Success");
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        public ActionResult DeleteUserProfile(User user)
        {
                UserFunctions.Delete(user);

            return RedirectToAction("Users", "Users");
        }

    }
}

////Save image to file
//var filename = image.FileName;
//var filePathOriginal = Server.MapPath("/Content/Uploads/Originals");
//var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
//string savedFileName = Path.Combine(filePathOriginal, filename);
//image.SaveAs(savedFileName);

////Read image back from file and create thumbnail from it
//var imageFile = Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename);
//using (var srcImage = Image.FromFile(imageFile))
//using (var newImage = new Bitmap(100, 100))
//using (var graphics = Graphics.FromImage(newImage))
//using (var stream = new MemoryStream())
//{
//    graphics.SmoothingMode = SmoothingMode.AntiAlias;
//    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
//    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
//    graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 100));
//    newImage.Save(stream, ImageFormat.Png);
//    var thumbNew = File(stream.ToArray(), "image/png");
//    artwork.ArtworkThumbnail = thumbNew.FileContents;
//}