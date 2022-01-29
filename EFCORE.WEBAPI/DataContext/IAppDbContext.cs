using EFCORE.WEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCORE.WEBAPI.DataContext
{
    public interface IAppDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChanges();
    }
}
