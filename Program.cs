using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

Console.WriteLine($"Token: {GenerateJWTToken()}");
Console.ReadKey();

string GenerateJWTToken()
{
    var issuer = "<Issuer>";
    var audience = "<Audience>";
    var issuerAt = DateTime.Now;
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("<Secret>"));

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