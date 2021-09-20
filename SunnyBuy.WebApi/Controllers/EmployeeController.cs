using SunnyBuy.Services.ProductServices.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SunnyBuy.Services;
using SunnyBuy.Domain;
using SunnyBuy.Services.EmployeeServices.Models;
using SunnyBuy.Services.EmployeeServices;

namespace SunnyBuy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        protected readonly EmployeeService employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost("login")]
        public async Task<int> Login(LoginModel model)
        {
            return await employeeService.Login(model);
        }

        [HttpPut()]
        public async Task<bool> EditImage(GetEmployeeModel model)
        {
            return await employeeService.EditImage(model);
        }

        [HttpGet("{employeeId}")]
        public async Task<GetEmployeeModel> Get(int employeeId)
        {
            return await employeeService.GetEmployee(employeeId);
        }
    }
}
