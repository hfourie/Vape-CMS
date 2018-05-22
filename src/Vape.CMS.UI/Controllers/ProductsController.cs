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
    public class ProductsController : Controller
    {
        #region [ Products ]
        // Get Products
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult GetProduct(Product product)
        {
            try
            {
                return Json(ProductFunctions.Get(product));
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateUpdateProducts(Product product)
        {
            int? ProductId = null;

            try
            {
                if (product.ProductId != null)
                {
                    ProductFunctions.Update(product);
                }
                else
                {
                    ProductId = ProductFunctions.Create(product);
                }

                return Json(ProductId);
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        public ActionResult DeleteProduct(Product product)
        {
            ProductFunctions.Delete(product);

            return RedirectToAction("Products", "Products");
        }

        #endregion

        //        #region Product Color
        //        [AcceptVerbs(HttpVerbs.Post)]
        //        public ActionResult CreateUpdateProductColor (DAL.DTO.ProductColorTieDto productColorTieDto)
        //        {
        //            if (productColorTieDto.ProductColorTieId != null)
        //            {
        //                ProductFunctions.UpdateProductColorTie(productColorTieDto);
        //            }
        //            else
        //            {
        //                ProductFunctions.CreateProductColorTie(productColorTieDto);
        //            }
        //            return Json("string");
        //        }
        //        #endregion

        //        #region Product Nicotine
        //        [AcceptVerbs(HttpVerbs.Post)]
        //        public ActionResult CreateUpdateProductNicotine (DAL.DTO.ProductNicotineTieDto productNicotineTieDto)
        //        {
        //            if (productNicotineTieDto.ProductNicotineTieId != null)
        //            {
        //                ProductFunctions.UpdateProductNicotineTie(productNicotineTieDto);
        //            }
        //            else
        //            {
        //                ProductFunctions.CreateProductNicotineTie(productNicotineTieDto);
        //            }
        //            return Json("string");
        //        }



        //        #endregion

        //        #region Product Size
        //        [AcceptVerbs(HttpVerbs.Post)]
        //        public ActionResult CreateUpdateProductSize(DAL.DTO.ProductSizeTieDto productSizeTieDto)
        //        {
        //            if (productSizeTieDto.ProductSizeTieId != null)
        //            {
        //                ProductFunctions.UpdateProductSizeTie(productSizeTieDto);
        //            }
        //            else
        //            {
        //                ProductFunctions.CreateProductSizeTie(productSizeTieDto);
        //            }
        //            return Json("string");
        //        }
        //        #endregion

    }
}