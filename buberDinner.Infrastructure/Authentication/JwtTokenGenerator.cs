using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using buberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using buberDinner.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using buberDinner.Domain.Entities;

namespace buberDinner.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSetting;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)//IOptions easier to unit test 
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSetting = jwtOptions.Value;
    }

    public string GeneratorToken(User user)
    {
        var singingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret)),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
       var securityToken = new JwtSecurityToken(
           issuer: _jwtSetting.Issuer,
           audience: _jwtSetting.Audience,
           expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSetting.ExpiresMinutes),
           claims: claims,
           signingCredentials: singingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}