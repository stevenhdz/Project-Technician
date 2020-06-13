using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace MvcCoreUploadAndDisplayImage_Demo.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido requerido")]
        public string Apellido { get; set; }

        [Range(10000, 9999999999, ErrorMessage = "Ingrese cedula valida")]
        [Required(ErrorMessage = "Cedula requerida")]
        public Int64 Cedula { get; set; }

        [Required(ErrorMessage = "Direccion requerida")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Fecha de ingreso requerida")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Fecha de entrega requerida")]
        public DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "Tipo de dispositivo requerido")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Serial requerido")]
        public string Serial { get; set; }

        [Required(ErrorMessage = "Marca requerida")]
        public string Marca { get; set; }

        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Garantia Proveedor requerida")]
        public string GarantiaMarca { get; set; }

        [Required(ErrorMessage = "Garantia Tecnica requerida")]
        public string GarantiaTecnica { get; set; }

        [Required(ErrorMessage = "Tip de servicio requerido")]
        public string TipoServicio { get; set; }

        [Range(100, 10000000, ErrorMessage = "Cifras de 100 en adelante")]
        [Required(ErrorMessage = "Precio requerido")]
        public string ValorPagar { get; set; }


        [Range(1, 9999999999, ErrorMessage = "Ingrese numero valido")]
        [Required(ErrorMessage = "Cantidad de equipos/dispositivos requerido")]
        public Int16 CantidadEquipos { get; set; }

        [StringLength(10)]
        [Range(3000000000, 3999999999, ErrorMessage = "Ingrese numero valido")]
        [Required(ErrorMessage = "Numero de contacto requerido")]
        public string NumeroCelular { get; set; }


        [Required(ErrorMessage = "Correo requerido")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        [DataType(DataType.EmailAddress)]
        public string Correos { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
