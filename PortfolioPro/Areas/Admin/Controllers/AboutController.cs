using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.BL;
using PortfolioPro.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace PortfolioPro.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        IIabout ii;

        public AboutController(IIabout islider)
        {
            ii = islider;
        }
        public IActionResult MyAbout()
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
            return RedirectToAction("MyAbout");
        }


        [HttpPost]
        public async Task<IActionResult> Save(TbAbout about, List<IFormFile> Files)
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
                        about.Image = Image;
                    }

                }

                if (about.Id == 0 || about.Id == null)
                {
                    ii.Add(about);
                    return RedirectToAction("MyAbout");
                }


                else
                {
                    ii.Edit(about);
                    return RedirectToAction("MyAbout");
                }
            }
            else
            {
                return View("MyAbout");
            }
        }

    }
}

