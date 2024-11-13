using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Singer_DTO
    {
        public int SingerId { get; set; }

        public string SingerFirstName { get; set; } = null!;

        public string? SingerLastName { get; set; }

        public string? ImageUrl { get; set; }

        public string? SingerAbout { get; set; }

        public int? NumOfAlbums { get; set; }

        public int? NumOfSongs { get; set; }
    }
}
