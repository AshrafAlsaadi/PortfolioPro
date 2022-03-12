using System;
using System.Collections.Generic;

#nullable disable

namespace PortfolioPro.Models
{
    public partial class TbFooter
    {
        public int? Id { get; set; }
        public string YourName { get; set; }
        public string YourEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
