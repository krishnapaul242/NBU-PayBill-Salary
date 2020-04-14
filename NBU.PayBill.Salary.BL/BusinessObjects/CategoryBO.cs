using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NBU.Common.Helper;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class CategoryBO : BaseBusinessEntity
    {
        private string categoryName;
        private string categoryID;

        public string CategoryName
        {
            get => categoryName;
            set => categoryName = value;
        }

        public string CategoryID
        {
            get => categoryID;
            set => categoryID = value;
        }
    }
}
