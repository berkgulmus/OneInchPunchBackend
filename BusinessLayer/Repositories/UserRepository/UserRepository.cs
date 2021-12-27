using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Requests;
using BusinessLayer.Responses;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace BusinessLayer.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;


        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GetUserResponse>> GetUser()
        {
            var users = await _context.Users.Include(d=>d.Deparment).Include(u=>u.Role).ToListAsync();

            if (users == null)
            {
                return null;
            }
            else
            {
                List<GetUserResponse> response = new List<GetUserResponse>();

                foreach (var user in users)
                {
                    response.Add(new GetUserResponse
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password,
                        Deparment = user.Deparment,
                        Role = user.Role
                    });
                }

                return response;
            }
        }

        public async Task<GetUserResponse> GetUserById(int Id) { 
        
            var user = await _context.Users.Include(d => d.Deparment).Include(u => u.Role).Where(x=>x.Id == Id ).SingleOrDefaultAsync();

            if (user == null)
            {
                return null;
            }
            else
            {
                GetUserResponse response = new GetUserResponse()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Deparment = user.Deparment,
                    Role = user.Role
                };

                return response;
            }
        }

        public async Task<PostUserResponse> PostUser(PostUserRequest postUserRequest)
        {


            //var checkUser = _context.Users.SingleOrDefault(u => u.Email == loginRequest.Email);
            var selectedDepartment = _context.Deparments.SingleOrDefault(u => u.Id == postUserRequest.DeparmentId);
            var selectedRole = new Role();

            var x = new User()
            {
                FirstName = postUserRequest.FirstName,
                LastName = postUserRequest.LastName,
                Email = postUserRequest.Email,
                Password = postUserRequest.Password,
                Deparment = selectedDepartment,

            };

            if (postUserRequest.RoleId == 0) {
                x.Role = null;
            }
            else
            {
                selectedRole = _context.Roles.SingleOrDefault(u => u.Id == postUserRequest.RoleId);
                x.Role = selectedRole;
            }

            await _context.Users.AddAsync(x);

            try
            {
                await _context.SaveChangesAsync();
                PostUserResponse response = new PostUserResponse()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Password = x.Password,
                    Deparment = x.Deparment,
                    Role= x.Role
                };
                return response;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
