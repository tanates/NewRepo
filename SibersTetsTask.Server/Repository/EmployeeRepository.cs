using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Interface.IEmployee;
using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddEmployee(Employee employee)
        {
            if(await _context.Employees.AnyAsync(i=>i.Name == employee.Name 
            && i.Name ==employee.Name 
            && i.MiddleName == employee.MiddleName))
            {
                throw new Exception("The employee is already in the database");
            }

            var employeeEntity = new EmployeeEntity
            {
                Id  = employee.Id,
                Name = employee.Name,
                MiddleName = employee.MiddleName,
                Surname = employee.Surname,
                Email = employee.Email,
                Projects = employee.Projects,
                HashPassword = employee.HashPassword,
            };

            await _context.Employees.AddAsync(employeeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task <bool> Delete(Guid id)
        {
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                throw new Exception("Not find project ");
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EmployeeEntity>> GetEmployee()
        {
           return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeById(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(i=>i.Id == id);

            if(employee == null)
            {
                throw new Exception("Employee not found by id");
            }
            return employee;
        }

        public async Task<List<ProjectEntity>> GetProjectsEmployee(Guid employeeId)
        {

             var employee = await _context.Employees
            .Include(e => e.Projects) // Uploading related employee projects
            .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null )
            {
                return new List<ProjectEntity>();
            }

            return employee.Projects.ToList();
        }

        public Task Update(Employee employee)
        {
            throw new NotImplementedException();
        }

    }
}
