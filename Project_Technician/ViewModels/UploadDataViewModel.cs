using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Technician.ViewModels
{
    public class UploadDataViewModel
    {
        [Display(Name = "File Source")]
        [Required]
        public IFormFile File { get; set; }
    }
}