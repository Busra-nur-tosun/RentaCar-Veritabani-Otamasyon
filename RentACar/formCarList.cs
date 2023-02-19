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
    public partial class formCarList : Form
    {
        private string connectionSentence = @"Data Source=DESKTOP-RDDKO5L;Initial Catalog=RenACar;Integrated Security=True";

        public formCarList()
        {
            InitializeComponent();
        }
        public void Car_List()
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();

            String commandSentence = "Select * From Cars";
            SqlCommand command = new SqlCommand(commandSentence, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
        private void formCarList_Load(object sender, EventArgs e)
        {
            Car_List();
        }
        public void Car_Update()
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();

            string commandSentence = "Update Cars set Brand=@Brand,Series=@Series,Model=@Model,Color=@Color,Kilometer=@Kilometer,Fuel=@Fuel,RentMoney=@RentMoney where NumberPlate=@NumberPlate";
            SqlCommand command = new SqlCommand(commandSentence, connection);
            command.Parameters.AddWithValue("@NumberPlate", txtlicenseplate.Text);
            command.Parameters.AddWithValue("@Brand", cmbBrand.Text);
            command.Parameters.AddWithValue("@Series", cmbSeries.Text);
            command.Parameters.AddWithValue("@Model", txtModel.Text);
            command.Parameters.AddWithValue("@Color", txtColor.Text);
            command.Parameters.AddWithValue("@Kilometer", txtKilometer.Text);
            command.Parameters.AddWithValue("@Fuel", cmbFuil.Text);
            command.Parameters.AddWithValue("@RentMoney", txtRentAmount.Text);
           
            command.ExecuteNonQuery();
            connection.Close();
            Car_List();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Car_Update();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtlicenseplate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmbBrand.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbSeries.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtModel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtColor.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtKilometer.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cmbFuil.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtRentAmount.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();


            string commandSentence = "Delete from Cars where NumberPlate='" + dataGridView1.CurrentRow.Cells["NumberPlate"].Value.ToString() + "'";
            SqlCommand command = new SqlCommand(commandSentence, connection);

            command.ExecuteNonQuery();
            connection.Close();
            Car_List();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
