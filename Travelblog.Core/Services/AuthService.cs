using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Travelblog.Core.Interfaces;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
        };

        var keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
        var key = new SymmetricSecurityKey(keyBytes);

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationInMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private byte[] GenerateSecurityKey(int keySizeInBytes)
    {
        // Read the SecretKey from configuration
        string secretKey = _configuration["Jwt:SecretKey"];

        try
        {
            // If the SecretKey is present, try to decode it
            return Convert.FromBase64String(secretKey);
        }
        catch (FormatException)
        {
            // Handle invalid Base64 format (consider generating a new key in this case)
        }

        // If the SecretKey is not present or invalid, generate a new one
        byte[] keyBytes = new byte[keySizeInBytes];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(keyBytes);
        }

        // Save the generated key in configuration
        _configuration["Jwt:SecretKey"] = Convert.ToBase64String(keyBytes);

        return keyBytes;
    }
}
