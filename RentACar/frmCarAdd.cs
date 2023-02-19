using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RentACar
{
    public partial class frmCarAdd : Form
    {
        public frmCarAdd()
        {
            InitializeComponent();
        }
        private string connectionSentence = @"Data Source=DESKTOP-RDDKO5L;Initial Catalog=RenACar;Integrated Security=True";

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbSeries.Items.Clear();
            if (cmbBrand.SelectedIndex == 0)
            {
                cmbSeries.Items.Add("Corsa");
                cmbSeries.Items.Add("Astra");
                cmbSeries.Items.Add("İnsignia");

            }
            else if (cmbBrand.SelectedIndex == 1)
            {
                cmbSeries.Items.Add("A-200");
                cmbSeries.Items.Add("C63");
                cmbSeries.Items.Add("S-400");
            }
            else if (cmbBrand.SelectedIndex == 2)
            {
                cmbSeries.Items.Add("M 520");
                cmbSeries.Items.Add("M4 competition");
                cmbSeries.Items.Add("M 63");
            }
            else if (cmbBrand.SelectedIndex == 3)
            {
                cmbSeries.Items.Add("Megane 6");
                cmbSeries.Items.Add("Clıo");
                cmbSeries.Items.Add("Fluence");
            }
            else if (cmbBrand.SelectedIndex == 4)
            {
                cmbSeries.Items.Add("courier");
                cmbSeries.Items.Add("GT-500");
                cmbSeries.Items.Add("Mustang");
            }
        }

        private void btnExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionSentence);
            connection.Open();
            SqlCommand command = new SqlCommand("Insert Into Cars Values(@NumberPlate,@Brand,@Series,@Model,@Color,@Kilometer,@Fuel,@RentMoney,@State)", connection);

            command.Parameters.AddWithValue("@NumberPlate", txtlicenseplate.Text);
            command.Parameters.AddWithValue("@Brand",cmbBrand.Text);
            command.Parameters.AddWithValue("@Series", cmbSeries.Text);
            command.Parameters.AddWithValue("@Model", txtModel.Text);
            command.Parameters.AddWithValue("@Color", txtColor.Text);
            command.Parameters.AddWithValue("@Kilometer", txtKilometer.Text);
            command.Parameters.AddWithValue("@Fuel", cmbFuil.Text);
            command.Parameters.AddWithValue("@RentMoney", txtRentAmount.Text);
            command.Parameters.AddWithValue("@State", cmbState.Text);

            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Başarılı");

        }

        private void frmCarAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
