using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AlbumsDetail_DTO
    {
        public int AlbumsDetailsId { get; set; }

        public int AlbumId { get; set; }

        public int SongId { get; set; }

        public string AlbumName { get; set; }

        public string SongName { get; set; }
    }
}
