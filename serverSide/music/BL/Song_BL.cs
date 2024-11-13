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
    public class Song_BL
    {
        private readonly Song_DAL songDAL;
        public Song_BL(Song_DAL dal)
        {
            songDAL = dal;
        }

        //conversion functions
        private Song_DTO ConvertToDTO(Song song)
        {
            return new Song_DTO()
            {
                SongId = song.SongId,
                SongName = song.SongName,
                SingerId = song.SingerId,
                SingerFirstName = song.Singer == null ? "" : song.Singer.SingerFirstName,
                SingerLastName = song.Singer == null ? "" : song.Singer.SingerLastName,
                PublishingDate = song.PublishingDate,
                UploadDate = song.UploadDate,
                SongUrl = song.SongUrl,
                ImageUrl = song.ImageUrl,
                SongAbout = song.SongAbout,
                LikeNum = song.LikeNum
            };
        }

        private List<Song_DTO> ConvertToDTO(List<Song> songs)
        {
            List<Song_DTO> lst=new List<Song_DTO>();
            foreach(Song s in songs)
                lst.Add(ConvertToDTO(s));
            return lst;
        }

        private Song ConvertFromDTO(Song_DTO song)
        {
            return new Song()
            {
                SongId = song.SongId,
                SongName = song.SongName,
                SingerId = song.SingerId,
                PublishingDate = song.PublishingDate,
                UploadDate = song.UploadDate,
                SongUrl = song.SongUrl,
                ImageUrl = song.ImageUrl,
                SongAbout = song.SongAbout,
                LikeNum = song.LikeNum, 
               // Singer = new Singer() { SingerId = song.SingerId}
            };
        }

        private List<Song> ConvertFromDTO(List<Song_DTO>songs)
        {
            List<Song> lst=new List<Song>();
            foreach (Song_DTO s in songs)
                lst.Add(ConvertFromDTO(s));
            return lst;
        }

        //get all
        public async Task<List<Song_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await songDAL.SelectAllAsync());
        }

        //get by song id
        public async Task<Song_DTO?> SelectBySongIdAsync(int songId)
        {
            Song s = await songDAL.SelectBySongIdAsync(songId);
            return s == null ? null : ConvertToDTO(s);
        }

        //get all by singer id
        public async Task<List<Song_DTO>> SelectAllBySingerIdAsync(int singerId)
        {
            return ConvertToDTO(await songDAL.SelectAllBySingerIdAsync(singerId));
        }

        //get one by singer id
        public async Task<Song_DTO?> SelectBySingerIdAsync(int singerId)
        {
            Song s = await songDAL.SelectBySingerIdAsync(singerId);
            return s == null ? null : ConvertToDTO(s);
        }

        //get by num likes = 
        public async Task<List<Song_DTO>> SelectAllByNumLikesAsync(int numLikes)
        {
            return ConvertToDTO(await songDAL.SelectAllByNumLikesAsync(numLikes));
        }

        //get by num likes >
        public async Task<List<Song_DTO>> SelectAllByNumLikesAboveAsync(int numLikes)
        {
            return ConvertToDTO(await songDAL.SelectAllByNumLikesAboveAsync(numLikes));
        }

        //get by num likes <
        public async Task<List<Song_DTO>> SelectAllByNumLikesLessAsync(int numLikes)
        {
            return ConvertToDTO(await songDAL.SelectAllByNumLikesLessAsync(numLikes));
        }

        //get by publishing date =
        public async Task<List<Song_DTO>> SelectAllByPublishingDateAsync(DateTime publishongDate)
        {
            return ConvertToDTO(await songDAL.SelectAllByPublishingDateAsync(publishongDate));
        }

        //get by publishing date >
        public async Task<List<Song_DTO>> SelectAllByPublishingDateAfterAsync(DateTime publishongDate)
        {
            return ConvertToDTO(await songDAL.SelectAllByPublishingDateAfterAsync(publishongDate));
        }

        //get by publishing date <
        public async Task<List<Song_DTO>> SelectAllByPublishingDateBeforeAsync(DateTime publishongDate)
        {
            return ConvertToDTO(await songDAL.SelectAllByPublishingDateBeforeAsync(publishongDate));
        }

        //get by upload date = 
        public async Task<List<Song_DTO>> SelectAllByUploadDateAsync(DateTime uploadDate)
        {
            return ConvertToDTO(await songDAL.SelectAllByUploadDateAsync(uploadDate));
        }

        //get by upload date >
        public async Task<List<Song_DTO>> SelectAllByUploadDateAfterAsync(DateTime uploadDate)
        {
            return ConvertToDTO(await songDAL.SelectAllByUploadDateAfterAsync(uploadDate));
        }

        //get by upload date <
        public async Task<List<Song_DTO>> SelectAllByUploadDateBeforeAsync(DateTime uploadDate)
        {
            return ConvertToDTO(await songDAL.SelectAllByUploadDateBeforeAsync(uploadDate));
        }

        //get songs by str
        public async Task<List<Song_DTO>> SelectAllContainStrInNameAsync(string str)
        {
            return ConvertToDTO(await songDAL.SelectAllContainStrInNameAsync(str));
        }

        //add song
        public async Task<int> AddSongAsync(Song_DTO song)
        {
            if (song == null) return -1;
            return await songDAL.AddSongAsync(ConvertFromDTO(song));
        }

        //delete by song id
        public async Task<int> DeleteByIdAsync(int songId)
        {
            return await songDAL.DeleteByIdAsync(songId);
        }

        //update
        public async Task<int> UpdateAsync(Song_DTO song)
        {
            if (song == null) return -1;
            return await songDAL.UpdateAsync(ConvertFromDTO(song));
        }
    }
}
