using CRUDprueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDprueba.Data
{
    public class ApplicationDbContext : DbContext //herencia de la clase DbContext (Instalar paquete "MicrosoftEntityFrameworkCore", luego el using)
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Libro> Libro { get; set; }
    }
}
