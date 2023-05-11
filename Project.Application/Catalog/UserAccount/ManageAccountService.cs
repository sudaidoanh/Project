using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Uttilities.Exceptions;
using Project.ViewModels.Catalog.UserAccount;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.UserAccount
{
    public class ManageAccountService : IManageAccountService
    {
        private readonly ProjectDbContext _context;
        private readonly IStorageService _storageService;
        public ManageAccountService(ProjectDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<Guid> Create(UserCreateRequest request)
        {
            var hasher = new PasswordHasher<AppUser>();
            var account = new AppUser()
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                NormalizedEmail = request.Email,
                Address = request.Address,
                UserName = request.UserName,
                NormalizedUserName = request.UserName,
                PhoneNumber = request.Phone,
                PasswordHash = hasher.HashPassword(null, request.Password),
                SecurityStamp = "",
                UserRoles = new List<UserRole>(){ new UserRole()
                {
                    RoleId = request.RoleId,
                } },
                AreaUser = new List<AreaUser> { new AreaUser()
                {
                    AreaId = request.AreaId,
                } }
            };
            await _context.AppUsers.AddAsync(account);
            await _context.SaveChangesAsync();
            return account.Id;
        }

        public async Task<int> Delete(Guid UserId)
        {
            var account = await _context.AppUsers.FindAsync(UserId);
            if (account == null) throw new CustomException($"Can not find user account {UserId}");
            var images =  _context.UserImages.Where(x => x.UserId == UserId);
            foreach(var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
                _context.UserImages.Remove(image);
            }
            
            _context.AppUsers.Remove(account);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var query = from u in _context.AppUsers
                        join au in _context.AreaUsers on u.Id equals au.UserId
                        join a in _context.Areas on au.AreaId equals a.Id
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.AppRoles on ur.RoleId equals r.Id
                        select new { u, a, r };
            ;
            return await query.Select(p => new UserViewModel()
            {
                Id = p.u.Id,
                FullName = p.u.FullName,
                Email = p.u.Email,
                Status = p.u.Status,
                Role = p.r.Name,
                Area = p.a.Name,
            }).ToListAsync();
        }

        public async Task<ResultModel<UserViewModel>> GetAllAccount(GetUserPagingRequest request)
        {
            var query = from u in _context.AppUsers 
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.AppRoles on ur.RoleId equals r.Id
                        join au in _context.AreaUsers on u.Id equals au.UserId
                        join a in _context.Areas on au.AreaId equals a.Id
                        select new {u, r, a};
                        ;
            if (!string.IsNullOrEmpty(request.Keyword)) query = query.Where(x => x.u.FullName.Contains(request.Keyword));

            /*if(request.UserId.Count > 0) query = query.Where(x => request.UserId.Contains(x.u.Id));*/
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new UserViewModel()
                {
                    Id = p.u.Id,
                    FullName = p.u.FullName,
                    Email = p.u.Email,
                    Status = p.u.Status,
                    Role = p.r.Name,
                    Area = p.a.Name,
                }).ToListAsync()
                ;
            var pageResult = new ResultModel<UserViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data,
            };
            return pageResult;
            
        }

        public async Task<UserViewModel> GetById(Guid UserId)
        {
            var account = await _context.AppUsers.FindAsync(UserId);
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (userRole == null) throw new CustomException($"Can not find Role of account {account.FullName}");
            var role = await _context.AppRoles.FindAsync(new Guid($"{userRole.RoleId}"));
            var userViewModel = new UserViewModel()
            {
                Id = UserId,
                FullName = account.FullName,
                Email = account.Email,
                Status = account.Status,
                Role = role.Name,
            }
            ;
            return userViewModel;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
