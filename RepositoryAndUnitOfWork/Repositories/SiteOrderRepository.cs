﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryAndUnitOfWork.DomainModels;
using RepositoryAndUnitOfWork.ORM;
using RepositoryAndUnitOfWork.RepositoryInterfaces;

namespace RepositoryAndUnitOfWork.Repositories
{
    public class SiteOrderRepository : ISiteOrderRepository
    {
        private FreelancerBlogContext _context;

        public SiteOrderRepository(FreelancerBlogContext context)
        {
            _context = context;
        }

        public void Add(SiteOrder entity)
        {
            _context.SiteOrders.Add(entity);
        }

        public void Remove(SiteOrder entity)
        {
            _context.SiteOrders.Remove(entity);
        }

        public void Update(SiteOrder entity)
        {
            _context.SiteOrders.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public Task<SiteOrder> FindByIdAsync(int id)
        {
            return _context.SiteOrders.SingleAsync(s => s.SiteOrderId.Equals(id));
        }

        public Task<List<SiteOrder>> GetAllAsync()
        {
            return _context.SiteOrders.ToListAsync();
        }

        public Task<int> AddSiteOrderAsync(SiteOrder siteOrder)
        {
            _context.SiteOrders.Add(siteOrder);

            return _context.SaveChangesAsync();
        }
    }
}
