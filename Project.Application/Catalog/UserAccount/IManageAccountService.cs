using Project.Application.Catalog.UserAccount.Dtos;
using Project.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.UserAccount
{
    public interface IManageAccountService
    {
        Task<int> View(ViewProfileRequest request);

        Task<int> Update(EditProfileRequest request);

        Task<int> UpdatePassword(EditPasswordRequest request);

        Task<int> Create(UserCreateRequest request);

        Task<List<UserViewModel>> GetAll();
        Task<PageViewModel<UserViewModel>> GetAllAccount(string keyword, int pageIndex, int pageSize);
    }
}
