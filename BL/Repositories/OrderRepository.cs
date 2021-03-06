using BL.Bases;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        private DbContext EC_DbContext;
        public OrderRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }


        public List<Order> GetAllOrder()
        {
            return GetAll().ToList();
        }

        public bool InsertOrder(Order order)
        {
            return Insert(order);
        }
        public void UpdateOrder(Order order)
        {
            Update(order);
        }
        public void DeleteOrder(int id)
        {
            Delete(id);
        }

        public bool CheckOrderExists(Order order)
        {
            return GetAny(l => l.Id == order.Id);
        }

        public Order GetOrderById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }



        public List<Order> OrderByTimeDecending()
        {
            return EC_DbContext.Set<Order>().OrderByDescending(o => o.Orderdate).Include(o => o.ApplicationUserIdentity_Id).ToList();
        }
        public int CountEntityForSpeCifcUser(string userID)
        {
            return DbSet.Where(o => o.ApplicationUserIdentity_Id == userID).Count();
        }
        public override IEnumerable<Order> GetPageRecords(int pageSize, int pageNumber)
        {
            pageSize = (pageSize <= 0) ? 10 : pageSize;
            pageNumber = (pageNumber < 1) ? 0 : pageNumber - 1;

            var kk = DbSet.Skip(pageNumber * pageSize).Take(pageSize).Include(order => order.appUser);

            return DbSet.Skip(pageNumber * pageSize).Take(pageSize).Include(order => order.appUser);
        }
        public IEnumerable<Order> GetPageRecordsForSpeceficUser(string userID, int pageSize, int pageNumber)
        {
            pageSize = (pageSize <= 0) ? 10 : pageSize;
            pageNumber = (pageNumber < 1) ? 0 : pageNumber - 1;

            return DbSet.Where(o => o.ApplicationUserIdentity_Id == userID).Skip(pageNumber * pageSize).Take(pageSize).Include(order => order.appUser);


        }

    }
}
