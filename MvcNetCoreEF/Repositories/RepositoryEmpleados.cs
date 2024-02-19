using MvcNetCoreEF.Data;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        //metodo para recuperar los oficios
        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();

            return consulta.ToList();
        }

        //recuperar empleados por su oficio
        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;

            return consulta.ToList();
        }

        //metodo para incrementar el salario por oficio 
        //devuelve el model de los empleados y su resumen
        public ModelEmpleados IncrementarSalarioOficio
            (int incremento, string oficio)
        {
            //recuperamos los empleados
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);
            //recorremos cada empleado para aumentar su salario
            foreach (Empleado emp in empleados)
            {
                emp.Salario += incremento;

            }
            //guardamos los cambios
            this.context.SaveChanges();
            //mediante lambda debemos recuperar el resumen de los datos
            int suma = empleados.Sum(x => x.Salario);
            double media = empleados.Average(z => z.Salario);

            ModelEmpleados model = new ModelEmpleados();
            model.Empleados = empleados;
            model.SumaSalarial = suma;
            model.MediaSalarial = media;

            return model;
        }
    }
}
