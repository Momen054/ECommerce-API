using AutoMapper;
using E_Commerce.DTOs.Auth;
using E_Commerce.DTOs.User;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Options;
using E_Commerce.Repositories.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace E_Commerce.Services
{
    public class JwtService(JwtOption jwtOption
        , IMapper _mapper, IUnitOfWork _repository) : IJwtService
    {
        public async Task<AuthResponseDto> AuthenticatUser(UserPermissionDto dto)
        {
            var user = await _repository.Jwt.GetUser(dto);


            if (user == null) throw new UnauthorizedAccessException("Invalid username or password");
            if(!BCrypt.Net.BCrypt.Verify(dto.PasswordHash,user.PasswordHash)) throw new UnauthorizedAccessException("Invalid username or password");

            var accessToken = GenerateAccessToken(user);

            var activeRefreshToken = user.RefreshTokens.FirstOrDefault(r => r.IsActive);
            if (activeRefreshToken==null)
            {
                activeRefreshToken = GenerateRefreshToken(user.Id);
                await _repository.Jwt.AddRefreshToken(activeRefreshToken);
            }

            await _repository.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = activeRefreshToken.Token,
                AccessTokenExpiration = DateTime.UtcNow.AddMinutes(jwtOption.AccessTokenMinutes)
            };
        }

        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var role in user.userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role!.Name));
            }

            var tokenHundler = new JwtSecurityTokenHandler();

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = jwtOption.Issuer,
                Audience = jwtOption.Audience,
                Expires = DateTime.UtcNow.AddMinutes(jwtOption.AccessTokenMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SigningKey))
                , SecurityAlgorithms.HmacSha256)
            };

            var createToken = tokenHundler.CreateToken(tokenDiscriptor);
            var accessToken = tokenHundler.WriteToken(createToken);

            return accessToken;
        }


        public RefreshToken GenerateRefreshToken(int userId)
        {
            var randomBytes = new byte[64];
            RandomNumberGenerator.Create()
                .GetBytes(randomBytes);
            var token = Convert.ToBase64String(randomBytes);
            var activeRefreshToken = new RefreshToken
            {
                Token = token,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(jwtOption.RefreshTokenDays)
            };
            return activeRefreshToken;
        }

        public async Task Register(UserDto dto)
        {

            var user = _mapper.Map<User>(dto);
            if (user.PasswordHash.Length < 6) throw new Exception("Password length must be greater than 6");
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.IsDeleted = false;
            user.CreatesAt = DateTime.UtcNow;
            await _repository.GenericRepository<User>().Create(user);
            await _repository.SaveChangesAsync();
        }

    }
}
