using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Technician.Models
{
    public class Employee
    {

        [Key]
        public int IdPersona { get; set; }
        public string FullNombre { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Tipo { get; set; }
        public string Serial { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string GarantiaMarca { get; set; }
        public string GarantiaTecnica { get; set; }
        public string TipoServicio { get; set; }
        public string ValorPagar { get; set; }
        public string CantidadEquipos { get; set; }
        public string NumeroCelular { get; set; }
        public string Correos { get; set; }
        public string ProfilePicture { get; set; }

        public Employee()
        {
            FullNombre = Nombre + " " + Apellido;
        }
    }
}
