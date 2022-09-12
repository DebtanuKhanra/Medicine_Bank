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
    public partial class Invoice : Form

    {
      
        public void foo(TextBox tBox, TextBox tQty, TextBox tPrice, TextBox tTotal)
        {
            if (tBox.Text == "")
            {
                MessageBox.Show("Please Enter Medicine Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tQty.Text == "")
            {
                MessageBox.Show("Please Enter Medicine Quantity", "Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string textValueName1 = tBox.Text.ToString();
                string textValueQty1 = tQty.Text.ToString();
                UpdateMedQty(textValueName1, textValueQty1, tPrice, tTotal);
            }
        }





        public double resultTotal = 0;
        public void UpdateMedQty(string paramName, string paramQty, TextBox paramPrice, TextBox paramTotal)
        {

            string con = ConfigurationManager.ConnectionStrings["MedicineData"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(con);

            try
            {
                SqlDataAdapter adap = new SqlDataAdapter("select * from table1 where Medicine_Name = @MedName", sqlconn);
                adap.SelectCommand.Parameters.AddWithValue("@MedName", paramName);

                SqlCommandBuilder cmd = new SqlCommandBuilder(adap);
                DataSet ds = new DataSet();
                adap.Fill(ds, "table1");
                DataRow dr = ds.Tables["table1"].Rows[0];  // if medicine found in the database then it returns greater than 0
                                                          // if medicine not found in the database then it returns 0 and since I am try and catch block
                                                         // so command will come to catch block and print the statement.
                if (dr != null)
                {
                    dr["Quantity"] = Convert.ToInt32(dr["Quantity"]) - Convert.ToInt32(paramQty);

                    paramPrice.Text = Convert.ToString(dr["Rupees"]);
                    paramTotal.Text = Convert.ToString(Convert.ToDouble(dr["Rupees"]) * Convert.ToDouble(paramQty));

                    double sTotal = Convert.ToDouble(dr["Rupees"]) * Convert.ToDouble(paramQty);
                    resultTotal += sTotal;// resulttotal  = resultTotal + sTotal , resultTo = 0+40
                                          // resulttotal  = resultTotal + sTotal , resultTo = 40+10
                    adap.Update(ds, "table1"); //  without this line database datas will not update.
                }
            }
            catch (Exception )
            {
                MessageBox.Show((paramName + " Spelling Mistake"),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                resultTotal = 0;// whenever user input wrong medicine name then resulTotal value will be 0 and start 
                                // start the process from starting.
            }

        }
        public Invoice()
        {
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
           

        }

        
        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                foo(textBox1, textQty1, textPrice1, textTotal1);
            }
            if (textBox2.Text != "")
            {
                foo(textBox2, textQty2, textPrice2, textTotal2);
            }
            if (textBox3.Text != "")
            {
                foo(textBox3, textQty3, textPrice3, textTotal3);
            }
            if (textBox4.Text != "")
            {
                foo(textBox4, textQty4, textPrice4, textTotal4);
            }
            if (textBox5.Text != "")
            {
                foo(textBox5, textQty5, textPrice5, textTotal5);
            }
            if (textBox6.Text != "")
            {
                foo(textBox6, textQty6, textPrice6, textTotal6);
            }
            if (textBox7.Text != "")
            {
                foo(textBox7, textQty7, textPrice7, textTotal7);
            }
            if (textBox8.Text != "")
            {
                foo(textBox8, textQty8, textPrice8, textTotal8);
            }
            if (textBox9.Text != "")
            {
                foo(textBox9, textQty9, textPrice9, textTotal9);
            }
            if (textBox10.Text != "")
            {
                foo(textBox10, textQty10, textPrice10, textTotal10);
            }
            if (textBox11.Text != "")
            {
                foo(textBox11, textQty11, textPrice11, textTotal11);
            }


            // display the value on the sub total text box
            if (Convert.ToInt32(resultTotal) > 0)
            {
                textSubTotal.Text = Convert.ToString(resultTotal);

                double gst = (double)resultTotal * (double)0.18;
                textTax.Text = Convert.ToString(gst);
                double gstPlusTotal = (resultTotal + gst);
                textTotal.Text = Convert.ToString(gstPlusTotal);

                btnSave.Enabled = false;   // to disable the btnSave
            }










            /*if (textBox1.Text != "")
            {


                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Medicine Name");
                }
                else if (textQty1.Text == "")
                {
                    MessageBox.Show("Please Enter Medicine Quantity");
                }
                else
                {
                    string textValueName1 = textBox1.Text.ToString();
                    string textValueQty1 = textQty1.Text.ToString();
                    UpdateMedQty(textValueName1, textValueQty1, textPrice1, textTotal1);

                }
            }
            if (textBox2.Text != "")
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Please Enter Medicine Name");
                }
                else if (textQty2.Text == "")
                {
                    MessageBox.Show("Please Enter Medicine Quantity");
                }
                else
                {
                    string textValueName2 = textBox2.Text.ToString();
                    string textValueQty2 = textQty2.Text.ToString();
                    UpdateMedQty(textValueName2, textValueQty2, textPrice2, textTotal2);
                }
            }
            if (textBox3.Text != "")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Medicine Name");
                }
                else if (textQty1.Text == "")
                {
                    MessageBox.Show("Please Enter Medicine Quantity");
                }
                else
                {
                    string textValueName3 = textBox3.Text.ToString();
                    string textValueQty3 = textQty3.Text.ToString();
                    UpdateMedQty(textValueName3, textValueQty3, textPrice3, textTotal3);
                }
            }
            if(textBox4.Text != "")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter Medicine Name");
                }
                else if (textQty1.Text == "")
                {
                    MessageBox.Show("Please Enter Medicine Quantity");
                }
                else
                {
                    string textValueName4 = textBox3.Text.ToString();
                    string textValueQty4 = textQty3.Text.ToString();
                    UpdateMedQty(textValueName4, textValueQty4, textPrice4, textTotal4);
                }
            }*/
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Invoice iv = new Invoice();
            iv.Show();
            this.Hide();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
