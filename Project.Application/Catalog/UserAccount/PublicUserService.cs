using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.Application.Common;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Uttilities.Exceptions;
using Project.ViewModels.Catalog.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.UserAccount
{
    public class PublicUserService : IPublicUserService
    {
        private readonly ProjectDbContext _context;
        private readonly IStorageService _storageService;
        public PublicUserService(ProjectDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<bool> LastestCommemts(EditPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(EditProfileRequest request)
        {
            var account = await _context.AppUsers.FindAsync(request.UserId);
            if(account == null) throw new CustomException($"Can not find user account {request.UserId}");
            account.FullName = request.FullName;
            account.Address = request.Address;
            account.PhoneNumber = request.Phone;
            if(request.ThumnailImage != null)
            {
                var thumnailImage = await _context.UserImages.FirstOrDefaultAsync(x => x.CurrentSet == true && x.UserId == request.UserId);
                if (thumnailImage != null) 
                {
                    thumnailImage.ImagePath = await this.SaveFile(request.ThumnailImage);
                    thumnailImage.FileSize = request.ThumnailImage.Length;
                    _context.UserImages.Update(thumnailImage);
                }
                else
                {
                    var userImage = new UserImage()
                    {
                        UserId = request.UserId,
                        ImagePath = await this.SaveFile(request.ThumnailImage),
                        CurrentSet = true,
                        DateCreated = DateTime.Now,
                        SortOder = 1,
                        FileSize = request.ThumnailImage.Length,
                    };
                    await _context.UserImages.AddAsync(userImage);
                }
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePassword(EditPasswordRequest request)
        {
            var hasher = new PasswordHasher<AppUser>();
            var account = await _context.AppUsers.FindAsync(request.UserId);
            if (account == null) throw new CustomException($"Can not find user account {request.UserId}");
            if(!hasher.HashPassword(null, request.OldPassword).Equals(account.PasswordHash)) throw new CustomException("The old password is incorrect");
            if(!request.NewPassword.Equals(request.ConfirmPassword)) throw new CustomException("Re-enter password does not match");
            account.PasswordHash = hasher.HashPassword(null, request.NewPassword);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AppUser> View(ViewProfileRequest request)
        {
            var account = await _context.AppUsers.FindAsync(request.UserId);
            if (account == null) throw new CustomException($"Can not find user account {request.UserId}");

            return account;
        }

        public Task<bool> ViewCourses(EditPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ViewTasks(EditPasswordRequest request)
        {
            throw new NotImplementedException();
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
