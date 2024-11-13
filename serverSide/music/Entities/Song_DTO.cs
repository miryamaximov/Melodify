using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Song_DTO
    {
        public int SongId { get; set; }

        public string SongName { get; set; } = null!;

        public int SingerId { get; set; }

        public string SingerFirstName { get; set; }

        public string SingerLastName { get; set; }

        public DateTime? PublishingDate { get; set; }

        public DateTime? UploadDate { get; set; }

        public string SongUrl { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? SongAbout { get; set; }

        public int? LikeNum { get; set; }
    }
}
