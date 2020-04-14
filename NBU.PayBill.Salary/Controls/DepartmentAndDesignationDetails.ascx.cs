using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBU.PayBill.Salary.Controls
{
    public partial class AddNewDepartment : System.Web.UI.UserControl
    {
        private string Title;

        public string GetTitle()
        {
            return Title;
        }

        public void SetTitle(string value)
        {
            Title = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.uc_lbl_title.Text = "Add New " + this.GetTitle();
        }
    }
}