using AMA.Common.Interfaces;
using AMA.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMA.Common.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context) => _context = context;
    }
}
