using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedPlaylistsDetailController : ControllerBase
    {
        private readonly SharedPlaylistsDeatail_BL sharedPlaylistsDeatailBL;
        public SharedPlaylistsDetailController(SharedPlaylistsDeatail_BL bl)
        {
            sharedPlaylistsDeatailBL = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await sharedPlaylistsDeatailBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetAllByPlaylistId/{playlistId}")]
        public async Task<IActionResult> GetAllByPlaylistId(int playlistId)
        {
            return Ok(await sharedPlaylistsDeatailBL.SelectAllByPlaylistIdAsync(playlistId));
        }

        [HttpGet]
        [Route("GetByPlaylistId/{playlistId}")]
        public async Task<IActionResult> GetByPlaylistId(int playlistId)
        {
            SharedPlaylistsDetail_DTO s = await sharedPlaylistsDeatailBL.SelectByPlaylistIdAsync(playlistId);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpGet]
        [Route("GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            return Ok(await sharedPlaylistsDeatailBL.SelectAllByUserIdAsync(userId));
        }

        [HttpGet]
        [Route("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            SharedPlaylistsDetail_DTO s = await sharedPlaylistsDeatailBL.SelectByUserIdAsync(userId);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] SharedPlaylistsDetail_DTO detail)
        {
            if (detail == null)
                return BadRequest("The object received is null");
            int res = await sharedPlaylistsDeatailBL.AddSharedPlaylistDetailAsync(detail);
            return res != 1 ? BadRequest("Add failed") : Ok(await sharedPlaylistsDeatailBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{playlistId}/{userId}")]
        public async Task<IActionResult> Delete(int playlistId, int userId)
        {
            return await sharedPlaylistsDeatailBL.DeleteByPlaylistIdAndUserIdAsync(playlistId, userId) != 1 ?
                BadRequest("Delete failed") : Ok(await sharedPlaylistsDeatailBL.SelectAllAsync());
        }
    }
}
