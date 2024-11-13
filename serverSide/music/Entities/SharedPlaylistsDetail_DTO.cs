using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SharedPlaylistsDetail_DTO
    {
        public int SharedPlaylistsDetailsId { get; set; }
        public int PlaylistId { get; set; }

        public int UserId { get; set; }

        public string PlaylistName { get; set; }

        public string UserName { get; set; }


    }
}
