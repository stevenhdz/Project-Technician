using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Project_Technician.Data;
using Project_Technician.Models;

namespace Project_Technician.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,FullNombre,Nombre,Apellido,Cedula,direccion,FechaIngreso,FechaEntrega,Tipo,Serial,Marca,Descripcion,GarantiaMarca,GarantiaTecnica,TipoServicio,ValorPagar,CantidadEquipos,NumeroCelular,Correos,ProfilePicture")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,FullNombre,Nombre,Apellido,Cedula,direccion,FechaIngreso,FechaEntrega,Tipo,Serial,Marca,Descripcion,GarantiaMarca,GarantiaTecnica,TipoServicio,ValorPagar,CantidadEquipos,NumeroCelular,Correos,ProfilePicture")] Employee employee)
        {
            if (id != employee.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.IdPersona))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.IdPersona == id);
        }

        public IActionResult Csv()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Id,Username");
            foreach (var user in _context.Employees)
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
            foreach (var employee in _context.Employees)
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
