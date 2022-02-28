﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public class UserRepository
    {
        private readonly DbConnect _context;

        public UserRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<User>>> ReadUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(string userId)
        {
            return await _context.Users.FirstAsync(id => id.ID == userId);
        }

        public async Task UpdateUser(User user)
        {

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public bool UserExists(string id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}