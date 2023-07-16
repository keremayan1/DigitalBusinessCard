using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaImages.Rules
{
    public class SocialMediaImageBusinessRules
    {
        private ISocialMediaImageRepository _socialMediaImageRepository;

        public SocialMediaImageBusinessRules(ISocialMediaImageRepository socialMediaImageRepository)
        {
            _socialMediaImageRepository = socialMediaImageRepository;
        }

        public async Task<bool> CheckIfSocialMediaIdExists(int socialMediaId)
        {
            var result = await _socialMediaImageRepository.GetAsync(x => x.SocialMediaId == socialMediaId);
            if (result != null)
            {
                throw new Exception("Bu Sosyal Medyanın Resmi Sistemde Bulunmaktadır!");
            }
            return true;
        }
        public async Task<bool> CheckIfSocialMediaIdIsNull(int socialMediaId)
        {
            var result = await _socialMediaImageRepository.GetAsync(x => x.SocialMediaId == socialMediaId);
            if (result == null)
            {
                throw new Exception("Bu Sosyal Medyanın Kayıdı Sistemde Bulunmamaktadır!");
            }
            return true;
        }
    }
}
