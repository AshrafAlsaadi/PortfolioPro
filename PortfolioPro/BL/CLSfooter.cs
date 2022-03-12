using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.Models;

namespace PortfolioPro.BL
{
    public interface IIfooter
    {
        List<TbFooter> getall();
        bool Add(TbFooter footer);
        TbFooter getallbyid(int id);
        bool Edit(TbFooter footer);
        bool Delete(int id);
    }
    public class CLSfooter : IIfooter
    {
        PortfolioProContext ff;
        public CLSfooter(PortfolioProContext portfolioProContext)
        {
            ff = portfolioProContext;
        }
        public List<TbFooter> getall()
        {

            List<TbFooter> myfooter = ff.TbFooters.OrderByDescending(a => a.Id).ToList();
            return myfooter;
        }

        public bool Add(TbFooter footer)
        {
            try
            {

                ff.Add<TbFooter>(footer);
                ff.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TbFooter getallbyid(int id)
        {

            TbFooter footer = ff.TbFooters.FirstOrDefault(a => a.Id == id);
            return footer;
        }

        public bool Edit(TbFooter footer)
        {
            try
            {

                ff.Entry(footer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ff.SaveChanges();
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

                TbFooter footer = ff.TbFooters.Where(a => a.Id == id).FirstOrDefault();
                ff.TbFooters.Remove(footer);
                ff.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
