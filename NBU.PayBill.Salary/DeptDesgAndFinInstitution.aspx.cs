using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBU.PayBill.Salary.BL.BusinessObjects;
using NBU.PayBill.Salary.BL.BusController;

namespace NBU.PayBill.Salary
{
    public partial class DeptDesgAndFinInstitution : System.Web.UI.Page
    {
        List<DepartmentBO> departments
        {
            get
            {
                if (ViewState["ALL_DEPARTMENTS"] == null)
                {
                    ViewState["ALL_DEPARTMENTS"] = DeptDesigAndFinInstitutionBusController.GetDepartmentBOs();
                }
                return (List<DepartmentBO>)ViewState["ALL_DEPARTMENTS"];
            }
        }

        List<DesignationBO> designations
        {
            get
            {
                if (ViewState["ALL_DESIGNATIONS"] == null)
                {
                    ViewState["ALL_DESIGNATIONS"] = DeptDesigAndFinInstitutionBusController.GetDesignationBOs();
                }
                return (List<DesignationBO>)ViewState["ALL_DESIGNATIONS"];
            }
        }

        List<FinancialInstitutionBO> financialInstitutions
        {
            get
            {
                if (ViewState["ALL_FINANCIAL_INSTITUTIONS"] == null)
                {
                    ViewState["ALL_FINANCIAL_INSTITUTIONS"] = DeptDesigAndFinInstitutionBusController.GetFinancialInstitutionBOs();
                }
                return (List<FinancialInstitutionBO>)ViewState["ALL_FINANCIAL_INSTITUTIONS"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
            } else
            {
                gvDepartment.DataSource = departments;
                gvDepartment.DataBind();
                gvDesignation.DataSource = designations;
                gvDesignation.DataBind();
                gvFinInstitution.DataSource = financialInstitutions;
                gvFinInstitution.DataBind();
            }
        }

        protected void btnDeptAdd_Click(object sender, EventArgs e)
        {
            DepartmentBO department = new DepartmentBO();
            //TextBox textBox = (TextBox) 
            department.DepartmentName = inputDeptName.Value.ToString();
            //department.DepartmentBankAccount = this.txtBankAcc.Text.Trim();
            if (DeptDesigAndFinInstitutionBusController.AddDepartment(department))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Added Successfully')", true);
            } else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Not Added. Some Problem Occurred')", true);
            }
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddDept_Command(object sender, CommandEventArgs e)
        {

        }

        protected void btnDesigAdd_Click(object sender, EventArgs e)
        {

        }
    }
}