using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Follower_DAL
    {
        private readonly MusicContext db;
        public Follower_DAL(MusicContext music)
        {
            db = music;
        }

        //get all
        public async Task<List<Follower>> SelectAllAsync()
        {
            return await db.Followers.Include(k=> k.Singer).Include(k=> k.User).ToListAsync();
        }

        //get all the followers by user id - כל הזמרים שהוא עוקב אחריהם
        public async Task<List<Follower>> SelectAllByUserIdAsync(int userId)
        {
            return await db.Followers.Include(k => k.Singer).Include(k => k.User).Where(k => k.UserId == userId).ToListAsync();
        }

        //get the first follower by user id - הזמר הראשון שנמצא שהוא עוקב אחריו
        public async Task<Follower> SelectByUserIdAsync(int userId)
        {
            return await db.Followers.Include(k => k.Singer).Include(k => k.User).FirstOrDefaultAsync(k => k.UserId == userId);
        }

        //get all the followers by singer id  - כל המשתמשים שעוקבים אחרי הזמר הזה
        public async Task<List<Follower>> SelectAllBySingerIdAsync(int singerId)
        {
            return await db.Followers.Include(k => k.Singer).Include(k => k.User).Where(k => k.SingerId == singerId).ToListAsync();
        }

        //get the first follower by singer id  - המשתמש הראשון שנמצא שעוקב אחרי הזמר הזה
        public async Task<Follower> SelectBySingerIdAsync(int singerId)
        {
            return await db.Followers.Include(k => k.Singer).Include(k => k.User).FirstOrDefaultAsync(k => k.SingerId == singerId);
        }

        //add a follower
        public async Task<int> AddFollowerAsync(Follower follower)
        {
            if (follower == null || db.Followers.Contains(follower))
                return -1;
            await db.Followers.AddAsync(follower);
            return await db.SaveChangesAsync();
        }

        //delete all by singer id
        //משמש רק למחיקת זמר שאז אני מוחקת את כל העוקבים שלו
        public async Task<int> DeleteAllBySingerIdAsync(int singerId)
        {
            foreach (Follower item in db.Followers.ToList())
            {
                if (item.SingerId == singerId)
                    db.Followers.Remove(item);
            }
            return await db.SaveChangesAsync();
        }


        //delete all by user id 
        //משמש רק למחיקת משתמש שאז אני מוחקת את כל מי שהוא עקב אחריו
        public async Task<int> DeleteAllByUserIdAsync(int userId)
        {
            foreach (Follower item in db.Followers.ToList())
            {
                if (item.UserId == userId)
                    db.Followers.Remove(item);
            }
            return await db.SaveChangesAsync();
        }

        //delete by user id and singer id
        public async Task<int> DeleteByUserIdAndSingerIdAsync(int userId, int singerId)
        {
            Follower f = db.Followers.FirstOrDefault(k => k.UserId == userId && k.SingerId == singerId);
            if (f == null) return -1;

            db.Followers.Remove(f);
            return await db.SaveChangesAsync();
        }
    }
}
