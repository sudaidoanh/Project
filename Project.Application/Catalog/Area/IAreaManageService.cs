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
    public interface IAreaManageService
    {
        Task<ResultModel<AreaViewModel>> GetAllArea(GetAreaPagingRequest request);
        Task<string> Create(string AreaName);
        Task<ResultModel<UserViewModel>> GetAreaUser(GetAreaPagingRequest request);
        Task<ResultModel<DistributorViewModel>> GetAreaDistributor(GetAreaPagingRequest request);

    }
}
