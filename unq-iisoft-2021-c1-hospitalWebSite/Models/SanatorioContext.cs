using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace Models.Hospital { 


 public class SanatorioContext: DbContext {
     public SanatorioContext(DbContextOptions<SanatorioContext> options)
            :base(options){

        }

        protected SanatorioContext()
        {
        }

        public DbSet<Medico> Medico  {get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ObraSocial> ObraSocial { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Turno> Turno { get; set; }

    }
}