using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

Console.WriteLine($"Token: {GenerateJWTToken()}");


string GenerateJWTToken()
{
    var issuer = "webApi";
    var audience = "https://localhost:44304/";
    var issuerAt = DateTime.Now;
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a1Jf6hDkJ9SDcWy4JAwN2hOIi7LsXsf0"));

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Expires = DateTime.UtcNow.AddMinutes(20),
        Issuer = issuer,
        Audience = audience,
        SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
        IssuedAt = issuerAt
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var stringToken = tokenHandler.WriteToken(token);
    return stringToken;
}
var token = Console.ReadLine();
var result = ValidateCurrentToken(token);

bool ValidateCurrentToken(string token)
{
    var Secret = "";
    var SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));

    var Issuer = "http://mysite.com";
    var Audience = "account";

    var tokenHandler = new JwtSecurityTokenHandler();
    try
    {
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = Issuer,
            ValidAudience = Audience,
            IssuerSigningKey = SecurityKey
        }, out SecurityToken validatedToken);
    }
    catch
    {
        return false;
    }
    return true;
}
Console.WriteLine(result);
Console.ReadKey();