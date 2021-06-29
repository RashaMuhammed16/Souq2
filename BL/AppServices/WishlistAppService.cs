using AutoMapper;
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
    public class WishlistAppService:Bases.BaseAppService
    {
        public WishlistAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }

        #region CURD

        public List<WishlistViewModel> GetAllWishlists()
        {
            return Mapper.Map<List<WishlistViewModel>>(TheUnitOfWork.wishListRepository.GetAllWishlist());
        }
        public WishlistViewModel GetWishlist(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<WishlistViewModel>(TheUnitOfWork.wishListRepository.GetById(id));
        }



        public bool SaveNewWishlist(WishlistViewModel wishlistViewModel)
        {
            if (wishlistViewModel == null)
                throw new ArgumentNullException();

            bool result = false;
            var wishlist = Mapper.Map<Wishlist>(wishlistViewModel);
            if (TheUnitOfWork.wishListRepository.Insert(wishlist))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool CreateUserWishlist(string userId)
        {
            bool result = false;
            Wishlist userWishlist = new Wishlist() { ID = userId };
            if (TheUnitOfWork.wishListRepository.Insert(userWishlist))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteWishlist(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;

            TheUnitOfWork.wishListRepository.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        //public void SaveNewWishlist(WishlistViewModel wishlistViewModel)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
