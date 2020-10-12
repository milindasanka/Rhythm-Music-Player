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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String[] paths, files;
        int Startindex = 0;
        String[] Filename, FilePath;
        Boolean playnext = false;

        bool playing = false;

        public bool isplaying//play check
        {
            get
            {
                return playing;
            }
            set
            {
                playing = value;
                if (playing)
                    {
                    axWindowsMediaPlayer1.Ctlcontrols.pause(); actionbtn.Image = play.Image;
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play(); actionbtn.Image = pause.Image;
                }
            }

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();//this is close btn
        }
        
        private void Form1_load(object sender, EventArgs e)
        {
            Startindex = 0;
            playnext = false;
            StopPlayer();
        }
        public void StopPlayer()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        public void playfile(int playlistindex)
        {
            if(listBox1.Items.Count <0)
            {
                return;
            }
            if(playlistindex <0)
            {
                return;
            }
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.URL = FilePath[playlistindex];
            axWindowsMediaPlayer1.Ctlcontrols.next();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//this is minimize btn
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)// maxmize and restore
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //playscreen
        {
            Startindex = listBox1.SelectedIndex;
            playfile(Startindex);
            bunifuCustomLabel4.Text = listBox1.Text;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)//play list btn
        {
            listBox1.BringToFront();
        }
      
        private void btnbrowse_Click(object sender, EventArgs e)//browse btn
        {
            Startindex = 0;
            playnext = false;
            OpenFileDialog opnFileDlg = new OpenFileDialog();
            opnFileDlg.Multiselect = true;
            opnFileDlg.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.mp4;*.mp4;*.mov;*.wmv;*.mpg;*.avi;*.3gp;*.flv;|all files|*.*";
            if(opnFileDlg.ShowDialog()==DialogResult.OK)
            {
                Filename = opnFileDlg.SafeFileNames;
                FilePath = opnFileDlg.FileNames;
                for(int i=0; i <= Filename.Length -1; i++)
                {
                    listBox1.Items.Add(Filename[i]);
                }
                Startindex = 0;
                playfile(0);

            }
        }

        private void btnnowplay_Click(object sender, EventArgs e)//now playing btn
        {
            axWindowsMediaPlayer1.BringToFront();
        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)//volume progers bar
        {
            axWindowsMediaPlayer1.settings.volume = bunifuSlider1.Value;
            bunifuCustomLabel3.Text = bunifuSlider1.Value.ToString();//volum
        }

        private void play_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void pause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        public EventHandler onActon = null;
        private void actionbtn_Click(object sender, EventArgs e)//pause
        {
            isplaying = !isplaying;
            if(onActon !=null)
            {
                onActon.Invoke(this, e);
            }
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)//stop
        {
            StopPlayer();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)//next
        {
            if(Startindex==listBox1.Items.Count -1)
            {
                Startindex = listBox1.Items.Count - 1;
            }
            else if (Startindex <listBox1.Items.Count)
            {
                Startindex = Startindex + 1;
            }
            playfile(Startindex);
        }

        private void btnback_Click(object sender, EventArgs e)//back
        {
            if(Startindex >0 )
            {
                Startindex = Startindex - 1;
            }
            playfile(Startindex);
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)//play
        {
            if(axWindowsMediaPlayer1.playState==WMPLib.WMPPlayState.wmppsPlaying)
            {
                bunifuProgressBar1.MaximumValue = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                timer1.Start();
            }
            else if (axWindowsMediaPlayer1.playState==WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer1.playState==WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
                bunifuProgressBar1.Value = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 5;
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)//back
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 5;
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)//goo
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition += 5;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)//mute
        {
            mutebttun.Show();
            axWindowsMediaPlayer1.settings.volume = 0;
            spkbtn.Hide();


        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)//go internet btn
        {
            Form2 from2 = new Form2();
            from2.Show();


            isplaying = !isplaying;
            if (onActon != null)
            {
                onActon.Invoke(this, e);
            }



        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)//about btn
        {
            Form3 from3 = new Form3();
            from3.Show();
        }

        private void mutebttun_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = bunifuSlider1.Value;
            mutebttun.Hide();
            spkbtn.Show();
        }

        private void m(object sender, PreviewKeyDownEventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = bunifuSlider1.Value;
            mutebttun.Hide();
            spkbtn.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //logo
        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {
            //progers bar
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            //time
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            //time
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            //name
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            //volume
        }

        private void bunifuImageButton2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Close();
        }

        private void btnsong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "P") { 
                listBox1.BringToFront(); //play list view
        }else
            { }
            if (e.KeyCode == Keys.Enter)
            {
                axWindowsMediaPlayer1.BringToFront(); //play view
                axWindowsMediaPlayer1.Ctlcontrols.play();// play
            }

            if (e.Control && e.KeyCode.ToString() == "O")
            {
                Startindex = 0;
                playnext = false;
                OpenFileDialog opnFileDlg = new OpenFileDialog();
                opnFileDlg.Multiselect = true;
                opnFileDlg.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.mp4;*.mp4;*.mov;*.wmv;*.mpg;*.avi;*.3gp;*.flv;|all files|*.*";
                if (opnFileDlg.ShowDialog() == DialogResult.OK)
                {
                    Filename = opnFileDlg.SafeFileNames;
                    FilePath = opnFileDlg.FileNames;
                    for (int i = 0; i <= Filename.Length - 1; i++)
                    {
                        listBox1.Items.Add(Filename[i]);
                    }
                    Startindex = 0;
                    playfile(0);

                }
            } // select file

            if (e.Control && e.KeyCode.ToString() == "I") { 
                Form2 from2 = new Form2();
            from2.Show();
            } // go internet

            if (e.KeyCode.ToString() == "M")
            {   if (axWindowsMediaPlayer1.settings.volume >= 1) { 
                mutebttun.Show();
                axWindowsMediaPlayer1.settings.volume = 0;
                spkbtn.Hide();
                } else
                {
                    mutebttun.Hide();
                    axWindowsMediaPlayer1.settings.volume = 100;
                    spkbtn.Show();
                }  // Mute Button

             }
            { }

            /*Play and pause button */
            if (e.KeyCode.ToString() == "P")    
                
            if (isplaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
                else
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }

            //maxium button    
            if (e.KeyCode.ToString() == "Z")
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }



        }

        private void btnnowplay_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void btnnowplay_KeyPress(object sender, KeyPressEventArgs e)
        {
           
               
        }

        private void btnbrowse_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            bunifuCustomLabel2.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString.ToString();
            if(axWindowsMediaPlayer1.playState==WMPLib.WMPPlayState.wmppsPlaying)
            {
                bunifuProgressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }
        }

        private void bunifuImageButton1_Click_2(object sender, EventArgs e)
        {
            Form4 from4 = new Form4();
            from4.Show();
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                listBox1.Items.Add(file);

                //drag & drop
                


            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // video next / back >>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //back
            if (keyData == Keys.Left)
            {
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 5;
                return true;
            }
            //next
            if (keyData == Keys.Right)
            {
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition += 5;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}
//Created By Anuradha Sanka HNDIT 2K18
