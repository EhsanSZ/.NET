using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Bugeto.Models.Services;

namespace WebApi.Bugeto.Controllers
{
    [Route("api/[controller]")] 
    //[Route("api/v{version:apiVersion}/[controller]")] //api/v1/r
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoriesController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// لیست دسته بندی ها را دیافت کن
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryRepository.GetAll());
        }

        /// <summary>
        ///  اطلاعات دسته بندی رو دریافت کن
        /// </summary>
        /// <param name="Id">شناسه دسته بندی</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_categoryRepository.Find(Id));
        }
        [HttpPut]

        public IActionResult Put(CategoryDto categoryDto)
        {
            return Ok(_categoryRepository.Edit(categoryDto));
        }

        [HttpPost]
        public IActionResult Post(string Name)
        {
            var result = _categoryRepository.AddCategory(Name);
            return Created(Url.Action(nameof(Get), "Categories", new { Id = result }, Request.Scheme), true);

        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok(_categoryRepository.Delete(Id));
        }
    }
}

