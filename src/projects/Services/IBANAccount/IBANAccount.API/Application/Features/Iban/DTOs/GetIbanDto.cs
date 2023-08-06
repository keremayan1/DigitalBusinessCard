﻿namespace IBANAccount.API.Application.Features.Iban.DTOs
{
    public class GetIbanDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int Length { get; set; }
        public string Code { get; set; }
        public string ImagePath { get; set; }
    }
}
