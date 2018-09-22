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

            _db.RvspResponses.Add(rvsp);
            _db.SaveChanges();

            _smtp.SendMail(rvsp.Email);

            return true;

        }
        public bool DeleteRvsp(RvspModel rvsp)
        {
            RvspModel removable = _db.RvspResponses.FirstOrDefault(x => x.RvspId == rvsp.RvspId);
            if (removable == null) return false;
                
            _db.RvspResponses.Remove(removable);              
            _db.SaveChanges();
            
            return true;
        }

        public DbSet<RvspModel> GetRvsp()
        {
            return _db.RvspResponses;
        }


    }
}