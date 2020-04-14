using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class FinancialInstitutionBO
    {
        private string financialInstitutionCD;
        private string financialInstitutionName;
        private string financialInstitutionAddress;

        public string FinancialInstitutionCD
        {
            get => financialInstitutionCD;
            set => financialInstitutionCD = value;
        }

        public string FinancialInstitutionName
        {
            get => financialInstitutionName;
            set => financialInstitutionName = value;
        }

        public string FinancialInstitutionAddress
        {
            get => financialInstitutionAddress;
            set => financialInstitutionAddress = value;
        }
    }
}
