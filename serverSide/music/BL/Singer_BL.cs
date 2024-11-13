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
    public class Singer_BL
    {
        private readonly Singer_DAL singerDAL;
        public Singer_BL(Singer_DAL dal)
        {
            singerDAL = dal;
        }

        //conversion functions
        private Singer_DTO ConvertToDTO(Singer singer)
        {
            return new Singer_DTO()
            {
                SingerId = singer.SingerId,
                SingerFirstName = singer.SingerFirstName,
                SingerLastName = singer.SingerLastName,
                ImageUrl = singer.ImageUrl,
                SingerAbout = singer.SingerAbout,
                NumOfAlbums = singer.Albums == null ? 0 : singer.Albums.Count(),
                NumOfSongs = singer.Songs == null ? 0 : singer.Songs.Count()
            };
        }

        private List<Singer_DTO> ConvertToDTO(List<Singer> singers)
        {
            List<Singer_DTO>lst = new List<Singer_DTO>();
            foreach (Singer s in singers)
                lst.Add(ConvertToDTO(s));
            return lst;
        }

        private Singer ConvertFromDTO(Singer_DTO singer)
        {
            return new Singer()
            {
                SingerId = singer.SingerId,
                SingerFirstName = singer.SingerFirstName,
                SingerLastName = singer.SingerLastName,
                ImageUrl = singer.ImageUrl,
                SingerAbout = singer.SingerAbout
            };
        }

        private List<Singer> ConvertFromDTO(List<Singer_DTO> singers)
        {
            List<Singer> lst = new List<Singer>();
            foreach (Singer_DTO s in singers)
                lst.Add(ConvertFromDTO(s));
            return lst;
        }

        //get all the singers not active
        public async Task<List<Singer_DTO>> SelectAllNotActiveAsync()
        {
            return ConvertToDTO(await singerDAL.SelectAllNotActiveAsync());
        }

        //get all
        public async Task<List<Singer_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await singerDAL.SelectAllAsync());
        }

        //get by singer id
        public async Task<Singer_DTO?> SelectByIdAsync(int singerId)
        {
            Singer s = await singerDAL.SelectByIdAsync(singerId);
            return s == null ? null : ConvertToDTO(s);
        }

        //get singers by string
        public async Task<List<Singer_DTO>> SelectByNameContainStrAsync(string str)
        {
            return ConvertToDTO(await singerDAL.SelectByNameContainStrAsync(str));
        }

        //add singer
        public async Task<int> AddSingerAsync(Singer_DTO singer)
        {
            if (singer == null) return -1;
            return await singerDAL.AddSingerAsync(ConvertFromDTO(singer));
        }

        //update 
        public async Task<int> UpdateAsync(Singer_DTO singer)
        {
            if (singer == null) return -1;
            return await singerDAL.UpdateAsync(ConvertFromDTO(singer));
        }

        //delete by singer id
        public async Task<int> DeleteAsync(int singerId)
        {
            return await singerDAL.DeleteAsync(singerId);
        }

        //delete completely
        public async Task<int> DeleteCompletelyAsync(int singerId)
        {
            return await singerDAL.DeleteCompletelyAsync(singerId);
        }

    }
}
