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
    public class SharedPlaylistsDeatail_BL
    {
        private readonly SharedPlaylistsDetail_DAL sharedPlaylistsDetailDAL;
        public SharedPlaylistsDeatail_BL(SharedPlaylistsDetail_DAL dal)
        {
            sharedPlaylistsDetailDAL = dal;
        }

        //conversion functions
        private SharedPlaylistsDetail_DTO ConvertToDTO(SharedPlaylistsDetail detail)
        {
            return new SharedPlaylistsDetail_DTO()
            {
                SharedPlaylistsDetailsId = detail.SharedPlaylistsDetailsId,
                PlaylistId = detail.PlaylistId,
                UserId = detail.UserId,
                UserName = detail.User == null ? "" : detail.User.UserName,
                PlaylistName = detail.Playlist == null ? "" : detail.Playlist.PlaylistName
            };
        }

        private List<SharedPlaylistsDetail_DTO> ConvertToDTO(List<SharedPlaylistsDetail>sharedPlaylistsDetails)
        {
            List<SharedPlaylistsDetail_DTO> lst = new List<SharedPlaylistsDetail_DTO>();
            foreach (SharedPlaylistsDetail s in sharedPlaylistsDetails)
                lst.Add(ConvertToDTO(s));
            return lst; 
        }

        private SharedPlaylistsDetail ConvertFromDTO(SharedPlaylistsDetail_DTO detail)
        {
            return new SharedPlaylistsDetail()
            {
                SharedPlaylistsDetailsId = detail.SharedPlaylistsDetailsId,
                PlaylistId = detail.PlaylistId,
                UserId = detail.UserId
            };
        }

        private List<SharedPlaylistsDetail> ConvertFromDTO(List<SharedPlaylistsDetail_DTO> sharedPlaylistsDetails)
        {
            List<SharedPlaylistsDetail> lst = new List<SharedPlaylistsDetail>();
            foreach (SharedPlaylistsDetail_DTO s in sharedPlaylistsDetails)
                lst.Add(ConvertFromDTO(s));
            return lst;
        }

        //get all
        public async Task<List<SharedPlaylistsDetail_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await sharedPlaylistsDetailDAL.SelectAllAsync());
        }

        //get all by user id
        public async Task<List<SharedPlaylistsDetail_DTO>> SelectAllByUserIdAsync(int userId)
        {
            return ConvertToDTO(await sharedPlaylistsDetailDAL.SelectAllByUserIdAsync(userId));
        }

        //get one by user id
        public async Task<SharedPlaylistsDetail_DTO?> SelectByUserIdAsync(int userId)
        {
            SharedPlaylistsDetail s = await sharedPlaylistsDetailDAL.SelectByUserIdAsync(userId);
            return s == null ? null : ConvertToDTO(s);
        }

        //get all by playlist id
        public async Task<List<SharedPlaylistsDetail_DTO>> SelectAllByPlaylistIdAsync(int playlistId)
        {
            return ConvertToDTO(await sharedPlaylistsDetailDAL.SelectAllByPlaylistIdAsync(playlistId));
        }

        //get one by playlist id
        public async Task<SharedPlaylistsDetail_DTO?> SelectByPlaylistIdAsync(int playlistId)
        {
            SharedPlaylistsDetail s = await sharedPlaylistsDetailDAL.SelectByPlaylistIdAsync(playlistId);
            return s == null ? null : ConvertToDTO(s);
        }

        //add
        public async Task<int> AddSharedPlaylistDetailAsync(SharedPlaylistsDetail_DTO sharedPlaylistsDetail)
        {
            if (sharedPlaylistsDetail == null)
                return -1;
            return await sharedPlaylistsDetailDAL.AddSharedPlaylistDetailAsync(ConvertFromDTO(sharedPlaylistsDetail));
        }

        //delete by playlist id and user id
        public async Task<int> DeleteByPlaylistIdAndUserIdAsync(int playlistId, int userId)
        {
            return await sharedPlaylistsDetailDAL.DeleteByPlaylistIdAndUserIdAsync(playlistId, userId);
        }
    }
}
