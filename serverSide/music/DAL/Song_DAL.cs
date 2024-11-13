using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Song_DAL
    {
        private readonly MusicContext db;
        public Song_DAL(MusicContext music)
        {
            db = music;
        }

        //get all the songs
        public async Task<List<Song>> SelectAllAsync()
        {
            return await db.Songs.Include(k=> k.Singer).ToListAsync();
        }

        //get song by id
        public async Task<Song> SelectBySongIdAsync(int songId)
        {
            return await db.Songs.Include(k => k.Singer).FirstOrDefaultAsync(k => k.SongId == songId);
        }

        //get all the songs by singer id
        public async Task<List<Song>> SelectAllBySingerIdAsync(int singerId)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.SingerId == singerId).ToListAsync();
        }

        //get first song by singer id
        public async Task<Song> SelectBySingerIdAsync(int singerId)
        {
            return await db.Songs.Include(k => k.Singer).FirstOrDefaultAsync(k => k.SingerId == singerId);
        }

        //get all the songs by number of likes
        public async Task<List<Song>> SelectAllByNumLikesAsync(int numLikes)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.LikeNum == numLikes).ToListAsync();
        }

        //get all the songs by number of likes but above this number
        public async Task<List<Song>> SelectAllByNumLikesAboveAsync(int numLikes)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.LikeNum > numLikes).ToListAsync();
        }

        //get all the songs by number of likes but less this number
        public async Task<List<Song>> SelectAllByNumLikesLessAsync(int numLikes)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.LikeNum < numLikes).ToListAsync();
        }

        //get all the songs the publishing date equal the date of the parameter
        public async Task<List<Song>> SelectAllByPublishingDateAsync(DateTime publishongDate)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.PublishingDate == publishongDate).ToListAsync();
        }

        //get all the songs the publishing date after the date of the parameter
        public async Task<List<Song>> SelectAllByPublishingDateAfterAsync(DateTime publishongDate)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.PublishingDate > publishongDate).ToListAsync();
        }

        //get all the songs the publishing date before the date of the parameter
        public async Task<List<Song>> SelectAllByPublishingDateBeforeAsync(DateTime publishongDate)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.PublishingDate < publishongDate).ToListAsync();
        }

        //get all the songs the publishing date equal the date of the parameter
        public async Task<List<Song>> SelectAllByUploadDateAsync(DateTime uploadDate)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.UploadDate == uploadDate).ToListAsync();
        }

        //get all the songs the publishing date after the date of the parameter
        public async Task<List<Song>> SelectAllByUploadDateAfterAsync(DateTime uploadDate)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.UploadDate > uploadDate).ToListAsync();
        }

        //get all the songs the publishing date before the date of the parameter
        public async Task<List<Song>> SelectAllByUploadDateBeforeAsync(DateTime uploadDate)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.UploadDate < uploadDate).ToListAsync();
        }


        //get all the songs that contain this string in their name
        public async Task<List<Song>> SelectAllContainStrInNameAsync(string str)
        {
            return await db.Songs.Include(k => k.Singer).Where(k => k.SongName.Contains(str)).ToListAsync();
        }

        //add a song
        public async Task<int> AddSongAsync(Song song)
        {
            if (song == null || db.Songs.Contains(song))
                return -1;
           
            await db.Songs.AddAsync(song);
            return await db.SaveChangesAsync();
        }

        //delete song by id
        public async Task<int> DeleteByIdAsync(int songId)
        {
            Song s = db.Songs.FirstOrDefault(k => k.SongId == songId);
            if (s == null)
                return -1;

            //delete the song from the album
            AlbumsDetail_DAL dal1 = new AlbumsDetail_DAL(db);
            if (await dal1.SelectBySongIdAsync(songId) != null)
                await dal1.DeleteBySongIdAsync(songId);
         
          //delete the song from all the categories
            CategoriesDetail_DAL dal2 = new CategoriesDetail_DAL(db);
            if (await dal2.SelectBySongIdAsync(songId) != null)
                await dal2.DeleteAllBySongIdAsync(songId);
           
            //delete the song from all the playlists
            PlaylistsDetail_DAL dal3 = new PlaylistsDetail_DAL(db);
            if (await dal3.SelectBySongIdAsync(songId) != null)
                await dal3.DeleteAllBySongIdAsync(songId);
          
            db.Songs.Remove(s);
            return await db.SaveChangesAsync();
        }

        //delete all by singer id
        public async Task<int> DeleteAllBySingerIdAsync(int singerId)
        {
            foreach (Song item in db.Songs.ToList())
            {
                if (item.SingerId == singerId)
                    if (await DeleteByIdAsync(singerId) != 1)
                        return -1;
            }
            return 1;
        }

        //update song
        public async Task<int> UpdateAsync(Song song)
        {
            if (song == null) return -1;
            Song s = db.Songs.FirstOrDefault(k => k.SongId == song.SongId);
            if (s == null)
                return -1;

            s.SongName = song.SongName;
            s.SingerId = song.SingerId;
            s.PublishingDate = song?.PublishingDate;
            s.UploadDate = song?.UploadDate;
            s.SongUrl = song.SongUrl;
            s.ImageUrl = song?.ImageUrl;
            s.SongAbout = song?.SongAbout;
            s.LikeNum = song?.LikeNum;
            return await db.SaveChangesAsync();
        }

    }
}
