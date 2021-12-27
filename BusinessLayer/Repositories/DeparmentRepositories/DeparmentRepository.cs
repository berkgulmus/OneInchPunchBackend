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

namespace BusinessLayer.Repositories.DeparmentRepositories
{
    public class DeparmentRepository : IDeparmentRepository
    {
        private readonly DataContext _context;

        public DeparmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GetDeparmentResponse>> GetDeparment()
        {
            var deparments = await _context.Deparments.ToListAsync();

            List<GetDeparmentResponse> response = new List<GetDeparmentResponse>();

            foreach (var departmant in deparments)
            {
                response.Add(new GetDeparmentResponse
                {
                    Id = departmant.Id,
                    Name = departmant.Name
                });
            }

            return response;
        }

        public async Task<GetDeparmentByIdWithUserResponse> GetDeparmentByIdWithUser(int id)
        {
            try
            {
                var deparment = await _context.Deparments
                    .Include(d => d.Users)
                    .ThenInclude(u => u.Role)
                    .Where(d => d.Id == id).SingleOrDefaultAsync();

                GetDeparmentByIdWithUserResponse response = new GetDeparmentByIdWithUserResponse()
                {
                    Id = deparment.Id,
                    Name = deparment.Name,
                    Users = deparment.Users
                };
                return response;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<PostDeparmentResponse> PostDepartment(PostDeparmentRequest postDeparmentRequest)
        {
            var deparmentMap = new Deparment()
            {
                Name = postDeparmentRequest.Name
            };
            await _context.Deparments.AddAsync(deparmentMap);

            try
            {
                await _context.SaveChangesAsync();
                PostDeparmentResponse response = new PostDeparmentResponse()
                {
                    Id = deparmentMap.Id,
                    Name = deparmentMap.Name
                };
                return response;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<GetDeparmentByIdResponse> GetDeparmentById(int id)
        {
            var deparment = await _context.Deparments.Where(d => d.Id == id).SingleOrDefaultAsync();
            try
            {
                GetDeparmentByIdResponse response = new GetDeparmentByIdResponse()
                {
                    Id = deparment.Id,
                    Name = deparment.Name
                };
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PutDeparmentResponse> PutDeparment(PutDeparmentRequest putDeparmentRequest, int id)
        {


            var department = await _context.Deparments.Where(d => d.Id == id).SingleOrDefaultAsync();
            

            var updateEntity = _context.Entry(department);
            updateEntity.Entity.Name = putDeparmentRequest.Name;
            updateEntity.State = EntityState.Modified;

            
            try
            {
                await _context.SaveChangesAsync();
                PutDeparmentResponse response = new PutDeparmentResponse()
                {
                    Id = department.Id,
                    Name = department.Name
                };
                return response;
            }
            catch (Exception)
            {

                return null;
            }


           

        }

        public async Task<bool> DeleteDeparment(int id)
        {
            var department = await _context.Deparments.Where(d => d.Id == id).SingleOrDefaultAsync();
            var deleteEntity = _context.Entry(department);
            deleteEntity.State = EntityState.Deleted;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}