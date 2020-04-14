using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBU.EmpWebService.ServiceObjects
{
    [Serializable]
    public class EmployeeSTO : BaseSTO
    {
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string DesignationCode { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeGroup { get; set; }
        public string GazettedStatus { get; set; }
        public string Contractual { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PAN { get; set; }
        public string Aadhar { get; set; }
        public string FatherName { get; set; }
        public string DateOfBirth { get; set; }
        public string Dateofjoining { get; set; }
        
    }

    [Serializable]
    public class EmployeeDependent
    {
        public string DepCode { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public string DateOfBirth { get; set; }
    }

    [Serializable]
    public class UserAppAccess
    {
        public string EmpID { get; set; }
        public string AppID { get; set; }
        public string AppName { get; set; }
        public string AccessType { get; set; }
        public string AccessTypeCode { get; set; }
    }
}