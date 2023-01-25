using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlX.XDevAPI.Relational;

namespace Users
{
    internal class LocalData
    {
        public static void getInfo (DataGridView table,string querty)
        {
            try
            {
                DB dB = new DB();
                MySqlDataAdapter adapter = new MySqlDataAdapter(querty,dB.getConnection());
                DataTable dt = new DataTable();
                dB.openConnection();
                adapter.Fill(dt);
                table.DataSource = dt;
                table.ClearSelection();
                dB.closeConnection();
                
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public static void doAction(string querty)
        {
            try
            {
                DB dB = new DB();
                MySqlCommand cmd = new MySqlCommand(querty, dB.getConnection());
                dB.openConnection();
                cmd.ExecuteReader();
                dB.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
