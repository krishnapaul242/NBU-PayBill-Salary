using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using NBU.EmpWebService.BL;
namespace NBU.EmpWebService.Service
{
    public class EmpWebService : IEmpWebService
    {
        public string IsValidUser(string userID, string userPassword, string applicationID)
        {
            return EmpBusinessController.IsValidUser(userID, userPassword, applicationID);
        }

        public string GetEmpAccessByApplication(string empId, string appId)
        {
            return EmpBusinessController.GetEmpAccessByApplication(empId, appId);
        }

        public string GetEmpDetailByEmpId(string empId)
        {
            return EmpBusinessController.GetEmpDetailByEmpId(empId);
        }

        public string GetActiveEmployeeList()
        {
            return EmpBusinessController.GetActiveEmployeeList();
        }

        public string GetEmpDependentListByEmpID(string empId)
        {
            return EmpBusinessController.GetEmpDependentListByEmpID(empId);
        }

        public string  GetEmployerDetail()
        {
        return EmpBusinessController.GetEmployerDetail();
        }
    }
}
