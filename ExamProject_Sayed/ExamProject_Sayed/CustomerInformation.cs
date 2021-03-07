using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ExamProject_Sayed
{
    public partial class CustomerInformation : Form
    {


        string cs = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        public CustomerInformation()
        {
            InitializeComponent();
        }

        public void ClearAllData()
        {
            txtCustomerName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtImageUrl.Text = "";
            pictureBox.Image = null;

        }

        public void RefreshData()
        {
            using (con = new SqlConnection(cs))
            {
                adapter = new SqlDataAdapter("Select * From Customers", con);
                dt = new DataTable();
                adapter.Fill(dt);
                dgViewCustomerInfo.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("Insert Into Customers(CustomerName, Address,Phone, Email,Picture) VALUES(@customername, @address, @phone,@email,@picture)", con);
                cmd.Parameters.AddWithValue("@customername", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@picture", txtImageUrl.Text);

                MessageBox.Show("Data Inserted Successfully");
                cmd.ExecuteNonQuery();
                con.Close();
                RefreshData();
                ClearAllData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("Update Customers Set CustomerName=@customername, Address=@address,Phone=@phone,Email=@email,Picture=@picture Where CustomerID=@customerid", con);
                cmd.Parameters.AddWithValue("@customername", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@picture", txtImageUrl.Text);
                cmd.Parameters.AddWithValue("@customerid", lblCid.Text);

                MessageBox.Show("Data Updated Successfully");
                cmd.ExecuteNonQuery();
                con.Close();

                RefreshData();
                ClearAllData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("Delete Customers Where CustomerID=@customerid", con);
                cmd.Parameters.AddWithValue("@customerid", lblCid.Text);
                MessageBox.Show("Data Delete Successfully");
                cmd.ExecuteNonQuery();
                con.Close();
                RefreshData();
                ClearAllData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*jpg; *jpeg; *gif; *bmp;)|*jpg; *jpeg; *gif; *bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtImageUrl.Text = open.FileName;
                pictureBox.Image = new Bitmap(open.FileName);

            }
        }

        private void dgViewCustomerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerName.Text = this.dgViewCustomerInfo.CurrentRow.Cells["CustomerName"].Value.ToString();
            txtAddress.Text = this.dgViewCustomerInfo.CurrentRow.Cells["Address"].Value.ToString();
            txtPhone.Text = this.dgViewCustomerInfo.CurrentRow.Cells["Phone"].Value.ToString();
            txtEmail.Text = this.dgViewCustomerInfo.CurrentRow.Cells["Email"].Value.ToString();
            txtImageUrl.Text = this.dgViewCustomerInfo.CurrentRow.Cells["Picture"].Value.ToString();


            lblCid.Text = this.dgViewCustomerInfo.CurrentRow.Cells["CustomerID"].Value.ToString();
        }
    }
}
