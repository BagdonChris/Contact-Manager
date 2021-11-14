using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Contact_Manager.Database;
using System.Data;
using System.IO;

namespace Contact_Manager.Core
{
    public class User
    {
        ManagerDatabase Db = new ManagerDatabase();

        public bool UsernameExists(string username)
        {
            var querry = "SELECT * FROM `user` WHERE `username`=@un";
            var command = new MySqlCommand(querry);
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;
            var adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddUser(string fName, string lName, string username, string password, MemoryStream pic)
        {
            var command = new MySqlCommand("INSERT INTO `user`(`fname`, `lname`, `username`, `password`, `picture`) VALUES (@fn,@ln,@un,@pw,@pic)", Db.getConnection);
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fName;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lName;
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pw", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = pic.ToArray();

            Db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                Db.CloseConnecction();
                return true;
            }
            else
            {
                Db.CloseConnecction();
                return false;
            }
        }
    }
}
