using BL;
using DAL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class SongController : ControllerBase
    {
        private readonly Song_BL songBL;
        public SongController(Song_BL bl)
        {
            songBL = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await songBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetBySongId/{songId}")]
        public async Task<IActionResult> GetBySongId(int songId)
        {
            Song_DTO s = await songBL.SelectBySongIdAsync(songId);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpGet]
        [Route("GetAllBySingerId/{singerId}")]
        public async Task<IActionResult> GetAllBySingerId(int singerId)
        {
            return Ok(await songBL.SelectAllBySingerIdAsync(singerId));
        }

        [HttpGet]
        [Route("GetBySingerId/{singerId}")]
        public async Task<IActionResult> GetBySingerId(int singerId)
        {
            Song_DTO s = await songBL.SelectBySingerIdAsync(singerId);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpGet]
        [Route("GetByNumLikes/{numLikes}")]
        public async Task<IActionResult> GetByNumLikes(int numLikes)
        {
            return Ok(await songBL.SelectAllByNumLikesAsync(numLikes));
        }

        [HttpGet]
        [Route("GetByNumLikesAbove/{numLikes}")]
        public async Task<IActionResult> GetByNumLikesAbove(int numLikes)
        {
            return Ok(await songBL.SelectAllByNumLikesAboveAsync(numLikes));
        }

        [HttpGet]
        [Route("GetByNumLikesLess/{numLikes}")]
        public async Task<IActionResult> GetByNumLikesLess(int numLikes)
        {
            return Ok(await songBL.SelectAllByNumLikesLessAsync(numLikes));
        }

        [HttpGet]
        [Route("GetByPublishingDate/{publishingDate}")]
        public async Task<IActionResult> GetByPublishingDate(DateTime publishingDate)
        {
            return Ok(await songBL.SelectAllByPublishingDateAsync(publishingDate));
        }

        [HttpGet]
        [Route("GetByPublishingDateAfter/{publishingDate}")]
        public async Task<IActionResult> GetByPublishingDateAfter(DateTime publishingDate)
        {
            return Ok(await songBL.SelectAllByPublishingDateAfterAsync(publishingDate));
        }

        [HttpGet]
        [Route("GetByPublishingDateBefore/{publishingDate}")]
        public async Task<IActionResult> GetByPublishingDateBefore(DateTime publishingDate)
        {
            return Ok(await songBL.SelectAllByPublishingDateBeforeAsync(publishingDate));
        }

        [HttpGet]
        [Route("GetByUploadDate/{uploadDate}")]
        public async Task<IActionResult> GetByUploadDate(DateTime uploadDate)
        {
            return Ok(await songBL.SelectAllByUploadDateAsync(uploadDate));
        }

        [HttpGet]
        [Route("GetByUploadDateAfter/{uploadDate}")]
        public async Task<IActionResult> GetByUploadDateAfter(DateTime uploadDate)
        {
            return Ok(await songBL.SelectAllByUploadDateAfterAsync(uploadDate));
        }

        [HttpGet]
        [Route("GetByUploadDateBefore/{uploadDate}")]
        public async Task<IActionResult> GetByUploadDateBefore(DateTime uploadDate)
        {
            return Ok(await songBL.SelectAllByUploadDateBeforeAsync(uploadDate));
        }

        [HttpGet]
        [Route("GetByStr/{str}")]
        public async Task<IActionResult> GetByStr(string str)
        {
            return Ok(await songBL.SelectAllContainStrInNameAsync(str));
        }


        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Song_DTO song)
        {
            if (song == null)
                return BadRequest("The object received is null");
            return await songBL.AddSongAsync(song) != 1 ? BadRequest("Add failed") :
                Ok(await songBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{songId}")]
        public async Task<IActionResult> Delete(int songId)
        {
            return await songBL.DeleteByIdAsync(songId) != 1 ? BadRequest("Delete failed") :
                Ok(await songBL.SelectAllAsync());
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] Song_DTO song)
        {
            if (song == null)
                return BadRequest("The object received is null");
            return await songBL.UpdateAsync(song) != 1 ? BadRequest("Update failed") :
                Ok(await songBL.SelectAllAsync());
        }
    }
}
