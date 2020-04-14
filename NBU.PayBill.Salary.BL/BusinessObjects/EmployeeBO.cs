using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.PayBill.Salary.BL.BusinessObjects
{
    [Serializable]
    public class EmployeeBO
    {
        private string empID;
        private string empAADHAR;
        private string empBloodGroup;
        private string empDepartmentCD;
        private string empDesignationCD;
        private string empDOB;
        private string empDOJ;
        private string empEmailId;
        private string empEmergencyContactNo;
        private string empGroup;
        private string empIdentificationMark;
        private string empIsActive;
        private string empName;
        private string empPAN;
        private string empPersonalContactNo;
        private string empRemarks;
        private string empResidentialAddress;
        private string empSex;
        private string empCaste;
        private string empDOR;
        private string empDNI;
        private string empMaritalStatus;
        private string empQuarterNumber;
        private string empQualification;
        private string empReligion;

        public string EmpID { get => empID; set => empID = value; }
        public string EmpAADHAR { get => empAADHAR; set => empAADHAR = value; }
        public string EmpBloodGroup { get => empBloodGroup; set => empBloodGroup = value; }
        public string EmpDepartmentCD { get => empDepartmentCD; set => empDepartmentCD = value; }
        public string EmpDesignationCD { get => empDesignationCD; set => empDesignationCD = value; }
        public string EmpDOB { get => empDOB; set => empDOB = value; }
        public string EmpDOJ { get => empDOJ; set => empDOJ = value; }
        public string EmpEmailId { get => empEmailId; set => empEmailId = value; }
        public string EmpEmergencyContactNo { get => empEmergencyContactNo; set => empEmergencyContactNo = value; }
        public string EmpGroup { get => empGroup; set => empGroup = value; }
        public string EmpIdentificationMark { get => empIdentificationMark; set => empIdentificationMark = value; }
        public string EmpIsActive { get => empIsActive; set => empIsActive = value; }
        public string EmpName { get => empName; set => empName = value; }
        public string EmpPAN { get => empPAN; set => empPAN = value; }
        public string EmpPersonalContactNo { get => empPersonalContactNo; set => empPersonalContactNo = value; }
        public string EmpRemarks { get => empRemarks; set => empRemarks = value; }
        public string EmpResidentialAddress { get => empResidentialAddress; set => empResidentialAddress = value; }
        public string EmpSex { get => empSex; set => empSex = value; }
        public string EmpCaste { get => empCaste; set => empCaste = value; }
        public string EmpDOR { get => empDOR; set => empDOR = value; }
        public string EmpDNI { get => empDNI; set => empDNI = value; }
        public string EmpMaritalStatus { get => empMaritalStatus; set => empMaritalStatus = value; }
        public string EmpQuarterNumber { get => empQuarterNumber; set => empQuarterNumber = value; }
        public string EmpQualification { get => empQualification; set => empQualification = value; }
        public string EmpReligion { get => empReligion; set => empReligion = value; }
    }
}
