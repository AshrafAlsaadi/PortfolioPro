using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.BL;
using PortfolioPro.Models;

namespace PortfolioPro.Controllers
{
    public class HomeController : Controller
    {
        IIslider il;
        IIabout ia;
        IIservice iss;
        IIfooter iff;
        public HomeController(IIslider islider,IIabout iabout,IIservice iservice,IIfooter ifooter)
        {
            il = islider;
            ia = iabout;
            iss = iservice;
            iff = ifooter;
        }
        public IActionResult Index()
        {
            ViewModel vmmodel = new ViewModel();
            vmmodel.sliderinfo = il.getall().ToList();
            vmmodel.aboutinfo = ia.getall().ToList();
            vmmodel.serviceinfo = iss.getall().ToList();
            vmmodel.footerinfo = iff.getall().ToList();
            return View(vmmodel);
        }
    }
}
