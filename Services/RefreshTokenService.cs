using E_Commerce.Data;
using E_Commerce.DTOs.Auth;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Options;
using E_Commerce.Repositories.UnitOfWork;


namespace E_Commerce.Services
{
    public class RefreshTokenService(JwtOption jwtOption
        ,IJwtService _service, IUnitOfWork _repository)
        :IRefreshTokenService
    {
        


        public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var storedToken = await _repository.RefreshTokens.GetToken(refreshToken);
            if (storedToken == null)
                throw new UnauthorizedAccessException("Invalid Refresh Token");
            if (!storedToken.IsActive)
                throw new UnauthorizedAccessException("Refresh Token is expired or revoked.");

            var accessToken =
                 _service.GenerateAccessToken(storedToken.User);


            storedToken.RevokedAt = DateTime.UtcNow;
            var newRefreshToken = _service.GenerateRefreshToken(storedToken.User.Id);

            await _repository.GenericRepository<RefreshToken>().Create(newRefreshToken);
            await _repository.SaveChangesAsync();


            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken.Token,
                AccessTokenExpiration =
                    DateTime.UtcNow.AddMinutes(jwtOption.AccessTokenMinutes)
            };
        }

        public async Task Revoked(string refreshToken)
        {
            var storedToken = await _repository.RefreshTokens.GetToken(refreshToken);
            if (storedToken == null)
                throw new UnauthorizedAccessException("Invalid Refresh Token");
            if (!storedToken.IsActive)
                throw new UnauthorizedAccessException("Refresh Token is expired or revoked.");

            storedToken.RevokedAt = DateTime.UtcNow;
            await _repository.SaveChangesAsync();
        }
    }
}
