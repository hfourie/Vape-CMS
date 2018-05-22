using System;
using System.Web.Mvc;
using Vape.CMS.DAL.Entities;
using Vape.CMS.DAL.Functions;

namespace Vape.CMS.UI.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult GetCategory(Category category)
        {
            try
            {
                return Json(CategoryFunctions.Get(category));
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateUpdateCategory(Category category)
        {
            try
            {
                if (category.CategoryId != null)
                    CategoryFunctions.Update(category);
                else
                    CategoryFunctions.Create(category);

                return Json("Category successfully created");
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        public ActionResult DeleteCategory(Category category)
        {
            CategoryFunctions.Delete(category);
            return RedirectToAction("Categories", "Category");
        }

    }
}