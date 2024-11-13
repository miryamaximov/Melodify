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
    public class Category_BL
    {
        private readonly Category_DAL categoryDAL;
        public Category_BL(Category_DAL dal)
        {
            categoryDAL = dal;
        }

        //conversion functions
        private Category_DTO ConvertToDTO(Category category)
        {
            return new Category_DTO()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        private List<Category_DTO> ConvertToDTO(List<Category>categories)
        {
            List<Category_DTO>lst = new List<Category_DTO>();
            foreach(Category c in categories)
                lst.Add(ConvertToDTO(c));
            return lst;
        }

        private Category ConvertFromDTO (Category_DTO category)
        {
            return new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        private List<Category> ConvertFromDTO(List<Category_DTO>categories)
        {
            List<Category>lst = new List<Category>();
            foreach (Category_DTO c in categories)
                lst.Add(ConvertFromDTO(c));
            return lst;
        }

        //get all
        public async Task<List<Category_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await categoryDAL.SelectAllAsync());
        }

        //get one by category id
        public async Task<Category_DTO?> SelectByIdAsync(int categoryId)
        {
            Category c = await categoryDAL.SelectByIdAsync(categoryId);
            return c == null ? null : ConvertToDTO(c);
        }

        //add category
        public async Task<int> AddCategory(Category_DTO category)
        {
            if (category == null) return -1;
            return await categoryDAL.AddCategory(ConvertFromDTO(category));
        }

        //update category
        public async Task<int> UpdateAsync(Category_DTO category)
        {
            if (category == null) return -1;
            return await categoryDAL.UpdateAsync(ConvertFromDTO(category));
        }

        //delete category
        public async Task<int> DeleteAsync(int categoryId)
        {
            return await categoryDAL.DeleteAsync(categoryId);
        }
    }
}
