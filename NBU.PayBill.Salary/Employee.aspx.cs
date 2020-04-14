using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBU.PayBill.Salary.BL.BusController;
using NBU.PayBill.Salary.BL.BusinessObjects;

namespace NBU.PayBill.Salary
{
    public partial class Employee : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ddlCategory.DataTextField = "CategoryName";
            this.ddlCategory.DataValueField = "CategoryID";
            this.ddlCategory.DataSource = this.categories;
            this.ddlCategory.DataBind();
            EmpListDemoLoader();
            if (!this.IsPostBack)
            {

            }
            else
            {

            }
        }

        private void ShowEmpDetails(string empCode)
        {

        }

        private void EmpListDemoLoader()
        {
            string constr = ConfigurationManager.AppSettings["ConStr"];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT TOP 20 * FROM [dbo].[EMPLMAST]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {

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

        protected void BtnAddNewEmp_Click(object sender, EventArgs e)
        {
            if (this.EmployeeDetailsView.Visible)
            {
                this.EmployeeDetailsView.Visible = false;
                btnAddNewEmp.Text = "+ Add New Employee";
            }
            else
            {
                this.EmployeeDetailsView.Visible = true;
                btnAddNewEmp.Text = "Cancel";
            }

        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPageEventArgs gve = (GridViewPageEventArgs)e;
            GridView1.PageIndex = gve.NewPageIndex;
            EmpListDemoLoader();
        }
    }
}