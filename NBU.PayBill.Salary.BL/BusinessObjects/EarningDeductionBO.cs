using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class EarningDeductionBO
    {
        private string edTypeID;
        private string edTypeName;
        private string isEarningOrDeduction;
        private string inSalarySlipForAll;
        private string categories;
        private string subcategories;

        public EarningDeductionBO()
        {
        }

        public string EDTypeID
        {
            get => edTypeID;
            set => edTypeID = value;
        }

        public string EDTypeName
        {
            get => edTypeName;
            set => edTypeName = value;
        }

        public string IsEarningOrDeduction
        {
            get => isEarningOrDeduction;
            set => isEarningOrDeduction = value;
        }

        public string InSalarySlipForAll
        {
            get => inSalarySlipForAll;
            set => inSalarySlipForAll = value;
        }

        public string Categories
        { 
            get => categories; 
            set => categories = value; 
        }

        public string Subcategories 
        { 
            get => subcategories; 
            set => subcategories = value; 
        }
    }
}
