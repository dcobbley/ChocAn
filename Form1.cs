using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChocAn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            if(!Directory.Exists(path+@"members"))
                Directory.CreateDirectory(path + @"\members");
            if (!Directory.Exists(path + @"provider"))
                Directory.CreateDirectory(path + @"\provider");

        }
    }
}
