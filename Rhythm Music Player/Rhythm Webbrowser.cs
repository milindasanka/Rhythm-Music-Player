using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rhythm_Music_Player
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//this is minimize btn
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox1_KeyPress(object sender, KeyPressEventArgs e)//keypreas search
        {
            if (e.KeyChar == (char)13)
                webBrowser1.Navigate("http://www.google.com/search?q=" + urlbox.Text);
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)//back
        {
            webBrowser1.GoBack();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)//next
        {
            webBrowser1.GoForward();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)//refresh
        {
            webBrowser1.Refresh();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)//search
        {
            if (!String.IsNullOrEmpty(urlbox.Text))
                webBrowser1.Navigate(urlbox.Text);
        }

        private void urlbox_TextChanged(object sender, EventArgs e)
        {
            //url

        }

        private void bunifuCustomTextbox2_KeyPress(object sender, KeyPressEventArgs e)//keypress go download
        {
            if (e.KeyChar == (char)13)
                webBrowser1.Navigate("https://en.savefrom.net/" + urlbox.Text);

        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)//You tube downloder
        {
            
                webBrowser1.Navigate("https://www.downvids.net/");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)//home
        {

            webBrowser1.Navigate("https://www.google.com");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)//webbrowser
        {
            urlbox.Text = "" + webBrowser1.Url;
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)//google link
        {
            webBrowser1.Navigate("https://www.google.com");
        }

        private void yahooToolStripMenuItem_Click(object sender, EventArgs e)//yahoo link
        {
            webBrowser1.Navigate("https://www.yahoo.com");
        }

        private void baiduToolStripMenuItem_Click(object sender, EventArgs e)//baidu link
        {
            webBrowser1.Navigate("https://www.baidu.com");
        }

        private void bingToolStripMenuItem_Click(object sender, EventArgs e)//bing link
        {
            webBrowser1.Navigate("https://www.bing.com");
        }

        private void duckDuckGoToolStripMenuItem_Click(object sender, EventArgs e) // duckduckgo link
        {
            webBrowser1.Navigate("https://www.duckduckgo.com");
        }

        private void yandexToolStripMenuItem_Click(object sender, EventArgs e)// yandex link
        {
            webBrowser1.Navigate("https://www.yandex.com");
        }

        private void aliExToolStripMenuItem_Click(object sender, EventArgs e)// aliexpress link
        {
            webBrowser1.Navigate("https://www.aliexpress.com");
        }

        private void ebayToolStripMenuItem_Click(object sender, EventArgs e)// ebay link
        {
            webBrowser1.Navigate("https://www.ebay.com");
        }

        private void amazonToolStripMenuItem_Click(object sender, EventArgs e)// amazon link
        {
            webBrowser1.Navigate("https://www.amazon.com");
        }

        private void darazToolStripMenuItem_Click(object sender, EventArgs e)//daraz link
        {
            webBrowser1.Navigate("https://www.daraz.com");
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)// youtube link
        {
            webBrowser1.Navigate("https://www.youtube.com");
        }

        private void vimoToolStripMenuItem_Click(object sender, EventArgs e)//vimeo link
        {
            webBrowser1.Navigate("https://vimeo.com/");
        }

        private void soundCloudToolStripMenuItem_Click(object sender, EventArgs e)//soundcloud link
        {
            webBrowser1.Navigate("https://www.soundcloud.com");
        }

        private void appleToolStripMenuItem_Click(object sender, EventArgs e)// apple link
        {
            webBrowser1.Navigate("https://www.apple.com");
        }

        private void netflixToolStripMenuItem_Click(object sender, EventArgs e)// netflix link
        {
            webBrowser1.Navigate("https://www.netflix.com");
        }

        private void w3SchoolsToolStripMenuItem_Click(object sender, EventArgs e)//w3schools link
        {
            webBrowser1.Navigate("https://www.w3schools.com/");
        }

        private void sololearnToolStripMenuItem_Click(object sender, EventArgs e)//sololearn link
        {
            webBrowser1.Navigate("https://www.sololearn.com/");
        }

        private void courseraToolStripMenuItem_Click(object sender, EventArgs e)//coursera link
        {
            webBrowser1.Navigate("https://www.coursera.org/");
        }

        private void tutorialspointToolStripMenuItem_Click(object sender, EventArgs e)// tutorialpoint link
        {
            webBrowser1.Navigate("https://www.tutorialspoint.com/");
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)//facebook link
        {
            webBrowser1.Navigate("https://www.facebook.com/");
        }

        private void twitterToolStripMenuItem_Click(object sender, EventArgs e)// twitter link
        {
            webBrowser1.Navigate("https://www.twitter.com/");
        }

        private void linkedInToolStripMenuItem_Click(object sender, EventArgs e)// linkedin link
        {
            webBrowser1.Navigate("https://www.linkedin.com/");
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
//Created By Anuradha Sanka HNDIT 2K18
