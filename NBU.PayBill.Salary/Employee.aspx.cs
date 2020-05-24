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
                this.ddlCategory.DataSource = this.categories;
                this.ddlCategory.DataBind();
                this.ddlDepartment.DataSource = this.departments;
                this.ddlDepartment.DataBind();
                this.ddlDesignation.DataSource = this.designations;
                this.ddlDesignation.DataBind();
                this.ed_ddlCategory.DataSource = this.categories;
                this.ed_ddlCategory.DataBind();
                this.ed_ddlDepartment.DataSource = this.departments;
                this.ed_ddlDepartment.DataBind();
                this.ed_ddlDesignation.DataSource = this.designations;
                this.ed_ddlDesignation.DataBind();
            }
            else
            {

            }
        }

        private void ShowEmpDetails(string EmpID) 
        {
            EmployeeBO employee = EmployeeBusController.GetEmployee(EmpID);
            if (employee.EmpID != null)
            {
                this.ed_Name.Text = employee.EmpName;
                this.ed_UID.Text = employee.EmpAADHAR;
                this.ed_PAN.Text = employee.EmpPAN;
                this.ed_Address.Text = employee.EmpResidentialAddress;
                this.ed_Email.Text = employee.EmpEmailId;
                this.ed_Phone.Text = employee.EmpPersonalContactNo;
                this.ed_Qualification.Text = employee.EmpQualification;
                this.ed_Quarter.Text = employee.EmpQuarterNumber;
                this.ed_IsActive.Text = employee.EmpIsActive == "Y" ? "YES" : "NO";
                this.ed_EmergencyPhone.Text = employee.EmpEmergencyContactNo;
                this.ed_Remarks.Text = employee.EmpRemarks;
                this.ed_DOB.Text = employee.EmpDOB;
                this.ed_DOJ.Text = employee.EmpDOJ;
                this.ed_DOR.Text = employee.EmpDOR;
                this.ed_DNI.Text = employee.EmpDNI;
                this.ed_ddlCaste.ClearSelection();
                try
                {
                    this.ed_ddlCaste.Items.FindByValue(employee.EmpCaste).Selected = true;
                }
                catch (NullReferenceException ex)
                {
                    this.ed_ddlCaste.Items.FindByValue("null").Selected = true;

                }
                this.ed_ddlCategory.ClearSelection();
                try
                {
                    this.ed_ddlCategory.Items.FindByValue(employee.EmpGroup).Selected = true;
                }
                catch (NullReferenceException ex)
                {
                    this.ed_ddlCategory.Items.FindByValue("null").Selected = true;
                }
                this.ed_ddlReligion.ClearSelection();
                try
                {
                    this.ed_ddlReligion.Items.FindByValue(employee.EmpReligion).Selected = true;
                }
                catch (NullReferenceException ex)
                {
                    this.ed_ddlReligion.Items.FindByValue("null").Selected = true;
                }
                this.ed_ddlMStatus.ClearSelection();
                try
                {
                    this.ed_ddlMStatus.Items.FindByValue(employee.EmpMaritalStatus).Selected = true;
                }
                catch (NullReferenceException ex)
                {
                    this.ed_ddlMStatus.Items.FindByValue("null").Selected = true;
                }
                this.ed_ddlDepartment.ClearSelection();
                try
                {
                    this.ed_ddlDepartment.Items.FindByValue(employee.EmpDepartmentCD).Selected = true;
                }
                catch (NullReferenceException ex)
                {
                    this.ed_ddlDepartment.Items.FindByValue("null").Selected = true;
                }
                this.ed_ddlDesignation.ClearSelection();
                try
                {
                    this.ed_ddlDesignation.Items.FindByValue(employee.EmpDesignationCD).Selected = true;
                }
                catch (NullReferenceException ex)
                {
                    this.ed_ddlDesignation.Items.FindByValue("null").Selected = true;
                }
                this.ed_ddlGender.ClearSelection();
                try
                {
                    this.ed_ddlGender.Items.FindByValue(employee.EmpSex).Selected = true;
                }
                catch (NullReferenceException ex)
                {
                    this.ed_ddlGender.Items.FindByValue("null").Selected = true;
                }
                this.ed_ddlBloodGroup.ClearSelection();
                try
                {
                    this.ed_ddlBloodGroup.Items.FindByValue(employee.EmpBloodGroup).Selected = true;
                }
                catch (NullReferenceException ex)
                {
                    this.ed_ddlBloodGroup.Items.FindByValue("null").Selected = true;
                }
                btnAdd.Enabled = false;
            }
            else btnAdd.Enabled = true;
        }

        private void EmpListDemoLoader()
        {
            this.ddlEmployee.DataTextField = "EmpName";
            this.ddlEmployee.DataValueField = "EmpID";
            this.ddlEmployee.DataSource = EmployeeBusController.FilterEmployees(new List<EmployeeItemBO>(employees), employeeFilter);
            this.ddlEmployee.DataBind();
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {

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
            ShowEmpDetails(ddlEmployee.SelectedValue);
        }

        protected void btnLoadEmployees_Click(object sender, EventArgs e)
        {
            EmployeeItemBO filter = new EmployeeItemBO();
            filter.EmpName = string.IsNullOrWhiteSpace(txtEmpName.Text)? null : txtEmpName.Text;
            filter.EmpGroup = ddlCategory.SelectedValue == "null"?null:ddlCategory.SelectedValue;
            filter.EmpDepartmentCD = ddlDepartment.SelectedValue == "null" ? null : ddlDepartment.SelectedValue;
            filter.EmpDesignationCD = ddlDesignation.SelectedValue == "null" ? null : ddlDesignation.SelectedValue;
            employeeFilter = filter;
            EmpListDemoLoader();
        }

        protected void btnEditSelected_Click(object sender, EventArgs e)
        {
            
        }

        protected void ddlEmployee_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if(ddlEmployee.SelectedIndex > 2)
            {
                ddlEmployee.SelectedIndex = ddlEmployee.SelectedIndex - 1;
            }
            else
            {
                ddlEmployee.SelectedIndex = ddlEmployee.Items.Count - 1;
            }
            ShowEmpDetails(ddlEmployee.SelectedValue);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if(ddlEmployee.SelectedIndex >= (ddlEmployee.Items.Count - 1))
            {
                ddlEmployee.SelectedIndex = 1;
            }
            else
            {
                ddlEmployee.SelectedIndex = ddlEmployee.SelectedIndex + 1;
            }
            ShowEmpDetails(ddlEmployee.SelectedValue);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EmployeeBO employee = new EmployeeBO();
            employee.EmpAADHAR = this.ed_UID.Text;
            employee.EmpBloodGroup = this.ed_ddlBloodGroup.SelectedValue;
            employee.EmpCaste = this.ed_ddlCaste.SelectedValue;
            employee.EmpDepartmentCD = this.ed_ddlDepartment.SelectedValue;
            employee.EmpDesignationCD = this.ed_ddlDesignation.SelectedValue;
            employee.EmpDNI = this.ed_DNI.Text;
            employee.EmpDOB = this.ed_DOB.Text;
            employee.EmpDOJ = this.ed_DOJ.Text;
            employee.EmpDOR = this.ed_DOR.Text;
            employee.EmpEmailId = this.ed_Email.Text;
            employee.EmpEmergencyContactNo = this.ed_EmergencyPhone.Text;
            employee.EmpGroup = this.ed_ddlCategory.SelectedValue;
            employee.EmpIsActive = this.ed_IsActive.Text;
            employee.EmpMaritalStatus = this.ed_ddlMStatus.SelectedValue;
            employee.EmpName = this.ed_Name.Text;
            employee.EmpPAN = this.ed_PAN.Text;
            employee.EmpPersonalContactNo = this.ed_Phone.Text;
            employee.EmpQualification = this.ed_Qualification.Text;
            employee.EmpQuarterNumber = this.ed_Quarter.Text;
            employee.EmpReligion = this.ed_ddlReligion.SelectedValue;
            employee.EmpRemarks = this.ed_Remarks.Text;
            employee.EmpResidentialAddress = this.ed_Address.Text;
            employee.EmpSex = this.ed_ddlGender.SelectedValue;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeBO employee = new EmployeeBO();
            employee.EmpAADHAR = this.ed_UID.Text;
            employee.EmpBloodGroup = this.ed_ddlBloodGroup.SelectedValue;
            employee.EmpCaste = this.ed_ddlCaste.SelectedValue;
            employee.EmpDepartmentCD = this.ed_ddlDepartment.SelectedValue;
            employee.EmpDesignationCD = this.ed_ddlDesignation.SelectedValue;
            employee.EmpDNI = this.ed_DNI.Text;
            employee.EmpDOB = this.ed_DOB.Text;
            employee.EmpDOJ = this.ed_DOJ.Text;
            employee.EmpDOR = this.ed_DOR.Text;
            employee.EmpEmailId = this.ed_Email.Text;
            employee.EmpEmergencyContactNo = this.ed_EmergencyPhone.Text;
            employee.EmpGroup = this.ed_ddlCategory.SelectedValue;
            employee.EmpIsActive = this.ed_IsActive.Text;
            employee.EmpMaritalStatus = this.ed_ddlMStatus.SelectedValue;
            employee.EmpName = this.ed_Name.Text;
            employee.EmpPAN = this.ed_PAN.Text;
            employee.EmpPersonalContactNo = this.ed_Phone.Text;
            employee.EmpQualification = this.ed_Qualification.Text;
            employee.EmpQuarterNumber = this.ed_Quarter.Text;
            employee.EmpReligion = this.ed_ddlReligion.SelectedValue;
            employee.EmpRemarks = this.ed_Remarks.Text;
            employee.EmpResidentialAddress = this.ed_Address.Text;
            employee.EmpSex = this.ed_ddlGender.SelectedValue;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}