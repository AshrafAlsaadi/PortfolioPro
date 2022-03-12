using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.BL;
using Microsoft.AspNetCore.Http;
using PortfolioPro.Models;
using System.IO;

namespace PortfolioPro.Area.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        IIslider ii;

        public SliderController(IIslider islider)
        {
            ii = islider;
        }
        public IActionResult MySlider()
        {


            return View(ii.getall());
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {

                return View(ii.getallbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Delete(int id)
        {
            ii.Delete(id);
            return RedirectToAction("MySlider");
        }


        [HttpPost]
        public async Task<IActionResult> Save(TbSlider slider, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Admin\img", Image);
                        using (var stream = System.IO.File.Create(FilePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        slider.Image = Image;
                    }

                }

                if (slider.Id == 0 || slider.Id == null)
                {
                    ii.Add(slider);
                    return RedirectToAction("MySlider");
                }


                else
                {
                    ii.Edit(slider);
                    return RedirectToAction("MySlider");
                }
            }
            else
            {
                return View("MySlider");
            }
        }

    }
}


    
