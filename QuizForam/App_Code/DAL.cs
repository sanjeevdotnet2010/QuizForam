using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mail;
using QuizForam;
using System.Collections.Generic;
using System.Reflection;

namespace QuizForam.App_Code
{

    public static class DAL
    {
        static string connstr = ConfigurationManager.AppSettings["ConpsQuzidb"].ToString();
        public static bool needTransaction = false;
        static SqlConnection conn;
        public static void openconnection(string connstr)
        {
            if (conn == null)
                conn = new SqlConnection(connstr);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public static void closeconnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();


        }

        private static SqlConnection currentConnection
        {
            get
            {
                object currentConnectionObj = HttpContext.Current.Items["currentConnection"];
                if (currentConnectionObj is SqlConnection)
                    return (SqlConnection)currentConnectionObj;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Items["currentConnection"] = value;
            }
        }

        private static SqlTransaction currentTransaction
        {
            get
            {
                object currentTransactionObj = HttpContext.Current.Items["currentTransaction"];
                if (currentTransactionObj is SqlTransaction)
                    return (SqlTransaction)currentTransactionObj;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Items["currentTransaction"] = value;
            }
        }

        public static SqlConnection GetNewConnection
        {
            get { return new SqlConnection(connstr); }
        }

        public static SqlConnection GetConnection
        {
            get
            {
                if (currentConnection == null)
                {
                    currentConnection = GetNewConnection;
                }
                if (currentConnection.State != ConnectionState.Open)
                {

                    currentConnection.Open();
                    try
                    {
                        if (needTransaction)
                            if (HttpContext.Current.Application["noShapshot"] == null)
                                currentTransaction = currentConnection.BeginTransaction(IsolationLevel.Snapshot);
                            else
                                currentTransaction = currentConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    }
                    catch
                    {
                        HttpContext.Current.Application["noShapshot"] = true;
                        currentTransaction = currentConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    }

                }

                return currentConnection;
            }
        }

        public static SqlTransaction CurrentTransaction
        {
            get { return currentTransaction; }
        }

        public static bool IsTransaction
        {
            get
            {
                return (CurrentTransaction != null);
            }
        }

        public static void RollBackTransaction()
        {
            if (currentConnection == null)
                return;
            if (currentTransaction != null)
            {
                try
                {
                    currentTransaction.Rollback();
                }
                catch
                {
                    currentTransaction = null;
                    currentConnection.Close();
                    currentConnection = null;
                }
            }
            currentTransaction = null;
        }

        public static void CommitTransaction()
        {
            if (currentConnection == null)
                return;
            if (currentTransaction != null)
            {
                currentTransaction.Commit();
                currentTransaction = null;
            }

            if (currentConnection.State != ConnectionState.Open)
                currentConnection.Close();
        }



        public static object ExecuteProc(string sql, DbSqlParameterCollection sqlParams)
        {
            bool isTransaction = IsTransaction;
            using (SqlCommand cmd = new SqlCommand(sql, (isTransaction) ? GetConnection : GetNewConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    if (currentTransaction != null)
                        cmd.Transaction = currentTransaction;

                    foreach (DbSqlParameter p in sqlParams)
                    {
                        cmd.Parameters.Add(p.Parameter);

                    }
                    //cmd.ExecuteNonQuery();
                    object ret = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return ret;
                }
                catch (Exception ex)
                {
                    LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (ExecuteProc) " + Environment.NewLine + "Error  : " + ex.Message);
                    RollBackTransaction();
                    throw;
                }
                finally
                {
                    cmd.Connection.Close();
                    // closeconnection();
                }
            };

        }

        public static void ExecuteCommandWithoutTransaction(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, GetNewConnection))
            {
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (ExecuteCommandWithoutTransaction) " + Environment.NewLine + "Error  : " + ex.Message);
                    throw;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            };
        }

        public static void ExecuteCommand(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, GetConnection))
            {
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    if (currentTransaction != null)
                        cmd.Transaction = currentTransaction;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (ExecuteCommand) " + Environment.NewLine + "Error  : " + ex.Message);
                    RollBackTransaction();
                    throw;
                }
                finally
                {
                    cmd.Connection.Close();

                }
            };
        }

        public static int ExecuteCommandWithParam(DbSqlParameterCollection sqlParam, string Text)
        {
            int i = 0;
            bool isTransaction = IsTransaction;
            using (SqlCommand cmd = new SqlCommand(Text, (isTransaction) ? GetConnection : GetNewConnection))
            {
                cmd.CommandType = CommandType.Text;
                foreach (DbSqlParameter p in sqlParam)
                {
                    cmd.Parameters.Add(p.Parameter);
                }
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    if (currentTransaction != null)
                        cmd.Transaction = currentTransaction;
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (ExecuteCommandWithParam) " + Environment.NewLine + "Error  : " + ex.Message);
                    RollBackTransaction();
                    throw;
                }
                finally
                {
                    cmd.Connection.Close();

                }
            };
            return i;
        }
        public static int ExecuteCommandWithParamInTransaction(DbSqlParameterCollection sqlParam, string Text)
        {
            int i = 0;
            bool isTransaction = true;
            using (SqlCommand cmd = new SqlCommand(Text, (isTransaction) ? GetConnection : GetNewConnection))
            {
                cmd.CommandType = CommandType.Text;
                foreach (DbSqlParameter p in sqlParam)
                {
                    cmd.Parameters.Add(p.Parameter);
                }
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    if (currentTransaction != null)
                        cmd.Transaction = currentTransaction;
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (ExecuteCommandWithParam) " + Environment.NewLine + "Error  : " + ex.Message);
                    RollBackTransaction();
                    throw;
                }
                finally
                {
                    cmd.Connection.Close();

                }
            };
            return i;
        }

        public static object SqlScalartoObj(string sqlStored, DbSqlParameterCollection sqlParams)
        {
            object DoStored;
            using (SqlCommand myCommand = new SqlCommand(sqlStored, GetNewConnection))
            {
                myCommand.CommandType = CommandType.StoredProcedure;
                foreach (DbSqlParameter p in sqlParams)
                {
                    myCommand.Parameters.Add(p.Parameter);
                }
                if (myCommand.Connection.State != ConnectionState.Open)
                    myCommand.Connection.Open();
                DoStored = myCommand.ExecuteScalar();
                myCommand.Connection.Close();
            }
            return DoStored;
        }

        public static string SqlScalar(string sql)
        {
            string r = string.Empty;
            try
            {
                r = SqlScalartoObj(sql).ToString();
            }
            catch
            {
                r = string.Empty;
            }
            return r;
        }

        public static object SqlScalartoObj(string sql)
        {
            bool isTransaction = IsTransaction;
            using (SqlCommand cmd = new SqlCommand(sql, (isTransaction) ? GetConnection : GetNewConnection))
            {

                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    if (isTransaction)
                        cmd.Transaction = currentTransaction;
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (SqlScalartoObj) " + Environment.NewLine + "Error  : " + ex.Message);
                    return null;
                }
                finally
                {
                    if (!isTransaction)
                        cmd.Connection.Close(); closeconnection();
                }
            }
        }
        
        public static DataTable GetDataTable(string Text)
        {
            bool isTransaction = IsTransaction;
            using (SqlCommand myCommand = new SqlCommand(Text, (isTransaction) ? GetConnection : GetNewConnection))
            {
                myCommand.CommandType = CommandType.Text;
                if (isTransaction)
                    myCommand.Transaction = currentTransaction;
                using (SqlDataAdapter adapter = new SqlDataAdapter(myCommand))
                {
                    using (DataTable dt = new DataTable())
                    {
                        try
                        {
                            adapter.Fill(dt);
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (GetDataTable) " + Environment.NewLine + "Error  : " + ex.Message);
                            throw;
                        }

                    }
                }
            }

        }

        public static DataTable GetDataTable(string sqlStored, DbSqlParameterCollection sqlParams)
        {

            bool isTransaction = IsTransaction;
            using (SqlCommand myCommand = new SqlCommand(sqlStored, (isTransaction) ? GetConnection : GetNewConnection))
            {
                myCommand.CommandType = CommandType.StoredProcedure;
                foreach (DbSqlParameter p in sqlParams)
                {
                    myCommand.Parameters.Add(p.Parameter);
                }
                if (isTransaction)
                    myCommand.Transaction = currentTransaction;

                using (SqlDataAdapter adapter = new SqlDataAdapter(myCommand))
                {
                    using (DataTable dt = new DataTable())
                    {
                        try
                        {
                            adapter.Fill(dt);
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (GetDataTable Two Para Proc) " + Environment.NewLine + "Error  : " + ex.Message);
                            throw;
                        }
                    }
                }
            }

        }

        public static DataTable GetDataTable(DbSqlParameterCollection sqlParams, string Text)
        {

            bool isTransaction = IsTransaction;
            using (SqlCommand myCommand = new SqlCommand(Text, (isTransaction) ? GetConnection : GetNewConnection))
            {
                myCommand.CommandType = CommandType.Text;
                foreach (DbSqlParameter p in sqlParams)
                {
                    myCommand.Parameters.Add(p.Parameter);
                }
                if (isTransaction)
                    myCommand.Transaction = currentTransaction;

                using (SqlDataAdapter adapter = new SqlDataAdapter(myCommand))
                {
                    using (DataTable dt = new DataTable())
                    {
                        try
                        {
                            adapter.Fill(dt);
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (GetDataTable Two Para Text) " + Environment.NewLine + "Error  : " + ex.Message);
                            throw;
                        }
                    }
                }
            }
        }

        public static DataSet GetDataSet(string sqlStored, DbSqlParameterCollection sqlParams)
        {
            bool isTransaction = IsTransaction;
            using (SqlCommand myCommand = new SqlCommand(sqlStored, (isTransaction) ? GetConnection : GetNewConnection))
            {
                myCommand.CommandType = CommandType.StoredProcedure;
                foreach (DbSqlParameter p in sqlParams)
                {
                    myCommand.Parameters.Add(p.Parameter);
                }

                if (isTransaction)
                    myCommand.Transaction = currentTransaction;

                using (SqlDataAdapter adapter = new SqlDataAdapter(myCommand))
                {
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            adapter.Fill(ds);
                            return ds;
                        }
                        catch (Exception ex)
                        {
                            LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (GetDataSet Two Para Proc) " + Environment.NewLine + "Error  : " + ex.Message);
                            throw;
                        }
                    }
                }
            }
        }

        public static DataSet GetDataSet(DbSqlParameterCollection sqlParams, string text)
        {
            bool isTransaction = IsTransaction;
            using (SqlCommand myCommand = new SqlCommand(text, (isTransaction) ? GetConnection : GetNewConnection))
            {
                myCommand.CommandType = CommandType.Text;
                foreach (DbSqlParameter p in sqlParams)
                {
                    myCommand.Parameters.Add(p.Parameter);
                }

                if (isTransaction)
                    myCommand.Transaction = currentTransaction;

                using (SqlDataAdapter adapter = new SqlDataAdapter(myCommand))
                {
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            adapter.Fill(ds);
                            return ds;
                        }
                        catch (Exception ex)
                        {
                            LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (GetDataSet Two Para Text) " + Environment.NewLine + "Error  : " + ex.Message);
                            throw;
                        }
                    }
                }
            }
        }

        public static DataSet GetDataSet(string sqlstring)
        {
            using (SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sqlstring, (IsTransaction) ? GetConnection : GetNewConnection))
            {
                if (IsTransaction)
                    mySqlDataAdapter.SelectCommand.Transaction = currentTransaction;

                using (DataSet myDataSet = new DataSet())
                {
                    try
                    {
                        mySqlDataAdapter.Fill(myDataSet);
                        return myDataSet;
                    }
                    catch (Exception ex)
                    {
                        LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (CreateDataset) " + Environment.NewLine + "Error  : " + ex.Message);
                        throw;
                    }

                }
            }
        }

        public static DataSet CreateDatasetWithoutTransaction(string sqlstring)
        {
            using (SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sqlstring, GetNewConnection))
            {
                using (DataSet myDataSet = new DataSet())
                {
                    try
                    {
                        mySqlDataAdapter.Fill(myDataSet);
                        return myDataSet;
                    }
                    catch (Exception ex)
                    {
                        LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (CreateDatasetWithoutTransaction) " + Environment.NewLine + "Error  : " + ex.Message);
                        throw;
                    }
                };
            }
        }

        public static DataSet SecureCreateDataset(string sqlstring, DbSqlParameterCollection sqlParams)
        {
            //DataSet Secure = new DataSet();
            using (SqlCommand cmd = (IsTransaction) ? GetConnection.CreateCommand() : GetNewConnection.CreateCommand())
            {
                cmd.CommandText = sqlstring;
                using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    if (IsTransaction)
                        SqlDataAdapter.SelectCommand.Transaction = currentTransaction;
                    foreach (DbSqlParameter ss in sqlParams)
                    {
                        cmd.Parameters.Add(ss.Parameter);
                    }
                    try
                    {
                        if (currentTransaction != null)
                            cmd.Transaction = currentTransaction;
                        using (DataSet Secure = new DataSet())
                        {
                            try
                            {
                                SqlDataAdapter.Fill(Secure);
                                return Secure;
                            }
                            catch (Exception ex)
                            {
                                LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "In Dal layer  (SecureCreateDataset) " + Environment.NewLine + "Error  : " + ex.Message);
                                throw;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // LogFileWrite("Page Url:   " + HttpContext.Current.Request.Url + Environment.NewLine + "Error  : " + ex.Message);
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        closeconnection();
                    }
                    ;
                }
            }
        }

        public static SqlDataReader CreateReader(string sqlstring)
        {
            using (SqlCommand myCmd = new SqlCommand(sqlstring, (IsTransaction) ? GetConnection : GetNewConnection))
            {
                SqlDataReader dr = null;

                if (myCmd.Connection.State != ConnectionState.Open)
                    myCmd.Connection.Open();
                if (currentTransaction != null)
                    myCmd.Transaction = currentTransaction;
                dr = myCmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
        }

        public static SqlDataReader CreateReader(string sqlstring, DbSqlParameterCollection sqlParams)
        {
            using (SqlCommand myCmd = new SqlCommand(sqlstring, (IsTransaction) ? GetConnection : GetNewConnection))
            {
                myCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = null;
                if (myCmd.Connection.State != ConnectionState.Open)
                    myCmd.Connection.Open();
                if (currentTransaction != null)
                    myCmd.Transaction = currentTransaction;

                foreach (DbSqlParameter par in sqlParams)
                    myCmd.Parameters.Add(par.Parameter);

                dr = myCmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
        }

        public static SqlDataReader CreateReader(DbSqlParameterCollection sqlParams, string text)
        {
            using (SqlCommand myCmd = new SqlCommand(text, (IsTransaction) ? GetConnection : GetNewConnection))
            {
                myCmd.CommandType = CommandType.Text;
                SqlDataReader dr = null;
                if (myCmd.Connection.State != ConnectionState.Open)
                    myCmd.Connection.Open();
                if (currentTransaction != null)
                    myCmd.Transaction = currentTransaction;

                foreach (DbSqlParameter par in sqlParams)
                    myCmd.Parameters.Add(par.Parameter);

                dr = myCmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
        }


        public static void LogFileWrite(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilePath = "";// HttpContext.Current.Server.MapPath(); // HttpContext.Server.MapPath("").ToString();
                logFilePath = HttpContext.Current.Server.MapPath("~/ErrorLog/ProgramLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt").ToString();
                if (logFilePath.Equals("")) return;
                #region Create the Log file directory if it does not exists
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                #endregion Create the Log file directory if it does not exists

                if (!logFileInfo.Exists)
                { fileStream = logFileInfo.Create(); }
                else
                { fileStream = new FileStream(logFilePath, FileMode.Append); }
                streamWriter = new StreamWriter(fileStream);


                streamWriter.WriteLine("Datetime of Error : " + DateTime.Now.ToString() + Environment.NewLine + message + Environment.NewLine + Environment.NewLine);

                //MailMessage mail = new MailMessage();
                //mail.To = "kapil@akcds.amity.edu";
                //mail.From = "Amity Admissions <admissions@amity.edu>";
                //mail.Subject = "Amity – Online Form - Error";
                //mail.Cc = "svishwakarma@akcds.amity.edu";
                //mail.Body = message;
                //mail.BodyFormat = MailFormat.Html;
                //SmtpMail.SmtpServer = System.Configuration.ConfigurationManager.AppSettings["AdmissionHost"].ToString();
                //SmtpMail.Send(mail);
            }
            catch
            {
                //streamWriter.Close();
                //fileStream.Close();
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }

        }



        public static void SendEmailMail(string strTo, string strFrom, string strSubject, string strmsgBody, string strURL)
        {
            MailMessage mail = new MailMessage();
            mail.To = strTo;
            mail.From = strFrom;
            mail.Subject = strSubject;
            mail.Bcc = "kapil@akcds.amity.edu";

            mail.Body = strmsgBody;
            mail.BodyFormat = MailFormat.Html;

            if (strURL.Trim() != "")
            {
                MailAttachment myattachment = new MailAttachment(strURL, MailEncoding.Base64);
                mail.Attachments.Add(myattachment);
                mail.Priority = MailPriority.High;
            }
            // SmtpMail.SmtpServer = "192.168.100.33";
            // SmtpMail.SmtpServer = "localhost";
            // SmtpMail.Send(mail);
        }


        public static List<T> ConvertDtToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }

    public class DbSqlParameterCollection : IEnumerable, IEnumerator
    {
        private int _index = -1;
        public ArrayList MySqlParameterArray = new ArrayList();

        public void Add(DbSqlParameter p)
        {
            MySqlParameterArray.Add(p);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this);
        }

        void IEnumerator.Reset()
        {
            this._index = -1;
        }

        object IEnumerator.Current
        {
            get { return (DbSqlParameter)MySqlParameterArray[this._index]; }
        }

        bool IEnumerator.MoveNext()
        {
            this._index++;
            try
            {
                return (this._index < MySqlParameterArray.Count);
            }
            catch
            {
                return (false);
            }
        }
    }

    public class DbSqlParameter
    {
        private SqlParameter parameter = new SqlParameter();

        public SqlParameter Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }

        public DbSqlParameter(string parameterName, object value)
        {
            parameter.ParameterName = parameterName;
            parameter.Value = value;
        }

        public DbSqlParameter(string parameterName, SqlDbType dbType)
        {
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = dbType;
        }

        public DbSqlParameter(string parameterName, SqlDbType dbType, int size)
        {
            parameter.ParameterName = parameterName;
            parameter.Size = size;
            parameter.SqlDbType = dbType;
        }

        public DbSqlParameter(string parameterName, SqlDbType dbType, int size, object value)
        {
            parameter.ParameterName = parameterName;
            parameter.Size = size;
            parameter.Value = value;
            parameter.SqlDbType = dbType;
        }


        public object Value
        {
            get { return parameter.Value; }
            set { parameter.Value = value; }
        }
    }


}
