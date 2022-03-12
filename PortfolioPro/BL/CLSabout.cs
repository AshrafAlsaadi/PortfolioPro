using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.Models;

namespace PortfolioPro.BL
{
    public interface IIabout
    {
        List<TbAbout> getall();
        bool Add(TbAbout about);
        TbAbout getallbyid(int id);
        bool Edit(TbAbout about);
        bool Delete(int id);
    }
    public class CLSabout : IIabout
    {
        PortfolioProContext aa;
        public CLSabout(PortfolioProContext portfolioProContext)
        {
            aa = portfolioProContext;
        }
        public List<TbAbout> getall()
        {

            List<TbAbout> myabout = aa.TbAbouts.OrderByDescending(a => a.Id).ToList();
            return myabout;
        }

        public bool Add(TbAbout about)
        {
            try
            {

                aa.Add<TbAbout>(about);
                aa.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TbAbout getallbyid(int id)
        {

            TbAbout about = aa.TbAbouts.FirstOrDefault(a => a.Id == id);
            return about;
        }

        public bool Edit(TbAbout about)
        {
            try
            {

                aa.Entry(about).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                aa.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                TbAbout about = aa.TbAbouts.Where(a => a.Id == id).FirstOrDefault();
                aa.TbAbouts.Remove(about);
                aa.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
