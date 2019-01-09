using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Agency.Application.Services;
using Agency.Application.ViewModel;

namespace Agency.UI.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Returns a user by Identity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserViewModel GetUser(int userId)
        {
            var userViewModel = new UserViewModel { Id = userId };
            var user = _userService.GetUser(userViewModel);
            if (user == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return user;
        }


        /// <summary>
        /// returns all users of the system
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAllUsers(UserViewModel userViewModel)
        {
            var users = _userService.GetAllUsers(userViewModel);
            if (users == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent));
           
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        /// <summary>
        /// Register the user in the system
        /// </summary>
        public HttpResponseMessage PostUser(UserViewModel userViewModel)
        {
            _userService.CreateUser(userViewModel);
            var response = Request.CreateResponse(HttpStatusCode.Created, userViewModel);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/comments/" + userViewModel.Id);
            return response;
        }

        /// <summary>
        /// Updates the user information
        /// </summary>
        public HttpResponseMessage PutUser(UserViewModel userViewModel)
        {
            _userService.UpdateUser(userViewModel);
            var response = Request.CreateResponse(HttpStatusCode.OK, userViewModel);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/comments/" + userViewModel.Id);
            return response;
        }


        /// <summary>
        /// Delete the user content
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteUser(UserViewModel userViewModel)
        {
            _userService.RemoveUser(userViewModel);
           
            var response= new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }

    }
}
