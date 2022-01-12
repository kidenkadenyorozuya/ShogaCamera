using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ShogaCamera
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //
            var form = new VideoCaptureDeviceForm();
            //

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //
                videoSourcePlayer1.VideoSource = form.VideoDevice;
                //
                videoSourcePlayer1.Start();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoSourcePlayer1.VideoSource != null && videoSourcePlayer1.VideoSource.IsRunning)
            {
                videoSourcePlayer1.VideoSource.SignalToStop();
            }
        }

    }
}
