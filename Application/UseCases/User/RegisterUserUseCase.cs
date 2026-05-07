using Application.DTOs;
using Application.Repositories;
using Application.Settings;
using Domain.Entities;
using Domain.MethodExtension;
using Domain.Repositories;

namespace Application.UseCases.User
{
    public class RegisterUserUseCase
    {
        private readonly IEntityRepository<UserEntity> _repository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserUseCase(IEntityRepository<UserEntity> repository, IPasswordHasher passwordHasher, IUserRepository userRepository)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<UserEntity> ExecuteAsync(RegisterUserDto dto)
        {
            if(await _userRepository.HasExistsByEmailAsync(dto.Email))
            {
                throw new InvalidOperationException($"{nameof(dto.Email)}: {dto.Email} alredy exists");
            }

            dto.RawPassword.ThrowIfNullValueOrEmpty();
            dto.RawPassword.ThrowIfLimitMax(PasswordSettings.Max);
            dto.RawPassword.ThrowIfLimitMin(PasswordSettings.Min);

            string hash = _passwordHasher.HashAsync(dto.RawPassword);

            UserEntity newUser = new(
               UserName: dto.UserName,
               Email: dto.Email,
               PasswordHash: hash,
               Role: dto.Role
               );

            await _repository.AddAsync(newUser);
            await _repository.SaveAsync();

            return newUser;
        }
    }
}
