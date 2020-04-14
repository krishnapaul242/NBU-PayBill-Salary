using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBU.PayBill.Salary.BL.BusinessObjects;
using NBU.PayBill.Salary.BL.DataAccessService;
using NBU.Common.Helper;

namespace NBU.PayBill.Salary.BL.BusController
{
    public static class DeptDesigAndFinInstitutionBusController
    {
        public static bool AddDepartment(DepartmentBO departmentBO)
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            int numberOfRowImpacted = 0;
            numberOfRowImpacted = deptDesigAndFinInstitutionDAS.AddDepartment(departmentBO);
            return numberOfRowImpacted > 0;
        }

        public static bool AddDesignaion(DesignationBO designationBO)
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            int numberOfRowImpacted = 0;
            numberOfRowImpacted = deptDesigAndFinInstitutionDAS.AddDesignation(designationBO);
            return numberOfRowImpacted > 0;
        }

        public static bool AddFinancialInstitution(FinancialInstitutionBO financialInstitutionBO)
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            int numberOfRowImpacted = 0;
            numberOfRowImpacted = deptDesigAndFinInstitutionDAS.AddFinancialInstitution(financialInstitutionBO);
            return numberOfRowImpacted > 0;
        }

        public static bool UpdateDepartment(DepartmentBO departmentBO)
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            int numberOfRowImpacted = 0;
            numberOfRowImpacted = deptDesigAndFinInstitutionDAS.UpdateDepartment(departmentBO);
            return numberOfRowImpacted > 0;
        }

        public static bool UpdateDesignation(DesignationBO designationBO)
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            int numberOfRowImpacted = 0;
            numberOfRowImpacted = deptDesigAndFinInstitutionDAS.UpdateDesignation(designationBO);
            return numberOfRowImpacted > 0;
        }

        public static bool UpdateFinancialInstitution(FinancialInstitutionBO financialInstitutionBO)
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            int numberOfRowImpacted = 0;
            numberOfRowImpacted = deptDesigAndFinInstitutionDAS.UpdateFinancialInstitution(financialInstitutionBO);
            return numberOfRowImpacted > 0;
        }

        public static List<DepartmentBO> GetDepartmentBOs()
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            string jsondata = deptDesigAndFinInstitutionDAS.GetAllDepartments();
            List<DepartmentBO> departmentBOs = new List<DepartmentBO>();
            if (!jsondata.StartsWith("DB_ERROR"))
                departmentBOs = StringUtil.DeserializeObjectFromJSON<List<DepartmentBO>>(jsondata);
            return departmentBOs;
        }

        public static List<DesignationBO> GetDesignationBOs()
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            string jsondata = deptDesigAndFinInstitutionDAS.GetAllDesignations();
            List<DesignationBO> designationBOs = new List<DesignationBO>();
            if (!jsondata.StartsWith("DB_ERROR"))
                designationBOs = StringUtil.DeserializeObjectFromJSON<List<DesignationBO>>(jsondata);
            return designationBOs;
        }

        public static List<FinancialInstitutionBO> GetFinancialInstitutionBOs()
        {
            DeptDesigAndFinInstitutionDAS deptDesigAndFinInstitutionDAS = new DeptDesigAndFinInstitutionDAS();
            string jsondata = deptDesigAndFinInstitutionDAS.GetAllFinancialInstitutions();
            List<FinancialInstitutionBO> financialInstitutionBOs = new List<FinancialInstitutionBO>();
            if (!jsondata.StartsWith("DB_ERROR"))
                financialInstitutionBOs = StringUtil.DeserializeObjectFromJSON<List<FinancialInstitutionBO>>(jsondata);
            return financialInstitutionBOs;
        }
    }
}
