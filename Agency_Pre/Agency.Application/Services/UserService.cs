using System;
using System.Collections.Generic;
using System.Linq;
using Agency.Application.Mappers;
using Agency.Application.Model;
using Agency.Application.ViewModel;
using log4net;
using NHibernate;
using NHibernate.Linq;

namespace Agency.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ISession _session;
        private readonly ILog _log;

        public UserService()
        {
            _session = SessionFactory.GetCurrentSession();
            _log = LogManager.GetLogger(typeof(Taxi));
        }

        /// <summary>
        /// create a user in system
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public ResponseMessage CreateUser(UserViewModel userViewModel)
        {
            ResponseMessage response;
            var user = userViewModel.ConvertToUserModel();
            try
            {
                SessionFactory.GetCurrentSession().Save(user);
                response = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                response = ResponseMessage.Failed;
            }
            return response;
        }

        /// <summary>
        /// update the user info
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public ResponseMessage UpdateUser(UserViewModel userViewModel)
        {
            ResponseMessage response;
            try
            {
                var user = userViewModel.ConvertToUserModel();
                SessionFactory.GetCurrentSession().Update(user);
                response = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                response = ResponseMessage.Failed;
            }
            return response;
        }

        /// <summary>
        /// get a user details
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public UserViewModel GetUser(UserViewModel userViewModel)
        {
            var response = new UserViewModel();
            try
            {
                var user = SessionFactory.GetCurrentSession().Get<User>(userViewModel.Id);
                response = user.ConverToUserViewModel();
                response.ResponseMessage = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                response.ResponseMessage = ResponseMessage.Failed;
            }
            return response;
        }

        /// <summary>
        /// Get All users of the systems by paging
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserViewModel> GetAllUsers(UserViewModel userViewModel)
        {

            return
                _session.Query<User>()
                    .ConvertToUserViewModelList()
                    .Skip(userViewModel.PagingViewModel.PageIndex * userViewModel.PagingViewModel.PageSize)
                    .Take(userViewModel.PagingViewModel.PageSize);
        }

        /// <summary>
        /// Removes the user from system
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public ResponseMessage RemoveUser(UserViewModel userViewModel)
        {
            ResponseMessage response;
            try
            {
                var user = userViewModel.ConvertToUserModel();
                //set IsDeleted to true
                SessionFactory.GetCurrentSession().Delete(user);
                response = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                response = ResponseMessage.Failed;
            }
            return response;
        }
    }
}
