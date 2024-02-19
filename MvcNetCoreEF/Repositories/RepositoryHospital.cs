using MvcNetCoreEF.Data;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Repositories
{
    public class RepositoryHospital
    {
        //la clase repo siempre recibirá el context
        //mediante inyección de dependencias
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<HospitalEF> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }

        public HospitalEF FindHospital(int idHospital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == idHospital
                           select datos;

            //por si no encontramos el  por el id. Tenemos un metodo
            //que es FirstOrDefault() que devuelve el primer registro
            //el valor por defect del model
            return consulta.FirstOrDefault();
        }

        public void InsertarHospital
            (int idHospital, string nombre, string direccion,
            string telefono, int camas)
        {
            //instanciar el obj
            HospitalEF hospital = new HospitalEF();
            hospital.IdHospital = idHospital;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;

            //añadimos el model a la coleccion dbset
            this.context.Hospitales.Add(hospital);
            //almacenamos en la BBDD
            this.context.SaveChanges();
        }

        public void ModificarHospital
            (int idHospital, string nombre, string direccion,
            string telefono, int camas)
        {
            //buscamos el hospital por su id
            HospitalEF hospital = this.FindHospital(idHospital);

            //modificamos sus propiedades
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;

            //guardamos los cambios en la bbdd
            this.context.SaveChanges();

        }

        public void DeleteHospital(int idHospital)
        {
            //buscamos el model hospital para eliminarlo
            HospitalEF hospital = this.FindHospital(idHospital);
            //eliminamos el obj del dbset
            this.context.Hospitales.Remove(hospital);
            //guardamos los cambios en la bbdd
            this.context.SaveChanges();
        }
    }
}
