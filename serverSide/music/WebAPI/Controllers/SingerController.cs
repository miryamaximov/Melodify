using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        private readonly Singer_BL singerBL;
        public SingerController(Singer_BL bl)
        {
            singerBL = bl;
        }

        [HttpGet]
        [Route("GetAllNotActive")]
        public async Task<IActionResult> GetAllNotActive()
        {
            return Ok(await singerBL.SelectAllNotActiveAsync());
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await singerBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetById/{singerId}")]
        public async Task<IActionResult> GetById(int singerId)
        {
            Singer_DTO s = await singerBL.SelectByIdAsync(singerId);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpGet]
        [Route("GetByStr/{str}")]
        public async Task<IActionResult> GetByStr(string str)
        {
            return Ok(await singerBL.SelectByNameContainStrAsync(str));
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Singer_DTO singer)
        {
            if (singer == null)
                return BadRequest("The object received is null");
            int res = await singerBL.AddSingerAsync(singer);
            return res != 1 ? BadRequest("Add failed") : Ok(await singerBL.SelectAllAsync());
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] Singer_DTO singer)
        {
            if (singer == null)
                return BadRequest("The object received is null");
            return await singerBL.UpdateAsync(singer) != 1 ? BadRequest("Update failed") :
                Ok(await singerBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{singerId}")]
        public async Task<IActionResult> Delete(int singerId)
        {
            int res = await singerBL.DeleteAsync(singerId);
            return res != 1 ? BadRequest("Delete failed") :
                Ok(await singerBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("DeleteCompletely/{singerId}")]
        public async Task<IActionResult> DeleteCompletely(int singerId)
        {
            return await singerBL.DeleteCompletelyAsync(singerId) != 1?  BadRequest("Delete failed") :
                Ok(await singerBL.SelectAllAsync());
        }
    }
}
