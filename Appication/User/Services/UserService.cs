using Application.DTO.Request;
using Application.Interfaces;
using Domain.Repositories;
using Domain;
using Blog.Infra.Services;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }

        public async Task<Guid> Create(UserDTO userRequest)
        {
            var existUser = await _userRepository.GetByUsername(userRequest.Login);

            if (existUser != null)
                throw new Exception("Usuário já existe no sistema!");

            if (!string.IsNullOrEmpty(userRequest.Password))
                userRequest.Password = GenerateHash.ComputeSha256Hash(userRequest.Password);

            var user = new User(userRequest.Login.ToLower(), userRequest.Password);

            await _userRepository.AddAsync(user);

            return user.Id;
        }

        public async Task<string> Authenticate(UserAuthenticateDTO userAuthenticate)
        {
            if (string.IsNullOrEmpty(userAuthenticate.Login))
                throw new Exception("É necessário informar o login para autenticar!");

            if (string.IsNullOrEmpty(userAuthenticate.Password))
                throw new Exception("É necessário informar a senha para autenticar!");

            var user = await _userRepository.GetByUsername(userAuthenticate.Login);

            if (user == null)
                throw new Exception("Usuário informado não existe no sistema!");

            var encryptedPassword = GenerateHash.ComputeSha256Hash(userAuthenticate.Password);

            if (encryptedPassword != user.Password)
                throw new Exception("Não foi possível recuperar o token!");

            return TokenService.GenerateToken(user);
        }
    }
}
