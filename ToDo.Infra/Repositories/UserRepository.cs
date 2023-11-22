using System.Xml.Schema;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using ToDo.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ToDoContext _context;

        public UserRepository (ToDoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                .Where
                (
                    x => 
                        x.Email.ToLower() == email.ToLower()
                )
                .AsNoTracking()
                .ToListAsync();
           
            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var allUsers = await _context.Users
                .Where
                (
                    x => 
                        x.Email.ToLower().Contains(email.ToLower())
                )
                .AsNoTracking()
                .ToListAsync();
           
            return allUsers;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var allUsers = await _context.Users
                .Where
                (
                    x => 
                        x.Email.ToLower().Contains(name.ToLower())
                )
                .AsNoTracking()
                .ToListAsync();
           
            return allUsers;
        }
    }
}