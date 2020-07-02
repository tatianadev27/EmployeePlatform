using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePlatform.DataAccess.Mappers;
using EmployeePlatform.DataAccess.Repositories.Contracts;
using EmployeePlatform.Database;
using EmployeePlatform.Database.Models;
using EmployeePlatform.Entities;

namespace EmployeePlatform.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeePlatformContext _db;

        public UserRepository(EmployeePlatformContext db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<User> query = _db.Users.AsEnumerable();
                    return query.Count() > 0 ? new GenericMapper<User, UserDTO>().MapList(query) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<UserDTO> GetById(int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<User> query = _db.Users.AsEnumerable();
                    User data = query.Count() > 0 ? query.Where(x => x.Id == id).FirstOrDefault() : null;
                    return data != null ? new GenericMapper<User, UserDTO>().Map(data) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<UserDTO> GetByEmail(string email)
        {
            return Task.Run(() =>
            {
                try
                {
                    IEnumerable<User> query = _db.Users.AsEnumerable();
                    User data = query.Count() > 0 ? query.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault() : null;
                    return data != null ? new GenericMapper<User, UserDTO>().Map(data) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex}");
                }
                return null;
            });
        }

        public Task<UserDTO> Add(UserDTO user)
        {
            return Task.Run(() =>
            {
                User newUser = new GenericMapper<UserDTO, User>().Map(user);
                _db.Users.Add(newUser);
                _db.SaveChanges();
                return user;
            });
        }

        public Task<UserDTO> Update(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
