using AutoMapper;
using BL.Configurations;
using BL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class BaseAppService : IDisposable
    {

        #region Vars
        protected IUnitOfWork TheUnitOfWork { get; set; }
        protected readonly IMapper Mapper = MapperConfig.Mapper;
      public  RoleManager<IdentityRole> roleManger;
        #endregion

        #region CTR
        public BaseAppService()
        {
            TheUnitOfWork = new UnitOfWork(roleManger);
        }

        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }
        #endregion
    }
}
