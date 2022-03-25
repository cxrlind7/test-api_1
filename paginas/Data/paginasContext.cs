using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using paginas.Models;

namespace paginas.Data
{
    public class paginasContext : DbContext
    {
        public paginasContext (DbContextOptions<paginasContext> options)
            : base(options)
        {
        }

        public DbSet<paginas.Models.PersonaClass> Tb_PersonasFisicas { get; set; }
    }
}
