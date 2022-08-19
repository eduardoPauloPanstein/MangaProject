using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class UserDAL : IUserDAL
    {
        private readonly MangaProjectDbContext _db;
        public UserDAL(MangaProjectDbContext db)
        {
            this._db = db;
        }

        public async Task<Response> Delete(int id)
        {
            User? user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return new Response("Usuario não encontrado no banco de dados.", false,null);
                //{
                //    HasSuccess = false,
                //    Message = "Usuario não encontrado no banco de dados.",
                //};
            }

            _db.Users.Remove(user);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse(user);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(ex, null);
            }
        }

        public async Task<Response> Insert(User user)
        {
            _db.Users.Add(user);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }

        public Task<Response> Login(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<SingleResponse<User>> Select(int id)
        {
            try
            {
                User? user = await _db.Users.FindAsync(id);
                if (user == null)
                {
                    return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(null,null);
                }
                return ResponseFactory.CreateInstance().CreateSingleSuccessResponse(user);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateSingleFailedResponse<User>(ex,null);
            }
        }

        public async Task<DataResponse<User>> SelectAll()
        {
            try
            {
                List<User> users = await _db.Users.ToListAsync();
                return ResponseFactory.CreateInstance().CreateDataSuccessResponse(users);

            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateDataFailedResponse<User>(ex);
            }
        }

        public async Task<Response> Update(User user)
        {
            _db.Users.Update(user);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
        }
    }
}
