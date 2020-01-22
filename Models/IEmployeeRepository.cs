using bootstrap.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bootstrap.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<RegisterViewModel> GetAllEmployees();
        RegisterViewModel GetEmployeeAsync(int Id);
        RegisterViewModel Add(RegisterViewModel employeeChanges);
        RegisterViewModel Update(RegisterViewModel employeeChanges);

        RegisterViewModel Delete(int Id);
        IEnumerable<CountryMaster> GetCountryMaster();
    }
}