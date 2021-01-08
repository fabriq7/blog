using Application.DTO.Request;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Guid> Create(UserDTO user);
        Task<string> Authenticate(UserAuthenticateDTO userAuthenticate);
    }
}
