using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using encuestas_cep_decero.Models;

namespace Encuestas_cep_decero.Data
{
    public class EncuestaContexto : DbContext
    {
        public EncuestaContexto (DbContextOptions<EncuestaContexto> options)
            : base(options)
        {
        }

        public DbSet<encuestas_cep_decero.Models.Encuesta> Encuesta { get; set; }
    }
}
