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

    public string GetAllEarnings(string category = "", string subcategory = "")
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        try
        {
            helper.OpenConnection();
            //Query to get earnings. Don't forget to add "as [name]" with field names.
            if (string.IsNullOrEmpty(category))
            {
                //query to select all earnings regardless of category or sub categories
                query = @"";
            }
            else if (string.IsNullOrEmpty(subcategory))
            {
                //query to select all earnings of specific category but regardless of subcategory
                query = @"";
            }
            else
            {
                //query to select all earnings of specific category and subcategory
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

    public int AddNewEarning()//arguments are required. Fill them later when BO is created.
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new earning
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

    public int AddNewDeduction()//arguments are required. Fill them later when BO is created.
    {
        SQLHelper helper = SQLHelper.GetInstance(this.connectionString);
        int numberOfRowImpacted = 0;
        try
        {
            helper.OpenConnection();
            //query to add new deduction
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
