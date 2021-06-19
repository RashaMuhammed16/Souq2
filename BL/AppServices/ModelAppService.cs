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
    public class ModelAppService : BaseAppService
    {
        public ModelAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<ModelViewModel> GetAllModels()
        {

            return Mapper.Map<List<ModelViewModel>>(TheUnitOfWork.Model.GetAllModel());
        }
        public List<ModelViewModel> GetAllModelsWhere(int brandId)
        {
            //    List<Product> products= TheUnitOfWork.Product.GetAllProduct().Where(p => p.Name.Contains(productToSearch)).ToList();
            var models = TheUnitOfWork.Model.GetWhere(m => m.BrandId == brandId);

            return Mapper.Map<List<ModelViewModel>>(models);
        }

        public ModelViewModel GetModel(int id)
        {
            return Mapper.Map<ModelViewModel>(TheUnitOfWork.Model.GetById(id));
        }


        public bool SaveNewModel(ModelViewModel ModelViewModel)
        {
            bool result = false;
            var shipper = Mapper.Map<Model>(ModelViewModel);
            if (TheUnitOfWork.Model.Insert(shipper))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdatModel(ModelViewModel modelViewModel)
        {
            var model = Mapper.Map<Model>(modelViewModel);
            TheUnitOfWork.Model.Update(model);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteModel(int id)
        {
            bool result = false;

            TheUnitOfWork.Model.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckModelExists(ModelViewModel modelViewModel)
        {
            var model = Mapper.Map<Model>(modelViewModel);
            return TheUnitOfWork.Model.CheckModelExists(model);
        }
        #endregion

    }
}