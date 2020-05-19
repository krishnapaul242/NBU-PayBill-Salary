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

        
    }
}
