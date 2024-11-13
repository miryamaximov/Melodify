using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Category_DAL
    {
        private readonly MusicContext db;
        public Category_DAL(MusicContext music)
        {
            db = music;
        }

        //get all the list of the categories
        public async Task<List<Category>> SelectAllAsync()
        {
            return await db.Categories.ToListAsync();
        }

        //get category by category id
        public async Task<Category> SelectByIdAsync(int categoryId)
        {
            return await db.Categories.FirstOrDefaultAsync(k => k.CategoryId == categoryId);
        }

        //add category
        public async Task<int> AddCategory(Category category)
        {
            if (category == null || db.Categories.Contains(category))
                return -1;
            await db.Categories.AddAsync(category);
            return await db.SaveChangesAsync();
        }

        //update category 
        public async Task<int> UpdateAsync(Category category)
        {
            if (category == null) return -1;
            Category c = db.Categories.FirstOrDefault(k=> k.CategoryId == category.CategoryId);
            if (c == null)
                return -1;
            c.CategoryName = category.CategoryName;
            return await db.SaveChangesAsync();
        }


        //delete a category
        public async Task<int> DeleteAsync(int categoryId)
        {
            int res = -1;
            Category c = await db.Categories.FirstOrDefaultAsync(k => k.CategoryId == categoryId);
            if (c == null)
                return res;
            CategoriesDetail_DAL dal = new CategoriesDetail_DAL(db);
            //delete all the songs of this category from the table of categories details
            res = await dal.DeleteAllByCategoryIdAsync(categoryId);
            if (res == -1)
                return res;
            db.Categories.Remove(c);
            res = await db.SaveChangesAsync();
            return res;
        }
    }
}
