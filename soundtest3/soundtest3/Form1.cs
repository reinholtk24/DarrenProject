using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib; 

namespace soundtest3
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer myPlayer = new WindowsMediaPlayer(); 
        public Form1()
        {
            InitializeComponent();
            myPlayer.URL = "Recording.m4a";
            sync(); 
        }

        public void sync()
        {
            myPlayer.controls.play(); 
        }
    }
}
