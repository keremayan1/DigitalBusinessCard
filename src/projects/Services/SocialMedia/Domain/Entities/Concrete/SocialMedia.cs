﻿using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class SocialMedia:Entity
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
       
    }
}