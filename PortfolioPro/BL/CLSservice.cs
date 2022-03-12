using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.Models;

namespace PortfolioPro.BL
{
    public interface IIservice
    {
        List<TbService> getall();
        bool Add(TbService service);
        TbService getallbyid(int id);
        bool Edit(TbService service);
        bool Delete(int id);
    }
    public class CLSservice : IIservice
    {
        PortfolioProContext ss;
        public CLSservice(PortfolioProContext portfolioProContext)
        {
            ss = portfolioProContext;
        }
        public List<TbService> getall()
        {

            List<TbService> myservice = ss.TbServices.OrderByDescending(a => a.Id).ToList();
            return myservice;
        }

        public bool Add(TbService service)
        {
            try
            {

                ss.Add<TbService>(service);
                ss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TbService getallbyid(int id)
        {

            TbService service = ss.TbServices.FirstOrDefault(a => a.Id == id);
            return service;
        }

        public bool Edit(TbService service)
        {
            try
            {

                ss.Entry(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

                TbService service = ss.TbServices.Where(a => a.Id == id).FirstOrDefault();
                ss.TbServices.Remove(service);
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
   
