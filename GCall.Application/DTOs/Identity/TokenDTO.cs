﻿namespace GCall.Application.DTOs.Identity
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}