using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBU.PayBill.Salary.BL.BusController;
using NBU.PayBill.Salary.BL.BusinessObjects;


namespace NBU.PayBill.Salary.Controls
{
    public partial class AddNewEmployee : System.Web.UI.UserControl
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.uc_ddl_Department.DataValueField = "DepartmentCD";
                this.uc_ddl_Department.DataTextField = "DepartmentName";
                this.uc_ddl_Department.DataSource = this.departments;
                this.uc_ddl_Department.DataBind();
                this.uc_ddl_Designation.DataValueField = "DesignationCD";

            }
        }
    }
}