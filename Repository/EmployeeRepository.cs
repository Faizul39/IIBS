using IIBS.Data;
using IIBS.Models;
using System.Collections.Generic;
using System.Linq;

namespace IIBS.Repository
{
   
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> empl = _context.employees.ToList();
            return empl;
           //return _context.employees.ToList();
        }
        public Employee GetEmployeeByID(int id)
        {
            Employee? emp = _context.employees.FirstOrDefault(e => e.EmployeeID == id);
            return emp;
        }
        public Employee Details(int id)
        {
            Employee? emp = _context.employees.FirstOrDefault(e => e.EmployeeID == id);
            return emp;
        }
        public Employee AddEmployee(Employee emp)
        {
            _context.employees.Add(emp);
            _context.SaveChanges();
            return emp;
        }
        public Employee UpdateEmployee(Employee uemp)
        {
            Employee emp = _context.employees.FirstOrDefault(e => e.EmployeeID == uemp.EmployeeID);
            emp.EmployeeID = uemp.EmployeeID;
            emp.First_Name = uemp.First_Name;
            emp.Last_Name = uemp.Last_Name;
            emp.Division = uemp.Division;
            emp.Title_and_Room = uemp.Title_and_Room;
            _context.employees.Update(emp);
            _context.SaveChanges(true);
            return uemp;
        }
        public void DeleteEmployee(int id)
        {
            var delemp = _context.employees.FirstOrDefault(e => e.EmployeeID == id);
            if (delemp != null)
            {
                _context.employees.Remove(delemp);
                _context.SaveChanges();
            }
        }
    }
}
