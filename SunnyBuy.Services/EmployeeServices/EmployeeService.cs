using SunnyBuy.Services.EmployeeServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SunnyBuy.Domain;
using System.Linq;

namespace SunnyBuy.Services.EmployeeServices
{
    public class EmployeeService
    {
        protected readonly SunnyBuyContext context;

        public EmployeeService(SunnyBuyContext context)
        {
            this.context = context;
        }
        public async Task<int> Login(LoginModel model)
        {
            var login = await context.Employee
                .Where(e => e.Email == model.Email && e.Password == model.Password)
                .FirstOrDefaultAsync();

            if (login == null)
            {
                return 0;
            }

            return login.EmployeeId;
        }

        public async Task<bool> EditImage(GetEmployeeModel model)
        {
            var employee = context.Employee
                .FirstOrDefault(a => a.EmployeeId == model.EmployeeId);

            employee.Image = model.Image;

            context.Employee.Update(employee);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<GetEmployeeModel> GetEmployee(int id)
        {
            return await context.Employee
            .Where(a => a.EmployeeId == id)
            .Select(c => new GetEmployeeModel
            {
                EmployeeId = c.EmployeeId,
                Name = c.Name,
                Password = c.Password,
                Email = c.Email,
                Image = c.Image,
                Position = c.Position
            }).FirstOrDefaultAsync();
        }
    }
}
