using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace MvcCoreUploadAndDisplayImage_Demo.ViewModels
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
        public string NumeroCelular { get; set; }
        public string Correos { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
