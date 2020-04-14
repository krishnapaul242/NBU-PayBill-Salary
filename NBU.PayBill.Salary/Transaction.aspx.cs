using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBU.PayBill.Salary.BL.BusController;
using NBU.PayBill.Salary.BL.BusinessObjects;
namespace NBU.PayBill.Salary
{
    public partial class Transaction : System.Web.UI.Page
    {
        List<CategoryBO> categories
        {
            get
            {
                if (ViewState["ALL_CATEGORIES"] == null)
                {
                    ViewState["ALL_CATEGORIES"] = EarningAndDeductionsBC.GetCategoryBOs();
                }
                return (List<CategoryBO>)ViewState["ALL_CATEGORIES"];
            }
        }

        private void DropDownLoader<T>(DropDownList d, string txtField, string valField, List<T> ts)
        {
            d.DataTextField = txtField;
            d.DataValueField = valField;
            d.DataSource = ts;
            d.DataBind();
        }

        private void DateTimeLoader()
        {
            this.footerDateTime.Text = DateTime.Now.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownLoader<CategoryBO>(ddlCategory, "CategoryName", "CategoryID", categories);
            DateTimeLoader();
        }

        protected void ddlSelectionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.ddlSelectionMethod.SelectedValue)
            {
                case "EN":
                    this.ddlCategory.Visible = false;
                    this.lblCategoryDDL.Visible = false;
                    this.ddlDepartment.Visible = false;
                    this.lblDepartmentDDL.Visible = false;
                    this.ddlEmployee.Visible = true;
                    this.lblEmployeeDDL.Visible = true;
                    this.txtEmpName.Visible = true;
                    this.lblEmpNameTXT.Visible = true;
                    this.ddlDesignation.Visible = false;
                    this.lblDesignationDDL.Visible = false;
                    break;
                case "DCS":
                    this.ddlCategory.Visible = true;
                    this.lblCategoryDDL.Visible = true;
                    this.ddlDepartment.Visible = true;
                    this.lblDepartmentDDL.Visible = true;
                    this.ddlEmployee.Visible = false;
                    this.lblEmployeeDDL.Visible = false;
                    this.txtEmpName.Visible = false;
                    this.lblEmpNameTXT.Visible = false;
                    this.ddlDesignation.Visible = false;
                    this.lblDesignationDDL.Visible = false;
                    break;
                case "DD":
                    this.ddlCategory.Visible = false;
                    this.lblCategoryDDL.Visible = false;
                    this.ddlDepartment.Visible = true;
                    this.lblDepartmentDDL.Visible = true;
                    this.ddlEmployee.Visible = false;
                    this.lblEmployeeDDL.Visible = false;
                    this.txtEmpName.Visible = false;
                    this.lblEmpNameTXT.Visible = false;
                    this.ddlDesignation.Visible = true;
                    this.lblDesignationDDL.Visible = true;
                    break;
            }
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}