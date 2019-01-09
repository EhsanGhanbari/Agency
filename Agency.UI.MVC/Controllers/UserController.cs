using System.Web.Mvc;
using Agency.Application.Services;
using Agency.Application.ViewModel;

namespace Agency.UI.MVC.Controllers
{
    //[Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Update the user information
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            var user = _userService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(userViewModel);
            }
            return View();
        }
    }
}
