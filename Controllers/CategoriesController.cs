using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using car_service.API.Models;
using car_service.API.Services;

namespace car_service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private CategoryService _categoryService;
        public CategoriesController (CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            
            return _categoryService.GetAllCategory();
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<Category>> GetId(int id)
        {
            return await _categoryService.GetById(id);
        }
    }
}