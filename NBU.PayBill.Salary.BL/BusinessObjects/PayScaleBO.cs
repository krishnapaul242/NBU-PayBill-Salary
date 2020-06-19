using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class PayScaleBO
    {
        private string scaleCD;
        private string effectiveMonthYear;
        private string empGroup;
        private string payBandNumber;
        private string startPay;
        private string endPay;
        private string gradePay;
        private string specialPay;

        public string ScaleCD { get => scaleCD; set => scaleCD = value; }
        public string EffectiveMonthYear { get => effectiveMonthYear; set => effectiveMonthYear = value; }
        public string EmpGroup { get => empGroup; set => empGroup = value; }
        public string PayBandNumber { get => payBandNumber; set => payBandNumber = value; }
        public string StartPay { get => startPay; set => startPay = value; }
        public string EndPay { get => endPay; set => endPay = value; }
        public string GradePay { get => gradePay; set => gradePay = value; }
        public string SpecialPay { get => specialPay; set => specialPay = value; }
    }
}
