using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly User_BL userBL;
        public UserController(User_BL bl)
        {
            userBL = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await userBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetById/{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            User_DTO u = await userBL.SelectByIdAsync(userId);
            return u == null ? NotFound() : Ok(u);
        }

        [HttpGet]
        [Route("GetByPassword/{password}")]
        public async Task<IActionResult> GetByPassword(string password)
        {
            User_DTO u = await userBL.SelectByPasswordAsync(password);
            return u == null ? NotFound() : Ok(u);
        }

        [HttpGet]
        [Route("GetByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            User_DTO u = await userBL.SelectByEmailAsync(email);
            return u == null ? NotFound() : Ok(u);  
        }

        [HttpGet]
        [Route("GetByNameAndPassword/{name}/{password}")]
        public async Task<IActionResult> GetByNameAndPassword(string name, string password)
        {
            User_DTO u = await userBL.SelectByNameAndPasswordAsync(name, password);
            return u == null ? NotFound() : Ok(u);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] User_DTO user)
        {
            if (user == null)
                return BadRequest("The object received is null");
            return await userBL.AddUserAsync(user) != 1 ? BadRequest("Add failed") :
                Ok(await userBL.SelectAllAsync());
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] User_DTO user)
        {
            if (user == null)
                return BadRequest("The object received is null");
            return await userBL.UpdateAsync(user) != 1 ? BadRequest("Update failed") :
                Ok(await userBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            return await userBL.DeleteAsync(userId) != 1 ? BadRequest("Delete failed") :
                Ok(await userBL.SelectAllAsync());
        }
    }
}
