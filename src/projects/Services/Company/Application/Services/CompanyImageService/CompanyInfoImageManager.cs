using Application.Services.Repositories;
using Core.Persistance.Images;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CompanyImageService
{
    public class CompanyInfoImageManager : ICompanyInfoImageService
    {
        private ICompanyInfoImageRepository _companyInfoImageRepository;
        private ImageService _imageService;

        public CompanyInfoImageManager(ICompanyInfoImageRepository companyInfoImageRepository, ImageService imageService)
        {
            _companyInfoImageRepository = companyInfoImageRepository;
            _imageService = imageService;
        }

        public async Task<CompanyInfoImage> AddCompanyInfoImage(CompanyInfoImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var uploadFile = await _imageService.UploadFile(formFile, cancellationToken);
            image.ImagePath = uploadFile;
            image.Date = DateTime.Now;
            var result = await _companyInfoImageRepository.AddAsync(image);

            return result;
        }

        public async Task<CompanyInfoImage> DeleteCompanyInfoImage(int companyInfoId)
        {
            var getId = await _companyInfoImageRepository.GetAsync(x => x.Id == companyInfoId);
            _imageService.DeleteFile(getId.ImagePath);
            await _companyInfoImageRepository.DeleteAsync(getId);
            return getId;


        }

        public async Task<CompanyInfoImage> UpdateCompanyInfoImage(CompanyInfoImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var getId = await _companyInfoImageRepository.GetAsync(x => x.CompanyId == image.CompanyId);
            _imageService.DeleteFile(getId.ImagePath);

            var addPhoto = await _imageService.UploadFile(formFile, cancellationToken);
            getId.ImagePath = addPhoto;
            getId.Date = DateTime.Now;

            var result = await _companyInfoImageRepository.UpdateAsync(getId);
            return result;
        }
    }
}
