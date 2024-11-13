using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Playlist_DAL
    {
        private readonly MusicContext db;
        public Playlist_DAL(MusicContext music)
        {
            db = music;
        }

        //get all the playlist that not active
        public async Task<List<Playlist>> SelectAllNotActiveAsync()
        {
            return await db.Playlists.Include(k => k.User).Where(k => k.IsActive == false).ToListAsync();
        }

        //get playlist not active by id
        public async Task<Playlist> SelectByIdNotActiveAsync(int playlistId)
        {
            return await db.Playlists.Include(k => k.User).FirstOrDefaultAsync(k => k.PlaylistId == playlistId && k.IsActive == false);
        }

        //get all playlist not actiive by user id
        public async Task<List<Playlist>> SelectAllByUserIdNotActiveAsync(int userId)
        {
            return await db.Playlists.Include(k => k.User).Where(k => k.UserId == userId && k.IsActive == false).ToListAsync();
        }

        //get all the playlists
        public async Task<List<Playlist>> SelectAllAsync()
        {
            return await db.Playlists.Include(k=> k.User).Where(k=> k.IsActive == true).ToListAsync();
        }

        //get playlist by id
        public async Task<Playlist> SelectByIdAsync(int playlistId)
        {
            return await db.Playlists.Include(k => k.User).FirstOrDefaultAsync(k => k.PlaylistId == playlistId && k.IsActive == true);
        }

        //get all playlists by user id
        public async Task<List<Playlist>> SelectAllByUserIdAsync(int userId)
        {
            return await db.Playlists.Include(k => k.User).Where(k=> k.UserId == userId && k.IsActive == true).ToListAsync();  
        }

        //get first playlist by user id
        public async Task<Playlist> SelectByUserIdAsync(int userId)
        {
            return await db.Playlists.Include(k => k.User).FirstOrDefaultAsync(k => k.UserId  == userId && k.IsActive == true);
        }

        //add a playlist
        public async Task<int> AddPlaylistAsync(Playlist playlist)
        {
            if (playlist == null || db.Playlists.Contains(playlist))
                return -1;
            playlist.IsActive = true;
            await db.Playlists.AddAsync(playlist);
            return await db.SaveChangesAsync();
        }

        //delete a playlist by id
        public async Task<int> DeleteAsync(int playlistId)
        {
            Playlist p = await db.Playlists.FirstOrDefaultAsync(k => k.PlaylistId == playlistId);
            if (p == null)
                return -1;
            SharedPlaylistsDetail_DAL dal1 = new SharedPlaylistsDetail_DAL(db);
            //הפלייליסט שותף כבר לחברים ולכן אי אפשר למחוק אותו
            //רק נשנה את הסטטוס שלו ללא פעיל
            if (await dal1.SelectByPlaylistIdAsync(playlistId) != null)
            {
                return await UpdateAsync(new Playlist()
                {
                    PlaylistId = p.PlaylistId,
                    UserId = p.UserId,
                    ProductionDate = p.ProductionDate,
                    UpdateDate = p.UpdateDate,
                    IsActive = false
                });
            }
            else
            {
                //מחיקת כל השירים של הפלייליסט הזה מטבלת פרטי פלייליסטים
                PlaylistsDetail_DAL dal2 = new PlaylistsDetail_DAL(db);
                await dal2.DeleteAllByPlaylistIdAsync(playlistId);
                db.Playlists.Remove(p);
            }

            return await db.SaveChangesAsync();
        }

       

        //update palylist details
        public async Task<int> UpdateAsync(Playlist playlist)
        {
            if (playlist == null) return -1;
            Playlist p = await db.Playlists.FirstOrDefaultAsync(k => k.PlaylistId == playlist.PlaylistId);
            if (p == null) return -1;
            p.UserId = playlist.UserId;
            p.ProductionDate = playlist?.ProductionDate;
            p.UpdateDate = playlist?.UpdateDate;
            p.PlaylistName = playlist?.PlaylistName;
            p.IsActive = playlist.IsActive;
            return await db.SaveChangesAsync();
        }


    }
}
