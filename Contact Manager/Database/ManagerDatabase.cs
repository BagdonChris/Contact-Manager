using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Contact_Manager.Database
{
    class ManagerDatabase
    {
        // connection
        MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3307;username=root;password=;database=contactmanager_db");

        public MySqlConnection getConnection
        {
            get
            {
                return this.Connection;
            }
        }

        public void OpenConnection()
        {
            if (this.Connection.State == ConnectionState.Closed)
            {
                this.Connection.Open();
            }
        }

        public void CloseConnecction()
        {
            if(this.Connection.State == ConnectionState.Open)
            {
                this.Connection.Close();
            }
        }
    }
}
