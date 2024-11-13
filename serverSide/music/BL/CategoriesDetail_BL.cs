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
    public class CategoriesDetail_BL
    {
        private readonly CategoriesDetail_DAL categoriesDetailDAL;
        public CategoriesDetail_BL(CategoriesDetail_DAL dal)
        {
            categoriesDetailDAL = dal;
        }

        //conversion function
        private CategoriesDetail_DTO ConvertToDTO(CategoriesDetail detail)
        {
            return new CategoriesDetail_DTO()
            {
                CategoriesDetailsId = detail.CategoriesDetailsId,
                CategoryId = detail.CategoryId,
                SongId = detail.SongId,
                CategoryName = detail.Category == null ? "" : detail.Category.CategoryName,
                SongName = detail.Song == null ? "" : detail.Song.SongName
            };
        }

        private List<CategoriesDetail_DTO> ConvertToDTO(List<CategoriesDetail>details)
        {
            List<CategoriesDetail_DTO>lst = new List<CategoriesDetail_DTO>();
            foreach (CategoriesDetail detail in details)
            {
                lst.Add(ConvertToDTO(detail));
            }
            return lst;
        }

        private CategoriesDetail ConvertFromDTO(CategoriesDetail_DTO detail)
        {
            return new CategoriesDetail()
            {
                CategoriesDetailsId = detail.CategoriesDetailsId,
                CategoryId = detail.CategoryId,
                SongId = detail.SongId
            };
        }
        private List<CategoriesDetail> ConvertFromDTO(List<CategoriesDetail_DTO> details)
        {
            List<CategoriesDetail> lst=new List<CategoriesDetail>();
            foreach (CategoriesDetail_DTO detail in details)
                lst.Add(ConvertFromDTO(detail));
            return lst;
        }

        //get all
        public async Task<List<CategoriesDetail_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await categoriesDetailDAL.SelectAllAsync());
        }

        //get all by categoy id
        public async Task<List<CategoriesDetail_DTO>> SelectAllByCategoryIdAsync(int categoryId)
        {
            return ConvertToDTO(await categoriesDetailDAL.SelectAllByCategoryIdAsync(categoryId));
        }

        //get one by category id
        public async Task<CategoriesDetail_DTO?> SelectByCategoryIdAsync(int categoryId)
        {
            CategoriesDetail c = await categoriesDetailDAL.SelectByCategoryIdAsync(categoryId);
            return c == null ? null : ConvertToDTO(c);
        }

        //get all by song id
        public async Task<List<CategoriesDetail_DTO>> SelectAllBySongIdAsync(int songId)
        {
            return ConvertToDTO(await categoriesDetailDAL.SelectAllBySongIdAsync(songId));
        }

        //get one by song id
        public async Task<CategoriesDetail_DTO?> SelectBySongIdAsync(int songId)
        {
            CategoriesDetail c = await categoriesDetailDAL.SelectBySongIdAsync(songId);
            return c == null ? null : ConvertToDTO(c);
        }

        //add 
        public async Task<int> AddCategoryDetailAsync(CategoriesDetail_DTO categoriesDetail)
        {
            if (categoriesDetail == null) return -1;
            return await categoriesDetailDAL.AddCategoryDetailAsync(ConvertFromDTO(categoriesDetail));
        }

        //delete by song id and category id
        public async Task<int> DeleteBySongIdAndCategoryIdAsync(int songId, int categoryId)
        {
            return await categoriesDetailDAL.DeleteBySongIdAndCategoryIdAsync(songId, categoryId);
        }

    }
}
