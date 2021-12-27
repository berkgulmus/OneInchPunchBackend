using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Requests;
using BusinessLayer.Responses;

namespace BusinessLayer.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<PostUserResponse> PostUser(PostUserRequest loginRequest);
        Task<List<GetUserResponse>> GetUser();
        Task<GetUserResponse> GetUserById(int Id);
    }
}
