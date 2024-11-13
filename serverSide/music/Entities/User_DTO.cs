using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User_DTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserPass { get; set; } = null!;

        public string? UserEmail { get; set; }

        public bool IsAdmin { get; set; }

        public int? NumOfPlaylists { get; set; }
    }
}
