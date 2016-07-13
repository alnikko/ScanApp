using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShipScan.Helpers;

namespace ShipScan
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            StatefullServiceClass context = new StatefullServiceClass();
            try
            {
                context.Url = "http://10.40.178.151/AcumaticaQA/(W(1))/Soap/SCANSHIP.asmx";
                context.Login("admin", "123");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                context.Logout();
            }
        }
    }
}