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

namespace Users
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = loginField.Text;
            String pussUser = pussField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` =  @uP", db.getConnection());
            command.Parameters.Add("@uL",MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = pussUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //если авторизация прошла успешно, мы сразу попадаем в главное меню
                this.Hide();
                MenuForm menuForm = new MenuForm();
                menuForm.Show();
            }

            else 
                MessageBox.Show("Ошибка авторизации");


        }

        private void AutorLabel_Click(object sender, EventArgs e)
        {
            this.Hide(); // функция закрытия окна авторизации
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();// отображение окна регистрации
        }
    }
}
