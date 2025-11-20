using EmployeesDepartments.Data;
using EmployeesDepartments.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeesDepartments.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = _context.Employees
                                    .Include(e => e.Department);

            return View(await employees.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.DepartmentId =
                new SelectList(_context.Departments, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            employee.Department = await _context.Departments
                .FirstAsync(d => d.Id == employee.DepartmentId);

            if (ModelState.IsValid)
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DepartmentId =
                new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);

            return View(employee);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            ViewBag.DepartmentId =
                new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DepartmentId =
                new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
