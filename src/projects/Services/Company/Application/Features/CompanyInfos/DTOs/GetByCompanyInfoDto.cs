using Application.Features.Sectors.DTOs;

namespace Application.Features.CompanyInfos.DTOs
{
    public class GetByCompanyInfoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string CompanyWebSiteUrl { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTelephoneNumber { get; set; }
        public string Info { get; set; }
        public string TaxNumber { get; set; }
        public string TaxInfo { get; set; }
        public string ImagePath { get; set; }
        

    }

}
