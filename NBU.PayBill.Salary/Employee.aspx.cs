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
        EmployeeItemBO employeeFilter
        {
            set
            {
                ViewState["FILTER"] = value;
            }
            get
            {
                if (ViewState["FILTER"] == null)
                {
                    //ViewState["FILTER"] = new EmployeeItemBO();
                    return null;
                }
                return (EmployeeItemBO)ViewState["FILTER"];
            }
        }

        List<EmployeeItemBO> employees
        {
            get
            {
                if(ViewState["EMPLOYEES"] == null)
                {
                    ViewState["EMPLOYEES"] = EmployeeBusController.GetAllEmployees();
                }
                
                return (List<EmployeeItemBO>)ViewState["EMPLOYEES"];
            }
        }
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

        List<DepartmentBO> departments
        {
            get
            {
                if(ViewState["ALL_DEPARTMENTS"] == null)
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
                if(ViewState["ALL_DESIGNATIONS"] == null)
                {
                    ViewState["ALL_DESIGNATIONS"] = DeptDesigAndFinInstitutionBusController.GetDesignationBOs();
                }
                return (List<DesignationBO>)ViewState["ALL_DESIGNATIONS"];
            }
        }

        /* 
         
             get
            {
                if(ViewState[""] == null)
                {
                    ViewState[""] = DeptDesigAndFinInstitutionBusController
                }
                return (List<>)ViewState[""];
            }
             
             */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ddlCategory.DataTextField = "CategoryName";
                this.ddlCategory.DataValueField = "CategoryID";
                this.ddlCategory.DataSource = this.categories;
                this.ddlCategory.DataBind();
                this.ddlDepartment.DataTextField = "DepartmentName";
                this.ddlDepartment.DataValueField = "DepartmentCD";
                this.ddlDepartment.DataSource = this.departments;
                this.ddlDepartment.DataBind();
                this.ddlDesignation.DataTextField = "DesignationName";
                this.ddlDesignation.DataValueField = "DesignationCD";
                this.ddlDesignation.DataSource = this.designations;
                this.ddlDesignation.DataBind();
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
            GridView1.DataSource = EmployeeBusController.FilterEmployees(new List<EmployeeItemBO>(employees),employeeFilter);
            GridView1.DataBind();
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSelectionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnLoadEmployees_Click(object sender, EventArgs e)
        {
            EmployeeItemBO filter = new EmployeeItemBO();
            filter.EmpName = string.IsNullOrWhiteSpace(txtEmpName.Text)? null : txtEmpName.Text;
            filter.EmpGroup = ddlCategory.SelectedValue == "null"?null:ddlCategory.SelectedValue;
            filter.EmpDepartmentCD = ddlDepartment.SelectedValue == "null" ? null : ddlDepartment.SelectedValue;
            filter.EmpDesignationCD = ddlDesignation.SelectedValue == "null" ? null : ddlDesignation.SelectedValue;
            employeeFilter = filter;
            this.btnEditSelected.Visible = true;
            EmpListDemoLoader();
        }

        protected void btnEditSelected_Click(object sender, EventArgs e)
        {
            
        }
    }
}