using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AlbumsDetail_DAL
    {
        private readonly MusicContext db;

        public AlbumsDetail_DAL(MusicContext music)
        {
            db = music;
        }

        //get all
        public async Task<List<AlbumsDetail>> SelectAllAsync()
        {
            return await db.AlbumsDetails.Include(k=>k.Album).Include(k=>k.Song).ToListAsync();
        }

        //get all by album id
        public async Task<List<AlbumsDetail>> SelectAllByAlbumIdAsync(int albumId)
        {
            return await db.AlbumsDetails.Include(k => k.Album).Include(k => k.Song).Where(k=> k.AlbumId == albumId).ToListAsync();
        }

        //get first by album id
        public async Task<AlbumsDetail> SelectByAlbumId(int albumId)
        {
            return await db.AlbumsDetails.Include(k => k.Album).Include(k => k.Song).FirstOrDefaultAsync(k => k.AlbumId == albumId);
        }

        //get by song id
        public async Task<AlbumsDetail> SelectBySongIdAsync(int songId)
        {
            return await db.AlbumsDetails.Include(k => k.Album).Include(k => k.Song).FirstOrDefaultAsync(k => k.SongId == songId);
        }

        //add a song to the album details
        public async Task<int> AddAlbumDetailAsync(AlbumsDetail detail)
        {
            if (detail == null || db.AlbumsDetails.Contains(detail))
                return -1;
            await db.AlbumsDetails.AddAsync(detail);
            return await db.SaveChangesAsync();
        }


        //delete all records that albumId equal to the parameter
        public async Task<int> DeleteAllByAlbumIdAsync(int albumId)
        {
           
            foreach (AlbumsDetail item in db.AlbumsDetails.ToList())
            {
                if (item.AlbumId == albumId)
                    db.AlbumsDetails.Remove(item);
            }
            return await db.SaveChangesAsync();
        }

        //delete by song id
        public async Task<int> DeleteBySongIdAsync(int songId)
        {
            AlbumsDetail a = db.AlbumsDetails.FirstOrDefault(k => k.SongId == songId);
            if (a == null)
                return -1;
            db.AlbumsDetails.Remove(a);
            return await db.SaveChangesAsync();
        }

        //לא שייך עדכון במחלקה זו מכיוון שאין אפשרות לעדכן קוד אלבום או קוד שיר


    }
}
