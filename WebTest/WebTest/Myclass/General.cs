using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CustomizesWebApp.MyClass
{
    public class General
    {
        #region "Common functions"

        string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        // CultureInfo CurrentCulture = CultureInfo.GetCultureInfo(ConfigurationManager.AppSettings["Culture"]);

        public int GetDataInsertORUpdateExcel(string storedProcedure, SqlParameter[] Params)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                cmd.Parameters.AddRange(Params);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ErrorMessage("Sql Error is=" + ex.Message.ToString());
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }

        public int GetDataInsertORUpdate(string storedProcedure, NameValueCollection nv)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);
                    //ErrorMessage(nv.AllKeys[i] + ":" + nv.Get(nv.AllKeys[i]));
                }

                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ErrorMessage("Sql Error is=" + ex.Message.ToString());
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }

        public void ErrorMessage(string msg)
        {
            string ACPPath = HostingEnvironment.MapPath("~/log.txt");
            StreamWriter swExtLogFile = new StreamWriter(ACPPath, true);
            swExtLogFile.Write(Environment.NewLine);
            swExtLogFile.Write("*****Error message=****" + msg + " at " + DateTime.Now.ToString());
            swExtLogFile.Flush();
            swExtLogFile.Close();
        }

        public int GetDataExecuteScaler(string storedProcedure, NameValueCollection nv)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);

                }

                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();

                    var result1 = cmd.ExecuteScalar();
                    result = result1 == DBNull.Value ? 0 : Convert.ToInt32(result1);


                }
                catch (Exception ex)
                {
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }

        public long GetDataExecuteScalerRetObj(string storedProcedure, NameValueCollection nv)
        {
            long result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);

                }
                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = (long)cmd.Parameters["@ID"].Value;

                }
                catch (Exception ex)
                {
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }

        public DataSet GetDataSet(string storedProcedure, NameValueCollection nv)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);

                }

                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    con.Open();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    da.Dispose();
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return ds;
        }

        public DataTable GetDataTable(string storedProcedure, NameValueCollection nv)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, con);

                for (int i = 0; i < nv.Count; i++)
                {
                    SqlParameter Param;
                    if ((nv.Get(nv.AllKeys[i])) == null)
                        Param = new SqlParameter(nv.AllKeys[i], DBNull.Value);
                    else
                        Param = new SqlParameter(nv.AllKeys[i], nv.Get(nv.AllKeys[i]));
                    cmd.Parameters.Add(Param);

                }

                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {
                    con.Open();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.StackTrace + ex.Message.ToString());
                    // ex.Message.ToString();
                    da.Dispose();
                    cmd.Connection.Close();
                }
                finally
                {
                    con.Close();
                }
            }

            return dt;
        }

        #endregion

        #region "*** Encrypt & Decrypt ***"
        public string EncryptFinal(string toEncrypt, bool useHashing)
        {
            string sEncrypt = Encrypt(toEncrypt, useHashing);
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(sEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("HealthcareSecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("HealthcareSecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);


        }
        public string DecryptFinal(string cipherString, bool useHashing)
        {
            string sDecrypt = Decrypt(cipherString, useHashing);
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(sDecrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("HealthcareSecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("HealthcareSecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        #endregion "*** Encrypt & Decrypt ***"

        public void ShowAlertAndRedirect(string message, string url)
        {
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; };";
            Page p = (Page)HttpContext.Current.CurrentHandler;
            p.ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


        }
        public void ShowMessageAndRedirect(Page page, string message, string url)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "redirect", "alert('" + message + "'); window.location='" + url + "';", true);
        }

        public void ShowMessage(Page page, string message)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + message + "');", true);
        }

        public void GetAllNotifications(string LogId, string facility, Repeater rep, Label lblCount)
        {

            var totalCount = 0;
            NameValueCollection nv = new NameValueCollection();
            DataTable dtSearch1 = new DataTable();

            nv.Add("@LoginID", LogId);
            nv.Add("@facility", facility);

            dtSearch1 = this.GetDataTable("SP_GetAllNotifications", nv);

            if (dtSearch1 != null)
            {
                foreach (DataRow dr in dtSearch1.Rows)
                {
                    if ((bool)dr["IsViewed"] == false)
                    {
                        totalCount += 1;
                    }
                }
            }

            lblCount.Text = totalCount.ToString();

            rep.DataSource = dtSearch1;
            rep.DataBind();
        }

        public DateTime getDatetime(string dt)
        {
            return DateTime.ParseExact(dt, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public DateTime getDatetime11(string dt)
        {
            return DateTime.ParseExact(dt, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        public int SendMail(string Email, string Username, string Password)
        {
            int IsReturn = 0;
            try
            {
                string EmailFromAddress = ConfigurationManager.AppSettings["EmailFromAddress"].ToString();
                string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"].ToString();

                var fromAddress = EmailFromAddress;

                var toAddress = Email;

                string fromPassword = EmailPassword;
                // Passing the values and make a email formate to display
                string subject = "Your UserName and Password For ";
                string body = "Dear ," + "\n";
                body += "Your UserName and Password For Weltec :" + "\n";
                body += "UserName : " + Username + " " + "\n\n";
                body += "Password : " + Password + " " + "\n\n";
                body += "Link : https://portal.weltecproject.in/login.aspx" + "\n\n";
                body += "Thank you!" + "\n";
                body += "Warm Regards," + "\n";

                // smtp settings
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 50000;
                }
                // Passing values to smtp object
                smtp.Send(fromAddress, toAddress, subject, body);
                IsReturn = 1;
            }
            catch (Exception ex)
            {
                //objGeneral.ErrorMessage("Error is=" + Convert.ToString(ex.Message));
                throw ex;
            }
            return IsReturn;
        }

    }
}