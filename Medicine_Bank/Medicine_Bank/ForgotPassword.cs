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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            SqlConnection Sqlforgot;
            Sqlforgot = ConnectionHelper.GetConnection();
            textUseremail.Text=textUseremail.Text.ToLower();

            try
            {
                Sqlforgot.Open();

                if (textPasskey.TextLength < 8)
                {
                    MessageBox.Show("Password should be contain 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (textPasskey.Text != textConfirmPass.Text)
                    {
                        MessageBox.Show("New Password not matched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        String forgotquery = "update table1 set Password=@passkey where EmailID=@email";
                        SqlCommand fogotcmd = new SqlCommand(forgotquery, Sqlforgot);
                        fogotcmd.Parameters.AddWithValue("@passkey", textPasskey.Text);
                        fogotcmd.Parameters.AddWithValue("@email", textUseremail.Text);

                        int u = fogotcmd.ExecuteNonQuery();
                        Sqlforgot.Close();
                        if (u > 0)
                        {
                            MessageBox.Show("Password Changed Sucessfully", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //labelforgot.Text = "Password Changed Sucessfully";
                            // labelforgot.ForeColor=System.Drawing.Color.Green;

                        }
                        else
                        {
                            MessageBox.Show("Password Not Changed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        /*SqlDataAdapter adap = new SqlDataAdapter("select * from table1 where EmailID = @useremail", Sqlforgot);
                        adap.SelectCommand.Parameters.AddWithValue("@useremail",textUseremail.Text);
                        SqlCommandBuilder cmd = new SqlCommandBuilder(adap);
                        DataSet ds = new DataSet();
                        adap.Fill(ds, "table1");
                        DataRow dr = ds.Tables["table1"].Rows[0];

                        if (dr != null)
                        {
                            dr["Password"] = textPasskey.Text;
                            MessageBox.Show("Password Changed");
                            adap.Update(ds, "table1");
                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void textConfirmPass_Keyup(object sender, KeyEventArgs e)
        {
            if (textPasskey.Text == textConfirmPass.Text)
            {
                labelforgot.Text = "✔️";
                labelforgot.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                labelforgot.Text = "❌";
                labelforgot.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textConfirmPass.PasswordChar == '*')
            {
                button1.BringToFront();
                textConfirmPass.PasswordChar = '\0';

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textConfirmPass.PasswordChar == '\0')
            {
                button2.BringToFront();
                textConfirmPass.PasswordChar = '*';

            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SqlConnection Sqlforgot;
            Sqlforgot = ConnectionHelper.GetConnection();

            HOME h1=new HOME();
            h1.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ForgotPassword fg = new ForgotPassword();
            fg.Show();
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
