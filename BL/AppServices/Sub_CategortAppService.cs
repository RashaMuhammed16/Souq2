using AutoMapper;
using BL.Bases;
using BL.Interfaces;
using BL.ViewModel;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
  public class Sub_CategortAppService: BaseAppService
    {
        public Sub_CategortAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<Sub_CategoryViewModel>GetAll()
        {
            return Mapper.Map<List<Sub_CategoryViewModel>>(TheUnitOfWork.SubCategory.GetAll());
        }
        public Sub_CategoryViewModel GetById(int id)
        {
            return Mapper.Map<Sub_CategoryViewModel>(TheUnitOfWork.SubCategory.GetById(id));
        }
        public bool CheckSubcategoryExists(Sub_Catogery sub_Catogery)
        {
            
            return TheUnitOfWork.SubCategory.CheckSubCategoryExists(sub_Catogery);
        }
        public bool UpdateCategory(Sub_CategoryViewModel sub_Catogery)
        {
          Sub_Catogery sub_Catogery1= Mapper.Map<Sub_Catogery>(sub_Catogery);
            TheUnitOfWork.SubCategory.Update(sub_Catogery1);
            return TheUnitOfWork.Commit() > new int();
        }
        public bool DeleteSubCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.SubCategory.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        public List<Sub_CategoryViewModel> GetAllsubCategoryWhere(int categoryID)
        {
            //    List<Product> products= TheUnitOfWork.Product.GetAllProduct().Where(p => p.Name.Contains(productToSearch)).ToList();
            var subs = TheUnitOfWork.SubCategory.GetWhere(s => s.CatogeryId == categoryID);

            return Mapper.Map<List<Sub_CategoryViewModel>>(subs);
        }

        public bool SaveNewSubCategory(Sub_CategoryViewModel sub_CategoryViewModel)
        {
            TheUnitOfWork.SubCategory.AddSubCategory(Mapper.Map<Sub_Catogery>(sub_CategoryViewModel))
;
            return TheUnitOfWork.Commit() > new int();
        }






    }
}
