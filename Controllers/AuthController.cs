﻿using Api___clone_wpp.FakeDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Api___clone_wpp.Controllers;

[ApiController, Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public IActionResult Login(AuthLoginRequest request)
    {
        if (!UserFakeDB.Users.Any(user => user.Id == request.UserId))
        {
            return NotFound("Usuário não encontrado!");
        }

        var byteSecret = Encoding.UTF8.GetBytes(AuthSettings.JwtSecret).ToArray();

        var secretKey =  new SigningCredentials( new SymmetricSecurityKey(byteSecret), algorithm: SecurityAlgorithms.HmacSha256);

        var userIdClaim = new Claim(ClaimTypes.NameIdentifier, request.UserId.ToString().ToUpperInvariant());

        var securityToken = new JwtSecurityToken(signingCredentials: secretKey, claims: [userIdClaim]);
            
        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return Ok( new
        {
            request.UserId,
            token
        });
    }
}
