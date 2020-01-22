using bootstrap.Models;
using System.Collections.Generic;
using System.Linq;

namespace bootstrap.Services
{
    public class MockEmployeeRepository 
    {
        private List<RegisterViewModel> RegisterViewModel;

        public MockEmployeeRepository()
        {
            RegisterViewModel = new List<RegisterViewModel>()
            {
                new RegisterViewModel() { Id =1, firstName = "Mary", mobile="465465",
                    Email = "mary@pragimtech.com", State= "mary.jpg" },
                new RegisterViewModel() {Id =2, firstName = "John", mobile="465465",
                    Email = "john@pragimtech.com", State="john.jpg" },
                new RegisterViewModel() {Id =3, firstName = "Sara", mobile="465465",
                    Email = "sara@pragimtech.com", State="sara.jpg" },
                new RegisterViewModel() {Id =4, firstName = "David", mobile="465465",
                    Email = "david@pragimtech.com" },
            };
        }
        public RegisterViewModel Add(RegisterViewModel employee)
        {
            employee.Id = RegisterViewModel.Max(e => e.Id) + 1;
            RegisterViewModel.Add(employee);
            return employee;
        }
        public IEnumerable<RegisterViewModel> GetAllEmployees()
        {
            return RegisterViewModel;
        }
        public RegisterViewModel GetEmployee(int Id)
        {
            return this.RegisterViewModel.FirstOrDefault(e => e.Id == Id);
        }

        public RegisterViewModel Delete(int Id)
        {
            RegisterViewModel employee = RegisterViewModel.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                RegisterViewModel.Remove(employee);
            }
            return employee;
        }
        public RegisterViewModel Update(RegisterViewModel employeeChanges)
        {
            RegisterViewModel employee = RegisterViewModel.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.firstName = employeeChanges.firstName;
                employee.Email = employeeChanges.Email;
                employee.mobile = employeeChanges.mobile;
            }
            return employee;
        }
    }
}