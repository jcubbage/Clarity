using Clarity.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Clarity.Core.Data
{
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Notification>? Notifications { get; set; }

        
    }
}
