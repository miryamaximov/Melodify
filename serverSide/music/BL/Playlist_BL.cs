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
    public class Playlist_BL
    {
        private readonly Playlist_DAL playlistDAL;
        public Playlist_BL(Playlist_DAL dal)
        {
            playlistDAL = dal;
        }

        //conversion functions
        private Playlist_DTO ConvertToDTO(Playlist playlist)
        {
            return new Playlist_DTO()
            {
                PlaylistId = playlist.PlaylistId,
                UserId = playlist.UserId,
                ProductionDate = playlist.ProductionDate,
                UpdateDate = playlist.UpdateDate,
                UserName = playlist.User == null ? "" : playlist.User.UserName,
                PlaylistName = playlist.PlaylistName
            };
        }

        private List<Playlist_DTO> ConvertToDTO(List<Playlist> playlists)
        {
            List<Playlist_DTO> lst = new List<Playlist_DTO>();
            foreach (Playlist p in playlists)
                lst.Add(ConvertToDTO(p));
            return lst;
        }

        private Playlist ConvertFromDTO (Playlist_DTO playlist)
        {
            return new Playlist()
            {
                PlaylistId = playlist.PlaylistId,
                UserId = playlist.UserId,
                ProductionDate = playlist.ProductionDate,
                UpdateDate = playlist.UpdateDate,
                PlaylistName = playlist.PlaylistName,
             //   User = new User() { UserId = playlist.UserId }
            };
        }

        private List<Playlist> ConvertFromDTO (List<Playlist_DTO>playlists)
        {
            List<Playlist>lst = new List<Playlist>();
            foreach (Playlist_DTO p in playlists)
                lst.Add(ConvertFromDTO(p));
            return lst;
        }

        //get all not active
        public async Task<List<Playlist_DTO>> SelectAllNotActiveAsync()
        {
            return ConvertToDTO(await playlistDAL.SelectAllNotActiveAsync());
        }

        //get by playlist id not active
        public async Task<Playlist_DTO> SelectByIdNotActiveAsync(int playlistId)
        {
            return ConvertToDTO(await playlistDAL.SelectByIdNotActiveAsync(playlistId));
        }

        //get all by user id not active
        public async Task<List<Playlist_DTO>> SelectAllByUserIdNotActiveAsync(int userId)
        {
            return ConvertToDTO(await playlistDAL.SelectAllByUserIdNotActiveAsync(userId));
        }

        //get all
        public async Task<List<Playlist_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await playlistDAL.SelectAllAsync());
        }

        //get by playlist id
        public async Task<Playlist_DTO?> SelectByIdAsync(int playlistId)
        {
            Playlist p = await playlistDAL.SelectByIdAsync(playlistId);
            return p == null ? null : ConvertToDTO(p);
        }

        //get all by user id (it is all the playlists this user is create)
        public async Task<List<Playlist_DTO>> SelectAllByUserIdAsync(int userId)
        {
            return ConvertToDTO(await playlistDAL.SelectAllByUserIdAsync(userId));
        }

        //get one by user id
        public async Task<Playlist_DTO?> SelectByUserIdAsync(int userId)
        {
            Playlist p = await playlistDAL.SelectByUserIdAsync(userId);
            return p == null ? null : ConvertToDTO(p);
        }

        //add playlist
        public async Task<int> AddPlaylistAsync(Playlist_DTO playlist)
        {
            if (playlist == null)
                return -1;
            return await playlistDAL.AddPlaylistAsync(ConvertFromDTO(playlist));
        }

        //delete by playlist id
        public async Task<int> DeleteAsync(int playlistId)
        {
            return await playlistDAL.DeleteAsync(playlistId);
        }

        //update
        public async Task<int> UpdateAsync(Playlist_DTO playlist)
        {
            if (playlist == null)
                return -1;
            return await playlistDAL.UpdateAsync(ConvertFromDTO(playlist));
        }
    }
}
