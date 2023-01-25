using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Users
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            LocalData.getInfo(dataGridView1, " SELECT product.id as '№ п/п', product.name as 'Название', product.cost as 'Стоимость', product.quantyty as 'Количество', product.date as 'Дата' FROM product;");

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void обПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение для учета продуктов", "Внимание!");
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LocalData.doAction("insert into product(name,cost,quantyty,date) value('" + comboBox1.SelectedItem.ToString() + "'," + textBox2.Text+ ", "+ textBox3.Text + ",'"+ textBox4.Text + "' );");
            LocalData.getInfo(dataGridView1, " SELECT product.id as '№ п/п', product.name as 'Название', product.cost as 'Стоимость', product.quantyty as 'Количество', product.date as 'Дата' FROM product;");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            LocalData.getInfo(dataGridView1, "SELECT product.id as '№ п/п', product.name as 'Название', product.cost as 'Стоимость', product.quantyty as 'Количество', product.date as 'Дата' FROM product where name like '%" + textBox5.Text + "%';");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить данные?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (dataGridView1.SelectedCells.Count > 0)
                    LocalData.doAction("delete from product where id = "+ dataGridView1[0,dataGridView1.CurrentRow.Index].Value.ToString()+";");
            LocalData.getInfo(dataGridView1, "SELECT product.id as '№ п/п', product.name as 'Название', product.cost as 'Стоимость', product.quantyty as 'Количество', product.date as 'Дата' FROM product where name like '%" + textBox5.Text + "%';");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
