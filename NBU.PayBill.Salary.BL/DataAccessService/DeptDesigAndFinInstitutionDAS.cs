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
    public class DeptDesigAndFinInstitutionDAS
    {
        /*
         * All functions to be written here.
         * Add department +
         * Add designation +
         * Add financial institution +
         * Edit department +
         * Edit designation +
         * Edit financial institution +
         * Get All departments +
         * Get All designation +
         * Get All financial institution +
         */

        private string connectionString = string.Empty;
        DataSet ds = null;
        string query = string.Empty;
        string dbErrMsg = string.Empty;

        /// <summary>
        /// A basic constructor function for this Data Access Service class.
        /// </summary>
        public DeptDesigAndFinInstitutionDAS()
        {
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        /// <summary>
        /// AddDepartment() is a function which takes DepartmentBO as parameter and insert its data in database. 
        /// It returns the number of rows affected by the operation which is 1 in success and 0 in failure.
        /// </summary>
        /// <param name="departmentBO">An object of DepartmentBO class which is used to hold the name and id of department.</param>
        /// <returns>int</returns>
        public int AddDepartment(DepartmentBO departmentBO)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                           INSERT INTO [dbo].[DepartmentMaster]
                                ([DepartmentName])
                            VALUES ('"
                                + departmentBO.DepartmentName +
                          @"')";

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

        /// <summary>
        /// UpdateDepartment() is a function which takes DepartmentBO as parameter and update its data in database.
        /// It returns the number of rows affected by the operation which is 1 in success and 0 in failure.
        /// </summary>
        /// <param name="departmentBO">An object of DepartmentBO class which is used to hold the name and id of department.</param>
        /// <returns>int</returns>
        public int UpdateDepartment(DepartmentBO departmentBO)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                           UPDATE [dbo].[DepartmentMaster]
                           SET [DepartmentName] = '" + departmentBO.DepartmentName + @"'
                           WHERE [DepartmentID] = '" + departmentBO.DepartmentCD   + @"')";

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

        /// <summary>
        /// GetAllDepartments() is a function to fetch all department names and id from the database. 
        /// It returns a json string which hold all data.
        /// It has to be deserialized using the StringUtil class.
        /// </summary>
        /// <returns>string</returns>
        public string GetAllDepartments()
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            try
            {
                helper.OpenConnection();
                query = @"
                        SELECT [DepartmentID] as DepartmentCD,[DepartmentName] as DepartmentName
                        FROM [dbo].[DepartmentMaster]";

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

        /// <summary>
        /// AddDesignation() is a function which takes DesignationBO as parameter and insert its data in database. 
        /// It returns the number of rows affected by the operation which is 1 in success and 0 in failure.
        /// </summary>
        /// <param name="designationBO">An object of DesignationBO class which is used to hold the name and id of designation.</param>
        /// <returns>int</returns>
        public int AddDesignation(DesignationBO designationBO)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                           INSERT INTO [dbo].[DesignationMaster]
                                ([DesignationName])
                            VALUES ('"
                                + designationBO.DesignationName +
                          @"')";

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

        /// <summary>
        /// UpdateDesignation() is a function which takes DesignationBO as parameter and update its data in database.
        /// It returns the number of rows affected by the operation which is 1 in success and 0 in failure.
        /// </summary>
        /// <param name="designationBO">An object of DesignationBO class which is used to hold the name and id of designation.</param>
        /// <returns>int</returns>
        public int UpdateDesignation(DesignationBO designationBO)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                           UPDATE [dbo].[DesignationMaster]
                           SET [DesignationName] = '" + designationBO.DesignationName + @"'
                           WHERE [DesignationID] = '" + designationBO.DesignationCD + @"')";

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

        /// <summary>
        /// GetAllDesignations() is a function to fetch all designation names and id from the database. 
        /// It returns a json string which hold all data.
        /// It has to be deserialized using the StringUtil class.
        /// </summary>
        /// <returns>string</returns>
        public string GetAllDesignations()
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            try
            {
                helper.OpenConnection();
                query = @"
                        SELECT [DesignationID] as DesignationCD,[DepartmentName] as DesignationName
                        FROM [dbo].[DesignationMaster]";

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="financialInstitutionBO"></param>
        /// <returns>int</returns>
        public int AddFinancialInstitution(FinancialInstitutionBO financialInstitutionBO)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                           INSERT INTO [dbo].[FinancialInstitutionMaster]
                                ([FinancialInstitutionName],[FinancialInstitutionAddress] )
                            VALUES ('"
                                + financialInstitutionBO.FinancialInstitutionName + @"', '" 
                                + financialInstitutionBO.FinancialInstitutionAddress +
                          @"')";

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

        /// <summary>
        /// Update FinancialInstituion() is a function which takes FinancialInstituionBO as parameter and update its data in database.
        /// It returns the number of rows affected by the operation which is 1 in success and 0 in failure.
        /// </summary>
        /// <param name="financialInstitutionBO">An object of FinancialInstitutionBO class which is used to hold the name and id of Financia lInstitution.</param>
        /// <returns>int</returns>
        public int UpdateFinancialInstitution(FinancialInstitutionBO financialInstitutionBO)
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            int numberOfRowImpacted = 0;
            try
            {
                helper.OpenConnection();
                query = @"
                           UPDATE [dbo].[FinancialInstitutionMaster]
                           SET [FinancialInstitutionName] = '" + financialInstitutionBO.FinancialInstitutionName + @"',
                               [FinancialInstitutionAddress = '" + financialInstitutionBO.FinancialInstitutionAddress + @"'
                           WHERE [FinancialInstitutionID] = '" + financialInstitutionBO.FinancialInstitutionCD + @"')";

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

        /// <summary>
        /// GetAllFinancialInstitutions() is a function to fetch all financial insttutions names and id from the database. 
        /// It returns a json string which hold all data.
        /// It has to be deserialized using the StringUtil class.
        /// </summary>
        /// <returns>string</returns>
        public string GetAllFinancialInstitutions()
        {
            SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
            try
            {
                helper.OpenConnection();
                query = @"
                        SELECT [FinancialInstitutionID] as FinancialInstitutionCD
                                ,[FinancialInstitutionName] as FinancialInstitutionName
                                ,[FinancialInstitutionAddress] as FinancialInstitutionAddress
                        FROM [dbo].[FinancialInstitutionMaster]";

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
