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
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }
        private string connectionSentence = @"Data Source=DESKTOP-RDDKO5L;Initial Catalog=RenACar;Integrated Security=True";

        private void frmSales_Load(object sender, EventArgs e)
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
    }
}
