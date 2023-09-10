using Core.Persistance.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class CompanyInfo : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SectorId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string CompanyWebSiteUrl { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTelephoneNumber { get; set; }
        public string Info { get; set; }
        public string TaxNumber { get; set; }
        public string TaxInfo { get; set; }
        public string CompanyLogoPath { get; set; }

        public virtual CompanyInfoImage? CompanyInfoImage { get; set; }

        public virtual Sector? Sector { get; set; }
        public virtual List<Address>? Addresses { get; set; }
        public CompanyInfo()
        {

        }

        public CompanyInfo(int id, string userId, string companyName, string companyTitle, string companyEmail, string companyWebSiteUrl, string companyTelephoneNumber, string ınfo, string taxNumber, string taxInfo, string companyLogoPath) : this()
        {
            Id = id;
            UserId = userId;
            CompanyName = companyName;
            CompanyTitle = companyTitle;

            CompanyEmail = companyEmail;
            CompanyWebSiteUrl = companyWebSiteUrl;
            CompanyTelephoneNumber = companyTelephoneNumber;
            Info = ınfo;
            TaxNumber = taxNumber;
            TaxInfo = taxInfo;
            CompanyLogoPath = companyLogoPath;
        }
    }

}
