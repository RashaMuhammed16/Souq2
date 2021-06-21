using BL.AppServices;
using BL.ViewModel;
using DataAccessLayer;
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
    public class AccountController : ControllerBase
    {

        private AccountAppService _accountAppService;
      
        private WishlistAppService _wishlistAppService;
        private RoleAppService _roleAppService;
        IHttpContextAccessor _httpContextAccessor;
        public AccountController(
            AccountAppService accountAppService,
           
            WishlistAppService wishlistAppService,
            RoleAppService roleAppService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._accountAppService = accountAppService;
          
            this._wishlistAppService = wishlistAppService;
            this._roleAppService = roleAppService;
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _accountAppService.GetAllAccounts();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var res = _accountAppService.GetAccountById(id);
            return Ok(res);
        }

        [HttpGet("current")]
        public IActionResult GetCurrentUser()
        {
            var userID = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var res = _accountAppService.GetAccountById(userID);
            return Ok(res);
        }
        [HttpPost("/RegisterAdmin")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserViewModel model)
        {

            return await Register(model, UserRoles.Admin);

        }

        [HttpPost("/Register")]
       // [HttpOptions]
        public async Task<IActionResult> RegisterUser([FromBody] UserViewModel model)
        {

            return await Register(model, UserRoles.User);

        }
        private async Task<IActionResult> Register(UserViewModel model, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountAppService.Register(model);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = result.Errors.FirstOrDefault().Description });

            ApplicationUserIdentity identityUser = await _accountAppService.Find(model.Email, model.PasswordHash);
            #region oldCreateCartWishlist
            ////////create cart for new user
            //////CartViewModel cartViewModel = new CartViewModel() { ApplicationUserIdentity_Id = identityUser.Id };
            //////_cartAppService.SaveNewCart(cartViewModel);

            //////WishlistViewModel wishlistViewModel = new WishlistViewModel() { ApplicationUserIdentity_Id = identityUser.Id };
            //////_wishlistAppService.SaveNewWishlist(wishlistViewModel);
            #endregion
            //////create roles
             // await _roleAppService.CreateRoles();
            await _accountAppService.AssignRole(identityUser.Id, roleName);
            //return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            return Ok(identityUser);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, UserViewModel registerViewodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //registerViewodel.PasswordHash = registerViewodel.ConfirmPassword = null;
            registerViewodel.PasswordHash = null;
            await _accountAppService.Update(registerViewodel);

            return Ok(new Response { Status = "Success", Message = "User updated successfully!" });

        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _accountAppService.Find(model.Email, model.PasswordHash);
            if (user != null)
            {
                dynamic token = await _accountAppService.CreateToken(user);

                return Ok(token);
            }
            return Unauthorized();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _accountAppService.DeleteAccount(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("count")]
        public IActionResult UsersCount()
        {
            return Ok(_accountAppService.CountEntity());
        }
        //[HttpGet("{pageSize}/{pageNumber}")]
        //public IActionResult GetUsersByPage(int pageSize, int pageNumber)
        //{
        //    return Ok(_accountAppService.GetPageRecords(pageSize, pageNumber));
        //}
      //public async Task<IActionResult> GetUser(string email,string password)
      //  {
      //      var user= await _accountAppService.Find(email,password)
            
      // }

    }
   
}
