using AutoMapper;
using BL.Interfaces;
using BL.ViewModel;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
  public  class RoleAppService : Bases.BaseAppService
    {
        public RoleAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }

        public async Task CreateRoles()
        {
            await TheUnitOfWork.Role.CreateRoles();
        }
        public RoleViewModel GetRoleById(string id)
        {
            if (id == null || id == "")
                throw new ArgumentNullException();

            return Mapper.Map<RoleViewModel>(TheUnitOfWork.Role.GetRoleByID(id));
        }
        public IdentityResult Create(string rolename)
        {
            return TheUnitOfWork.Role.Create(rolename);
        }
        public async Task<IdentityResult> Update(RoleViewModel roleViewModel)
        {
            if (roleViewModel == null)
                throw new ArgumentNullException();
            if (roleViewModel.Id == null || roleViewModel.Id == string.Empty)
                throw new ArgumentException();

            var role = Mapper.Map<IdentityRole>(roleViewModel);
            return await TheUnitOfWork.Role.UpdateRole(role);
        }
        public List<RoleViewModel> GetAllRoles()
        {
            return Mapper.Map<List<RoleViewModel>>(TheUnitOfWork.Role.getAllRoles());
        }
        public bool DeleteRole(string id)
        {
            if (id == null || id == "")
                throw new ArgumentNullException();
            bool result = false;

            TheUnitOfWork.Role.DeleteRole(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        //    public List<UserViewModel> getAllUsers(string id)
        //    {
        //        List<ApplicationUserIdentity> users = new List<ApplicationUserIdentity>();
        //        var role = TheUnitOfWork.Role.getAllRoles().FirstOrDefault(r => r.Id == id);
        //        //role.users is about table relation called usersRoles in Db

        //        TheUnitOfWork.Account.GetWhere(a=>a.rol)
        //            var user = TheUnitOfWork.Account.GetAccountById(userRole.ToString);
        //            if (user.isDeleted == false)
        //                users.Add(user);


        //        return Mapper.Map<List<RegisterViewodel>>(users);
        //    }
        //}
    }
}