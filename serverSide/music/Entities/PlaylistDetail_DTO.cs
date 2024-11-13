using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlaylistDetail_DTO
    {
        public int PlaylistsDetailsId { get; set; }

        public int PlaylistId { get; set; }

        public int SongId { get; set; }

        public string SongName { get; set; }

        public string PlaylistName { get; set; }
    }
}
