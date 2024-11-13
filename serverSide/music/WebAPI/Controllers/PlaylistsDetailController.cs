using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsDetailController : ControllerBase
    {
        private readonly PlaylistsDetail_BL playlistsDetailBL;
        public PlaylistsDetailController(PlaylistsDetail_BL bl)
        {
            playlistsDetailBL = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await playlistsDetailBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetAllByPlaylistId/{playlistId}")]
        public async Task<IActionResult> GetAllByPlaylistId(int playlistId)
        {
            return Ok(await playlistsDetailBL.SelectAllByPlaylistIdAsync(playlistId));
        }

        [HttpGet]
        [Route("GetByPlaylistId/{playlistId}")]
        public async Task<IActionResult> GetByPlaylistId(int playlistId)
        {
            PlaylistDetail_DTO p = await playlistsDetailBL.SelectByPlaylistIdAsync(playlistId);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpGet]
        [Route("GetAllBySongId/{songId}")]
        public async Task<IActionResult> GetAllBySongId(int songId)
        {
            return Ok(await playlistsDetailBL.SelectBySongIdAsync(songId));
        }

        [HttpGet]
        [Route("GetBySongId/{songId}")]
        public async Task<IActionResult> GetBySongId(int songId)
        {
            PlaylistDetail_DTO p = await playlistsDetailBL.SelectBySongIdAsync(songId);
            return p == null ? NotFound() : Ok(p);
        }


        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] PlaylistDetail_DTO playlist)
        {
            if (playlist == null)
                return BadRequest("The object received is null");
            int res = await playlistsDetailBL.AddPlaylistDetailAsync(playlist);
            return res != 1 ? BadRequest("Add failed") : Ok(await playlistsDetailBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{songId}/{playlistId}")]
        public async Task<IActionResult> Delete(int songId, int playlistId)
        {
            int res = await playlistsDetailBL.DeleteBySongIdAndPlaylistIdAsync(songId, playlistId);
            return res != 1 ? BadRequest("Delete failed") : Ok(await playlistsDetailBL.SelectAllAsync());
        }
    }
}
