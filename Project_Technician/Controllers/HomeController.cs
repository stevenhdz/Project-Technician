﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Technician.Data;
using Project_Technician.Models;
using Project_Technician.ViewModels;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
                    Respuesta = model.Respuesta,
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
            cell.SetCellValue("Nombre");
            cell = row.CreateCell(2);
            cell.SetCellValue("Cedula");
            cell = row.CreateCell(3);
            cell.SetCellValue("Direccion");
            cell = row.CreateCell(4);
            cell.SetCellValue("Fecha Ingreso");
            cell = row.CreateCell(5);
            cell.SetCellValue("Fecha Entrega");
            cell = row.CreateCell(6);
            cell.SetCellValue("Tipo");
            cell = row.CreateCell(7);
            cell.SetCellValue("Serial");
            cell = row.CreateCell(8);
            cell.SetCellValue("Marca");
            cell = row.CreateCell(9);
            cell.SetCellValue("Descripcion");
            cell = row.CreateCell(10);
            cell.SetCellValue("Respuesta");
            cell = row.CreateCell(11);
            cell.SetCellValue("Garantia Marca");
            cell = row.CreateCell(12);
            cell.SetCellValue("Garantia Tecnica");
            cell = row.CreateCell(13);
            cell.SetCellValue("Tipo Servicio");
            cell = row.CreateCell(14);
            cell.SetCellValue("Valor Pagar");
            cell = row.CreateCell(15);
            cell.SetCellValue("Cantidad Equipos");
            cell = row.CreateCell(16);
            cell.SetCellValue("Numero Celular");
            cell = row.CreateCell(17);
            cell.SetCellValue("Correos");
            cell = row.CreateCell(18);
            cell.SetCellValue("ProfilePicture");
            foreach (var employee in dbContext.Employees)
            {
                rowNumber++;
                row = sheet.CreateRow(rowNumber);
                cell = row.CreateCell(0);
                cell.SetCellValue(employee.IdPersona);
                cell = row.CreateCell(1);
                cell.SetCellValue(employee.Nombre+" "+employee.Apellido);
                cell = row.CreateCell(2);
                cell.SetCellValue(employee.Cedula);
                cell = row.CreateCell(3);
                cell.SetCellValue(employee.direccion);
                cell = row.CreateCell(4);
                cell.SetCellValue(employee.FechaIngreso);
                cell = row.CreateCell(5);
                cell.SetCellValue(employee.FechaEntrega);
                cell = row.CreateCell(6);
                cell.SetCellValue(employee.Tipo);
                cell = row.CreateCell(7);
                cell.SetCellValue(employee.Serial);
                cell = row.CreateCell(8);
                cell.SetCellValue(employee.Marca);
                cell = row.CreateCell(9);
                cell.SetCellValue(employee.Descripcion);
                cell = row.CreateCell(10);
                cell.SetCellValue(employee.Respuesta);
                cell = row.CreateCell(11);
                cell.SetCellValue(employee.GarantiaMarca);
                cell = row.CreateCell(12);
                cell.SetCellValue(employee.GarantiaTecnica);
                cell = row.CreateCell(13);
                cell.SetCellValue(employee.TipoServicio);
                cell = row.CreateCell(14);
                cell.SetCellValue(employee.ValorPagar);
                cell = row.CreateCell(15);
                cell.SetCellValue(employee.CantidadEquipos);
                cell = row.CreateCell(16);
                cell.SetCellValue(employee.NumeroCelular);
                cell = row.CreateCell(17);
                cell.SetCellValue(employee.Correos);
                cell = row.CreateCell(18);
                cell.SetCellValue(employee.ProfilePicture);
                cell = row.CreateCell(19);
                cell.SetCellValue(employee.FechaIngreso);
            }
            using (var stream = new MemoryStream())
            {
                workbook.Write(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "employee.xlsx");
            }

        }
    }
}
