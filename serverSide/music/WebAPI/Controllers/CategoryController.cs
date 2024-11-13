using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Category_BL categoryBL;
        public CategoryController(Category_BL bl)
        {
            categoryBL = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetById/{categoryId}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            return Ok(await categoryBL.SelectByIdAsync(categoryId));
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Category_DTO category)
        {
            if (category == null) 
                return BadRequest("The object received is null");
            int res = await categoryBL.AddCategory(category);
            return res != 1 ? BadRequest("Add failed") : Ok(await categoryBL.SelectAllAsync());
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] Category_DTO category)
        {
            if (category == null)
                return BadRequest("The object received is null");
            int res = await categoryBL.UpdateAsync(category);
            return res != 1 ? BadRequest("Update failed") : Ok(await categoryBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            return await categoryBL.DeleteAsync(categoryId) != 1 ? BadRequest("Delete failed") : Ok(await categoryBL.SelectAllAsync());
        }
    }
}
