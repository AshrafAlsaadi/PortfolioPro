using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.Models;


namespace PortfolioPro.BL
{
    public interface IIslider
    {
        List<TbSlider> getall();
        bool Add(TbSlider slider);
        TbSlider getallbyid(int id);
        bool Edit(TbSlider slider);
        bool Delete(int id);
    }
    public class CLSslider:IIslider
    {
        PortfolioProContext ss;
        public CLSslider(PortfolioProContext portfolioProContext)
        {
            ss = portfolioProContext;
        }
        public List<TbSlider> getall()
        {

            List<TbSlider> Myslider = ss.TbSliders.OrderByDescending(a => a.Id).ToList();
            return Myslider;
        }

        public bool Add(TbSlider slider)
        {
            try
            {

                ss.Add<TbSlider>(slider);
                ss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TbSlider getallbyid(int id)
        {

            TbSlider slider = ss.TbSliders.FirstOrDefault(a => a.Id == id);
            return slider;
        }

        public bool Edit(TbSlider slider)
        {
            try
            {

                ss.Entry(slider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ss.SaveChanges();
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

                TbSlider oslide = ss.TbSliders.Where(a => a.Id == id).FirstOrDefault();
                ss.TbSliders.Remove(oslide);
                ss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

