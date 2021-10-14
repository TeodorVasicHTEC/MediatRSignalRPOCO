using System;
using System.Collections.Generic;
using System.Linq;
using Mediator.Domain.Models;

namespace Mediator.Domain.Data
{
    public class DataAccess : IDataAccess
    {
        private List<Employee> _employees = new List<Employee>();
        public DataAccess()
        {
            _employees.Add(new Employee{FirstName = "Vuk", LastName = "Isic", Id = Guid.NewGuid()});
            _employees.Add(new Employee{FirstName = "Teodor", LastName = "Vasic", Id = Guid.NewGuid()});
            _employees.Add(new Employee{FirstName = "Aleksandar", LastName = "Jovanov", Id = Guid.NewGuid() });
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee AddEmployee(string firstName, string secondName)
        {
            var newEmployee = new Employee {FirstName = firstName, LastName = secondName, Id = Guid.NewGuid() };
            _employees.Add(newEmployee);
            return newEmployee;
        }

        public bool RemoveEmployee(Guid id)
        {
            _employees.Remove(_employees.FirstOrDefault(e => e.Id == id));
            return true;
        }
    }
}