using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsDetailController : ControllerBase
    {
        private readonly AlbumsDetail_BL albumsDetailBL;
        public AlbumsDetailController(AlbumsDetail_BL bl)
        {
            albumsDetailBL = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await albumsDetailBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetAllByAlbumId/{albumId}")]
        public async Task<IActionResult> GetAllByAlbumId(int albumId)
        {
            return Ok(await albumsDetailBL.SelectAllByAlbumIdAsync(albumId));
        }

        [HttpGet]
        [Route("GetByAlbumId/{albumId}")]
        public async Task<IActionResult> GetByAlbumId(int albumId)
        {
            AlbumsDetail_DTO a = await albumsDetailBL.SelectByAlbumId(albumId);
            return a == null ? NotFound() : Ok(a);
        }

        [HttpGet]
        [Route("GetBySongId/{songId}")]
        public async Task<IActionResult> GetBySongId(int songId)
        {
            AlbumsDetail_DTO a = await albumsDetailBL.SelectBySongIdAsync(songId);
            return a == null? NotFound() : Ok(a);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] AlbumsDetail_DTO detail)
        {
            if (detail == null)
                return BadRequest("The object received is null");
            int res = await albumsDetailBL.AddAlbumDetailAsync(detail);
            return res != 1 ? BadRequest("Add failed") : Ok(await albumsDetailBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{songId}")]
        public async Task<IActionResult> Delete(int songId)
        {
            int res = await albumsDetailBL.DeleteBySongIdAsync(songId);
            return res != 1 ? BadRequest("Delete failed") : Ok(await albumsDetailBL.SelectAllAsync());
        }
    }
}
