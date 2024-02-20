using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_POO_GYM
{
    internal class DbSubscription
    {
       public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=subscription";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void AddSubscription(Subscription std)
        {
            string sql = "INSERT INTO subscription_tabel VALUES (NULL, @SubscriptionName, @SubscriptionSex, @SubscriptionLocation, @SubscriptionType, NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SubscriptionName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@SubscriptionSex", MySqlDbType.VarChar).Value = std.Sex;
            cmd.Parameters.Add("@SubscriptionLocation", MySqlDbType.VarChar).Value = std.Location;
            cmd.Parameters.Add("@SubscriptionType", MySqlDbType.VarChar).Value = std.Type;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Subscription not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        public static void UpdateSubscription(Subscription std, string id)
        {
            string sql = "UPDATE subscription_tabel SET Name = @SubscriptionName, Sex = @SubscriptionSex, Location = @SubscriptionLocation, Type = @SubscriptionType WHERE ID = @SubscriptionID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SubscriptionID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@SubscriptionName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@SubscriptionSex", MySqlDbType.VarChar).Value = std.Sex;
            cmd.Parameters.Add("@SubscriptionLocation", MySqlDbType.VarChar).Value = std.Location;
            cmd.Parameters.Add("@SubscriptionType", MySqlDbType.VarChar).Value = std.Type;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Subscription not updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        public static void DeleteSubscription(string id)
        {
            string sql = "DELETE FROM subscription_tabel WHERE ID = @SubscriptionID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SubscriptionID", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Subscription not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();

        }
    }
}
