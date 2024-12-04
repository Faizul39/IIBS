using IIBS.Data;
using IIBS.Models;
using System.Collections.Generic;
using System.Linq;

namespace IIBS.Repository
{
    public interface IEmployee
    {
        List<Employee> GetAllEmployee();
        Employee GetEmployeeByID(int id);
        Employee Details(int id);
        Employee AddEmployee(Employee emp);
        Employee UpdateEmployee(Employee uemp);
        void DeleteEmployee(int id);
    }
}
