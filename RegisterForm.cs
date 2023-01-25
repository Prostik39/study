using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Users
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {

            if(loginField.Text == "")
            {
                MessageBox.Show("Введите все данные");

                return;
            }

            if (passField.Text == "")
            {
                MessageBox.Show("Введите все данные ");

                return;
            }

            if (userFIOField.Text == "")
            {
                MessageBox.Show("Введите все данные ");

                return;
            }

            if (isUserExists())
                return;

            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`login`,`pass`,`fio`) VALUES (@login,@pass,@fio)", dB.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value =loginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = userFIOField.Text;
            

            dB.openConnection();

            if (command.ExecuteNonQuery() == 1)
            
                MessageBox.Show("Регистрация прошла успешно");
            
            else
                MessageBox.Show("Повторите попытку");

            dB.closeConnection();
        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;
            

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть, введите другой");
                return true;
            }
            else 
                return false;
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide(); // функция закрытия окна регистрации
            LoginForm loginForm = new LoginForm();
            loginForm.Show();// отображение окна авторизации
        }
    }
}
