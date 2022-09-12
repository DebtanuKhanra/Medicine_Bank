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


namespace Medicine_Bank
{
    public partial class Login : Form

    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
      
            SqlConnection LogConn;
            LogConn = ConnectionHelper.GetConnection();
            textUseremail.Text=textUseremail.Text.ToLower();
            if (textUseremail.Text == "")
            {
                MessageBox.Show("Please Enter Your Useremail", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textPasskey.Text == "")
            {
                MessageBox.Show("Please Enter Your Useremail", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select *from table1", LogConn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "table1");
                bool isEmail = false;
                bool isPassword = false;

                foreach (DataRow dr in ds.Tables["table1"].Rows)
                {
                    if ((textUseremail.Text.Equals(dr["EmailID"])) && (textPasskey.Text.Equals(dr["Password"])))
                    {
                        isEmail = true;
                        isPassword = true;
                        break;
                    }
                    else if ((!textUseremail.Text.Equals(dr["EmailID"])) && (textPasskey.Text.Equals(dr["Password"])))
                    {
                        isEmail = false;
                        isPassword = true;
                        break;
                    }
                    else if ((textUseremail.Text.Equals(dr["EmailID"])) && (!textPasskey.Text.Equals(dr["Password"])))
                    {
                        isEmail = true;
                        isPassword = false;
                        break;
                    }
                }

                if (isEmail == true && isPassword == true)
                {
                    MessageBox.Show("Login Sucessfully", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menu mn = new Menu();
                    mn.Show();
                    this.Hide();
                }
                else if (isEmail == true && isPassword == false)
                {
                    MessageBox.Show("Password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (isPassword == true && isEmail == false)
                {
                    MessageBox.Show("Email ID is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Email Id or Password both are incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }












            /*   LogConn.Open();
               String sql = "select*from table1";
               SqlCommand cmd = new SqlCommand(sql, LogConn);
               SqlDataAdapter adapter = new SqlDataAdapter(cmd);
               DataSet ds = new DataSet();
               adapter.Fill(ds, "table1");
               foreach (DataRow dr in ds.Tables["table1"].Rows)
               {
                   if (textUseremail.Text.Equals(dr["EmailID"]) && textPasskey.Text.Equals(dr["Password"]))
                   {


                       MessageBox.Show("Login Sucessfully", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       Menu mn = new Menu();
                       mn.Show();
                       this.Hide();
                       break;
                   }

                   else if (textUseremail.Text.Equals(dr["EmailID"]) && !textPasskey.Text.Equals(dr["Password"]))
                   {
                       MessageBox.Show("Wrong PPPPP");
                       break;
                   }

                   else if (!textUseremail.Text.Equals(dr["EmailID"]) && textPasskey.Text.Equals(dr["Password"]))
                   {
                       MessageBox.Show("Wrong EEEE");
                       break;
                   }

               }

               LogConn.Close();
   */










            /*     LogConn.Open();
                 String logquery = "select EmailID,Password from table1 where EmailID=@useremail and Password=@password ";
                 SqlCommand logcmd = new SqlCommand(logquery, LogConn);
                 logcmd.Parameters.AddWithValue("@useremail", textUseremail.Text);
                 logcmd.Parameters.AddWithValue("@password", textPasskey.Text);
                 SqlDataAdapter ad = new SqlDataAdapter(logcmd);
                 DataTable dt = new DataTable();
                 ad.Fill(dt);
                 if (dt.Rows.Count > 0)
                 {
                     MessageBox.Show("Login Successfully", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     Menu mainMenu = new Menu();
                     mainMenu.Show();
                     this.Hide();

                 }
                 else
                 {

                     MessageBox.Show("Invalid Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     textUseremail.Text = "";
                     textPasskey.Text = "";
                     textUseremail.Focus();
                     textPasskey.Focus();


                 }
                 LogConn.Close();*/
        }



        private void btnHome_Click(object sender, EventArgs e)
        {
            HOME homepage = new HOME();
            homepage.Show();
            this.Hide();
        }

        private void btnForgotpass_Click(object sender, EventArgs e)
        {
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
            this.Hide();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (textPasskey.PasswordChar == '*')
            {
                btnHide.BringToFront();
                textPasskey.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (textPasskey.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                textPasskey.PasswordChar = '*';
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Login ll = new Login();
            ll.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Registration r = new Registration();
            r.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Exit?", "Exit Application", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
