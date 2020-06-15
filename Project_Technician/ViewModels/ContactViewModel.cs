using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project_Technician.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public int IdContact { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Correo requerido")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [StringLength(10)]
        [RegularExpression("^([3]{1})([0-5]{1})[0-9]{8}", ErrorMessage = "Numero invalido")]
        [Required(ErrorMessage = "Numero de contacto requerido")]
        public string Phone { get; set; }

        public string Mensaje { get; set; }
    }
}
