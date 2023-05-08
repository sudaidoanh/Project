using Project.Data.Entities;
using Project.ViewModels.Catalog.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.UserAccount
{
    public interface IPublicUserService
    {
        Task<UserViewModel> View(Guid guid);

        Task<bool> Update(EditProfileRequest request);

        Task<bool> UpdatePassword(EditPasswordRequest request);
        Task<bool> ViewTasks(EditPasswordRequest request);
        Task<bool> LastestCommemts(EditPasswordRequest request);
        Task<bool> ViewCourses(EditPasswordRequest request);
    }
}
