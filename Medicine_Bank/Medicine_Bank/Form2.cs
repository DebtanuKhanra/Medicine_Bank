using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace Medicine_Bank
{
    public partial class Registration : Form
    {

        public void mustinput()
        {

            if (textUserID.Text == "")
            {
                MessageBox.Show("User ID required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textUserID.Focus();
            }
            else if (textUsername.Text == "")
            {
                MessageBox.Show("Username Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textUsername.Focus();
            }
            else if (textEmail.Text == "")
            {
                MessageBox.Show("Email ID required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textEmail.Focus();
            }
            else if (textPass.Text == "")
            {
                MessageBox.Show("Password reiquired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textPass.Focus();
            }

        }
        public void commandValues(SqlCommand sqlcmd)
        {
            sqlcmd.Parameters.AddWithValue("@userid", textUserID.Text);
            sqlcmd.Parameters.AddWithValue("@username", textUsername.Text);
            sqlcmd.Parameters.AddWithValue("@email", textEmail.Text);
            sqlcmd.Parameters.AddWithValue("@password", textPass.Text);


        }
        public Registration()
        {
            InitializeComponent();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon;
            sqlcon = ConnectionHelper.GetConnection();
            textEmail.Text = textEmail.Text.ToLower();

            if (textUserID.Text.Length == 0 || textUsername.Text.Length == 0 || textEmail.Text.Length == 0 || textPass.Text.Length == 0)
            {
                mustinput();
            }
            else
            {
                try
                {
                    SqlDataAdapter adap = new SqlDataAdapter("select *from table1", sqlcon);
                    DataSet ds = new DataSet();
                    adap.Fill(ds, "table1");
                    bool IsEmail = false;
                    bool IsUserID = false;

                    foreach (DataRow dr in ds.Tables["table1"].Rows)
                    {

                        int id = Convert.ToInt32(textUserID.Text);
                        if ((id.Equals(dr["UserID"])) && (!textEmail.Text.Equals(dr["EmailID"])))
                        {
                            IsEmail = false;
                            IsUserID = true;
                            break;
                        }
                        else if ((!id.Equals(dr["UserID"])) && (textEmail.Text.Equals(dr["EmailID"])))
                        {
                            IsEmail = true;
                            IsUserID = false;
                            break;
                        }
                        else if ((id.Equals(dr["UserID"])) && (textEmail.Text.Equals(dr["EmailID"])))
                        {
                            IsEmail = true;
                            IsUserID = true;
                            break;
                        }
                    }
                    

                    if (IsUserID == true && IsEmail == false)
                    {
                        MessageBox.Show("User ID is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else if (IsEmail == true && IsUserID == false)
                    {
                        MessageBox.Show("Email ID is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if(IsEmail == true && IsUserID == true)
                    {
                        MessageBox.Show("Either email or u id exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    

                    else
                    {

                        sqlcon.Open();

                        if (textPass.TextLength < 8)
                        {
                            MessageBox.Show("Password must be contain 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {
                            if (!textPass.Text.Equals (textConfirmPass.Text))
                            {
                                MessageBox.Show("Password not matched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {


                                String query = "insert into table1 values (@userid,@username,@email,@password,'" + dateRegistration.Text + "')";
                                SqlCommand cmd = new SqlCommand(query, sqlcon);
                                commandValues(cmd);
                                int i = cmd.ExecuteNonQuery();
                                sqlcon.Close();

                                if (i > 0)
                                {
                                    MessageBox.Show("SignUP Successfully", "SignUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Login loginform = new Login();
                                    loginform.Show();
                                    this.Hide();
                                    /* textUserID.Text = "";
                                     textUsername.Text = "";
                                     textEmail.Text = "";
                                     textPass.Text = "";*/
                                }
                                else
                                {
                                    MessageBox.Show("Error!! Unable to SignUP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    }

              
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textUserID.Clear();
            textUsername.Clear();
            textEmail.Clear();
            textPass.Clear();
            textConfirmPass.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.Show();
            this.Hide();
        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HOME homepage=new HOME();
            homepage.Show();
            this.Hide();
        }

        private void textConfirmPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (textPass.Text == textConfirmPass.Text)
            {
                labelSign.Text = "✔️";
                labelSign.ForeColor=System.Drawing.Color.Green;
            }
            else
            {
                labelSign.Text = "❌";
                labelSign.ForeColor = System.Drawing.Color.Red;
            }
        }

        

       

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (textConfirmPass.PasswordChar == '*')
            {
                btnHide.BringToFront();
                textConfirmPass.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (textConfirmPass.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                textConfirmPass.PasswordChar = '*';
            }
        }

        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Registration rr = new Registration();
            rr.Show();
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
