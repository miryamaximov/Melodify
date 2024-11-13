using DAL;
using DAL.models;
using Entities;

namespace BL
{
    public class Album_BL
    {
        private readonly Album_DAL albumDAL;
        public Album_BL(Album_DAL dal)
        {
            albumDAL = dal;
        }

        //conversion function

        private Album_DTO ConvertToDTO(Album album)
        {
            return new Album_DTO()
            {
                AlbumId = album.AlbumId,
                AlbumName = album.AlbumName,
                AlbumSingerId = album.AlbumSingerId,
                AlbumSingerFirstName = album.AlbumSingerNavigation == null ? "" :
                album.AlbumSingerNavigation.SingerFirstName,
                AlbumSingerLastName = album.AlbumSingerNavigation == null ? "" : 
                album.AlbumSingerNavigation.SingerLastName,
                PublishingDate = album.PublishingDate,
                UploadDate = album.UploadDate,
                ImageUrl = album.ImageUrl
            };
        }

        private List<Album_DTO> ConvertToDTO(List<Album> albums)
        {
            List<Album_DTO> lst = new List<Album_DTO>();
            foreach (Album a in albums)
            {
                lst.Add(ConvertToDTO(a));
            }
            return lst;
        }


        private Album ConvertFromDTO(Album_DTO album)
        {
            return new Album()
            {
                AlbumId = album.AlbumId,
                AlbumName = album.AlbumName,
                AlbumSingerId = album.AlbumSingerId,
                PublishingDate = album.PublishingDate,
                UploadDate = album.UploadDate,
                ImageUrl = album.ImageUrl
            };
        }

        private List<Album> ConvertFromDTO(List<Album_DTO> albums)
        {
            List<Album>lst = new List<Album>();
            foreach (Album_DTO a in albums)
            {
                lst.Add(ConvertFromDTO(a));
            }
            return lst;
        }

        //get all
        public async Task<List<Album_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await albumDAL.SelectAllAsync());
        }

        //get one by albumId
        public async Task<Album_DTO?> SelectByAlbumIdAsync(int albumId)
        {
            Album album = await albumDAL.SelectByAlbumIdAsync(albumId);
            return album == null ? null : ConvertToDTO(album);
        }

        //get all by singer id
        public async Task<List<Album_DTO>> SelectAllBySingerIdAsync(int singerId)
        {
            return ConvertToDTO(await albumDAL.SelectAllBySingerIdAsync(singerId));
        }

        //get one by singer id
        public async Task<Album_DTO?> SelectBySingerIdAsync(int singerId)
        {
            Album album = await albumDAL.SelectBySingerIdAsync(singerId);
            return album == null ? null : ConvertToDTO(album);
        }

        //add album
        public async Task<int> AddAlbumAsync(Album_DTO album)
        {
            if (album == null)
                return -1;
            return await albumDAL.AddAlbumAsync(ConvertFromDTO(album));
        }

        //delete album
        public async Task<int> DeleteAsync(int albumId)
        {
            return await albumDAL.DeleteAsync(albumId);
        }

        //update album 
        public async Task<int> UpdateAsync(Album_DTO album)
        {
            if (album == null)
                return -1;
            return await albumDAL.UpdateAsync(ConvertFromDTO(album));
        }

    }
}
