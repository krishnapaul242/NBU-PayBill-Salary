using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NBU.Common.Helper;
using NBU.EmpWebService.ServiceObjects;
using Newtonsoft.Json;

namespace NBU.EmpWebService.BL
{  
    public static class EmpBusinessController
    {
        static string errorMsg = string.Empty;

        public static string IsValidUser(string userID, string userPassword, string applicationID)
        {
            EmpDataService eds = new EmpDataService();
            string userJson = eds.IsValidUser(StringUtil.Decode(userID).Trim(), userPassword.Trim(), StringUtil.Decode(applicationID).Trim());

            UserSTO user = new UserSTO();
            errorMsg = string.Empty;

            if (string.IsNullOrWhiteSpace(userJson))
                errorMsg = "ERROR : No data found";
            else
            {
                try
                {
                    user = JsonConvert.DeserializeObject<List<UserSTO>>(userJson)[0];
                }
                catch (Exception ex)
                {
                    errorMsg = "ERROR : " + ex.Message;
                }
            }

            if (string.IsNullOrEmpty(errorMsg))
                user.BussinessErrorMsg = string.Empty;
            else
                user.BussinessErrorMsg = errorMsg;

            return StringUtil.SerializeObjectToXML(user, typeof(UserSTO));
        }

        public static string GetEmpAccessByApplication(string empId, string appId)
        {
            EmpDataService eds = new EmpDataService();
            string empAppAccJson = eds.GetEmpAccessByApplication(StringUtil.Decode(empId).Trim(), StringUtil.Decode(appId).Trim());

            EmployeeApplicationAccessSTO empAppAccess = new EmployeeApplicationAccessSTO();
            errorMsg = string.Empty;

            if (string.IsNullOrWhiteSpace(empAppAccJson))
                errorMsg = "ERROR : No data found";
            else
            {
                try
                {
                    empAppAccess = JsonConvert.DeserializeObject<List<EmployeeApplicationAccessSTO>>(empAppAccJson)[0];
                }
                catch (Exception ex)
                {
                    errorMsg = "ERROR : " + ex.Message;
                }
            }

            if (string.IsNullOrEmpty(errorMsg))
                empAppAccess.BussinessErrorMsg = string.Empty;
            else            
                empAppAccess.BussinessErrorMsg = errorMsg;

            return StringUtil.SerializeObjectToXML(empAppAccess, typeof(EmployeeApplicationAccessSTO));
        }

        public static string GetEmpDetailByEmpId(string empId)
        {
            EmpDataService eds = new EmpDataService();
            string employeeJson = eds.GetEmpDetailByEmpId(StringUtil.Decode(empId).Trim());

            EmployeeSTO employee = new EmployeeSTO();
            errorMsg = string.Empty;

            if (string.IsNullOrWhiteSpace(employeeJson))
                errorMsg = "ERROR : No data found";
            else
            {
                try
                {
                    employee = JsonConvert.DeserializeObject<List<EmployeeSTO>>(employeeJson)[0];
                }
                catch (Exception ex)
                {
                    errorMsg = "ERROR : " + ex.Message;
                }
            }

            if (string.IsNullOrEmpty(errorMsg))
                employee.BussinessErrorMsg = string.Empty;
            else
                employee.BussinessErrorMsg = errorMsg;

            return StringUtil.SerializeObjectToXML(employee, typeof(EmployeeSTO));
        }

        public static string GetActiveEmployeeList()
        {
            EmpDataService eds = new EmpDataService();
            string employeeListJson = eds.GetActiveEmployeeList();

            List<EmployeeSTO> employeeList = new List<EmployeeSTO>();
            errorMsg = string.Empty;

            if (string.IsNullOrWhiteSpace(employeeListJson))
                errorMsg = "ERROR : No data found";
            else
            {
                try
                {
                    employeeList = JsonConvert.DeserializeObject<List<EmployeeSTO>>(employeeListJson);
                }
                catch (Exception ex)
                {
                    errorMsg = "ERROR : " + ex.Message;
                }
            }

            string strXML = StringUtil.SerializeObjectToXML(employeeList, typeof(List<EmployeeSTO>));
            return strXML;
        }

        public static string GetEmpDependentListByEmpID(string empId)
        {
            EmpDataService eds = new EmpDataService();
            string dependentListJson = eds.GetEmpDependentListByEmpID(StringUtil.Decode(empId).Trim());

            List<EmployeeDependent> dependentList = new List<EmployeeDependent>();

            errorMsg = string.Empty;

            if (string.IsNullOrWhiteSpace(dependentListJson))
                errorMsg = "ERROR : No data found";
            else
            {
                try
                {
                    dependentList = JsonConvert.DeserializeObject<List<EmployeeDependent>>(dependentListJson);
                }
                catch (Exception ex)
                {
                    errorMsg = "ERROR : " + ex.Message;
                }
            }

            string strXML = StringUtil.SerializeObjectToXML(dependentList, typeof(List<EmployeeDependent>));
            return strXML;
        }

        public static string GetEmployerDetail()
        {
            EmpDataService eds = new EmpDataService();
            string employerJson = eds.GetEmployerDetail();
            Employer employer = new Employer();
            errorMsg = string.Empty;

            if (string.IsNullOrWhiteSpace(employerJson))
                errorMsg = "ERROR : No data found";
            else
            {
                try
                {
                    employer = JsonConvert.DeserializeObject<List<Employer>>(employerJson)[0];
                }
                catch (Exception ex)
                {
                    errorMsg = "ERROR : " + ex.Message;
                }
            }

            if (string.IsNullOrEmpty(errorMsg))
                employer.BussinessErrorMsg = string.Empty;
            else
                employer.BussinessErrorMsg = errorMsg;

            return StringUtil.SerializeObjectToXML(employer, typeof(Employer));
        }
    }
}
