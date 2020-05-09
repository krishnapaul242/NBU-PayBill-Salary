using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NBU.PayBill.Salary.BL.BusController;
using NBU.PayBill.Salary.BL.BusinessObjects;
using NBU.Common.Helper;

namespace NBU.PayBill.Salary
{
    public partial class DeptDesigAndFinInstitution : System.Web.UI.Page
    {
        
        private string RequestCode
        {
            get
            {
                return (string)ViewState["REQUEST_CODE"];
            }
            set
            {
                ViewState["REQUEST_CODE"] = value;
            }
        }


        private string SelectedAction
        {
            get
            {
                return (string)ViewState["SELECTED_ACTION"];
            }
            set
            {
                ViewState["SELECTED_ACTION"] = value;
            }
        }

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

        private static string ResourceTable(string code)
        {
            string resource;
            switch (code)
            {
                case "AddDept":
                    resource = "Add New Department";
                    break;
                case "EditDept":
                    resource = "Update Department Information";
                    break;
                case "AddDesig":
                    resource = "Add New Designation";
                    break;
                case "EditDesig":
                    resource = "Update Designation Information";
                    break;
                case "AddFin":
                    resource = "Add New Financial Institution";
                    break;
                case "EditFin":
                    resource = "Update Financial Institution Information";
                    break;
                case "PageURL":
                    resource = "~/DeptDesigAndFinInstitution.aspx";
                    break;
                case "StringUpdate":
                    resource = "Update";
                    break;
                case "StringAdd":
                    resource = "Add";
                    break;
                default:
                    resource = string.Empty;
                    break;
            }
            return resource;
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
                BindData();
            }
            else
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
                        BindData();
                        break;
                }
            }
        }

        private bool DeleteAction()
        {
            bool result = false;
            switch (this.SelectedTypeCode)
            {
                case "DT":
                    DepartmentBO department = new DepartmentBO();
                    department.DepartmentCD = this.RequestCode;
                    result = DeptDesigAndFinInstitutionBusController.RemoveDepartment(department);
                    if(result)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Deleted Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Not Deleted. Some Problem Occurred')", true);
                    }
                    this.SelectedTypeCode = null;
                    break;
                case "DS":
                    DesignationBO designation = new DesignationBO();
                    designation.DesignationCD = this.RequestCode;
                    result = DeptDesigAndFinInstitutionBusController.RemoveDesignation(designation);
                    if (result)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Designation Deleted Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Designation Not Deleted. Some Problem Occurred')", true);
                    }
                    this.SelectedTypeCode = null;
                    break;
                case "FI":
                    FinancialInstitutionBO financialInstitution = new FinancialInstitutionBO();
                    financialInstitution.FinancialInstitutionCD = this.RequestCode;
                    result = DeptDesigAndFinInstitutionBusController.RemoveFinancialInstitution(financialInstitution);
                    if (result)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Financial Institution Deleted Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Financial Institution Not Deleted. Some Problem Occurred')", true);
                    }
                    this.SelectedTypeCode = null;
                    break;
                default:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bad Request.')", true);
                    break;
            }
            return result;
        }

        private void EditAction()
        {
            string postbackurl = ResourceTable("PageURL");
            switch (this.SelectedTypeCode)
            {
                case "DT":
                    DepartmentBO department = new DepartmentBO();
                    department.DepartmentCD = this.RequestCode;
                    department = DeptDesigAndFinInstitutionBusController.GetDepartmentBO(department);
                    lbl_Dept_title.Text = ResourceTable("EditDept");
                    this.txtDeptName.Text = department.DepartmentName;
                    this.txtBankAcc.Text = department.DepartmentBankAccount;
                    postbackurl += "?CD=" + StringUtil.Encode(department.DepartmentCD);
                    this.btnAddDept.PostBackUrl = postbackurl;
                    this.btnAddDept.Text = ResourceTable("StringUpdate");
                    break;
                case "DS":
                    DesignationBO designation = new DesignationBO();
                    designation.DesignationCD = this.RequestCode;
                    designation = DeptDesigAndFinInstitutionBusController.GetDesignationBO(designation);
                    lbl_Desig_title.Text = ResourceTable("EditDesig");
                    this.txtDesigName.Text = designation.DesignationName;
                    postbackurl += "?CD=" + StringUtil.Encode(designation.DesignationCD);
                    this.btnDesigAdd.PostBackUrl = postbackurl;
                    this.btnDesigAdd.Text = ResourceTable("StringUpdate");
                    break;
                case "FI":
                    FinancialInstitutionBO financialInstitution = new FinancialInstitutionBO();
                    financialInstitution.FinancialInstitutionCD = this.RequestCode;
                    financialInstitution = DeptDesigAndFinInstitutionBusController.GetFinancialInstitutionBO(financialInstitution);
                    lbl_Fin_title.Text = ResourceTable("EditFin");
                    this.txtFinInstName.Text = financialInstitution.FinancialInstitutionName;
                    this.txtFinInstAddress.Text = financialInstitution.FinancialInstitutionAddress;
                    postbackurl += "?CD=" + StringUtil.Encode(financialInstitution.FinancialInstitutionCD);
                    this.btnFinInstAdd.PostBackUrl = postbackurl;
                    this.btnFinInstAdd.Text = ResourceTable("StringUpdate");
                    break;
                default:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bad Request.')", true);
                    break;
            }
        }

        private void AddAction()
        {
            string postbackurl = ResourceTable("PageURL");
            switch (this.SelectedTypeCode)
            {
                case "DT":
                    lbl_Dept_title.Text = ResourceTable("AddDept");
                    txtDeptName.Text = ResourceTable("");
                    txtBankAcc.Text = ResourceTable("");
                    this.btnAddDept.PostBackUrl = postbackurl;
                    break;
                case "DS":
                    lbl_Desig_title.Text = ResourceTable("AddDesig");
                    txtDesigName.Text = ResourceTable("");
                    this.btnDesigAdd.PostBackUrl = postbackurl;
                    break;
                case "FI":
                    lbl_Fin_title.Text = ResourceTable("AddFin");
                    txtFinInstAddress.Text = ResourceTable("");
                    txtFinInstName.Text = ResourceTable("");
                    this.btnFinInstAdd.PostBackUrl = postbackurl;
                    break;
                default:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bad Request.')", true);
                    break;
            }
        }

        private void CallAction()
        {
            switch (this.SelectedAction)
            {
                case "DEL":
                    DeleteAction();
                    break;
                case "EDT":
                    EditAction();
                    break;
                case "ADD":
                    AddAction();
                    break;
                default:
                    ShowDiv();
                    break;
            }
        }

        private void BindData()
        {
            gvDepartment.DataSource = Departments;
            gvDepartment.DataBind();
            gvDesignation.DataSource = Designations;
            gvDesignation.DataBind();
            gvFinInstitution.DataSource = FinancialInstitutions;
            gvFinInstitution.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection nvc = Request.QueryString;
            if (!this.IsPostBack)
            {
                if (nvc.Count > 0 && nvc.GetValues("TC") != null && nvc.GetValues("TC").Length != 0)
                {
                    this.SelectedTypeCode = nvc.GetValues("TC").ElementAt(0);
                    if (nvc.Count > 1 && nvc.GetValues("ACT") != null && nvc.GetValues("ACT").Length != 0)
                    {
                        this.SelectedAction = nvc.GetValues("ACT").ElementAt(0);
                        if (nvc.Count > 2 && nvc.GetValues("CD") != null && nvc.GetValues("CD").Length != 0)
                        {
                            this.RequestCode = StringUtil.Decode(nvc.GetValues("CD").ElementAt(0));
                        }
                        else this.RequestCode = null;
                    }
                    else this.SelectedAction = null;
                }
                else this.SelectedTypeCode = null;
                CallAction();
            } else
            {
                if (nvc.Count > 0 && nvc.GetValues("CD") != null && nvc.GetValues("CD").Length != 0)
                {
                    this.RequestCode = StringUtil.Decode(nvc.GetValues("CD").ElementAt(0));
                }
                else this.RequestCode = null;
            }
            
            ShowDiv();
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            DepartmentBO department = new DepartmentBO();
            if (this.RequestCode != null)
            {
                department.DepartmentCD = this.RequestCode;
                if (DeptDesigAndFinInstitutionBusController.IsDepartmentPresent(department))
                {
                    department.DepartmentName = this.txtDeptName.Text;
                    department.DepartmentBankAccount = this.txtBankAcc.Text;
                    bool result = DeptDesigAndFinInstitutionBusController.UpdateDepartment(department);
                    if (result)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Updated Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Not Updated. Some Problem Occurred')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bad Request.')", true);
                }

            } 
            else
            {
                department.DepartmentName = this.txtDeptName.Text;
                department.DepartmentBankAccount = this.txtBankAcc.Text;
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
            this.SelectedTypeCode = null;
            ShowDiv();
        }
        
        protected void lnkAddDept_Click(object sender, EventArgs e)
        {
            this.SelectedTypeCode = "DT";
            ShowDiv();
        }

        protected void lnkAddDesig_Click(object sender, EventArgs e)
        {
            this.SelectedTypeCode = "DS";
            ShowDiv();
        }

        protected void lnkAddFI_Click(object sender, EventArgs e)
        {
            this.SelectedTypeCode = "FI";
            ShowDiv();
        }

        protected void btnDesigAdd_Click(object sender, EventArgs e)
        {
            DesignationBO designation = new DesignationBO();
            if(this.RequestCode != null)
            {
                designation.DesignationCD = this.RequestCode;
                if (DeptDesigAndFinInstitutionBusController.IsDesignationPresent(designation))
                {
                    designation.DesignationName = txtDesigName.Text;
                    bool result = DeptDesigAndFinInstitutionBusController.UpdateDesignation(designation);
                    if (result)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Designation Updated Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Designation Not Updated. Some Problem Occurred')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bad Request.')", true);
                }
            } 
            else
            {
                designation.DesignationName = txtDesigName.Text;
                bool result = DeptDesigAndFinInstitutionBusController.AddDesignaion(designation);
                if (result)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Designation Added Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Designation Not Added. Some Problem Occurred')", true);
                }
            }
            
            this.SelectedTypeCode = null;
            ShowDiv();
        }

        protected void btnDesigCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeptCancel_Click(object sender, EventArgs e)
        {
            this.SelectedTypeCode = null;
            ShowDiv();
        }

        protected void btnDeleteDept_ServerClick(object sender, EventArgs e)
        {
            DepartmentBO department = new DepartmentBO();
            
        }

        protected void btnFinInstAdd_Click(object sender, EventArgs e)
        {
            FinancialInstitutionBO financialInstitution = new FinancialInstitutionBO();
            if(this.RequestCode != null)
            {
                financialInstitution.FinancialInstitutionCD = this.RequestCode;
                if (DeptDesigAndFinInstitutionBusController.IsFinancialInstitutionPresent(financialInstitution))
                {
                    financialInstitution.FinancialInstitutionName = this.txtFinInstName.Text;
                    financialInstitution.FinancialInstitutionAddress = this.txtFinInstAddress.Text;
                    bool result = DeptDesigAndFinInstitutionBusController.UpdateFinancialInstitution(financialInstitution);
                    if (result)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Financial Institution Updated Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Financial Institution Not Updated. Some Problem Occurred')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bad Request.')", true);
                }
            }
            else
            {
                financialInstitution.FinancialInstitutionName = this.txtFinInstName.Text;
                financialInstitution.FinancialInstitutionAddress = this.txtFinInstAddress.Text;
                bool result = DeptDesigAndFinInstitutionBusController.AddFinancialInstitution(financialInstitution);
                if (result)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Financial Institution Added Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Financial Institution Not Added. Some Problem Occurred')", true);
                }
            }
        }
    }
}