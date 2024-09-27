using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EmployeeManagementSystem.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeContext _context;


        public DeleteModel(EmployeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
            Employee = await _context.Employees.FindAsync(id);
            if (Employee == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();
            Employee = await _context.Employees.FindAsync(id);
            if (Employee != null)
            {
                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
