using BookStores.API.Settings;
using BookStores.Domain.Models;
using BookStores.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStores.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService UserService;

        public UsersController(IOptionsSnapshot<JwtSettings> jwtSettings, IUserService UserService)
        {
            _jwtSettings = jwtSettings.Value;
            this.UserService = UserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            user.Password = HashPassword(user.Password);

            await UserService.CreateUser(user);

            return Created(string.Empty, string.Empty);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] User user)
        {
            // user.Password = HashPassword(user.Password);

            user.Password = "/gdwUN3xT3+Gzrk0cKxzvnK709gGOppdL3RTqYyL19g=";

            var isValidCredential = await UserService.SignIn(user);
            if (isValidCredential)
                return Ok(GenerateJwt(user));
            else
                return Unauthorized();
        }

        private string HashPassword(string Password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedPassword;
        }
        private string GenerateJwt(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            /*var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);*/

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
