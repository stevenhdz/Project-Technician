using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Technician.Data;
using Project_Technician.Models;
using Project_Technician.ViewModels;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace Project_Technician.Controllers
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

        public IActionResult Csv()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Id,Username");
            foreach (var user in dbContext.Employees)
            {
                builder.AppendLine($"{user.IdPersona},{user.FullNombre}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "users.csv");
        }

        public IActionResult Excel()
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("My sheet");
            int rowNumber = 0;
            IRow row = sheet.CreateRow(rowNumber);
            ICell cell = row.CreateCell(rowNumber);
            cell.SetCellValue("Id");
            cell = row.CreateCell(1);
            cell.SetCellValue("Name");
            foreach (var employee in dbContext.Employees)
            {
                rowNumber++;
                row = sheet.CreateRow(rowNumber);
                cell = row.CreateCell(0);
                cell.SetCellValue(employee.IdPersona);
                cell = row.CreateCell(1);
                cell.SetCellValue(employee.FullNombre);
            }
            using (var stream = new MemoryStream())
            {
                workbook.Write(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ArticleList");
            }

        }
    }
}
