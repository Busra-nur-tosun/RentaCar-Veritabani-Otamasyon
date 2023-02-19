using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class frnCustomerList : Form
    {
        private string connectionSentence = @"Data Source=DESKTOP-RDDKO5L;Initial Catalog=RenACar;Integrated Security=True";

        public frnCustomerList()
        {
            InitializeComponent();
        }

        private void frnCustomerList_Load(object sender, EventArgs e)
        {
            CustomerList();
        }
        public void CustomerList()
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From  Customers ",connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();


        }

        private void button1_Click(object sender, EventArgs e)//güncelle butonu
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Update Customers set TcNo=@TcNo,NameSurname=@NameSurname,PhoneNumber=@PhoneNumber,Mail=@Mail,Adress=@Adress  ", connection);
            command.Parameters.AddWithValue("@TcNo", txtTc.Text);
            command.Parameters.AddWithValue("@NameSurname", txtNameSurname.Text);
            command.Parameters.AddWithValue("@PhoneNumber", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@Mail", txtMail.Text);
            command.Parameters.AddWithValue("@Adress", txtAdress.Text);
            command.ExecuteNonQuery();
            CustomerList();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)//delete butonu
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from Customers  where TcNo='" +dataGridView1.CurrentRow.Cells["TcNo"].Value.ToString() + "'",connection);
            command.ExecuteNonQuery();
            CustomerList();
            connection.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
           txtNameSurname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAdress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
