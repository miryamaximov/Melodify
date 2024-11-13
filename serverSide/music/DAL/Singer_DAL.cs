using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Singer_DAL
    {
        private readonly MusicContext db;
        public Singer_DAL(MusicContext music)
        {
            db = music;
        }

        //get all the singers not active
        public async Task<List<Singer>> SelectAllNotActiveAsync()
        {
            return await db.Singers.Where(k => k.IsActive == false).Include(k => k.Songs).Include(k => k.Albums).ToListAsync();
        }

        //get all the singers
        public async Task<List<Singer>> SelectAllAsync()
        {
            return await db.Singers.Where(k=>k.IsActive == true).Include(k=> k.Songs).Include(k=>k.Albums).ToListAsync();
        }

        //get singer by id
        public async Task<Singer> SelectByIdAsync(int singerId)
        {
            return await db.Singers.Include(k => k.Songs).Include(k => k.Albums).FirstOrDefaultAsync(k => k.SingerId == singerId && k.IsActive == true);
        }

        //get all singers their name contain this string
        public async Task<List<Singer>> SelectByNameContainStrAsync(string str)
        {
            return await db.Singers.Include(k => k.Songs).Include(k => k.Albums).Where(k => k.IsActive == true &&( k.SingerLastName.Contains(str) || k.SingerFirstName.Contains(str))).ToListAsync();
        }

        //add a singer 
        public async Task<int> AddSingerAsync(Singer singer)
        {
            if (singer == null || db.Singers.Contains(singer))
                return -1;
            singer.IsActive = true;
            await db.Singers.AddAsync(singer);
            return await db.SaveChangesAsync();
        }

        //update a singer
        public async Task<int> UpdateAsync(Singer singer)
        {
            if (singer == null)
                return -1;
            Singer s = db.Singers.FirstOrDefault(k => k.SingerId == singer.SingerId);
            if (s == null) return -1;
            s.SingerFirstName = singer.SingerFirstName;
            s.SingerLastName = singer?.SingerLastName;
            s.ImageUrl = singer?.ImageUrl;
            s.SingerAbout = singer?.SingerAbout;
            s.IsActive = singer.IsActive;
            return await db.SaveChangesAsync();
        }

        //delete a singer by id
        public async Task<int> DeleteAsync(int singerId)
        {
            Singer s = db.Singers.FirstOrDefault(k => k.SingerId == singerId);
            if (s == null)
                return -1;
            //מחיקה של כל העוקבים של הזמר
            Follower_DAL dal1 = new Follower_DAL(db);
            if (await dal1.SelectBySingerIdAsync(singerId) != null)
                await dal1.DeleteAllBySingerIdAsync(singerId);
            //עדכון הזמר כלא פעיל
            return await UpdateAsync(new Singer()
            {
                SingerId = s.SingerId,
                SingerFirstName = s.SingerFirstName,
                SingerLastName = s.SingerLastName,
                ImageUrl = s.ImageUrl,
                SingerAbout = s.SingerAbout,
                IsActive = false
            });
        }

        //delete total the singer
        public async Task<int> DeleteCompletelyAsync(int singerId)
        {
            Singer s = db.Singers.FirstOrDefault(k => k.SingerId == singerId);
            if (s == null)
                return -1;
            Follower_DAL dal1 = new Follower_DAL(db);
            if (await dal1.SelectBySingerIdAsync(singerId) != null)
                await dal1.DeleteAllBySingerIdAsync(singerId);
            Album_DAL dal2 = new Album_DAL(db);
            if (await dal2.SelectBySingerIdAsync(singerId) != null)
                await dal2.DeleteAllBySingerIdAsync(singerId);
            Song_DAL dal3 = new Song_DAL(db);
            if (await dal3.SelectBySingerIdAsync(singerId) != null)
                await dal3.DeleteAllBySingerIdAsync(singerId);
            db.Singers.Remove(s);
            return await db.SaveChangesAsync();
        }
    }
}
