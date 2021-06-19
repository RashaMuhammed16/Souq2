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
   public class SubCategoryRepository:BaseRepository<Sub_Catogery>
    {
   
      public  SubCategoryRepository(DbContext context):base(context)
        {

        }
        public void AddSubCategory(Sub_Catogery sub_Category)
        {
            Insert(sub_Category);
        }
        public IQueryable<Sub_Catogery> GetWheree(System.Linq.Expressions.Expression<Func<Sub_Catogery, bool>> filter = null, string includeProperties = "")
        {
            return GetWhere(filter);
        }

        public IEnumerable<Sub_Catogery>GetAllSubCategory()
        {
            return GetAll().Include(s=>s.Category).ToList();
        }
        public bool CheckSubCategoryExists(Sub_Catogery sub_Catogery)
        {
            return GetAny(sub_c => sub_Catogery.ID == sub_c.ID);
        }
        public Sub_Catogery GetSubCategoryById(int id)
        {
            return GetById(id);
        }
        public void UpdateCategory(Sub_Catogery sub_Catogery)
        {
            Update(sub_Catogery);
        }
        public void delete_SubCategory(Sub_Catogery sub_Catogery)
        {
            Delete(sub_Catogery);
        }

       

    }
}
