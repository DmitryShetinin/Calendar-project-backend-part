﻿using BackEnd.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BackEnd.Interfaces.Auth;

namespace BackEnd.Infrastructure;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;


    public string GenerateToken(User user)
    {
      
        Claim[] claims = [new("userId", user.Id.ToString())]; 


        var sighingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: sighingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpritesHours)
            );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
} 
