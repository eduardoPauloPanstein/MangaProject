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


        public async Task<Response> Login(User user)
        {
            try
            {
                var userReturn = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);

                if (userReturn is null)
                {
                    return new SingleResponse<User>()
                    {
                        HasSuccess = false,
                        Message = "Credenciais de usuario invalidas!",
                        Data = userReturn
                    };
                }

                return new SingleResponse<User>()
                {
                    HasSuccess = true,
                    Message = "Credenciais de usuario validas!",
                    Data = userReturn
                };

            }
            catch (Exception ex)
            {
                return new SingleResponse<User>()
                {
                    HasSuccess = false,
                    Message = "Erro no banco, contate o administrador.",
                    Exception = ex
                };

            }
        }

        public async Task<Response> Delete(int id)
        {
            User? user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return new SingleResponse<User>()
                {
                    HasSuccess = false,
                    Message = "Usuario não encontrado no banco de dados.",
                };
            }

            _db.Users.Remove(user);
            try
            {
                await _db.SaveChangesAsync();
                return new SingleResponse<User>()
                {
                    HasSuccess = true,
                    Message = "Usuario deletado com sucesso!",
                    Data = user
                };

            }
            catch (Exception ex)
            {
                return new SingleResponse<User>()
                {
                    HasSuccess = false,
                    Message = "Erro no banco, contate o administrador.",
                    Exception = ex
                };

            }
        }

        public async Task<Response> Insert(User user)
        {
            _db.Users.Add(user);
            try
            {
                await _db.SaveChangesAsync();
                return new Response()
                {
                    HasSuccess = true,
                    Message = "Usuario cadastrado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    HasSuccess = false,
                    Message = "Erro no banco de dados, contate o administrador.",
                    Exception = ex
                };
            }
        }

        public async Task<SingleResponse<User>> Select(int id)
        {
            try
            {
                User? user = await _db.Users.FindAsync(id);
                if (user == null)
                {
                    return new SingleResponse<User>()
                    {
                        HasSuccess = false,
                        Message = "Usuario não encontrado no banco de dados.",
                    };
                }
                return new SingleResponse<User>()
                {
                    HasSuccess = true,
                    Message = "Usuario selecionado com sucesso!",
                    Data = user
                };

            }
            catch (Exception ex)
            {
                return new SingleResponse<User>()
                {
                    HasSuccess = false,
                    Message = "Erro no banco, contate o administrador.",
                    Exception = ex
                };

            }
        }

        public async Task<DataResponse<User>> SelectAll()
        {
            try
            {
                List<User> users = await _db.Users.ToListAsync();
                return new DataResponse<User>()
                {
                    HasSuccess = true,
                    Message = "Usuarios selecionados com sucesso!",
                    Data = users
                };

            }
            catch (Exception ex)
            {
                return new DataResponse<User>()
                {
                    HasSuccess = false,
                    Message = "Erro no banco, contate o administrador.",
                    Exception = ex
                };

            }
        }

        public async Task<Response> Update(User user)
        {
            _db.Users.Update(user);
            try
            {
                await _db.SaveChangesAsync();
                return new Response()
                {
                    HasSuccess = true,
                    Message = "Usuario atualizado com sucesso."
                };
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2601")) //UQ_
                {
                    // Duplicate Key Exception
                }

                return new Response()
                {
                    HasSuccess = false,
                    Message = "Erro no banco de dados, contate o administrador.",
                    Exception = ex
                };
            }
        }

    }
}
