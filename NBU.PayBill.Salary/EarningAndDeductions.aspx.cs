using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBU.PayBill.Salary
{
    public partial class Earning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCaddEarningForm.SetTitle("Earning");
            this.UCaddDeductionForm.SetTitle("Deduction");
        }

        protected void ddlEarningDeductions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bind data for the selected index

        }
    }
}