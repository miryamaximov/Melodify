using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {

        private readonly Album_BL albumBL;

        public AlbumController(Album_BL bL)
        {
            albumBL = bL;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await albumBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetByAlbumId/{albumId}")]
        public async Task<IActionResult> GetByAlbumId(int albumId)
        {
            Album_DTO a = await albumBL.SelectByAlbumIdAsync(albumId);
            return a == null ? NotFound() : Ok(a);
        }

        [HttpGet]
        [Route("GetAllBySingerId/{singerId}")]
        public async Task<IActionResult> GetAllBySingerId(int singersId)
        {
            return Ok(await albumBL.SelectAllBySingerIdAsync(singersId));
        }

        [HttpGet]
        [Route("GetBySingerId/{singerId}")]
        public async Task<IActionResult> GetBySingerId(int singerId)
        {
            Album_DTO album = await albumBL.SelectBySingerIdAsync(singerId);
            return album == null ? NotFound() : Ok(album);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Album_DTO album)
        {
            if (album == null)
                return BadRequest("The object received is null");
            int res = await albumBL.AddAlbumAsync(album);
            return res == -1 ? BadRequest("Add failed") : Ok(await albumBL.SelectAllAsync());
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] Album_DTO album)
        {
            if (album == null) 
                return BadRequest("The object received is null");
            int res = await albumBL.UpdateAsync(album);
            return res != 1 ? BadRequest("Update failed") : Ok(await albumBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{albumId}")]
        public async Task<IActionResult> Delete(int albumId)
        {
            int res = await albumBL.DeleteAsync(albumId);
            return res != 1 ? BadRequest("Delete failed") : Ok(await albumBL.SelectAllAsync());
        }


    }
}
