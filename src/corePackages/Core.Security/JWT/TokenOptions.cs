﻿namespace Core.Security.JWT;

public class TokenOptions
{
    public List<string> Audience { get; set; }
    public string Issuer { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string SecurityKey { get; set; }
    public int RefreshTokenTTL { get; set; }
}