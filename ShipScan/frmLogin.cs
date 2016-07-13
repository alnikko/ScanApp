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
           
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnLogin.Enabled = false;

                if (Login())
                {
                    Cursor.Current = Cursors.Default;

                    //Display Main Menu


                    // Clear Password
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        #region Methods
        protected bool Login()
        {
            StatefullServiceClass context = new StatefullServiceClass();
            bool success;
            try
            {
                context.Url = "http://10.40.178.151/AcumaticaQA/(W(1))/Soap/SCANSHIP.asmx";
                context.Login(txtUserName.Text, txtPassword.Text);
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Error");
                success = false;
            }
            finally
            {
                context.Logout();
            }
            return success;
        }
        #endregion

        private void menuItemOptions_Click(object sender, EventArgs e)
        {

        }
    }
}