using System.Web.Mvc;

namespace Vape.CMS.UI.Controllers
{
    public class AuthController : Controller
    {

        #region [ login ]

        // Get Auth
        /// <summary>
        /// Create a public action result that calls the view Login. 
        /// </summary>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// HttpPost links to login view where post is created. ???
        /// </summary>
        [HttpPost]
        public ActionResult Validate(DAL.DTO.LoginDto model)
        {
            return RedirectToAction("Dashboard", "Dashboard");
        }

        #endregion

        #region [ Register ]
        //Get Register
        /// <summary>
        /// Create a public action result that calls the view Register.
        /// </summary>
        /// <returns></returns>

        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegisterUser(DAL.DTO.RegisterDto model)
        {

            var Name = model.Name;
            var Surname = model.Surname;
            var CellNumber = model.CellNumber;
            var Email = model.Email;
            var Password = model.Password;

            return RedirectToAction("Dashboard", "Dashboard");

        }
        #endregion
    }
}