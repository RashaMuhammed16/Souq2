using BL.AppServices;
using BL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private PaymentAppService _paymentAppService;
        private IHttpContextAccessor _httpContextAccessor;
        public PaymentController(PaymentAppService paymentAppService, IHttpContextAccessor httpContextAccessor)
        {
            _paymentAppService = paymentAppService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult GetAllPayment()
        {
            var payments = _paymentAppService.GetAllPayments();
            return Ok(payments);
        }

        [HttpPost]
        public IActionResult Create(PaymentViewModel paymentViewModel)
        {
            var userID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            paymentViewModel.ApplicationUserIdentity_Id =  userID;
            var payments = _paymentAppService.GetAllPayments();
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            try
            {
                _paymentAppService.SaveNewPayment(paymentViewModel);

                return Created("Createed", paymentViewModel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }


    }
}
