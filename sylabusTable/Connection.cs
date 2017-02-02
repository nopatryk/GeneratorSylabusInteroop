using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GeneratorSylabus
{
    class Connection : IDisposable
    {
        public int err = 0;
        public string errorStr = "";

        private string server, database, login, password, port;
        private bool windowsAuth;


        messageForm mf;

        public Connection()
        {
            mf = new messageForm();
            mf.Show();
            mf.Refresh();

            string ip = Properties.Settings.Default.ip.Replace(" ","");
            server = ip;
            if (!Properties.Settings.Default.port.Equals(""))
            {
                port = "," + Properties.Settings.Default.port;
            }
            else
            {
                port = "";
            }
            database = Properties.Settings.Default.dbName;
            windowsAuth = Properties.Settings.Default.auth;
            login = Properties.Settings.Default.login;
            password = Properties.Settings.Default.password;
        }

        public SqlConnection connectToDb()
        {
            string connStr = "Data Source=" + server + port + "; Database=" + database + ";Connection Timeout=5; Integrated security=";
            connStr += windowsAuth ? "true; " : "false; ";
            if (!windowsAuth)
            {
                connStr += "User ID=" + login + "; Password=" + password + ";";
            }
            //connStr += "Connect Timeout=3;";
         
            SqlConnection conn = new SqlConnection(connStr);

            try
                {
                    conn.Open();
                    err = 0;
                } catch(Exception e)
                {
                    errorStr = e.Message;
                    err = 1;
                }
            mf.Dispose();
           // mf.Close();

            return conn;

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    mf.Close();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {

            Dispose(true);

        }
        #endregion

    }
}
