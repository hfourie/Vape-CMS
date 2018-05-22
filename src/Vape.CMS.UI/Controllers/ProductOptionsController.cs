using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Vape.CMS.DAL.Entities;
using Vape.CMS.DAL.Functions;

namespace Vape.CMS.UI.Controllers
{
    public class ProductOptionsController : Controller
    {
        #region [Color]

        public ActionResult Colors()
        {
            return View();
        }

        public ActionResult GetColor(DAL.Entities.Color color)
        {
            try
            {
                return Json(ColorFunctions.Get(color));
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateUpdateColor(DAL.Entities.Color color)
        {
            try
            {
                if (color.ColorId != null)
                    ColorFunctions.Update(color);
                else
                    ColorFunctions.Create(color);

                return Json("Success");
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        public ActionResult DeleteColor(DAL.Entities.Color color)
        {
            ColorFunctions.Delete(color);

            return RedirectToAction("Colors", "ProductOptions");
        }
        #endregion

        #region [Nicotine]

        public ActionResult Nicotine()
        {
            return View();
        }

        public ActionResult GetNicotine(Nicotine nicotine)
        {
            try
            {
                return Json(NicotineFunctions.Get(nicotine));
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateUpdateNicotine(Nicotine nicotine)
        {
            try
            {
                if (nicotine.NicotineId != null)
                    NicotineFunctions.Update(nicotine);
                else
                    NicotineFunctions.Create(nicotine);

                return Json("Success");
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        public ActionResult DeleteNicotine(Nicotine nicotine)
        {
            NicotineFunctions.Delete(nicotine);
            return RedirectToAction("Nicotine", "ProductOptions");
        }
        #endregion

        #region [Size]

        public ActionResult Sizes()
        {
            return View();
        }

        public ActionResult GetSize(DAL.Entities.Size size)
        {
            try
            {
                return Json(SizeFunctions.Get(size));
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateUpdateSize(DAL.Entities.Size size)
        {
            try
            {
                if (size.SizeId != null)
                    SizeFunctions.Update(size);
                else
                    SizeFunctions.Create(size);

                return Json("Success");
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        public ActionResult DeleteSize(DAL.Entities.Size size)
        {
            SizeFunctions.Delete(size);
            return RedirectToAction("Sizes", "ProductOptions");
        }
        #endregion
    }
}
