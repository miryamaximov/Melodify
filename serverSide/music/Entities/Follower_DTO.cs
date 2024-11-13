using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Follower_DTO
    {
        public int FollowerId { get; set; }

        public int SingerId { get; set; }

        public int UserId { get; set; }

        public string SingerFirstName { get; set; }

        public string SingerLastName { get; set; }

        public string UserName { get; set; }
    }
}
