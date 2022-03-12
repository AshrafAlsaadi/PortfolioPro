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
    public class ServiceController : Controller
    {
        IIservice si;

        public ServiceController(IIservice islider)
        {
            si = islider;
        }
        public IActionResult MyService()
            
        {

            return View(si.getall());
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {

                return View(si.getallbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Delete(int id)
        {
            si.Delete(id);
            return RedirectToAction("MyService");
        }


        [HttpPost]
        public async Task<IActionResult> Save(TbService service, List<IFormFile> Files)
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
                        service.Image = Image;
                    }

                }

                if (service.Id == 0 || service.Id == null)
                {
                    si.Add(service);
                    return RedirectToAction("MyService");
                }


                else
                {
                    si.Edit(service);
                    return RedirectToAction("MyService");
                }
            }
            else
            {
                return View(service);
            }
        }

    }
}

