using DAL;
using DAL.models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Follower_BL
    {
        private readonly Follower_DAL followerDAL;
        public Follower_BL(Follower_DAL dal)
        {
            followerDAL = dal;
        }

        //conversion functions
        private Follower_DTO ConvertToDTO(Follower follower)
        {
            return new Follower_DTO()
            {
                FollowerId = follower.FollowerId,
                SingerId = follower.SingerId,
                UserId = follower.UserId,
                SingerFirstName = follower.Singer == null ? "" : follower.Singer.SingerFirstName,
                SingerLastName = follower.Singer == null ? "" : follower.Singer.SingerLastName,
                UserName = follower.User == null ? "" : follower.User.UserName
            };
        }

        private List<Follower_DTO> ConvertToDTO (List<Follower>followers)
        {
            List<Follower_DTO> lst = new List<Follower_DTO>();
            foreach (Follower f in followers)
                lst.Add(ConvertToDTO(f));
            return lst;
        }

        private Follower ConvertFromDTO(Follower_DTO follower)
        {
            return new Follower()
            {
                FollowerId = follower.FollowerId,
                SingerId = follower.SingerId,
                UserId = follower.UserId
            };
        }

        private List<Follower> ConvertFromDTO (List<Follower_DTO> followers)
        {
            List<Follower> lst = new List<Follower>();
            foreach (Follower_DTO f in followers)
                lst.Add(ConvertFromDTO(f));
            return lst;
        }

        //get all
        public async Task<List<Follower_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await followerDAL.SelectAllAsync());
        }

        //get all by user id
        public async Task<List<Follower_DTO>> SelectAllByUserIdAsync(int userId)
        {
            return ConvertToDTO(await followerDAL.SelectAllByUserIdAsync(userId));
        }

        //get one by user id
        public async Task<Follower_DTO?> SelectByUserIdAsync(int userId)
        {
            Follower f = await followerDAL.SelectByUserIdAsync(userId);
            return f == null ? null : ConvertToDTO(f);
        }

        //get all by singer id
        public async Task<List<Follower_DTO>> SelectAllBySingerIdAsync(int singerId)
        {
            return ConvertToDTO(await followerDAL.SelectAllBySingerIdAsync(singerId));
        }

        //get one by singer id
        public async Task<Follower_DTO?> SelectBySingerIdAsync(int singerId)
        {
            Follower f = await followerDAL.SelectBySingerIdAsync(singerId);
            return f == null ? null : ConvertToDTO(f);
        }

        //add follower
        public async Task<int> AddFollowerAsync(Follower_DTO follower)
        {
            if (follower == null)
                return -1;
            return await followerDAL.AddFollowerAsync(ConvertFromDTO(follower));
        }

        //delete by user id and singer id
        public async Task<int> DeleteByUserIdAndSingerIdAsync(int userId, int singerId)
        {
            return await followerDAL.DeleteByUserIdAndSingerIdAsync(userId, singerId);
        }
    }
}
