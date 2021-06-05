﻿using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Bases;
using BL.ViewModel;
using DataAccessLayer.Models;
using BL.Interfaces;

namespace BL.AppServices
{
    public class OrderAppService: BaseAppService
    { 
        #region CURD
        public List<OrderViewModel> GetAllOrder()
        {

            return Mapper.Map<List<OrderViewModel>>(TheUnitOfWork.Order.GetAllOrder());
        }
        public OrderViewModel GetOrder(int id)
        {
            return Mapper.Map<OrderViewModel>(TheUnitOfWork.Order.GetById(id));
        }



        public bool SaveNewOrder(OrderViewModel orderViewModel)
        {
            bool result = false;
            var order = Mapper.Map<Order>(orderViewModel);
            if (TheUnitOfWork.Order.Insert(order))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = Mapper.Map<Order>(orderViewModel);
            TheUnitOfWork.Order.Update(order);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteOrder(int id)
        {
            bool result = false;

            TheUnitOfWork.Order.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(OrderViewModel orderViewModel)
        {
            Order order = Mapper.Map<Order>(orderViewModel);
            return TheUnitOfWork.Order.CheckOrderExists(order);
        }
        #endregion

    }
}

