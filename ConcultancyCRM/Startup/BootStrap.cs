using ConcultancyCRM.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConcultancyCRM.Startup
{
    public static class BootStrap
    {
        public static void Init(IConfiguration configuration)
        {
            //auto migrate db
            using (var _context = new MyDBContext(configuration))
            {
                _context.Database.Migrate();
            }
        }
    }
}
