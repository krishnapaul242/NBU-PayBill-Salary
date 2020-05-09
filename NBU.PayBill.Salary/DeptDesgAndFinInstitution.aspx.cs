using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBU.PayBill.Salary.BL.BusinessObjects;
using NBU.PayBill.Salary.BL.BusController;
using NBU.Common.Helper;
using System.Collections.Specialized;


namespace NBU.PayBill.Salary
{
    public partial class DeptDesgAndFinInstitution : System.Web.UI.Page
    {
        private string SelectedTypeCode
        {
            get
            {
                return (string)ViewState["SELECTED_TYPE_CODE"];
            }
            set
            {
                ViewState["SELECTED_TYPE_CODE"] = value;
            }
        }

        private string SelectedActionCode
        {
            get
            {
                return (string)ViewState["SELECTED_ACTION_CODE"];
            }
            set
            {
                ViewState["SELECTED_ACTION_CODE"] = value;
            }
        }

        private List<DepartmentBO> Departments
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

        private List<DesignationBO> Designations
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

        private List<FinancialInstitutionBO> FinancialInstitutions
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

        private void ShowDiv()
        {
            divShowDetails.Visible = false;
            divDepartmentDetails.Visible = false;
            divDesignationDetails.Visible = false;
            divFinInstDetails.Visible = false;

            if (this.SelectedTypeCode == null)
            {
                divShowDetails.Visible = true;
            } else
            {
                switch (this.SelectedTypeCode)
                {
                    case "DT":
                        divDepartmentDetails.Visible = true;
                        break;
                    case "DS":
                        divDesignationDetails.Visible = true;
                        break;
                    case "FI":
                        divFinInstDetails.Visible = true;
                        break;
                    default:
                        divShowDetails.Visible = true;
                        break;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    NameValueCollection nvc = Request.QueryString;
            //    if (nvc.Count > 0 && nvc.GetValues("TYPE") != null && nvc.GetValues("TYPE").Length != 0)
            //    {
            //        this.SelectedTypeCode = StringUtil.Decode(nvc.GetValues("TYPE").ElementAt(0));
            //        if (nvc.Count > 0 && nvc.GetValues("ACTION") != null && nvc.GetValues("ACTION").Length != 0)
            //        {
            //            this.SelectedActionCode = StringUtil.Decode(nvc.GetValues("ACTION").ElementAt(0));
            //        }
            //        else
            //        {
            //            this.SelectedActionCode = null;
            //        }
            //    }
            //    else
            //    {
            //        this.SelectedTypeCode = null;
            //    }
            //    ShowDiv();
            //} else
            //{

            //}






            if (IsPostBack)
            {

            }
            else
            {
                gvDepartment.DataSource = Departments;
                gvDepartment.DataBind();
                gvDesignation.DataSource = Designations;
                gvDesignation.DataBind();
                gvFinInstitution.DataSource = FinancialInstitutions;
                gvFinInstitution.DataBind();
                divShowDetails.Visible = true;
                divDepartmentDetails.Visible = false;
                divDesignationDetails.Visible = false;
                divFinInstDetails.Visible = false;
            }
        }

        //protected void btnDeptAdd_Click(object sender, EventArgs e)
        //{
        //    DepartmentBO department = new DepartmentBO();
        //    //TextBox textBox = (TextBox) 
        //    department.DepartmentName = inputDeptName.Value.ToString();
        //    //department.DepartmentBankAccount = this.txtBankAcc.Text.Trim();
        //    if (DeptDesigAndFinInstitutionBusController.AddDepartment(department))
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Added Successfully')", true);
        //    } else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Not Added. Some Problem Occurred')", true);
        //    }
        //}

        protected void btnAddDept_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddDept_Command(object sender, CommandEventArgs e)
        {

        }

        protected void btnDesigAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddDept_Click1(object sender, EventArgs e)
        {

        }

        protected void btnAddDepartment_Click(object sender, EventArgs e)
        {
            divShowDetails.Visible = false;
            divDepartmentDetails.Visible = true;
            divDesignationDetails.Visible = false;
            divFinInstDetails.Visible = false;
        }

        protected void btnAddDesignation_Click(object sender, EventArgs e)
        {
            divShowDetails.Visible = false;
            divDepartmentDetails.Visible = false;
            divDesignationDetails.Visible = true;
            divFinInstDetails.Visible = false;
        }

        protected void btnAddFinInst_Click(object sender, EventArgs e)
        {
            divShowDetails.Visible = false;
            divDepartmentDetails.Visible = false;
            divDesignationDetails.Visible = false;
            divFinInstDetails.Visible = true;
        }

        protected void BtnAddDept_Click2(object sender, EventArgs e)
        {
            divShowDetails.Visible = false;
            divDepartmentDetails.Visible = true;
            divDesignationDetails.Visible = false;
            divFinInstDetails.Visible = false;
        }
    }
}