using System;
using System.ComponentModel.DataAnnotations;

namespace MvcCoreUploadAndDisplayImage_Demo.Models
{
    public class Contacto
    {
        [Key]
        public int IdContact { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Mensaje { get; set; }
    }
}
