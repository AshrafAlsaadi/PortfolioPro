using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioPro.Models
{
    public class ViewModel
    {
        public IEnumerable<TbSlider> sliderinfo { get; set; }
        public IEnumerable<TbAbout> aboutinfo { get; set; }
        public IEnumerable<TbService> serviceinfo { get; set; }
        public IEnumerable<TbFooter> footerinfo { get; set; }
    }
}
