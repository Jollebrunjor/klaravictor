using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using klaravictor.Models;

namespace klaravictor.Services
{
    public class RvspService : IRvspService
    {
        private readonly DataModel _db;
        private readonly ISmtpService _smtp;
        public RvspService()
        {
            _db = new DataModel();
            _smtp = new SmtpService();
        }

        public bool SaveRvsp(RvspModel rvsp)
        {
            if (rvsp == null) return false;

            try
            {
                _db.RvspResponses.Add(rvsp);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            _smtp.SendMail(rvsp.Email, rvsp.Name);
            return true;

        }
        public bool DeleteRvsp(RvspModel rvsp)
        {
            RvspModel removable = _db.RvspResponses.FirstOrDefault(x => x.RvspId == rvsp.RvspId);
            if (removable == null) return false;

            try
            {
                _db.RvspResponses.Remove(removable);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            
            return true;
        }

        public DbSet<RvspModel> GetRvsp()
        {
            return _db.RvspResponses;
        }


    }
}