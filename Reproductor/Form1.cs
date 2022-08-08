using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Application.Exit();
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()== DialogResult.OK) {

                var playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("MyPlayList");

                foreach (string file in openFileDialog1.FileNames)
                {
                    var mediaItem = axWindowsMediaPlayer1.newMedia(file);
                    playlist.appendItem(mediaItem);
                }

                axWindowsMediaPlayer1.currentPlaylist = playlist;

                axWindowsMediaPlayer1.Ctlcontrols.play();

                pictureBox5.Visible = false;

                pictureBox3.Enabled = true;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.fullScreen = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                pictureBox5.Visible = true;
            }

            else if (e.newState == 2)
            {
                pictureBox5.Visible = true;
            }

            else
            {
                pictureBox5.Visible = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
