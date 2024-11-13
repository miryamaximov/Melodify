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
    public class PlaylistsDetail_BL
    {
        private readonly PlaylistsDetail_DAL playlistsDetailDAL;
        public PlaylistsDetail_BL(PlaylistsDetail_DAL dal)
        {
            playlistsDetailDAL = dal;
        }

        //conversion functions
        private PlaylistDetail_DTO ConvertToDTO(PlaylistsDetail detail)
        {
            return new PlaylistDetail_DTO()
            {
                PlaylistsDetailsId = detail.PlaylistsDetailsId,
                PlaylistId = detail.PlaylistId,
                SongId = detail.SongId,
                SongName = detail.Song == null ? "" : detail.Song.SongName,
                PlaylistName = detail.Playlist == null ? "" : detail.Playlist.PlaylistName
            };
        }

        private List<PlaylistDetail_DTO> ConvertToDTO(List<PlaylistsDetail> playlistsDetailList)
        {
            List<PlaylistDetail_DTO> lst = new List<PlaylistDetail_DTO>();
            foreach (PlaylistsDetail p in playlistsDetailList)
                lst.Add(ConvertToDTO(p));
            return lst;
        }

        private PlaylistsDetail ConvertFromDTO(PlaylistDetail_DTO detail)
        {
            return new PlaylistsDetail()
            {
                PlaylistsDetailsId = detail.PlaylistsDetailsId,
                PlaylistId = detail.PlaylistId,
                SongId = detail.SongId
            };
        }

        private List<PlaylistsDetail> ConvertFromDTO(List<PlaylistDetail_DTO>playlists)
        {
            List<PlaylistsDetail>lst= new List<PlaylistsDetail>();
            foreach (PlaylistDetail_DTO p in playlists)
                lst.Add(ConvertFromDTO(p));
            return lst;
        }

        //get all
        public async Task<List<PlaylistDetail_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await playlistsDetailDAL.SelectAllAsync());
        }

        //get all by playlist id
        public async Task<List<PlaylistDetail_DTO>> SelectAllByPlaylistIdAsync(int playlistId)
        {
            return ConvertToDTO(await playlistsDetailDAL.SelectAllByPlaylistIdAsync(playlistId));
        }

        //get one by playlist id
        public async Task<PlaylistDetail_DTO?> SelectByPlaylistIdAsync(int playlistId)
        {
            PlaylistsDetail p = await playlistsDetailDAL.SelectByPlaylistIdAsync(playlistId);
            return p == null ? null : ConvertToDTO(p);
        }
        //get all by song id
        public async Task<List<PlaylistDetail_DTO>> SelectAllBySongIdAsync(int songId)
        {
            return ConvertToDTO(await playlistsDetailDAL.SelectAllByPlaylistIdAsync(songId));
        }

        //get by song id
        public async Task<PlaylistDetail_DTO?> SelectBySongIdAsync(int songId)
        {
            PlaylistsDetail p = await playlistsDetailDAL.SelectBySongIdAsync(songId);
            return p == null ? null : ConvertToDTO(p);
        }

        //add 
        public async Task<int> AddPlaylistDetailAsync(PlaylistDetail_DTO playlistDetail)
        {
            if (playlistDetail == null)
                return -1;
            return await playlistsDetailDAL.AddPlaylistDetailAsync(ConvertFromDTO(playlistDetail));
        }

        //delete song from playlist
        public async Task<int> DeleteBySongIdAndPlaylistIdAsync(int songId, int playlistId)
        {
            return await playlistsDetailDAL.DeleteBySongIdAndPlaylistIdAsync(songId, playlistId);
        }
    }
}
