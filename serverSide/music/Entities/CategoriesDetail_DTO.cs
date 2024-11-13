using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CategoriesDetail_DTO
    {
        public int CategoriesDetailsId { get; set; }

        public int CategoryId { get; set; }

        public int SongId { get; set; }

        public string CategoryName { get; set; }

        public string SongName { get; set; }
    }
}
