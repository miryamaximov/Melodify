using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class User_DAL
    {
        private readonly MusicContext db;
        public User_DAL(MusicContext music)
        {
            db = music;
        }

        //get all
        public async Task<List<User>> SelectAllAsync()
        {
            return await db.Users.Include(k=>k.Playlists).ToListAsync();
        }

        //get user by id
        public async Task<User> SelectByIdAsync(int userId)
        {
            return await db.Users.Include(k => k.Playlists).FirstOrDefaultAsync(k => k.UserId == userId);
        }

        //get user by password
        public async Task<User> SelectByPasswordAsync(string pass)
        {
            return await db.Users.Include(k => k.Playlists).FirstOrDefaultAsync(k => k.UserPass.Equals(pass));
        }

        //get user by email
        public async Task<User> SelectByEmailAsync(string email)
        {
            return await db.Users.Include(k => k.Playlists).FirstOrDefaultAsync(k => k.UserEmail.Equals(email));
        }

        //get user by name and password
        public async Task<User> SelectByNameAndPasswordAsync(string name, string pass)
        {
            return await db.Users.Include(k => k.Playlists).FirstOrDefaultAsync(k => k.UserName.Equals(name) && k.UserPass.Equals(pass));
        }

        //add user
        public async Task<int> AddUserAsync(User user)
        {
            if (user == null || db.Users.Contains(user))
                return -1;
            await db.Users.AddAsync(user);
            return await db.SaveChangesAsync();
        }

        //update user
        public async Task<int> UpdateAsync(User user)
        {
            if (user == null) return -1;
            User u = await db.Users.FirstOrDefaultAsync(k => k.UserId == user.UserId);
            if (u == null)
                return -1;
            u.UserName = user.UserName;
            u.UserPass = user.UserPass;
            u.UserEmail = user?.UserEmail;
            return await db.SaveChangesAsync();
        }

        //delete user
        public async Task<int> DeleteAsync(int userId)
        {
            User u = await db.Users.FirstOrDefaultAsync(k => k.UserId == userId);
            if (u == null)
                return -1;

            //מחיקת כל הרשומות שמתארות את הזמרים שהמשתמש הזה עוקב אחריהם
            Follower_DAL dal1 = new Follower_DAL(db);
            await dal1.DeleteAllByUserIdAsync(userId);
           

            //מחיקת כל הפלייליסטים שהמשתמש הזה יצר,
            //במחיקה מתבצעת גם בדיקה האם הפלייליסט שותף לחברים
            //ואם כן לא תתבצע מחיקה אלא עדכון של סטטוס הפלייליסט ללא פעיל
            Playlist_DAL dal2 = new Playlist_DAL(db);
            foreach (Playlist playlist in db.Playlists.ToList())
            {
                if (playlist.UserId == userId)
                    await dal2.DeleteAsync(userId);
            }

            //מחיקת כל הרשומות שמתארות את הפלייליסטים ששותפו לו
            SharedPlaylistsDetail_DAL dal3 = new SharedPlaylistsDetail_DAL(db);
            if (await dal3.SelectByUserIdAsync(userId) != null)   //SelectAllByUserIdAsync(userId).Result[0]
                await dal3.DeleteAllByUserIdAsync(userId);

            db.Users.Remove(u);
            return await db.SaveChangesAsync();
        }

    }
}
