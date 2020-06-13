using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_technician.Data;
using Project_technician.Models;
using Project_technician.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Project_technician.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var employee = await dbContext.Employees.ToListAsync();
            return View(employee);
        }

        //vista privacidad
        public IActionResult Privacy()
        {
            return View();
        }

        //vista contact
        public IActionResult Contact()
        {
            return View();
        }

        //vista new 
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Employee employee = new Employee
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    FullNombre = model.Nombre +" "+ model.Apellido,
                    Cedula = model.Cedula,
                    direccion = model.direccion,
                    FechaIngreso = model.FechaIngreso,
                    FechaEntrega = model.FechaEntrega,
                    Tipo = model.Tipo,
                    Serial = model.Serial,
                    Marca = model.Marca,
                    Descripcion = model.Descripcion,
                    GarantiaMarca = model.GarantiaMarca,
                    GarantiaTecnica = model.GarantiaTecnica,
                    TipoServicio = model.TipoServicio,
                    ValorPagar = model.ValorPagar,
                    CantidadEquipos = model.CantidadEquipos,
                    NumeroCelular = model.NumeroCelular,
                    Correos = model.Correos,
                    ProfilePicture = uniqueFileName,
                };
                dbContext.Add(employee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(EmployeeViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
