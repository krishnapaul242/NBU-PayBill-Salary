﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBU.PayBill.Salary
{
    public partial class SalaryEarningsDeductions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEarningsDeductions_Click(object sender, EventArgs e)
        {
            this.EarningDeductionBox.Visible = true;
            this.PayscaleBox.Visible = false;
        }

        protected void btnPayScale_Click(object sender, EventArgs e)
        {
            this.EarningDeductionBox.Visible = false;
            this.PayscaleBox.Visible = true;
        }
    }
}