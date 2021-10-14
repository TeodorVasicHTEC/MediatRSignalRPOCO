using System;
using System.Collections.Generic;
using Mediator.Domain.Models;

namespace Mediator.Domain.Data
{
    public interface IDataAccess
    {
        List<Employee> GetEmployees();
        Employee AddEmployee(string firstName, string secondName);
        bool RemoveEmployee(Guid id);
    }
}