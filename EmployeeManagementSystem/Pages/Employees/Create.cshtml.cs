using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeManagementSystem.Model;
using System;

namespace EmployeeManagementSystem.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly EmployeContext _context;

        public CreateModel(EmployeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = new Employee();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
