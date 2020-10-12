using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rhythm_Music_Player
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton26_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/milinda-anuradha-sanka-619132131/");//linkedIn

        }

        private void bunifuImageButton24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/milindasanka");//twitter

        }

        private void bunifuImageButton23_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/milindaanurdha.sanka");//facebook

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
//Created By Anuradha Sanka HNDIT 2K18