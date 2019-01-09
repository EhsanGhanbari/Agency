using System.Web.Mvc;
using Agency.Application.Services;
using Agency.Application.ViewModel;

namespace Agency.UI.MVC.Areas.HotBoysArea.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// List of all users of the systems
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var userViewModel = new UserViewModel();
            var users = _userService.GetAllUsers();
            return View("List",users);
        }


        /// <summary>
        /// List of all owners of the systems
        /// </summary>
        /// <returns></returns>
        public ActionResult Owners()
        {
            return View();
        }


        /// <summary>
        /// Remove  Action, void return
        /// Ajax call
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPost] 
        public void Remove(int id)
        {
            if (ModelState.IsValid)
            {
                _userService.RemoveUser(id);
            }
            //return a message
        }
    }
}
