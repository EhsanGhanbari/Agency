using System.Collections.Generic;
using Agency.Application.ViewModel;

namespace Agency.Application.Services
{
    public interface IUserService
    {
        ResponseMessage CreateUser(UserViewModel userViewModel);
        ResponseMessage UpdateUser(UserViewModel userViewModel);
        UserViewModel GetUser(UserViewModel userViewModel);
        IEnumerable<UserViewModel> GetAllUsers(UserViewModel userViewModel);
        ResponseMessage RemoveUser(UserViewModel userViewModel);

    }
}
