using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerkwazNetTask.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions DbCon)
           : base(DbCon)
        {
        }

        public DbSet<Models.Blog> blogs { get; set; }
    }
}
