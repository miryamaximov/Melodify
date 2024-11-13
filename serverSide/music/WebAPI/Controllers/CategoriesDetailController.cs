using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesDetailController : ControllerBase
    {
        private readonly CategoriesDetail_BL categoriesDetailBL;
        public CategoriesDetailController(CategoriesDetail_BL bl)
        {
            categoriesDetailBL = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoriesDetailBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetAllByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetAllByCategoryId(int categoryId)
        {
            return Ok(await categoriesDetailBL.SelectAllByCategoryIdAsync(categoryId));
        }

        [HttpGet]
        [Route("GetByCategoryId")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            return Ok(await categoriesDetailBL.SelectByCategoryIdAsync(categoryId));
        }

        [HttpGet]
        [Route("GetAllBySongId/{songId}")]
        public async Task<IActionResult> GetAllBySongId(int songId)
        {
            return Ok(await categoriesDetailBL.SelectAllBySongIdAsync(songId));
        }

        [HttpGet]
        [Route("GetBySongId")]
        public async Task<IActionResult> GetBySongId(int songId)
        {
            return Ok(await categoriesDetailBL.SelectBySongIdAsync(songId));
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] CategoriesDetail_DTO detail)
        {
            if (detail == null) 
                return BadRequest("The object received is null");
            int res = await categoriesDetailBL.AddCategoryDetailAsync(detail);
            return res != 1 ? BadRequest("Add failed") : Ok(await categoriesDetailBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{songId}/{categoryId}")]
        public async Task<IActionResult> Delete(int songId, int categoryId)
        {
            int res = await categoriesDetailBL.DeleteBySongIdAndCategoryIdAsync(songId, categoryId);
            return res != 1 ? BadRequest("Delete failed") : Ok(await categoriesDetailBL.SelectAllAsync());
        }

    }
}