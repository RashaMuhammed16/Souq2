using BL.AppServices;
using BL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryAppService categoryAppservice=new CategoryAppService();

        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoryViewModel newCategory)
        {
            //categoryAppservice.SaveNewCategory(newCategory);
            return Ok(categoryAppservice.SaveNewCategory(newCategory));
        }
       
    }
}

