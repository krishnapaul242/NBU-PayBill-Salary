using NBU.Common.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBU.PayBill.Salary.BL.BusinessObjects;
public class EarningAndDeductionsDAS
{
    private string connectionString = string.Empty;
    DataSet ds = null;
    string query = string.Empty;
    string dbErrMsg = string.Empty;

    private string IncrementOne(string type, string id)
    {
        string EDID = Convert.ToString(Convert.ToInt16(id.Substring(1)) + 1).PadLeft(3, '0');
        return type + EDID;
    }

    public EarningAndDeductionsDAS()
    {
        this.connectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }

    public string GetAllCategories()
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            //Query to get categories. Don't forget to add "as [name]" with field names.
            query = @"SELECT [category_code] as CategoryID
                                ,[category_name] as CategoryName
                          FROM [dbo].[Category]";

            ds = helper.ExecuteDataSet(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
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

    public string GetAllSubCategories(string category = "")
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            //Query to get categories. Don't forget to add "as [name]" with field names.
            if (string.IsNullOrEmpty(category))
            {
                //query to select all subcategories regardless of category
                query = @"";
            }
            else
            {
                //query to select all subcategories of specific category
                query = @"";
            }

            ds = helper.ExecuteDataSet(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
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

    public string GetAllPayScales()
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            //Query to get payscales. Don't forget to add "as [name]" with field names.
            query = @"SELECT [ScaleCD] as ScaleCD
                            ,[EffectiveMonthYear] as EffectiveMonthYear
                            ,[EmpGroup] as EmpGroup
                        FROM [NBU_EmployeeMaster].[dbo].[PayScaleMaster]";

            ds = helper.ExecuteDataSet(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
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

    public string GetPayScale(string payscaleid)
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            query = @"
                        SELECT [ScaleCD] as ScaleCD
                              ,[EffectiveMonthYear] as EffectiveMonthYear
                              ,[EmpGroup] as EmpGroup
                              ,[PayBandNumber] as PayBandNumber
                              ,[StartPay] as StartPay
                              ,[EndPay] as End Pay
                              ,[GradePay] as Grade Pay
                              ,[SpecialPay] as Special Pay
                          FROM [dbo].[PayScaleMaster]
                          WHERE [ScaleCD] LIKE '" + payscaleid + "'";

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

    public int AddPayScale(PayScaleBO ps)
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new earning
            query = @"INSERT INTO [dbo].[PayScaleMaster]
                        ([ScaleCD]
                        ,[EffectiveMonthYear]
                        ,[EmpGroup]
                        ,[PayBandNumber]
                        ,[StartPay]
                        ,[EndPay]
                        ,[GradePay]
                        ,[SpecialPay])
                     VALUES
                           (   " +
                             "SELECT CAST((SELECT TOP 1 ps.[ScaleCD] FROM [dbo].[PayScaleMaster] as ps ORDER BY CAST(ps.[ScaleCD] as int) DESC)+1 as varchar)," +
                             "'" + ps.EffectiveMonthYear + "'," +
                             "'" + ps.EmpGroup + "'," +
                             "'" + ps.PayBandNumber + "'," +
                             "'" + ps.StartPay + "'," +
                             "'" + ps.EndPay + "'," +
                             "'" + ps.GradePay + "'," +
                             "'" + ps.SpecialPay + "',";


            numberOfRowImpacted = helper.ExecuteNonQuery(query);
        }
        catch (Exception ex)
        {
            numberOfRowImpacted = -1;
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
        }
        finally
        {
            helper.CloseConnection();
        }

        return numberOfRowImpacted;
    }

    public int UpdatePayScale(PayScaleBO ps)
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new earning
            query = @"UPDATE [dbo].[PayScaleMaster]
                       SET " +
                          "[EffectiveMonthYear] = '"+ ps.EffectiveMonthYear + "'" +
                          " [EmpGroup] = '" + ps.EmpGroup + "'" +
                          " [PayBandNumber] = '" + ps.PayBandNumber + "'" +
                          " [StartPay] = '" + ps.StartPay + "'" +
                          " [EndPay] = '" + ps.EndPay + "'" +
                          " [GradePay] = '" + ps.GradePay + "'" +
                          " [SpecialPay] = '" + ps.SpecialPay + "'" +
                     " WHERE[ScaleCD] LIKE '"+ ps.ScaleCD + "'";

            numberOfRowImpacted = helper.ExecuteNonQuery(query);
        }
        catch (Exception ex)
        {
            numberOfRowImpacted = -1;
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
        }
        finally
        {
            helper.CloseConnection();
        }

        return numberOfRowImpacted;
    }

    public int DeletePayScale(string id)
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            query = @"
                           DELETE FROM [dbo].[PayScaleMaster]
                                WHERE [ScaleCD] LIKE '"
                            + id + "'";

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

    public string GetAllEarningDeductions(string category = "", string subcategory = "")
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            //Query to get earnings. Don't forget to add "as [name]" with field names.
            if (string.IsNullOrEmpty(category) && string.IsNullOrEmpty(subcategory))
            {
                //query to select all earnings regardless of category or sub categories
                query = @"SELECT [ED_code] as EDid
                                ,[ED_type] as EDtype
                                ,[ED_name] as EDname
                                ,[ED_scale] as EDscale
                                ,[ED_description] as EDdescription
                                ,[ED_isFixedOrVariable] as EDfixOrVar
                                ,[ED_value] as EDvalue
                                ,[ED_eligibilityConditionOperator] as EDeligiblityCondOp
                                ,[ED_eligibiltyConditionValue] as EDeligibilityCondValue
                                ,[ED_maxValue] as EDmaxValue
                                ,[ED_category] as EDcategory
                                ,[ED_subcategory] as EDsubcategory
                                ,[ED_WEF_monthYear] as EDmonthYear
                                ,[ED_forAll] as EDforAll
                            FROM [NBU_EmployeeMaster].[dbo].[EarningsAndDeductionsDescription]";
            }
            else if (string.IsNullOrEmpty(category))
            {
                //query to select all earnings of specific subcategory but regardless of category
                query = @"SELECT [ED_code] as EDid
                                ,[ED_type] as EDtype
                                ,[ED_name] as EDname
                                ,[ED_scale] as EDscale
                                ,[ED_description] as EDdescription
                                ,[ED_isFixedOrVariable] as EDfixOrVar
                                ,[ED_value] as EDvalue
                                ,[ED_eligibilityConditionOperator] as EDeligiblityCondOp
                                ,[ED_eligibiltyConditionValue] as EDeligibilityCondValue
                                ,[ED_maxValue] as EDmaxValue
                                ,[ED_category] as EDcategory
                                ,[ED_subcategory] as EDsubcategory
                                ,[ED_WEF_monthYear] as EDmonthYear
                                ,[ED_forAll] as EDforAll
                            FROM [NBU_EmployeeMaster].[dbo].[EarningsAndDeductionsDescription]
                            WHERE [ED_subcategory] LIKE '{0}'";
                string.Format(query, subcategory);
            }
            else if (string.IsNullOrEmpty(subcategory))
            {
                //query to select all earnings of specific category but regardless of subcategory
                query = @"SELECT [ED_code] as EDid
                                ,[ED_type] as EDtype
                                ,[ED_name] as EDname
                                ,[ED_scale] as EDscale
                                ,[ED_description] as EDdescription
                                ,[ED_isFixedOrVariable] as EDfixOrVar
                                ,[ED_value] as EDvalue
                                ,[ED_eligibilityConditionOperator] as EDeligiblityCondOp
                                ,[ED_eligibiltyConditionValue] as EDeligibilityCondValue
                                ,[ED_maxValue] as EDmaxValue
                                ,[ED_category] as EDcategory
                                ,[ED_subcategory] as EDsubcategory
                                ,[ED_WEF_monthYear] as EDmonthYear
                                ,[ED_forAll] as EDforAll
                            FROM [NBU_EmployeeMaster].[dbo].[EarningsAndDeductionsDescription]
                            WHERE [ED_category] LIKE '{0}'";
                string.Format(query, category);
            }
            else
            {
                //query to select all earnings of specific category and subcategory
                query = @"SELECT [ED_code] as EDid
                                ,[ED_type] as EDtype
                                ,[ED_name] as EDname
                                ,[ED_scale] as EDscale
                                ,[ED_description] as EDdescription
                                ,[ED_isFixedOrVariable] as EDfixOrVar
                                ,[ED_value] as EDvalue
                                ,[ED_eligibilityConditionOperator] as EDeligiblityCondOp
                                ,[ED_eligibiltyConditionValue] as EDeligibilityCondValue
                                ,[ED_maxValue] as EDmaxValue
                                ,[ED_category] as EDcategory
                                ,[ED_subcategory] as EDsubcategory
                                ,[ED_WEF_monthYear] as EDmonthYear
                                ,[ED_forAll] as EDforAll
                            FROM [NBU_EmployeeMaster].[dbo].[EarningsAndDeductionsDescription]
                            WHERE [ED_subcategory] LIKE '{0}' AND [ED_category] LIKE '{1}'";
                string.Format(query, subcategory, category);
            }

            ds = helper.ExecuteDataSet(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
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

    public string GetAllDeductions(string category = "", string subcategory = "")
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            //Query to get deductions. Don't forget to add "as [name]" with field names.
            if (string.IsNullOrEmpty(category))
            {
                //query to select all deductions regardless of category or sub categories
                query = @"";
            }
            else if (string.IsNullOrEmpty(subcategory))
            {
                //query to select all deductions of specific category but regardless of subcategory
                query = @"";
            }
            else
            {
                //query to select all deductions of specific category and subcategory
                query = @"";
            }

            ds = helper.ExecuteDataSet(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
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

    public string GetNextID(string type)
    {
        //type is E by default which means Earning, Setting it to D will get next deduction ID

        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            //Query to get categories. Don't forget to add "as [name]" with field names.
            if (type == "E")
            {
                //query to get next earning id
                query = @"";
            }
            else if (type == "D")
            {
                //query to get next deductions id
                query = @"";
            }
            else
            {
                //handling unknown input for type
            }

            ds = helper.ExecuteDataSet(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
        }
        finally
        {
            helper.CloseConnection();
        }
        //increment 1 in the id by using a private function
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            string id = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
            return IncrementOne(type, id);
        }
        else
            return "DB_ERROR : " + dbErrMsg;
    }

    public string GetEarningDeduction(string EDid)
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            query = @"      SELECT
                                 [ED_code] as EDid
                                ,[ED_type] as EDtype
                                ,[ED_name] as EDname
                                ,[ED_scale] as EDscale
                                ,[ED_description] as EDdescription
                                ,[ED_isFixedOrVariable] as EDfixOrVar
                                ,[ED_value] as EDvalue
                                ,[ED_eligibilityConditionOperator] as EDeligiblityCondOp
                                ,[ED_eligibiltyConditionValue] as EDeligibilityCondValue
                                ,[ED_maxValue] as EDmaxValue
                                ,[ED_category] as EDcategory
                                ,[ED_subcategory] as EDsubcategory
                                ,[ED_WEF_monthYear] as EDmonthYear
                                ,[ED_forAll] as EDforAll
                            FROM [NBU_EmployeeMaster].[dbo].[EarningsAndDeductionsDescription]
                            WHERE [ED_code] LIKE '" + EDid + "'";

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

    public int AddNewEarningDeduction(EarningDeductionBO ed)//arguments are required. Fill them later when BO is created.
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new earning
            query = @"INSERT INTO [dbo].[EarningsAndDeductionsDescription]
                           ([ED_code]
                           ,[ED_type]
                           ,[ED_name]
                           ,[ED_scale]
                           ,[ED_description]
                           ,[ED_isFixedOrVariable]
                           ,[ED_value]
                           ,[ED_eligibilityConditionOperator]
                           ,[ED_eligibiltyConditionValue]
                           ,[ED_maxValue]
                           ,[ED_category]
                           ,[ED_subcategory]
                           ,[ED_WEF_monthYear]
                           ,[ED_forAll])
                     VALUES
                           (   " +
                             "SELECT CAST((SELECT TOP 1 ed.[ED_code] FROM[dbo].[EarningsAndDeductionsDescription] as ed ORDER BY CAST(ed.[ED_code] as int) DESC)+1 as varchar)," +
                             "'" + ed.EDtype + "'," +
                             "'" + ed.EDname + "'," +
                             "'" + ed.EDscale + "'," +
                             "'" + ed.EDdescription + "'," +
                             "'" + ed.EDfixOrVar + "'," +
                             "'" + ed.EDvalue + "'," +
                             "'" + ed.EDeligibilityCondOp + "'," +
                             "'" + ed.EDeligibiltyCondValue + "'," +
                             "'" + ed.EDmaxValue + "'," +
                             "'" + ed.EDcategory + "'," +
                             "'" + ed.EDsubcategory + "'," +
                             "'" + ed.EDmonthYear + "'," +
                             "'" + ed.EDforAll + "')";

            numberOfRowImpacted = helper.ExecuteNonQuery(query);
        }
        catch (Exception ex)
        {
            numberOfRowImpacted = -1;
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
        }
        finally
        {
            helper.CloseConnection();
        }

        return numberOfRowImpacted;
    }

    public int UpdateEarningDeduction(EarningDeductionBO ed)
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new earning
            query = @"UPDATE [dbo].[EarningsAndDeductionsDescription]
                       SET " +
                          ",[ED_name] = '" + ed.EDname + "'" +
                          ",[ED_scale] = '" + ed.EDscale + "'" +
                          ",[ED_description] = '" + ed.EDdescription + "'" +
                          ",[ED_isFixedOrVariable] = '" + ed.EDfixOrVar + "'" +
                          ",[ED_value] = '" + ed.EDvalue + "'" +
                          ",[ED_eligibilityConditionOperator] = '" + ed.EDeligibilityCondOp + "'" +
                          ",[ED_eligibiltyConditionValue] = '" + ed.EDeligibiltyCondValue + "'" +
                          ",[ED_maxValue] = '" + ed.EDmaxValue + "'" +
                          ",[ED_category] = '" + ed.EDcategory + "'" +
                          ",[ED_subcategory] = '" + ed.EDsubcategory + "'" +
                          ",[ED_WEF_monthYear] = '" + ed.EDmonthYear + "'" +
                          ",[ED_forAll] = '" + ed.EDforAll + "'" +
                     "WHERE [ED_code] LIKE '"+ ed.EDid + "'" ;

            numberOfRowImpacted = helper.ExecuteNonQuery(query);
        }
        catch (Exception ex)
        {
            numberOfRowImpacted = -1;
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
        }
        finally
        {
            helper.CloseConnection();
        }

        return numberOfRowImpacted;
    }

    public int DeleteEarningDeduction(string EDid)
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            query = @"
                           DELETE FROM [dbo].[EarningsAndDeductionsDescription]
                                WHERE [ED_code] LIKE '"
                            + EDid + "'";

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

    public int AddNewCategory(CategoryBO categoryBO)//arguments are required. Fill them later when BO is created.
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new category
            query = $@"INSERT INTO [dbo].[Category]
                                        (   [category_code]
                                           ,[category_name]     )
                                VALUES
                                        (   {categoryBO.CategoryID.Trim()}
                                            ,{categoryBO.CategoryName.Trim().ToUpper()})
                                GO";

            numberOfRowImpacted = helper.ExecuteNonQuery(query);
        }
        catch (Exception ex)
        {
            numberOfRowImpacted = -1;
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
        }
        finally
        {
            helper.CloseConnection();
        }

        return numberOfRowImpacted;
    }

    public int UpdateCategory(CategoryBO categoryBO)
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new category
            query = $@"UPDATE [dbo].[Category]
                        SET [category_code] = '{categoryBO.CategoryID.Trim()}'
                            ,[category_name] = '{categoryBO.CategoryName.Trim().ToUpper()}'";

            numberOfRowImpacted = helper.ExecuteNonQuery(query);
        }
        catch (Exception ex)
        {
            numberOfRowImpacted = -1;
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
        }
        finally
        {
            helper.CloseConnection();
        }

        return numberOfRowImpacted;
    }
    public int AddNewSubCategory()//arguments are required. Fill them later when BO is created.
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new subcategory
            query = @"";

            numberOfRowImpacted = helper.ExecuteNonQuery(query);
        }
        catch (Exception ex)
        {
            numberOfRowImpacted = -1;
            Console.WriteLine(ex.Message);
            dbErrMsg = ex.Message;
        }
        finally
        {
            helper.CloseConnection();
        }

        return numberOfRowImpacted;
    }
}
