using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PlaylistsDetail_DAL
    {
        private readonly MusicContext db;
        public PlaylistsDetail_DAL(MusicContext music)
        {
            db = music;
        }

        //get all
        public async Task<List<PlaylistsDetail>> SelectAllAsync()
        {
            return await db.PlaylistsDetails.Include(k=> k.Song).Include(k=>k.Playlist).ToListAsync();
        }

        //get all by playlist id
        public async Task<List<PlaylistsDetail>> SelectAllByPlaylistIdAsync(int playlistId)
        {
            return await db.PlaylistsDetails.Include(k => k.Song).Include(k => k.Playlist).Where(k=> k.PlaylistId == playlistId).ToListAsync();
        }

        //get first by playlist id
        public async Task<PlaylistsDetail> SelectByPlaylistIdAsync(int playlistId)
        {
            return await db.PlaylistsDetails.Include(k => k.Song).Include(k => k.Playlist).FirstOrDefaultAsync(k => k.PlaylistId == playlistId);
        }

        //get all by song id
        public async Task<List<PlaylistsDetail>> SelectAllBySongIdAsync(int songId)
        {
            return await db.PlaylistsDetails.Include(k => k.Song).Include(k => k.Playlist).Where(k => k.SongId == songId).ToListAsync();
        }

        //get by song id
        public async Task<PlaylistsDetail> SelectBySongIdAsync(int songId)
        {
            return await db.PlaylistsDetails.Include(k => k.Song).Include(k => k.Playlist).FirstOrDefaultAsync(k => k.SongId == songId);
        }

        //add a song to the playlist
        public async Task<int> AddPlaylistDetailAsync(PlaylistsDetail detail)
        {
            if (detail == null || db.PlaylistsDetails.Contains(detail))
                return -1;
            await db.PlaylistsDetails.AddAsync(detail);
            return await db.SaveChangesAsync();
        }

        //delete all records by playlist id - משמש רק למחיקת פלייליסט
        public async Task<int> DeleteAllByPlaylistIdAsync(int playlistId)
        {
            foreach (PlaylistsDetail item in db.PlaylistsDetails.ToList())
            {
                if (item.PlaylistId == playlistId)
                    db.PlaylistsDetails.Remove(item);
            }
            return await db.SaveChangesAsync();
        }

        //delete all recrds by song id - משמש רק למחיקת שיר שאז אני מוחקת אותו מכל הפלייליסטים
        public async Task<int> DeleteAllBySongIdAsync(int songId)
        {
            foreach(PlaylistsDetail p in db.PlaylistsDetails.ToList())
            {
                if (p.SongId == songId)
                    db.PlaylistsDetails.Remove(p);
            }
            return await db.SaveChangesAsync();
        }

        //delete by song id and playlist id
        public async Task<int> DeleteBySongIdAndPlaylistIdAsync(int songId, int playlistId)
        {
            PlaylistsDetail p = db.PlaylistsDetails.FirstOrDefault(k => k.SongId == songId && k.PlaylistId == playlistId);
            if (p == null)
                return -1;
            db.PlaylistsDetails.Remove(p);
            return await db.SaveChangesAsync();
        }

        //לא שייך במחלקה זו עדכון מכיוון שאין אפשרות לעדכן קוד פלייליסט או קוד שיר
    }
}
