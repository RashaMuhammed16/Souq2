using AutoMapper;
using BL.ViewModel;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>()
                //.ForMember(vm => vm.ColorName, vm => vm.MapFrom(m => m.Color.Name))
                //.ForMember(vm => vm.CategoryName, vm => vm.MapFrom(m => m.Category.Name))
                .ReverseMap()
               
                .ForMember(m => m.Sub_Catogery, m => m.Ignore());

            CreateMap<Order, OrderViewModel>().ReverseMap();
          

            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<Rate, RateViewModel>().ReverseMap().ForMember(r => r.User, r => r.Ignore()).ForMember(r=>r.Product,r=>r.Ignore());
                
        

           // CreateMap<ProductCart, ProductCartViewModel>().ReverseMap();
            CreateMap<ProductWishList, ProductWishListViewModel>().ReverseMap();

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Sub_Catogery, Sub_CategoryViewModel>().ReverseMap().ForMember(r => r.Category, r => r.Ignore())
            ;
            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<Model, ModelViewModel>().ReverseMap();
            CreateMap<BillingAddress, BillingAddressModelView>().ReverseMap();

            //  CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<Wishlist, WishlistViewModel>().ReverseMap();

            CreateMap<ApplicationUserIdentity, LoginViewModel>().ReverseMap();
            CreateMap<ApplicationUserIdentity, UserViewModel>().ReverseMap();
          //  CreateMap<Sub_Catogery, Sub_CategoryViewModel>().ReverseMap().ForMember(s=>s.Category);
          //  CreateMap<Color, ColorDTO>().ReverseMap();
        }
    }
}
