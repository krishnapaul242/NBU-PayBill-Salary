using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class DesignationBO
    {
        private string designationCD;
        private string designationName;

        public string DesignationCD
        {
            get => designationCD;
            set => designationCD = value;
        }

        public string DesignationName
        {
            get => designationName;
            set => designationName = value;
        }
    }
}
