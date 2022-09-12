using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Medicine_Bank
{
    public partial class About_Us : Form
    {
        public About_Us()
        {
            InitializeComponent();
        }

        private void githubdeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/DebtanuKhanra");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HOME hm = new HOME();
            hm.Show();
            this.Hide();
        }

        private void LinkedInDeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/debtanu-khanra-149a931a5/");
        }

        private void GithubIssac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/istiaque1314");
        
        }

        private void LinkedInIssac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/mdistiaqueansari/");
        }

        private void gmaildeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:debtanukhanra2000@gmail.com");
        }

        private void linklabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:issacansari321@gmail.com");
        }
    }
}
