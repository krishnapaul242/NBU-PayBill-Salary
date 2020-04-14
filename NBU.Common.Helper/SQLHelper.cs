using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace NBU.Common.Helper
{
    /// <summary>
    /// Singleton database connection provider class.
    /// </summary>
    public sealed class SQLHelper
    {

        private static SQLHelper helperObject = null;
        private static Mutex mutexObject = new Mutex();
        private string connectionString = string.Empty;
        private SqlConnection connection;

        /// <summary>
        /// Private constructor. Initializes the following things :
        /// 1. A connection-string with details database connection details.
        ///    The connection-string is fetched from the App.config/Web.config file of the
        ///    startup-project.                
        /// </summary>
        private SQLHelper()
        {
            //connectionString = Decode(ConfigurationManager.AppSettings["ConnectionString"]);
            //connectionString = ConfigurationManager.AppSettings["EmployeeConnectionString"];
        }

        private SQLHelper(string conStr)
        {
            connectionString = conStr;
        }


        /// <summary>
        /// Thread-safe static method GetInstance creates exactly one instance of the
        /// SQLHelper class. Upon consecutive calls to this method, that only created 
        /// instance is returned.
        /// </summary>
        /// <returns></returns>

        public static SQLHelper GetInstance()
        {
            return GetInstance(string.Empty);
        }

        public static SQLHelper GetInstance(string conStr)
        {
            try
            {
                mutexObject.WaitOne();

                if (helperObject == null || !helperObject.connectionString.Equals(conStr))
                {
                    if (String.IsNullOrEmpty(conStr))
                        helperObject = new SQLHelper();
                    else
                        helperObject = new SQLHelper(conStr);
                }
            }
            finally
            {
                mutexObject.ReleaseMutex();
            }

            return helperObject;
        }

        /// <summary>
        /// Closes the connection and release the connection object.
        /// </summary>
        public void OpenConnection()
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        /// <summary>
        /// Closes the connection and release the connection object.
        /// </summary>
        public void CloseConnection()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
                connection.Close();
            connection = null;
        }

        private string Decode(string cipherText)
        {
            return System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(cipherText));
        }
        
        /// <summary>
        /// Method used to execute a raw sql dml query statement.
        /// </summary>
        /// <param name="dmlStatement">The dml query statement string.</param>
        /// <returns>Returns the number of rows affected by the executed query.</returns>
        /// <exception cref="System.Exception">
        /// Thrown when there is any error in a database related operation.
        /// </exception>
        public int ExecuteNonQuery(string dmlStatement)
        {
            int rowsAffected = -1;
            SqlConnection connectionObject = null;

            try
            {
                connectionObject = new SqlConnection(connectionString);
                SqlCommand commandObject = new SqlCommand(
                    dmlStatement, connectionObject);

                connectionObject.Open();
                rowsAffected = commandObject.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log Error

                throw ex;
            }
            finally
            {
                if (connectionObject != null)
                    connectionObject.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Method used to execute a stored procedure.
        /// </summary>
        /// <param name="spName">Stored procedure name.</param>
        /// <returns>
        /// Returns the number of rows affected by the executed stored procedure.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown when there is any error in a database related operation.
        /// </exception>
        public int ExecuteSP(string spName)
        {
            int rowsAffected = -1;
            SqlConnection connectionObject = null;

            try
            {
                connectionObject = new SqlConnection(connectionString);
                SqlCommand commandObject = new SqlCommand(
                    spName, connectionObject);

                commandObject.CommandType = CommandType.StoredProcedure;

                connectionObject.Open();
                rowsAffected = commandObject.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Log Error

                throw ex;
            }
            finally
            {
                if (connectionObject != null)
                    connectionObject.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Method used to execute a stored procedure.
        /// </summary>
        /// <param name="spName">Stored procedure name.</param>
        /// <param name="parameters">Any parameters for the stored procedure.</param>
        /// <returns>
        /// Returns the number of rows affected by the executed stored procedure.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown when there is any error in a database related operation.
        /// </exception>
        public int ExecuteSP(string spName, IDbDataParameter[] parameters)
        {
            int rowsAffected = -1;
            SqlConnection connectionObject = null;

            try
            {
                if (this.connection == null)
                {
                    connectionObject = new SqlConnection(connectionString);
                    connectionObject.Open();
                }
                else
                    connectionObject = this.connection;

                SqlCommand commandObject = new SqlCommand(
                    spName, connectionObject);

                commandObject.CommandType = CommandType.StoredProcedure;
                commandObject.Parameters.AddRange(parameters);

                rowsAffected = commandObject.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Log Error

                throw ex;
            }
            finally
            {
                if (this.connection == null && connectionObject != null)
                    connectionObject.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Method used to execute a stored procedure.
        /// </summary>
        /// <param name="spName">Stored procedure name.</param>        
        /// <returns>
        /// Returns a dataset filled with the values returned by the 
        /// executed stored procedure.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown when there is any error in a database related operation.
        /// </exception>
        public DataSet ExecuteDataSetSP(string spName)
        {
            SqlConnection connectionObject = null;
            DataSet dsObject = new DataSet();

            try
            {
                connectionObject = new SqlConnection(connectionString);

                SqlCommand commandObject = new SqlCommand(spName, connectionObject);
                commandObject.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapterObject = new SqlDataAdapter(commandObject);
                adapterObject.Fill(dsObject);
            }
            catch (Exception ex)
            {
                //Log Error
                throw ex;
            }
            finally
            {
                if (connectionObject != null)
                    connectionObject.Close();
            }

            return dsObject;
        }

        public DataSet ExecuteDataSet(string dmlStatement)
        {
            SqlConnection connectionObject = null;
            DataSet dsObject = new DataSet();

            try
            {
                connectionObject = new SqlConnection(connectionString);

                SqlCommand commandObject = new SqlCommand(dmlStatement, connectionObject);
                commandObject.CommandType = CommandType.Text;

                SqlDataAdapter adapterObject = new SqlDataAdapter(commandObject);
                adapterObject.Fill(dsObject);
            }
            catch (Exception ex)
            {
                //Log Error
                throw ex;
            }
            finally
            {
                if (connectionObject != null)
                    connectionObject.Close();
            }

            return dsObject;
        }

        /// <summary>
        /// Method used to execute a stored procedure.
        /// </summary>
        /// <param name="spName">Stored procedure name.</param>
        /// <param name="parameters">Any parameters for the stored procedure.</param>
        /// <returns>
        /// Returns a dataset filled with the values returned by the 
        /// executed stored procedure.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown when there is any error in a database related operation.
        /// </exception>
        public DataSet ExecuteDataSetSP(string spName, IDbDataParameter[] parameters)
        {
            SqlConnection connectionObject = null;
            DataSet dsObject = new DataSet();

            try
            {
                connectionObject = new SqlConnection(connectionString);

                SqlCommand commandObject = new SqlCommand(spName, connectionObject);
                commandObject.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                    commandObject.Parameters.AddRange(parameters);

                SqlDataAdapter adapterObject = new SqlDataAdapter(commandObject);
                adapterObject.Fill(dsObject);
            }
            catch (Exception ex)
            {
                //Log Error
                throw ex;
            }
            finally
            {
                if (connectionObject != null)
                    connectionObject.Close();
            }

            return dsObject;
        }

        /// <summary>
        /// Overloaded method used to generate a proper sql parameter object.
        /// </summary>
        /// <typeparam name="T">
        /// Generic type, to indicate the type of the parameter value.
        /// </typeparam>
        /// <param name="dataType">SQL data-type of the parameter.</param>
        /// <param name="parameterName">Name of the parameter in the database.</param>
        /// <param name="value">Value of the parameter.</param>
        /// <returns>
        /// Returns SqlParameter object filled with parameter 
        /// type, name, and value information.
        /// </returns>
        public IDbDataParameter CreateParameter<T>(SqlDbType dataType, string parameterName, T value)
        {
            SqlParameter parameterObject = new SqlParameter(parameterName, dataType);
            parameterObject.Value = value;

            return parameterObject;
        }

        /// <summary>
        /// Method used to generate a proper sql parameter object.
        /// </summary>
        /// <typeparam name="T">
        /// Generic type, to indicate the type of the parameter value.
        /// </typeparam>
        /// <param name="dataType">SQL data-type of the parameter.</param>
        /// <param name="parameterName">Name of the parameter in the database.</param>
        /// <param name="value">Value of the parameter.</param>
        /// <param name="length">Length of the parameter.</param>
        /// <returns>
        /// Returns SqlParameter object filled with parameter 
        /// type, name, and value information.
        /// </returns>
        public IDbDataParameter CreateParameterWithSize<T>(SqlDbType dataType, int length, string parameterName, T value)
        {
            SqlParameter parameterObject = new SqlParameter(
                parameterName, dataType, length);

            parameterObject.Value = value;

            return parameterObject;
        }

        /// <summary>
        /// Method used to execute a stored procedure.
        /// </summary>
        /// <param name="spName">Stored procedure name.</param>
        /// <param name="parameters">Any parameters for the stored procedure.</param>
        /// <returns>
        /// Integer value selected from the database.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown when there is any error in a database related operation.
        /// </exception>
        public int ExecuteScalar(string spName, IDbDataParameter[] parameters)
        {
            SqlConnection connectionObject = null;

            try
            {
                connectionObject = new SqlConnection(connectionString);
                SqlCommand commandObject = new SqlCommand(
                    spName, connectionObject);

                commandObject.CommandType = CommandType.StoredProcedure;
                commandObject.Parameters.AddRange(parameters);

                connectionObject.Open();
                return (int)commandObject.ExecuteScalar();
            }
            catch (Exception)
            {
                //Log Error
                throw;
            }
            finally
            {
                if (connectionObject != null)
                    connectionObject.Close();
            }

        }
    }

}
