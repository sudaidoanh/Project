using Microsoft.EntityFrameworkCore;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Uttilities.Exceptions;
using Project.ViewModels.Catalog.Noftication;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly ProjectDbContext _context;
        public NotificationService(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateNewNotification(AddNotificationRequest request)
        {
            foreach( var x in request.Receivers )
            {
                var notif = new Project.Data.Entities.Notification()
                {
                    Date = DateTime.Now,
                    Header = request.Title,
                    Content = request.Content,
                    SenderId = new Guid($"{request.SenderID}"),
                    Receivers = new Guid($"{x}"),
                    Status = Data.Enums.Status.InActive,
                };
                await _context.AddAsync(notif);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ResultModel<NotificationViewModel>> GetNotificationPaging(Guid user, GetNotificationPagingRequest request)
        {
            var userMoment = await _context.AppUsers.FindAsync(user);
            if (userMoment == null )
            {
                throw new CustomException($"Cant not get User {user}");
            }
            var query = from n in _context.Notifications.Where(x => x.SenderId.Equals(user) || x.Receivers.Equals(user))
                        from u in _context.AppUsers.Where(u => u.Id.Equals(n.SenderId)).DefaultIfEmpty()
                        select new {n, u.FullName};
            if (!string.IsNullOrEmpty(request.Keyword)) query = query.Where(x => x.n.Content.Contains(request.Keyword) || x.FullName.Contains(request.Keyword));
            int totalRow = await query.CountAsync();
            if (totalRow == 0) return null;
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select( p => new NotificationViewModel()
                {
                    Id = p.n.Id,
                    Content = p.n.Content,
                    Title = p.n.Header,
                    SenderName = userMoment.FullName.Equals(p.FullName)? "You" : p.FullName,
                    Status = p.n.Status,

                }).ToListAsync();
            return new ResultModel<NotificationViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data,
            };
            throw new NotImplementedException();
        }
    }
}
