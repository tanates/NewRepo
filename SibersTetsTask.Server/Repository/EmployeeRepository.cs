using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Interface.IEmployee;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;
using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelEntity.User;

namespace SibersTetsTask.Server.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddEmployee(EmployeeDTO employee ,string hashPassword)
        {
            if(await _context.Employees.AnyAsync(i=>i.FirstName == employee.Name 
            && i.FirstName == employee.Name 
            && i.MiddleName == employee.MiddleName))
            {
                throw new Exception("The employee is already in the database");
            }

            if(await _context.Employees.AnyAsync(i=> i.Email == employee.Email))
            {
                throw new Exception("Email to borrow");
            }
            var employeeEntity = new EmployeeEntity
            {
                Id  = employee.Id,
                FirstName = employee.Name,
                MiddleName = employee.MiddleName,
                LastName = employee.Surname,
                Email = employee.Email,
                HashPassword = hashPassword,
            };

            await _context.Employees.AddAsync(employeeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task <bool> Delete(string email)
        {
            var employees = await _context.Employees.FirstOrDefaultAsync(i=>i.Email==email);
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

        public async Task<EmployeeEntity> GetEmployeeByEmail(Guid employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(i=>i.Id == employeeId);

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

        public async Task<string> Update(EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(i=>i.Email==employeeDTO.Email);

                if (employee == null)
                {
                    return $"Employee not found {employeeDTO.Email}";
                }

                employee.FirstName = employeeDTO.Name ?? employee.FirstName;
                employee.LastName = employeeDTO.Surname ?? employee.LastName;
                employee.MiddleName = employeeDTO.MiddleName ?? employee.MiddleName;
                employee.Email = employeeDTO.Email ?? employee.Email;

                await _context.SaveChangesAsync();
                return "Update sucssefull";
            }
            catch (Exception ex)
            {

                return $"Error Update : {ex}"; 
            }
          
        }



     
    }
}
