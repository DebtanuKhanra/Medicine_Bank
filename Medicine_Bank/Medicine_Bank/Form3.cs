using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medicine_Bank
{
    public partial class Menu : Form
    {

        public void mustinput()
        {
            if (textMname.Text == "")
            {
                MessageBox.Show("Please Type a Medicine Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textMname.Focus();
            }
            else if (textMrp.Text == "")
            {
                MessageBox.Show("Please Enter MRP ", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textMrp.Focus();
            }
            else if (textQty.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textQty.Focus();
            }
        }
        public Menu()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Log Out?", "Logout", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Logout Successfully","Logout Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
                HOME homepage = new HOME();
                homepage.Show();
                this.Hide();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            SqlConnection menucon = new SqlConnection("Data Source=DESKTOP-VT7456D\\SQLEXPRESS;Initial Catalog=Medicine;Integrated Security=True;");
            String medquery = "select*from table1";
            SqlCommand medcmd = new SqlCommand(medquery, menucon);
            SqlDataAdapter ad =new SqlDataAdapter(medcmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            meddatatable.DataSource = dt;




        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string SqlConn = ConfigurationManager.ConnectionStrings["MedicineData"].ConnectionString;
            using (SqlConnection searchCon = new SqlConnection(SqlConn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    string sql = "SELECT Sl_No, Medicine_Name, Rupees, Quantity FROM table1";
                    if (!string.IsNullOrEmpty(TextSearch.Text.Trim()))  // trim function remove all the white space.
                    {
                        sql += " WHERE Medicine_Name LIKE @Medicine_Name + '%'";
                        cmd.Parameters.AddWithValue("@Medicine_Name", TextSearch.Text.Trim());
                    }
                    cmd.CommandText = sql;
                    cmd.Connection = searchCon;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        meddatatable.DataSource = dt;
                    }
                }
            }

        }

        private void btnMedinsert_Click(object sender, EventArgs e)
        {
            SqlConnection menucon = new SqlConnection("Data Source=DESKTOP-VT7456D\\SQLEXPRESS;Initial Catalog=Medicine;Integrated Security=True;");
            if (textMname.Text.Length == 0 || textMrp.Text.Length == 0 || textQty.Text.Length == 0)
            {
                mustinput();
            }
            else
            {
                try
                {
                    menucon.Open();

                    SqlDataAdapter adap = new SqlDataAdapter("select Medicine_Name from table1 where Medicine_Name='"+textMname.Text+"'",menucon);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("This Medicine already in Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else { 




                    String medadd = "insert into table1 values(@medname,@mrp,@qty)";
                    SqlCommand cmd = new SqlCommand(medadd, menucon);


                    cmd.Parameters.AddWithValue("@medname", textMname.Text);
                    cmd.Parameters.AddWithValue("@mrp", textMrp.Text);
                    cmd.Parameters.AddWithValue("@qty", textQty.Text);

                    int i = cmd.ExecuteNonQuery();

                    menucon.Close();

                        if (i > 0)
                        {
                            MessageBox.Show("New medicine Stocked Sucessfully", "Medicine Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            textMname.Text = "";
                            textMrp.Text = "";
                            textQty.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Failed to stock new Medicine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login ln=new Login();
            ln.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            Invoice page = new Invoice();
            page.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["MedicineData"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(con);

            if (textMedQ.Text == "")
            {
                MessageBox.Show("Please enter Medicine Name");
            }
            else if (textAddQ.Text == "")
            {
                MessageBox.Show("Please enter Medicine quantity");
            }
            else
            {

                SqlDataAdapter adap = new SqlDataAdapter("select * from table1 where Medicine_Name = @MedName", sqlconn);
                adap.SelectCommand.Parameters.AddWithValue("@MedName", textMedQ.Text);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adap);
                DataSet ds = new DataSet();
                adap.Fill(ds, "table1");
                DataRow dr = ds.Tables["table1"].Rows[0];

                if (dr != null)
                {
                    dr["Quantity"] = Convert.ToInt32(dr["Quantity"]) + Convert.ToInt32(textAddQ.Text);
                    MessageBox.Show("Medicine Added Instock","Add Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    adap.Update(ds, "table1");
                }
            }

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
