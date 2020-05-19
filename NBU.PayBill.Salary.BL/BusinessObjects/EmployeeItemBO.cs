using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class EmployeeItemBO
    {
        private string empID;
        private string empDepartmentCD;
        private string empDesignationCD;
        private string empName;
        private string empGroup;

        public string EmpID
        {
            get => empID;
            set => empID = value;
        }

        public string EmpDepartmentCD
        {
            get => empDepartmentCD;
            set => empDepartmentCD = value;
        }

        public string EmpDesignationCD
        {
            get => empDesignationCD;
            set => empDesignationCD = value;
        }

        public string EmpName
        {
            get => empName;
            set => empName = value;
        }

        public string EmpGroup
        {
            get => empGroup;
            set => empGroup = value;
        }

        public EmployeeItemBO()
        {
            EmpDepartmentCD = null;
            EmpDesignationCD = null;
            EmpGroup = null;
            EmpID = null;
            EmpName = null;
        }
    }
}
