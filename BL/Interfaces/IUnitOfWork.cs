using BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methode
        int Commit();
        #endregion


       
        CategoryRepository Category { get; }
        SubCategoryRepository SubCategory { get; }
        ProductRepository  Product { get; }
        AccountRepository Account { get; }
        PaymentRepository Payment { get; }
        ModelRepository Model{ get; }
        BrandsRepository Brand { get; }
        OrderRepository Order { get; }
        OrderDetailsRepository OrderDetails { get; }
        ProductWishListRepository ProductWishList { get; }
        RateRepository Rate { get; }
        ShipperRepository Shipper { get; }
        BillingAddressRepository BillingAddress { get; }
        RoleRepository Role { get; }
    }
}
