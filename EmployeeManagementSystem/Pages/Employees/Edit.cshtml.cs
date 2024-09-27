using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementSystem.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly EmployeContext _context;

        public EditModel(EmployeContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
