﻿namespace WebAPI.Application.Features.UserCryptos.DTOs
{
    public class UpdatedUserCryptoDto
    {
        public int Id { get; set; }
        public int CryptoId { get; set; }
        public string CyrptoUrl { get; set; }
    }
}
