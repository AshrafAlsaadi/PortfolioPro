using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.BL;
using PortfolioPro.Models;
using Microsoft.AspNetCore.Http;

namespace PortfolioPro.Areas.Admin.Controllers
{
        [Area("Admin")]
        public class FooterController : Controller
        {
            IIfooter fo;

            public FooterController(IIfooter islider)
            {
                fo = islider;
            }
            public IActionResult MyFooter()

            {

                return View(fo.getall());
            }

            public IActionResult Edit(int? id)
            {
                if (id != null)
                {

                    return View(fo.getallbyid(Convert.ToInt32(id)));
                }
                else
                {
                    return View();
                }

            }

            public IActionResult Delete(int id)
            {
                fo.Delete(id);
                return RedirectToAction("MyFooter");
            }


            [HttpPost]
            public IActionResult Save(TbFooter footer)
            {
                if (ModelState.IsValid)
                {
                
                    if (footer.Id == 0 || footer.Id == null)
                    {
                        fo.Add(footer);
                        return RedirectToAction("MyFooter");
                    }


                    else
                    {
                        fo.Edit(footer);
                        return RedirectToAction("MyFooter");
                    }
                }
                else
                {
                    return View(footer);
                }
            }

        }
    }

