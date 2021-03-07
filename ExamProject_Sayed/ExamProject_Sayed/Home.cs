using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamProject_Sayed
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerInformation ci = new CustomerInformation();
            ci.ShowDialog();

        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            BookingInformation bi = new BookingInformation();
            bi.ShowDialog();
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            CustomerReportGenerate rpt = new CustomerReportGenerate();
            this.Hide();
            rpt.ShowDialog();
        }
    }
}
