using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project_Technician.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido requerido")]
        public string Apellido { get; set; }

        [StringLength(10)]
        [Range(10000, 9999999999, ErrorMessage = "Ingrese cedula valida")]
        [Required(ErrorMessage = "Cedula requerida")]
        public string Cedula { get; set; }

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

        public string Respuesta { get; set; }

        [Required(ErrorMessage = "Garantia Proveedor requerida")]
        public string GarantiaMarca { get; set; }

        [Required(ErrorMessage = "Garantia Tecnica requerida")]
        public string GarantiaTecnica { get; set; }

        [Required(ErrorMessage = "Tip de servicio requerido")]
        public string TipoServicio { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Precio requerido")]
        public string ValorPagar { get; set; }

        [Range(1, 9999999999, ErrorMessage = "Ingrese numero valido")]
        [Required(ErrorMessage = "Cantidad de equipos")]
        public string CantidadEquipos { get; set; }

        [StringLength(10)]
        [RegularExpression("^([3]{1})([0-5]{1})[0-9]{8}", ErrorMessage = "Numero invalido")]
        [Required(ErrorMessage = "Numero de contacto requerido")]
        public string NumeroCelular { get; set; }


        [Required(ErrorMessage = "Correo requerido")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        [DataType(DataType.EmailAddress)]
        public string Correos { get; set; }

        [Required(ErrorMessage = "Imagen requerido")]
        public IFormFile ProfileImage { get; set; }
    }
}
