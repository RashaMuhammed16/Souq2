using BL.AppServices;
using DataAccessLayer.Models;
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
 
    public class RateController : ControllerBase
    {
        RateAppService rateAppService;
        HttpContextAccessor HttpContextAccessor;
        RateController(RateAppService rate, HttpContextAccessor httpContextAccessor)
        {
            this.rateAppService = rate;
            this.HttpContextAccessor = httpContextAccessor;
        }
        [HttpGet("{productId}")]
        public IActionResult GetUserReviewOnProduct(int productId)
        {
            var userId = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var UserReview = rateAppService.GetUserRateOnProduct(userId, productId);
            return Ok(UserReview);
        }
        [HttpPost]
        public IActionResult CreateReview(Rate ProductRate)


        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not Correct");
            }
            var userId = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ProductRate.UserID = userId;
            var UserReview = rateAppService.SaveNewReview(ProductRate);
            return Ok(UserReview);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUserRate(int id)
        {
            var userId = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            rateAppService.DeleteReview(id);
            return NoContent();
        }
        [HttpGet]
        public IActionResult ReviewCount(int productId)
        {
            int Count = rateAppService.CountEntity(productId);
            return Ok(Count);
        }
        [HttpPut]
        public IActionResult EditReview(int id, Rate rate)
        {
            if (id != rate.ID)
            {
                return BadRequest("Ids Not Matched");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userID = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            rate.UserID = userID;
            return Ok(rateAppService.UpdateRate(rate));

        }

    }
}
