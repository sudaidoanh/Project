using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Project.Application.Common;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Uttilities.Exceptions;
using Project.ViewModels.Catalog.Area;
using Project.ViewModels.Catalog.UserAccount;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.Area
{
    public class AreaManageService : IAreaManageService
    {
        private readonly ProjectDbContext _context;
        public AreaManageService(ProjectDbContext context) {  _context = context; }

        public async Task<string> Create(string AreaName)
        {
            if (await _context.Areas.FirstOrDefaultAsync(x => x.Name == AreaName) != null) throw new CustomException("Area Exist");
            var getId = await _context.Areas.MaxAsync(x => x.Id);
            var area = new Project.Data.Entities.Area()
            {
                Name = AreaName,
                Code = $"COD{getId+1}"
            };
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
            return area.Code;
        }

        public async Task<DistributorViewModel> GetDistributorById(int AreaId)
        {
            var areaDistributor = await _context.AreaDistributors.FirstOrDefaultAsync(x => x.AreaId == AreaId);
            var dis = await _context.Distributors.FindAsync(areaDistributor.DistributorId);
            var distributor = new DistributorViewModel()
            {
                Id = dis.Id,
                Name = dis.Name,
                Email = dis.Email,
                Address = dis.Address,
                Phone = dis.Phone,
            };
            return distributor;
        }

        public async Task<int> Delete(List<int> AreaId)
        {
            foreach(var x in AreaId)
            {
                var area = await _context.Areas.FindAsync(x);
                if (area == null) throw new CustomException($"Can not find area {x}");
                _context.Areas.Remove(area);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<ResultModel<AreaViewModel>> GetAllArea(GetAreaPagingRequest request)
        {
            var query = from a in _context.Areas.Where(a => a.Name.Contains(request.Keyword) || a.Code.Contains(request.Keyword))
                        from ad in _context.AreaDistributors.Where(ad => a.Id == ad.AreaId).DefaultIfEmpty()
                        select new { a, ad };

            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new AreaViewModel()
                {
                    Id = p.a.Id,
                    Code = p.a.Code,
                    Name = p.a.Name,
                    DistributorCity = p.ad.DistributorId,
                }).ToListAsync()
                ;
            var pageResult = new ResultModel<AreaViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data,
            };
            return pageResult;
        }

        public async Task<ResultModel<DistributorViewModel>> GetAreaDistributor(int AreaId, GetAreaPagingRequest request)
        {
            var query = from ad in _context.AreaDistributors.Where( ad => ad.AreaId == AreaId)
                        join d in _context.Distributors on ad.DistributorId equals d.Id
                        select new { ad, d };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.d.Name.Contains(request.Keyword));
            }
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new DistributorViewModel()
                {
                    Id = p.d.Id,
                    Name = p.d.Name,
                    Address = p.d.Address,
                    Email = p.d.Email,
                    Phone = p.d.Phone,
                }).ToListAsync()
                ;
            var pageResult = new ResultModel<DistributorViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data,
            };
            return pageResult;
        }

        public async Task<ResultModel<UserViewModel>> GetAreaUser(int AreaId, GetAreaPagingRequest request)
        {
            var query = from a in _context.Areas
                        join au in _context.AreaUsers on a.Id equals au.AreaId 
                        join u in _context.AppUsers on au.UserId equals u.Id
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.AppRoles on ur.RoleId equals r.Id
                        select new { a, au, u, r} ;
            query = query.Where(x => x.au.AreaId == AreaId);
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.u.FullName.Contains(request.Keyword));

            }
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new UserViewModel()
                {
                    Id = p.u.Id,
                    FullName = p.u.FullName,
                    Email = p.u.Email,
                    Role = p.r.Name,
                }).ToListAsync()
                ;
            var pageResult = new ResultModel<UserViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data,
            };
            return pageResult;
        }

        public async Task<Guid> CreateAccountUserArea(int AreaId, UserCreateRequest request)
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
                    AreaId = AreaId,
                } }
            };
            await _context.AppUsers.AddAsync(account);
            await _context.SaveChangesAsync();
            return account.Id;
        }

        public async Task<int> AssignAreaUser(int AreaId, List<Guid> guid)
        {
            foreach( var x in guid)
            {
                var areaUser = new AreaUser()
                {
                    AreaId = AreaId,
                    UserId = x,
                };
                await _context.AreaUsers.AddAsync(areaUser);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateDistributorArea(int AreaId, DistributorCreateRequest request)
        {
            var distributor = new Distributor()
            {
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                AreaDistributors = new List<AreaDistributor>
                {
                    new AreaDistributor()
                    {
                        AreaId = AreaId,
                    } },
            };
        
            await _context.Distributors.AddAsync(distributor);
            await _context.SaveChangesAsync();
            return distributor.Id;
        }

        public async Task<int> DeleteUserArea(List<Guid> guid)
        {
            foreach (var x in guid)
            {
                var areaUser = await _context.AreaUsers.FirstOrDefaultAsync(c => c.UserId == x);
                if (areaUser == null) throw new CustomException($"Can not find user {x}");
                _context.AreaUsers.Remove(areaUser);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUDistributor(List<int> distributorId)
        {
            foreach( var x in distributorId)
            {
                var distributor = await _context.Distributors.FindAsync(x);
                _context.Distributors.Remove(distributor);

            }
            return await _context.SaveChangesAsync();
            
        }
    }
}
