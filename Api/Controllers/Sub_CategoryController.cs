using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.AppServices;
using BL.ViewModel;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sub_CategoryController : ControllerBase
    {
        Sub_CategortAppService sub_CategortAppService;

        public Sub_CategoryController(Sub_CategortAppService  sub_CategortAppService)
        {
            this.sub_CategortAppService = sub_CategortAppService;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(sub_CategortAppService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetSubCategoryById(int id)
        {
            return Ok(sub_CategortAppService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(Sub_CategoryViewModel subcategoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                sub_CategortAppService.SaveNewSubCategory(subcategoryViewModel);

                //string urlDetails = Url.Link("DefaultApi", new { id = categoryViewModel.ID });
                //return Created(urlDetails, "Added Sucess");
                return Created("CreateCategory", subcategoryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Sub_CategoryViewModel SubcategoryViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                sub_CategortAppService.UpdateCategory(SubcategoryViewModel);
                return Ok(SubcategoryViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Sub_CategoryViewModel sub_CategoryViewModel = sub_CategortAppService.GetById(id);
            try
            {
                sub_CategortAppService.DeleteSubCategory(sub_CategoryViewModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
