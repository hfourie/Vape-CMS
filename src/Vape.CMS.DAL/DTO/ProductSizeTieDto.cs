﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.CMS.DAL.DTO
{
   public class ProductSizeTieDto
    {
        public int? ProductSizeTieId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public double SizeAmount { get; set; }
        public double SizeDiscount { get; set; }
        public int SizeStock { get; set; }
    }
}
