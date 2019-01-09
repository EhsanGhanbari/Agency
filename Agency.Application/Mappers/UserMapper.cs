using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Application.Model;
using Agency.Application.ViewModel;
using AutoMapper;

namespace Agency.Application.Mappers
{
    public static class UserMapper
    {
        /// <summary>
        /// Convert to User View Model
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserViewModel ConverToUserViewModel(this User user)
        {
            return Mapper.Map<User, UserViewModel>(user);
        }


        /// <summary>
        /// Converet to user View Model
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        public static User ConvertToUserModel(this UserViewModel userViewModel)
        {
            return Mapper.Map<UserViewModel, User>(userViewModel);
        }

        /// <summary>
        /// Conver list if user model to user View model
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static IEnumerable<UserViewModel> ConvertToUserViewModelList(this IEnumerable<User> users)
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }
    }
}
