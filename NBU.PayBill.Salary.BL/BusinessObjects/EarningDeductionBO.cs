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
        private string edcode;
        private string edtype;
        private string edname;
        private string edscale;
        private string eddescription;
        private string edisFixedOrVariable;
        private string edvalue;
        private string edeligibilityConditionOperator;
        private string edeligibiltyConditionValue;
        private string edmaxValue;
        private string edcategory;
        private string edsubcategory;
        private string edWEF_monthYear;
        private string edforAll;

        public string EDid { get => edcode; set => edcode = value; }
        public string EDtype { get => edtype; set => edtype = value; }
        public string EDname { get => edname; set => edname = value; }
        public string EDscale { get => edscale; set => edscale = value; }
        public string EDdescription { get => eddescription; set => eddescription = value; }
        public string EDfixOrVar { get => edisFixedOrVariable; set => edisFixedOrVariable = value; }
        public string EDvalue { get => edvalue; set => edvalue = value; }
        public string EDeligibilityCondOp { get => edeligibilityConditionOperator; set => edeligibilityConditionOperator = value; }
        public string EDeligibiltyCondValue { get => edeligibiltyConditionValue; set => edeligibiltyConditionValue = value; }
        public string EDmaxValue { get => edmaxValue; set => edmaxValue = value; }
        public string EDcategory { get => edcategory; set => edcategory = value; }
        public string EDsubcategory { get => edsubcategory; set => edsubcategory = value; }
        public string EDmonthYear { get => edWEF_monthYear; set => edWEF_monthYear = value; }
        public string EDforAll { get => edforAll; set => edforAll = value; }
    }
}
