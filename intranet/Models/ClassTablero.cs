using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace intranet.Models
{
    public class Procesos
    {
        [Key]
        public int Id_Proceso { get; set; }
        public string Proceso { get; set; }
        public string Numeral { get; set; }
        public string Unidad { get; set; }
        public string Fuente { get; set; }
        public string Observacion { get; set; }
        public List<Procesos> List_Procesos { get; set; } = new List<Procesos>();
    }

    public class Registros
    {
        [Key]
        public int Id_Registro { get; set; }
        public string Periodo { get; set; }
        public float Numerador { get; set; }
        public float Denominador { get; set; }
        public float Indicador { get; set; }
        public float Meta { get; set; }
        public int ProcesoId { get; set; }
        public Procesos Reg_Proceso { get; set; }
    }

    public class TableroContext : DbContext
    {
            public TableroContext(DbContextOptions<TableroContext> options)
                : base(options)
            { }

            public DbSet<Procesos> Procesos { get; set; }
            public DbSet<Registros> Registros { get; set; }
    }
}
