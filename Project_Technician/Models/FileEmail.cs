using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Technician.Models
{
    public class FileEmail
    {
        [Required (ErrorMessage = "Debe seleccionar un archivo")]
        public IFormFile File { get; set; }
    }
}
