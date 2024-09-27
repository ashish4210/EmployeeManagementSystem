using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementSystem.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmployeContext _context;

        public IndexModel(EmployeContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.Name.Contains(searchString) ||
                                         e.Email.Contains(searchString) ||
                                         e.Department.Contains(searchString));
            }

            Employees = await query.ToListAsync();
        }
    }
}
