using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SeedAPI.Data;
using SeedAPI.Data.Context;

namespace SeedAPI.Repositories
{
    public class BaseRepository : IDisposable
    {
        private IApplicationContext _context;

        public BaseRepository(IApplicationContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
        }
    }
}