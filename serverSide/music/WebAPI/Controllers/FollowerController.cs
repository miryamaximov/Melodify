using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly Follower_BL followerBL;
        public FollowerController(Follower_BL bl)
        {
            followerBL = bl;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await followerBL.SelectAllAsync());
        }

        [HttpGet]
        [Route("GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            return Ok(await followerBL.SelectAllByUserIdAsync(userId));
        }

        [HttpGet]
        [Route("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            Follower_DTO f = await followerBL.SelectByUserIdAsync(userId);
            return f == null ? NotFound() : Ok(f);
        }

        [HttpGet]
        [Route("GetAllBySingerId/{singerId}")]
        public async Task<IActionResult> GetAllBySingerId(int singerId)
        {
            return Ok(await followerBL.SelectAllBySingerIdAsync(singerId));
        }

        [HttpGet]
        [Route("GetBySingerId/{singerId}")]
        public async Task<IActionResult> GetBySingerId(int singerId)
        {
            Follower_DTO f = await followerBL.SelectBySingerIdAsync(singerId);
            return f == null ? NotFound() : Ok(f);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Follower_DTO follower)
        {
            if (follower == null)
                return BadRequest("The object received is null");
            int res = await followerBL.AddFollowerAsync(follower);
            return res != 1 ? BadRequest("Add failed") : Ok(await followerBL.SelectAllAsync());
        }

        [HttpDelete]
        [Route("Delete/{userId}/{singerId}")]
        public async Task<IActionResult> Delete(int userId, int singerId)
        {
            int res = await followerBL.DeleteByUserIdAndSingerIdAsync(userId, singerId);
            return res != 1 ? BadRequest("Delete failed") : Ok(await followerBL.SelectAllAsync());
        }



    }
}
