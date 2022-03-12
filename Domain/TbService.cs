using System;
using System.Collections.Generic;

#nullable disable

namespace PortfolioPro.Models
{
    public partial class TbService
    {
        public int? Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string Image { get; set; }
    }
}
