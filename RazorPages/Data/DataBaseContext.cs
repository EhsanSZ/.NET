using Microsoft.EntityFrameworkCore;
using RazorPage.Bugeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Data
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base (options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
