using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DND_Helper
{
    public partial class Auth_m : Form
    {
        public Auth_m()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg() { TopLevel = false, TopMost = true };
            panel1.Controls.Add(reg);
            reg.BringToFront();
            reg.Show();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
        }

        private void Auth_m_Load(object sender, EventArgs e)
        {
            this.ShowIcon=false;
            Auth1 auth1 = new Auth1() { TopLevel = false, TopMost = true };
            panel1.Controls.Add(auth1);
            auth1.BringToFront();
            auth1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Auth1 auth1 = new Auth1() { TopLevel = false, TopMost = true };
            panel1.Controls.Add(auth1);
            auth1.BringToFront();
            auth1.Show();
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
        }
    }
}
