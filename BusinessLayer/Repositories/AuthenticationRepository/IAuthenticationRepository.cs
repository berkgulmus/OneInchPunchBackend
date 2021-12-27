using System.Threading.Tasks;
using BusinessLayer.Requests;
using BusinessLayer.Responses;

namespace BusinessLayer.Repositories.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}