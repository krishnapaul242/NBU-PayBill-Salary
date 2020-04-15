using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class DepartmentBO
    {
        private string departmentCD;
        private string departmentName;
        private string departmentBankAccount;

        public string DepartmentCD
        {
            get => departmentCD;
            set => departmentCD = value;
        }

        public string DepartmentName
        {
            get => departmentName;
            set => departmentName = value;
        }

        public string DepartmentBankAccount
        {
            get => departmentBankAccount;
            set => departmentBankAccount = value;
        }
    }
}
