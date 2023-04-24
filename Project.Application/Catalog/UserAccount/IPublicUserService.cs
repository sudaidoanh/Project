using Project.Application.Catalog.UserAccount.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.UserAccount
{
    public interface IPublicUserService
    {
        int View(ViewProfileRequest request);

        int Update(EditProfileRequest request);

        int UpdatePassword(EditPasswordRequest request);
    }
}
