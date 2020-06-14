using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project_Technician.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public int IdContact { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Mensaje { get; set; }
    }
}
