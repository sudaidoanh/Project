﻿using Microsoft.EntityFrameworkCore;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.ViewModels.Catalog.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.Plan
{
    public class PlanService : IPlanService
    {
        private readonly ProjectDbContext _context;
        public PlanService(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVisitPlan(PlanViewModel request)
        {
            foreach(var x in request.Invited)
            {
                var plan = new Project.Data.Entities.Plan()
                {
                    Calendar = request.Calendar,
                    CreatedDate = DateTime.Now,
                    Purpose = request.Purpose,
                    TypeDate = request.TypeDate,
                    UserId = request.UserId,
                    DistributorId = request.DistributorId,
                    PlanDetails = new List<PlanDetail>(){ new PlanDetail()
                    {
                        Invited = x,
                        Status = RequestStatus.Unanswered,
                    } },
                };

                await _context.Plans.AddAsync(plan);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<LoadDistributorRequest>> LoadListDistributor(string keyword)
        {
            var query = from d in _context.Distributors.Where(d => d.Name.Contains(keyword))
                        from p in _context.Plans.Where(p => p.DistributorId != d.Id).DefaultIfEmpty()
                        select new { d }
                        ;
            return await query.Select(p => new LoadDistributorRequest()
            {
                Id = p.d.Id,
                Name = p.d.Name
            }).ToListAsync();
        }

        public async Task<List<LoadUserRequest>> LoadListUser(string keyword)
        {
            var query = from u in _context.AppUsers.Where(u => u.FullName.Contains(keyword))
                        select new { u }
                        ;
            return await query.Select(p => new LoadUserRequest()
            {
                Id = p.u.Id,
                Name = p.u.FullName
            }).ToListAsync();
        }

        public async Task<List<GetAskVisitRequest>> GetRequestPlan(Guid guid)
        {
            var query = from pd in _context.PlanDetails.Where(p => p.Invited.Equals(guid))
                        from p in _context.Plans.Where( p => p.Id == pd.PlanId).DefaultIfEmpty()
                        select new { pd, p };
            return await query.Select(a => new GetAskVisitRequest()
            {
                Id = a.p.Id,
                Calendar = a.p.Calendar,
                DistributorId = a.p.DistributorId,
                Purpose = a.p.Purpose,
                TypeDate = a.p.TypeDate,
                UserAsk = a.p.UserId
            }).ToListAsync();
        }

        public async Task<List<PlanViewModel>> GetVisitPlan(Guid guid)
        {
            var query = from p in _context.Plans.Where(p => p.UserId.Equals(guid))
                        select new { p };
            return await query.Select(a => new PlanViewModel()
            {
                Calendar = a.p.Calendar,
                DistributorId = a.p.DistributorId,
                Purpose = a.p.Purpose,
                TypeDate = a.p.TypeDate,
            }).ToListAsync();
        }

        public async Task<bool> ReplyVisitPlan(Guid InvitedUser, int planId, RequestStatus reply)
        {
            var plan = await _context.PlanDetails.FirstOrDefaultAsync(x => x.PlanId == planId && x.Invited.Equals(InvitedUser));
            if(plan == null)
            {
                return false;
            }
            plan.Status = reply;
            _context.PlanDetails.Update(plan);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
