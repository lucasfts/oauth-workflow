using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthorizationServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OAuthController : ControllerBase
    {
        [HttpPost("authorize")]
        public ActionResult<string> Authorize()
        {
            var privateKey = System.IO.File.ReadAllText("private-key.pem");
            var rsa = RSA.Create();
            rsa.ImportFromPem(privateKey.ToCharArray());
            var securityKey = new RsaSecurityKey(rsa);
            var claims = new Claim[] { new Claim(ClaimTypes.Name, "User123456") };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = "AuthorizationServer",
                Audience = "ResourceServer",
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha512)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
            var jwsToken = tokenHandler.WriteToken(jwtToken);

            return Ok(jwsToken);
        }
    }
}