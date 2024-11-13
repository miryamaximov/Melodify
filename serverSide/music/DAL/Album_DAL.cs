using DAL.models;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace DAL
{
    public class Album_DAL
    {
        private readonly MusicContext db;

        public Album_DAL(MusicContext music)
        {
            db = music;
        }

        //get all the list of the albums
        public async Task<List<Album>> SelectAllAsync()
        {
            return await db.Albums.Include(k=> k.AlbumSingerNavigation).ToListAsync();
        }

        //get album by album id
        public async Task<Album> SelectByAlbumIdAsync(int albumId)
        {
            return await db.Albums.Include(k=>k.AlbumSingerNavigation).FirstOrDefaultAsync(k => k.AlbumId == albumId);
        }

        //get list of albums by singer id
        public async Task<List<Album>> SelectAllBySingerIdAsync(int singerId)
        {
            return await db.Albums.Include(k => k.AlbumSingerNavigation).Where(k => k.AlbumSingerId == singerId).ToListAsync();
        }

        //get first album of singer by id
        public async Task<Album> SelectBySingerIdAsync(int singerId)
        {
            return await db.Albums.Include(k => k.AlbumSingerNavigation).FirstOrDefaultAsync(k => k.AlbumSingerId == singerId);
        }

        //add an album
        public async Task<int> AddAlbumAsync(Album album)
        {
            if (album == null || db.Albums.Contains(album))
                return -1;
           
            await db.Albums.AddAsync(album);
            return await db.SaveChangesAsync();
        }

        //delete an album by id
        public async Task<int> DeleteAsync(int albumId)
        {
            int res = -1;
            Album a = await db.Albums.FirstOrDefaultAsync(k => k.AlbumId == albumId);
            if (a == null)
                return res;
            AlbumsDetail_DAL dal = new AlbumsDetail_DAL(db);
            //מחיקת כל השירים של אלבום זה מטבלת פרטי אלבומים
            res = await dal.DeleteAllByAlbumIdAsync(albumId);
            if (res == -1)
                return res;
            db.Albums.Remove(a);
            res = await db.SaveChangesAsync();
            return res;
        }

        //delete all albums of singer by singer id
        public async Task<int> DeleteAllBySingerIdAsync(int singerId)
        {
            foreach (Album item in db.Albums.ToList())
            {
                if (item.AlbumSingerId == singerId)
                    if (await DeleteAsync(item.AlbumId) != 1)
                        return -1;
            }
            return 1;
        }

        //update album details
        public async Task<int> UpdateAsync(Album album)
        {
            if (album == null) return -1;
            Album a = await db.Albums.FirstOrDefaultAsync(k => k.AlbumId == album.AlbumId);
            if (a == null)
                return -1;

            a.AlbumName = album.AlbumName;
            a.AlbumSingerId = album.AlbumSingerId;
            a.PublishingDate = album?.PublishingDate;
            a.UploadDate = album?.UploadDate;
            a.ImageUrl = album?.ImageUrl;
            return await db.SaveChangesAsync();
        }

    }
}
