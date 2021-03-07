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

namespace ExamProject_Sayed
{
    public partial class BookingInformation : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        DataRow dr;
        public BookingInformation()
        {
            InitializeComponent();
            RefreshData();
            CustomerID();
        }

        public void ClearAllData()
        {
            txtBookingDate.Text = "";
            txtRoomNumber.Text = "";
            txtRoomType.Text = "";
            cmbCustomerID.SelectedValue = false;

        }
        public void RefreshData()
        {
            using (con = new SqlConnection(cs))
            {
                adapter = new SqlDataAdapter("Select * From Booking", con);
                dt = new DataTable();
                adapter.Fill(dt);
                dgViewBookingInfo.DataSource = dt;
            }
        }
        public void CustomerID()
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("Select * From Customers", con);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);

                dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "--Select CustomerID--" };
                dt.Rows.InsertAt(dr, 0);

                cmbCustomerID.ValueMember = "CustomerID";
                cmbCustomerID.DisplayMember = "CustomerID";

                cmbCustomerID.DataSource = dt;
                con.Close();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("Insert Into Booking(BookingDate, RoomNumber,BookingType,CustomerID) VALUES(@bookingdate, @roomnumber, @bookingtype,@customerid)", con);
                cmd.Parameters.AddWithValue("@bookingdate", txtBookingDate.Text);
                cmd.Parameters.AddWithValue("@roomnumber", txtRoomNumber.Text);
                cmd.Parameters.AddWithValue("@bookingtype", txtRoomType.Text);
                cmd.Parameters.AddWithValue("@customerid", cmbCustomerID.SelectedValue);

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
                cmd = new SqlCommand("Update Booking Set BookingDate=@bookingdate,RoomNumber=@roomnumber, BookingType=@bookingtype,CustomerID=@customerid Where BookingID=@bookingid", con);
                cmd.Parameters.AddWithValue("@bookingdate", txtBookingDate.Text);
                cmd.Parameters.AddWithValue("@roomnumber", txtRoomNumber.Text);
                cmd.Parameters.AddWithValue("@bookingtype", txtRoomType.Text);
                cmd.Parameters.AddWithValue("@customerid", cmbCustomerID.Text);
                cmd.Parameters.AddWithValue("@bookingid", lblBid.Text);


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
                cmd = new SqlCommand("Delete Booking Where BookingID=@bookingid", con);
                cmd.Parameters.AddWithValue("@bookingid", lblBid.Text);
                MessageBox.Show("Data Delete Successfully");
                cmd.ExecuteNonQuery();
                con.Close();
                RefreshData();
                ClearAllData();
            }
        }

        private void dgViewBookingInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookingDate.Text = this.dgViewBookingInfo.CurrentRow.Cells["BookingDate"].Value.ToString();
            txtRoomNumber.Text = this.dgViewBookingInfo.CurrentRow.Cells["RoomNumber"].Value.ToString();
            txtRoomType.Text = this.dgViewBookingInfo.CurrentRow.Cells["BookingType"].Value.ToString();
            cmbCustomerID.Text = this.dgViewBookingInfo.CurrentRow.Cells["CustomerID"].Value.ToString();
            lblBid.Text = this.dgViewBookingInfo.CurrentRow.Cells["BookingID"].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
