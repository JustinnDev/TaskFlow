using Domain.Entities;
using Domain.Repositories;
using Domain.MethodExtension;
using Application.DTOs;
using Application.Repositories;

namespace Application.UseCases.User
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEntityRepository<UserEntity> _entityRepository;
        private readonly IPasswordHasher _passwordHasher;

        public LoginUserUseCase(IUserRepository userRepository, IEntityRepository<UserEntity> entityRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _entityRepository = entityRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserEntity> ExecuteAsync(LoginUserDto dto)
        {
            var errorMessage = "Username or Password is wrong";
            var userId = await _userRepository.GetIdBByUsername(dto.UserName);

            userId.ThrowIfNullOrEmpty(errorMessage);

            var user = await _entityRepository.GetByIdAsync(userId.Value);

            user.ThrowIfNull(errorMessage);

            if(!_passwordHasher.VerifyAsync(dto.RawPassword, user.PasswordHash))
            {
                throw new InvalidOperationException(errorMessage);
            }

            return user;
        }
    }
}
