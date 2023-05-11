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
        Task<Guid> CreateAccountUserArea(int AreaId, UserCreateRequest request);
        Task<int> DeleteUserArea(List<Guid> guids);
        Task<int> Delete(List<int> AreaId);
        Task<int> CreateDistributorArea(int AreaId, DistributorCreateRequest request);

        Task<ResultModel<UserViewModel>> GetAreaUser(int AreaId, GetAreaPagingRequest request);
        Task<ResultModel<DistributorViewModel>> GetAreaDistributor(int AreaId, GetAreaPagingRequest request);

    }
}
