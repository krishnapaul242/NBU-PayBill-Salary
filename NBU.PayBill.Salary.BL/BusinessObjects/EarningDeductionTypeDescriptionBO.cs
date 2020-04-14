using System;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class EarningDeductionTypeDescriptionBO
    {
        public EarningDeductionTypeDescriptionBO()
        {

        }

        private string edTypeID;
        private string edSubTypeID;
        private string isEDTypeForAll;
        private string edTypeFixedVal;
        private string edTypePercentageVal;
        private string edTypeEligibilityConditonOperator;
        private string edTypeConditionValue;
        private string edTypeMaxValue;

        public string EDTypeID
        {
            get => edTypeID;
            set => edTypeID = value;
        }

        public string EDSubTypeID
        {
            get => edSubTypeID;
            set => edSubTypeID = value;
        }

        public string IsEDTypeForAll
        {
            get => isEDTypeForAll;
            set => isEDTypeForAll = value;
        }

        public string EDTypeFixedVal
        {
            get => edTypeFixedVal;
            set => edTypeFixedVal = value;
        }

        public string EDTypePercentageVal
        {
            get => edTypePercentageVal;
            set => edTypePercentageVal = value;
        }

        public string EDTypeEligibilityConditonOperator
        {
            get => edTypeEligibilityConditonOperator;
            set => edTypeEligibilityConditonOperator = value;
        }

        public string EDTypeConditionValue
        {
            get => edTypeConditionValue;
            set => edTypeConditionValue = value;
        }

        public string EDTypeMaxValue
        {
            get => edTypeMaxValue;
            set => edTypeMaxValue = value;
        }
    }
}
