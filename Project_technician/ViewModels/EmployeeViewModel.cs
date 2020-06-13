using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project_technician.ViewModels
{
    public class EmployeeViewModel
    {
        public string FullNombre { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Int64 Cedula { get; set; }
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
        public Int16 CantidadEquipos { get; set; }
        [StringLength(10)]
        [Range(3000000000,3999999999,ErrorMessage="Ingrese numero valido")]
        [Required(ErrorMessage = "Numero de contacto requerido")]
        public string NumeroCelular { get; set; }
        public string Correos { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
