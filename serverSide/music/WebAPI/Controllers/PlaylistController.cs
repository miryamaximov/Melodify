using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly Playlist_BL playlistBL;
        public PlaylistController(Playlist_BL bl)
        {
            playlistBL = bl;
        }

        [HttpGet]
        [Route("GetAllNotActive")]
        public async Task<IActionResult> GetAllNotActive()
        {
            return Ok(await playlistBL.SelectAllNotActiveAsync());
        }

        [HttpGet]
        [Route("GetByIdNotActive/{playlistId}")]
        public async Task<IActionResult> GetByIdNotActive(int playlistId)
        {
            Playlist_DTO p = await playlistBL.SelectByIdNotActiveAsync(playlistId);
            return p == null ? NotFound() : Ok(p);  
        }

        [HttpGet]
        [Route("GetAllByUserIdNotActive/{userId}")]
        public async Task<IActionResult> GetAllByUserIdNotActive(int userId)
        {
            return Ok(await playlistBL.SelectAllByUserIdNotActiveAsync(userId));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await playlistBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetById/{playlistId}")]
        public async Task<IActionResult> GetById(int playlistId)
        {
            Playlist_DTO p = await playlistBL.SelectByIdAsync(playlistId);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpGet]
        [Route("GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            return Ok(await playlistBL.SelectAllByUserIdAsync(userId));
        }

        [HttpGet]
        [Route("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            Playlist_DTO p = await playlistBL.SelectByUserIdAsync(userId);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Playlist_DTO playlist)
        {
            if (playlist == null)
                return BadRequest("The object received is null");
            int res = await playlistBL.AddPlaylistAsync(playlist);
            return res != 1 ? BadRequest("Add failed") : Ok(await playlistBL.SelectAllAsync());
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] Playlist_DTO playlist)
        {
            if (playlist == null)
                return BadRequest("The object received is null");
            int res = await playlistBL.UpdateAsync(playlist);
            return res != 1 ? BadRequest("Update failed") : Ok(await playlistBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{playlistId}")]
        public async Task<IActionResult> Delete(int playlistId)
        {
            int res = await playlistBL.DeleteAsync(playlistId);
            return res != 1 ? BadRequest("Delete failed") : Ok(await playlistBL.SelectAllAsync());
        }
    }
}
