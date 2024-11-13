using DAL;
using DAL.models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlbumsDetail_BL
    {
        private readonly AlbumsDetail_DAL albumsDetailDAL;
        public AlbumsDetail_BL(AlbumsDetail_DAL dal)
        {
            albumsDetailDAL = dal;
        }

        //conversion function
        private AlbumsDetail_DTO ConvertToDTO(AlbumsDetail detail)
        {
            return new AlbumsDetail_DTO()
            {
                AlbumsDetailsId = detail.AlbumsDetailsId,
                AlbumId = detail.AlbumId,
                SongId = detail.SongId,
                AlbumName = detail.Album == null ? "" : detail.Album.AlbumName,
                SongName = detail.Song == null ? "" : detail.Song.SongName
            };
        }

        private List<AlbumsDetail_DTO> ConvertToDTO(List<AlbumsDetail>details)
        {
            List<AlbumsDetail_DTO> lst = new List<AlbumsDetail_DTO>();
            foreach (AlbumsDetail detail in details) 
                {
                    lst.Add(ConvertToDTO(detail));
                }
            return lst;
        }

        private AlbumsDetail ConvertFromDTO(AlbumsDetail_DTO detail)
        {
            return new AlbumsDetail()
            {
                AlbumsDetailsId = detail.AlbumsDetailsId,
                AlbumId = detail.AlbumId,
                SongId = detail.SongId
            };
        }

        private List<AlbumsDetail> ConvertFromDTO(List<AlbumsDetail_DTO>details)
        {
            List<AlbumsDetail> lst = new List<AlbumsDetail>();
            foreach (AlbumsDetail_DTO detail in details)
            {
                lst.Add(ConvertFromDTO(detail));
            }
            return lst;
        }

        //get all
        public async Task<List<AlbumsDetail_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await albumsDetailDAL.SelectAllAsync());
        }

        //get all by album id
        public async Task<List<AlbumsDetail_DTO>> SelectAllByAlbumIdAsync(int albumId)
        {
            return ConvertToDTO(await albumsDetailDAL.SelectAllByAlbumIdAsync(albumId)); 
        }

        //get one by album id
        public async Task<AlbumsDetail_DTO?> SelectByAlbumId(int albumId)
        {
            AlbumsDetail detail = await albumsDetailDAL.SelectByAlbumId(albumId);
            return detail == null ? null : ConvertToDTO(detail);
        }

        //get by song id
        public async Task<AlbumsDetail_DTO?> SelectBySongIdAsync(int songId)
        {
            AlbumsDetail detail = await albumsDetailDAL.SelectBySongIdAsync(songId);
            return detail == null ? null : ConvertToDTO(detail);
        }

        //add
        public async Task<int> AddAlbumDetailAsync(AlbumsDetail_DTO albumsDetail)
        {
            if (albumsDetail == null)
                return -1;
            return await albumsDetailDAL.AddAlbumDetailAsync(ConvertFromDTO(albumsDetail));
        }

        //delete by song id
        public async Task<int> DeleteBySongIdAsync(int songId)
        {
            return await albumsDetailDAL.DeleteBySongIdAsync(songId);
        }


     }
}
