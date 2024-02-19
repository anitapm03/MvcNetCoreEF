using Microsoft.EntityFrameworkCore;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Data
{
    public class HospitalContext: DbContext
    {
        //tendremos un constructor que recibirá las opciones 
        //de inicio y conexión de la BBDD
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        { }

        //por cada model necesitamos una colaccion DbSet que sera 
        //la que usaremos para las consultas Linq
        public DbSet<HospitalEF> Hospitales { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
