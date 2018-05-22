using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.CMS.DAL.DTO
{
    public class SizeListDto
    {
        public int? SizeId { get; set; }
        public int Size { get; set; }
        public DateTime Updated { get; set; }
        public int UserIdUpdated { get; set; }
        public int Deleted { get; set; }
    }
}
