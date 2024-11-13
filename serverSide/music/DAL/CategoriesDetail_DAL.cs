using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriesDetail_DAL
    {
        private readonly MusicContext db;
        public CategoriesDetail_DAL(MusicContext music)
        {
            db = music;
        }

        //get all categories details
        public async Task<List<CategoriesDetail>> SelectAllAsync()
        {
            return await db.CategoriesDetails.Include(k=> k.Category).Include(k=>k.Song).ToListAsync();
        }

        //get all songs by category id
        public async Task<List<CategoriesDetail>> SelectAllByCategoryIdAsync(int categoryId)
        {
            return await db.CategoriesDetails.Include(k => k.Category).Include(k => k.Song).Where(k=> k.CategoryId == categoryId).ToListAsync();
        }

        //get first by category id
        public async Task<CategoriesDetail> SelectByCategoryIdAsync(int categoryId)
        {
            return await db.CategoriesDetails.Include(k => k.Category).Include(k => k.Song).FirstOrDefaultAsync(k => k.CategoryId == categoryId);
        }

        //get all by song id
        public async Task<List<CategoriesDetail>> SelectAllBySongIdAsync(int songId)
        {
            return await db.CategoriesDetails.Include(k => k.Category).Include(k => k.Song).Where(k => k.SongId == songId).ToListAsync();
        }

        //get category by song id
        public async Task<CategoriesDetail> SelectBySongIdAsync(int songId)
        {
            return await db.CategoriesDetails.Include(k => k.Category).Include(k => k.Song).FirstOrDefaultAsync(k => k.SongId == songId);
        }

        //add category detail
        public async Task<int> AddCategoryDetailAsync(CategoriesDetail detail)
        {
            if (detail == null || db.CategoriesDetails.Contains(detail))
                return -1;
            await db.CategoriesDetails.AddAsync(detail);
            return await db.SaveChangesAsync();
        }

        //delete all the record that belong to this song id
        public async Task<int> DeleteAllBySongIdAsync(int songId)
        {
            foreach (CategoriesDetail item  in db.CategoriesDetails.ToList())
            {
                if (item.SongId == songId)
                    db.CategoriesDetails.Remove(item);
            }
            return await db.SaveChangesAsync();
        }

        //delete all the record that belong to this category id
        public async Task<int> DeleteAllByCategoryIdAsync(int categoryId)
        {
            foreach (CategoriesDetail item in db.CategoriesDetails.ToList())
            {
                if (item.CategoryId == categoryId)
                    db.CategoriesDetails.Remove(item);
            }
            return await db.SaveChangesAsync();
        }


        //delete record by song id
        public async Task<int> DeleteBySongIdAndCategoryIdAsync(int songId, int categoryId)
        {
            CategoriesDetail c = await db.CategoriesDetails.FirstOrDefaultAsync(k => k.SongId == songId && k.CategoryId == categoryId);
            if (c == null)
                return -1;
            db.CategoriesDetails.Remove(c);
            return await db.SaveChangesAsync();
        }

        //לא שייך במחלקה זו עדכון מכיוון שאין אפשרות לעדכן קוד קטגוריה או קוד שיר

    }
}
