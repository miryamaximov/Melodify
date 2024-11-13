using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Playlist_DTO
    {

        public int PlaylistId { get; set; }

        public string? PlaylistName { get; set; }

        public int UserId { get; set; }

        public DateTime? ProductionDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UserName { get; set; }
    }
}
