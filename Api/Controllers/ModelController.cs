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
    public class ModelController : ControllerBase
    {
       ModelAppService _modelAppService;
        BrandAppService BrandAppService;
        public ModelController(ModelAppService modelAppService,BrandAppService brandAppService)
        {
            this._modelAppService = modelAppService;
            this.BrandAppService = brandAppService;

        }
        [HttpGet("GetModels/{id}")]
        public IActionResult GetAllsubCategoryWhere(int id)
        {
            return Ok(_modelAppService.GetAllModelsWhere(id));
        }
        [HttpGet]
        public IActionResult GetAllModels()
        {
            var models = _modelAppService.GetAllModels();
            foreach (var model in models)
                model.BrandName = BrandAppService.GetBrand(model.BrandId).Name;
           return Ok(models);
        }
        [HttpGet("{id}")]
        public IActionResult GetModelById(int id)
        {
            return Ok(_modelAppService.GetModel(id));
        }
        [HttpPost]
        public IActionResult Create(ModelViewModel modelViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _modelAppService.SaveNewModel(modelViewModel);

            //string urlDetails = Url.Link("DefaultApi", new { id = categoryViewModel.ID });

            //return Created(urlDetails, "Added Sucess");
           
            
            return Created("CreateModel", modelViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, ModelViewModel modelViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _modelAppService.UpdatModel(modelViewModel);
                return Ok(modelViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _modelAppService.DeleteModel(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
