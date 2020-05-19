using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBU.PayBill.Salary.BL.BusinessObjects;
using NBU.PayBill.Salary.BL.DataAccessService;
using NBU.PayBill.Salary.BL.BusController;
using NBU.Common.Helper;

namespace NBU.PayBill.Salary.BL.BusController
{
    public static class EmployeeBusController
    {
        public static List<EmployeeItemBO> GetAllEmployees(EmployeeItemBO employee = null)
        {
            EmployeeDAS employeeDAS = new EmployeeDAS();
            string jsondata = employeeDAS.GetAllEmployees();
            List<EmployeeItemBO> employees = new List<EmployeeItemBO>();
            if (!jsondata.StartsWith("DB_ERROR"))
                employees = StringUtil.DeserializeObjectFromJSON<List<EmployeeItemBO>>(jsondata);
            if (employee != null) employees = FilterEmployees(employees, employee);
            return employees;
        }

        public static List<EmployeeItemBO> FilterEmployees(List<EmployeeItemBO> employees, EmployeeItemBO employee)
        {
            if(employee.EmpDepartmentCD != null)
            {
                employees.RemoveAll(emp => emp.EmpDepartmentCD != employee.EmpDepartmentCD);
            }
            if(employee.EmpDesignationCD != null)
            {
                employees.RemoveAll(emp => emp.EmpDesignationCD != employee.EmpDesignationCD);
            }
            if(employee.EmpGroup != null)
            {
                employees.RemoveAll(emp => emp.EmpGroup != employee.EmpGroup);
            }
            if (employee.EmpName != null)
            {
                employees.RemoveAll(emp => !emp.EmpName.ToLower().Contains(employee.EmpName.ToLower()));
            }

            return employees;
        }
    }
}
