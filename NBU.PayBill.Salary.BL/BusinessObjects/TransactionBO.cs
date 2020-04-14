using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class TransactionBO
    {
        private string transactionID;
        private string empID;
        private string empName;
        private string departmentID;
        private string designationID;
        private string categoryID;
        private string basicPay;
        private string gradePay;
        private string specialPay;
        private string workingDays;
        private string absentDays;
        private string empDNI;
        private string tag;
        private string totalEarnings;
        private string totalDeductions;
        private string netPay;
        private string transactionRemarks;
        private string updateTMS;
        private string updateUser;
        private string transactionForMonth;
        private string transactionForYear;

        public string TransactionID { get => transactionID; set => transactionID = value; }
        public string EmpID { get => empID; set => empID = value; }
        public string EmpName { get => empName; set => empName = value; }
        public string DepartmentID { get => departmentID; set => departmentID = value; }
        public string DesignationID { get => designationID; set => designationID = value; }
        public string CategoryID { get => categoryID; set => categoryID = value; }
        public string BasicPay { get => basicPay; set => basicPay = value; }
        public string GradePay { get => gradePay; set => gradePay = value; }
        public string SpecialPay { get => specialPay; set => specialPay = value; }
        public string WorkingDays { get => workingDays; set => workingDays = value; }
        public string AbsentDays { get => absentDays; set => absentDays = value; }
        public string EmpDNI { get => empDNI; set => empDNI = value; }
        public string Tag { get => tag; set => tag = value; }
        public string TotalEarnings { get => totalEarnings; set => totalEarnings = value; }
        public string TotalDeductions { get => totalDeductions; set => totalDeductions = value; }
        public string NetPay { get => netPay; set => netPay = value; }
        public string TransactionRemarks { get => transactionRemarks; set => transactionRemarks = value; }
        public string UpdateTMS { get => updateTMS; set => updateTMS = value; }
        public string UpdateUser { get => updateUser; set => updateUser = value; }
        public string TransactionForMonth { get => transactionForMonth; set => transactionForMonth = value; }
        public string TransactionForYear { get => transactionForYear; set => transactionForYear = value; }
    }
}
