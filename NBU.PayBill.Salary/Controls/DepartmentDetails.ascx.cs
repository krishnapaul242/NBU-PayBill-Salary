using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBU.PayBill.Salary.BL.BusinessObjects;
using NBU.PayBill.Salary.BL.BusController;

namespace NBU.PayBill.Salary.Controls
{
    public partial class DepartmentDetails : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uc_btn_submit_Click(object sender, EventArgs e)
        {
            DepartmentBO department = new DepartmentBO();
            department.DepartmentName = uc_txt_Name.Text;
            department.DepartmentBankAccount = uc_txt_BankAcc.Text;
            bool result = DeptDesigAndFinInstitutionBusController.AddDepartment(department);
            if (result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Not Added. Some Problem Occurred')", true);
            }
        }
    }
}