using Project.Application.Catalog.UserAccount.Dtos;
using Project.Application.Dtos;
using Project.Data.EF;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.UserAccount
{
    public class ManageAccountService : IManageAccountService
    {
        private readonly ProjectDbContext _context;
        public ManageAccountService(ProjectDbContext context) 
        { 
            _context = context;
        }
        public async Task<int> Create(UserCreateRequest request)
        {
            var account = new AppUser()
            {

            };
            _context.AppUsers.Add(account);
            return await _context.SaveChangesAsync();
        }

        Task<List<UserViewModel>> IManageAccountService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<PageViewModel<UserViewModel>> IManageAccountService.GetAllAccount(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        Task<int> IManageAccountService.Update(EditProfileRequest request)
        {
            throw new NotImplementedException();
        }

        Task<int> IManageAccountService.UpdatePassword(EditPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        Task<int> IManageAccountService.View(ViewProfileRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
