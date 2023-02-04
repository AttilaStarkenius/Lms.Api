using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lms.Core.Entities;

namespace Lms.Data.Data
{
    public class LmsApiContext : DbContext
    {
        public LmsApiContext (DbContextOptions<LmsApiContext> options)
            : base(options)
        {
        }

        public DbSet<Lms.Core.Entities.Tournament> Tournament { get; set; } = default!;

        public DbSet<Lms.Core.Entities.Game> Game { get; set; } = default!;
    }
}
