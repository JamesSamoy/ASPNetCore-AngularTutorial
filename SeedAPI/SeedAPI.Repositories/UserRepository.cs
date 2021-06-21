using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SeedAPI.Data;
using SeedAPI.Data.Context;

namespace SeedAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContext _context;
        
        public UserRepository(IApplicationContext context)
        {
            _context = context;
        }

        public User Save(User domain)
        {
            try
            {
                var user = _context.UsersDB.Add(domain);
                return domain;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(User domain)
        {
            try
            {
                _context.UsersDB.Update(domain);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                User user = _context.UsersDB.FirstOrDefault(x => x.Id.Equals(id));
                if (user != null)
                {
                    _context.UsersDB.Remove(user);
                    return true;
                }
                
                return false;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return _context.UsersDB.OrderBy(x => x.Name).ToList();
            }
            catch (Exception e)
            {
                throw e;      
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.DisposeTransaction();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}