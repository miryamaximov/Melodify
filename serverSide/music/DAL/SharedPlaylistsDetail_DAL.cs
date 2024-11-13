using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SharedPlaylistsDetail_DAL
    {
        private readonly MusicContext db;
        public SharedPlaylistsDetail_DAL(MusicContext music)
        {
            db = music;
        }

        //get all 
        public async Task<List<SharedPlaylistsDetail>> SelectAllAsync()
        {
            return await db.SharedPlaylistsDetails.Include(k=>k.Playlist).Include(k=> k.User).Where(k=> k.IsActive == true).ToListAsync();
        }

        //get all by user id
        public async Task<List<SharedPlaylistsDetail>> SelectAllByUserIdAsync(int userId)
        {
            return await db.SharedPlaylistsDetails.Include(k => k.Playlist).Include(k => k.User).Where(k=> k.UserId == userId && k.IsActive == true).ToListAsync();
        }

        //get first by user id
        public async Task<SharedPlaylistsDetail?> SelectByUserIdAsync(int userId)
        {
            return await db.SharedPlaylistsDetails.Include(k => k.Playlist).Include(k => k.User).FirstOrDefaultAsync(k => k.UserId == userId && k.IsActive == true );
        }

        //get all by playlist id
        public async Task<List<SharedPlaylistsDetail>> SelectAllByPlaylistIdAsync(int playlistId)
        {
            return await db.SharedPlaylistsDetails.Include(k => k.Playlist).Include(k => k.User).Where(k => k.PlaylistId == playlistId && k.IsActive == true).ToListAsync();
        }

        //get one by playlist id
        public async Task<SharedPlaylistsDetail?> SelectByPlaylistIdAsync(int playlistId)
        {
            return await db.SharedPlaylistsDetails.Include(k => k.Playlist).Include(k => k.User).FirstOrDefaultAsync(k => k.PlaylistId == playlistId && k.IsActive == true);
        }

        //add a record to the shared playlist
        public async Task<int> AddSharedPlaylistDetailAsync(SharedPlaylistsDetail detail)
        {
            if (detail == null || db.SharedPlaylistsDetails.Contains(detail))
                return -1;
            detail.IsActive = true;
            await db.SharedPlaylistsDetails.AddAsync(detail);
            return await db.SaveChangesAsync();
        }

        //delete record by playlist id and user id
        public async Task<int> DeleteByPlaylistIdAndUserIdAsync(int playlistId, int userId)
        {
            SharedPlaylistsDetail s = db.SharedPlaylistsDetails.FirstOrDefault(k => k.PlaylistId == playlistId && k.UserId == userId);
            if (s == null)
                return -1;
           
            db.SharedPlaylistsDetails.Remove(s);
            return await db.SaveChangesAsync();
        }

        //delete all records by user id - משמש רק במחיקת משתמש
        public async Task<int> DeleteAllByUserIdAsync(int userId)
        {
            
            foreach (SharedPlaylistsDetail item in db.SharedPlaylistsDetails.ToList())
            {
                if (item.UserId == userId)
                    db.SharedPlaylistsDetails.Remove(item);
            }
            return await db.SaveChangesAsync();
        }

        //לא שייך עדכון מכיוון שאין אפשרות לעדכן קוד פלייליסט או קוד משתמש

    }
}
