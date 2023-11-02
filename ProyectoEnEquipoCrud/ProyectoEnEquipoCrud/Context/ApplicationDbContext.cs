using Microsoft.EntityFrameworkCore;
using ProyectoEnEquipoCrud.Models;
using System.Collections.Generic;


namespace ProyectoEnEquipoCrud.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Titulo> titulos { get; set; }
    }
}
