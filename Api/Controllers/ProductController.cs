using BL.AppServices;
using BL.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
    public class ProductController : Controller
    {
        ProductAppService _productAppService;

        public ProductController(ProductAppService productAppService)
        {
            this._productAppService = productAppService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productAppService.GetAllProduct();
            
            return Ok(_productAppService.GetAllProduct());
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {


            var res = _productAppService.GetProduct(id);
            return Ok(_productAppService.GetProduct(id));
        }
        [HttpGet("newArrivals/{numOfProducts}")]
        public IActionResult GetNewArrivalsProducts(int numOfProducts)
        {
            return Ok(_productAppService.GetNewArrivalsProduct(numOfProducts));
        }
        [HttpGet("relatedProducts/{categoryId}/{numberOfProducts}")]
        public IActionResult GetRandomRelatedProducts(int categoryId, int numberOfProducts)
        {
            return Ok(_productAppService.GetRandomRelatedProducts(categoryId, numberOfProducts));
        }


        [HttpGet("GetAllWith/{scategoryId}/")]
        public IActionResult GetproductsOfCategory(int scategoryId)
        {
            return Ok(_productAppService.GetAllProductWhere(scategoryId));
        }
        [HttpGet("subcategory/{subcatId}/{pageSize}/{pageNumber}")]
        public IActionResult GetProductsBySubCategoryIdPagination(int catId, int pageSize, int pageNumber)
        {
            return Ok(_productAppService.GetProductsBySubCategoryIdPagination(catId, pageSize, pageNumber));
        }
        
        [HttpGet("search/{searchKeyWord}")]
        public IActionResult GetProductsBySearchKeyWord(string searchKeyWord)
        {
            return Ok(_productAppService.GetProductsBySearch(searchKeyWord));
        }
        [HttpPost]

        public IActionResult Create(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
           
                _productAppService.SaveNewProduct(productViewModel);
                
                return Created("CreateProduct", productViewModel);
            
            ////catch (Exception ex)
            ////{
            ////    return BadRequest(ex.Message);

            ////}
        }

        [HttpPut("{id}")]
      
        public IActionResult Edit(int id, ProductViewModel productViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _productAppService.UpdateProduct(productViewModel);
                return Ok(productViewModel);
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
                _productAppService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("count")]
        public IActionResult ProductsCount(int categoryId = 0, int colorId = 0)
        {
            return Ok(_productAppService.CountEntity(categoryId, colorId));
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetProductsByPage(int pageSize, int pageNumber)
        {
            return Ok(_productAppService.GetPageRecords(pageSize, pageNumber));
        }

    }
}
