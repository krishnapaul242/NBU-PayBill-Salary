using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

using Newtonsoft.Json;
using NBU.Common.Helper;
using NBU.EmpWebService.ServiceObjects;

namespace NBU.EmpWebService.BL
{
    public class EmpDataService
    {
        string connectionString;
        string errorMsg;

        public EmpDataService()
        {
            connectionString = ConfigurationManager.AppSettings["EmpMasterConnectionString"];
            errorMsg = string.Empty;
        }

        private string executeQuery(string qry)
        {
            DataSet ds = null;
            SQLHelper helper = SQLHelper.GetInstance(connectionString);

            try
            {
                helper.OpenConnection();
                ds = helper.ExecuteDataSet(qry);
            }
            catch (Exception ex)
            {
                errorMsg = "ERROR : " + ex.Message;
            }
            finally
            {
                helper.CloseConnection();
            }

            if (!string.IsNullOrEmpty(errorMsg))
                return errorMsg;

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
                return "ERROR : No data found";
            else
                return JsonConvert.SerializeObject(ds.Tables[0]);
        }

        public string IsValidUser(string userID, string userPassword, string applicationID)
        {
            string qry = @"
                            SELECT 
                                c.[UserID] as UserId, 
                                a.[EmpID] AS EmpId,
                                a.[EmpName] as Name
                            FROM [EmpMaster] a
	                            LEFT OUTER JOIN [EmpApplicationMapping] b
		                            ON a.[EmpID]=b.[EmpID]
	                            LEFT OUTER JOIN [EmpUser] c	
		                            ON a.[EmpID]=c.[EmpID]                                
                            WHERE 
	                            LTRIM(RTRIM(c.[UserID]))='" + userID + @"'
	                            AND LTRIM(RTRIM(c.[UserPWD]))='" + userPassword + @"'
                                AND b.[ApplicationID]='" + applicationID + @"'";

            return executeQuery(qry);
        }

        public string GetEmpAccessByApplication(string empId, string appId)
        {
            string qry = @"SELECT 
                                 a.[EmpID] as EmpID
                                ,a.[ApplicationID] as AppID
                                ,b.[ApplicationName] as AppName
                                ,a.[AccessTypeCode] as AccessTypeCode
                                ,c.[EmpAccessTypeDesc] as AccessType
                        FROM EmpApplicationMapping a
		                    LEFT OUTER JOIN Application b
			                    ON a.[ApplicationID]=b.[ApplicationID]
		                    LEFT OUTER JOIN EmpAccessType c
			                    ON a.[AccessTypeCode]=c.[EmpAccessTypeCD]
                            WHERE 
	                            a.[EmpID]='" + empId + @"'
                            AND a.[ApplicationID]='" + appId + @"'";

            return executeQuery(qry);
        }

        public string GetEmpDetailByEmpId(string empId)
        {
            string qry = @"SELECT 
                                a.[EmpID] as EmpID    
                                ,a.[EmpName] as Name
                                ,a.[EmpDesignationCD] as DesignationCode
                                ,b.[DesignationName] as DesignationName
                                ,a.[EmpDepartmentCD] as DepartmentCode
                                ,c.[DepartmentName] as DepartmentName
                                ,a.[EmpIsActive] as Status
                                ,a.[EmpSex] as Gender
                                ,a.[EmpPersonalContactNo] as ContactNo
                                ,a.[EmpEmailId] as Email
                                ,a.[EmpResidentialAddress] as Address
                                ,a.[EmpPAN] as PAN
                                ,a.[EmpAADHAR] as Aadhar
                                ,a.[EmpDOB] as DateOfBirth
                                ,a.[EmpDOJ] as Dateofjoining
                                ,a.[EmpBloodGroup] as BloodGroup
                                ,a.[EmpIdentificationMark] as IdentityMark
                            FROM [EmpMaster] a
                                LEFT OUTER JOIN [Designation] b
                                    ON a.[EmpDesignationCD]=b.[DesignationCD]
                                LEFT OUTER JOIN [Department] c
                                    ON a.[EmpDepartmentCD]=c.[DepartmentCD]
                            WHERE 
	                            a.[EmpID]='" + empId + @"'";

            return executeQuery(qry);
        }

        public string GetActiveEmployeeList()
        {
            string qry = @"SELECT 
                                a.[EmpID] as EmpID    
                                ,a.[EmpName] as Name
                                ,a.[EmpDesignationCD] as DesignationCode
                                ,a.[EmpDepartmentCD] as DepartmentCode
                                ,a.[EmpIsActive] as Status
                                ,a.[EmpSex] as Gender
                                ,a.[EmpPersonalContactNo] as ContactNo
                                ,a.[EmpEmailId] as Email
                                ,a.[EmpResidentialAddress] as Address
                                ,a.[EmpPAN] as Pan
                            FROM [EmpMaster] a
	                            LEFT OUTER JOIN [Designation] b
		                            ON a.[EmpDesignationCD]=b.[DesignationCD]
	                            LEFT OUTER JOIN [EmpUser] c	
		                            ON a.[EmpID]=c.[EmpID]
                                LEFT OUTER JOIN [Department] d
                                    ON a.[EmpDepartmentCD]=d.[DepartmentCD]
                            WHERE 
	                            a.[EmpIsActive]='Y'
                            order by a.[EmpName]";

            return executeQuery(qry);
        }

        public string GetEmpDependentListByEmpID(string empId)
        {
            string qry = @"SELECT 
                             [DepCode] as DepCode
                            ,[EmpDepName] as Name
                            ,[EmpDepRelation] as Relation
                            ,[EmpDepDOB] as DateOfBirth
                            ,[EmpDepAadhar] as Aadhar
                            ,[EmpDepIdentyMark] as IdentityMark
                            ,[EmpDepBloodGroup] as BloodGroup
                            ,[EmpDepPhotoURL] as ImgName
                            ,[EmpDepRemarks] as Remarks
                          FROM [EmpDependant]
                          WHERE [EmpID]='" + empId + @"'";

            return executeQuery(qry);
        }

        public string GetEmployerDetail()
        {
            string qry = @"SELECT  [Name] as EmployerName
                                  ,[Address] as EmployerAddress
                                  ,[ContactNo] as EmployerContactNo
                                  ,[EmailId] as EmployerEmail
                                  ,[TAN] as EmployerTAN
                                  ,[PAN] as EmployerPAN
                            FROM [Employer]";

            return executeQuery(qry);
        
        }
    }
}
