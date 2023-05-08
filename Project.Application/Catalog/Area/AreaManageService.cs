using Microsoft.EntityFrameworkCore;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Uttilities.Exceptions;
using Project.ViewModels.Catalog.Area;
using Project.ViewModels.Catalog.UserAccount;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<ResultModel<AreaViewModel>> GetAllArea(GetAreaPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<DistributorViewModel>> GetAreaDistributor(GetAreaPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<UserViewModel>> GetAreaUser(GetAreaPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
