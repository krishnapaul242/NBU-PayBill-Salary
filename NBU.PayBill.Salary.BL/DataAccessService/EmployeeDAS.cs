using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBU.Common.Helper;
using NBU.PayBill.Salary.BL.BusinessObjects;

namespace NBU.PayBill.Salary.BL.DataAccessService
{
    public class EmployeeDAS
    {
        /* All functions to be written here.
         * Get All Employees
         * Get One Employee
         */
        private string connectionString = string.Empty;
        DataSet ds = null;
        string query = string.Empty;
        string dbErrMsg = string.Empty;

        public EmployeeDAS()
        {
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string GetAllEmployees()
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            try
            {
                helper.OpenConnection();
                query = @"
                        SELECT   [EmpID] as EmpID
                                ,[EmpDepartmentCD] as EmpDepartmentCD
                                ,[EmpDesignationCD] as EmpDesignationCD
                                ,[EmpName] as EmpName
                                ,[EmpGroup] as EmpGroup
                        FROM [NBU_EmployeeMaster].[dbo].[EmpMaster]
                        ORDER BY CAST(EmpID as int)";

                ds = helper.ExecuteDataSet(query);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                helper.CloseConnection();
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                return StringUtil.SerializeObjectToJSON(ds.Tables[0]);
            else
                return "DB_ERROR : " + dbErrMsg;
        }

        public string GetEmployeeByID(string EmpID)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            try
            {
                helper.OpenConnection();
                query = @"
                        SELECT
                             [EmpID] as EmpID
                            ,[EmpAADHAR] as EmpAADHAR
                            ,[EmpBloodGroup] as EmpBloodGroup
                            ,[EmpDepartmentCD] as EmpDepartmentCD
                            ,[EmpDesignationCD] as EmpDesignationCD
                            ,[EmpDOB] as EmpDOB
                            ,[EmpDOJ] as EmpDOJ
                            ,[EmpEmailId] as EmpEmailId
                            ,[EmpEmergencyContactNo] as EmpEmergencyContactNo
                            ,[EmpGroup] as EmpGroup
                            ,[EmpIdentificationMark] as EmpIdentificationMark
                            ,[EmpIsActive] as EmpIsActive
                            ,[EmpName] as EmpName
                            ,[EmpPAN] as EmpPAN
                            ,[EmpPersonalContactNo] as EmpPersonalContactNo
                            ,[EmpRemarks] as EmpRemarks
                            ,[EmpResidentialAddress] as EmpResidentialAddress
                            ,[EmpSex] as EmpSex
                            ,[EmpCaste] as EmpCaste
                            ,[EmpDOR] as EmpDOR
                            ,[EmpDNI] as EmpDNI
                            ,[EmpMaritalStatus] as EmpMaritalStatus
                            ,[EmpQuarterNumber] as EmpQuarterNumber
                            ,[EmpQualification] as EmpQualification
                            ,[EmpReligion] as EmpReligion
                        FROM [NBU_EmployeeMaster].[dbo].[EmpMaster]
                        WHERE [EmpID] LIKE '" + EmpID +
                        "'";
                ds = helper.ExecuteDataSet(query);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                helper.CloseConnection();
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                return StringUtil.SerializeObjectToJSON(ds.Tables[0]);
            else
                return "DB_ERROR : " + dbErrMsg;
        }

        public int UpdateEmployee(EmployeeBO employee)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                           UPDATE [dbo].[EmpMaster]
                           SET  [EmpName] = '" + employee.EmpName + @"'
                                ,[EmpAADHAR] = '" + employee.EmpAADHAR + @"'
                                ,[EmpBloodGroup] = '" + employee.EmpBloodGroup + @"'
                                ,[EmpDepartmentCD] = '" + employee.EmpDepartmentCD + @"'
                                ,[EmpDesignationCD] = '" + employee.EmpDesignationCD + @"'
                                ,[EmpDOB] = '" + employee.EmpDOB + @"'
                                ,[EmpDOJ] = '" + employee.EmpDOJ + @"'
                                ,[EmpEmailId] = '" + employee.EmpEmailId + @"'
                                ,[EmpEmergencyContactNo] = '" + employee.EmpEmergencyContactNo + @"'
                                ,[EmpGroup] = '" + employee.EmpGroup + @"'
                                ,[EmpIsActive] = '" + employee.EmpIsActive + @"'
                                ,[EmpPAN] = '" + employee.EmpPAN + @"'
                                ,[EmpPersonalContactNo] = '" + employee.EmpPersonalContactNo + @"'
                                ,[EmpRemarks] = '" + employee.EmpRemarks + @"'
                                ,[EmpResidentialAddress] = '" + employee.EmpResidentialAddress + @"'
                                ,[EmpSex] = '" + employee.EmpSex + @"'
                                ,[EmpCaste] = '" + employee.EmpCaste + @"'
                                ,[EmpDOR] = '" + employee.EmpDOR + @"'
                                ,[EmpDNI] = '" + employee.EmpDNI + @"'
                                ,[EmpMaritalStatus] = '" + employee.EmpMaritalStatus + @"'
                                ,[EmpQuarterNumber] = '" + employee.EmpQuarterNumber + @"'
                                ,[EmpQualification] = '" + employee.EmpQualification + @"'
                                ,[EmpReligion] = '" + employee.EmpReligion + @"'
                                ,[UpdateTMS] = '" + DateTime.Now.ToString() + @"'
                                ,[UpdateUser] = 'testing'
                           WHERE [EmpID] LIKE '" + employee.EmpID + "'";

                numberOfRowImpacted = helper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                numberOfRowImpacted = -1;
            }
            finally
            {
                helper.CloseConnection();
            }

            return numberOfRowImpacted;
        }

        public int AddEmployee(EmployeeBO employee)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                          INSERT INTO [dbo].[EmpMaster]
                                ([EmpID]
                                ,[EmpAADHAR]
                                ,[EmpBloodGroup]
                                ,[EmpDepartmentCD]
                                ,[EmpDesignationCD]
                                ,[EmpDOB]
                                ,[EmpDOJ]
                                ,[EmpEmailId]
                                ,[EmpEmergencyContactNo]
                                ,[EmpGroup]
                                ,[EmpIsActive]
                                ,[EmpName]
                                ,[EmpPAN]
                                ,[EmpPersonalContactNo]
                                ,[EmpRemarks]
                                ,[EmpResidentialAddress]
                                ,[EmpSex]
                                ,[EmpCaste]
                                ,[EmpDOR]
                                ,[EmpDNI]
                                ,[EmpMaritalStatus]
                                ,[EmpQuarterNumber]
                                ,[EmpQualification]
                                ,[EmpReligion]
                                ,[UpdateTMS]
                                ,[UpdateUser])
						VALUES
								(CAST((SELECT TOP 1 e.[EmpID] FROM [dbo].[EmpMaster] as e ORDER BY CAST(e.[EmpID] as int) DESC)+1 as varchar)
                                , '" + employee.EmpAADHAR + @"'
                                , '" + employee.EmpBloodGroup + @"'
                                , '" + employee.EmpDepartmentCD + @"'
                                , '" + employee.EmpDesignationCD + @"'
                                , '" + employee.EmpDOB + @"'
                                , '" + employee.EmpDOJ + @"'
                                , '" + employee.EmpEmailId + @"'
                                , '" + employee.EmpEmergencyContactNo + @"'
                                , '" + employee.EmpGroup + @"'
                                , '" + employee.EmpIsActive + @"'
                                , '" + employee.EmpName + @"'
                                , '" + employee.EmpPAN + @"'
                                , '" + employee.EmpPersonalContactNo + @"'
                                , '" + employee.EmpRemarks + @"'
                                , '" + employee.EmpResidentialAddress + @"'
                                , '" + employee.EmpSex + @"'
                                , '" + employee.EmpCaste + @"'
                                , '" + employee.EmpDOR + @"'
                                , '" + employee.EmpDNI + @"'
                                , '" + employee.EmpMaritalStatus + @"'
                                , '" + employee.EmpQuarterNumber + @"'
                                , '" + employee.EmpQualification + @"'
                                , '" + employee.EmpReligion + @"'
                                , '" + DateTime.Now.ToString() + @"'
                                , 'testing')";

                numberOfRowImpacted = helper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                numberOfRowImpacted = -1;
            }
            finally
            {
                helper.CloseConnection();
            }

            return numberOfRowImpacted;
        }

        public int DeleteEmployee(string EmpID)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                           DELETE FROM [dbo].[EmpMaster]
                                WHERE [EmpID] LIKE '"
                                + EmpID + "'";

                numberOfRowImpacted = helper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                numberOfRowImpacted = -1;
            }
            finally
            {
                helper.CloseConnection();
            }

            return numberOfRowImpacted;
        }
    }
}
