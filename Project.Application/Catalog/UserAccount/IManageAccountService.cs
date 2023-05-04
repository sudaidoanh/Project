using Project.ViewModels.Catalog.UserAccount;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.UserAccount
{
    public interface IManageAccountService
    {
        Task<Guid> Create(UserCreateRequest request);
        Task<int> Delete(Guid UserId);
        Task<ResultModel<UserViewModel>> GetAllAccount(GetUserPagingRequest request);
        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(Guid UserId);  
    }
}
