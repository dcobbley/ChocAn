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
            if (!Directory.Exists(path + @"consultation"))
                Directory.CreateDirectory(path + @"\consultation");
            if (!Directory.Exists(path + @"providerServiceCodes"))
                Directory.CreateDirectory(path + @"\providerServiceCodes");

            //Test

            /*
            //member test.
            Info temp = new Info();
            temp.name = "David Cobbley";
            temp.ID = 123456789;
            temp.address = "4600 Nw 174th ave.";
            temp.city = "portland";
            temp.zip = 97229;
            temp.valid = "valid";

            Members.addMembers(temp);
            */

            //consultation test
            Consultation consultationTest = new Consultation("11-30-12", "11:24:13", "11-30-12", "these are my comments", 123456789, 987654321, 135246);
            consultationTest.writeServiceToDisk();
            
        }
        public void countFiles()
        {
            string path = Directory.GetCurrentDirectory();
            int count = 0;
            DirectoryInfo dir = new DirectoryInfo(path + @"\consultation");
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            foreach (FileSystemInfo fsi in infos)
            {
                ++count;
            }
            MessageBox.Show("The total number of files in the folder is: " + count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //countFiles();

            //consultation test
            Consultation consultationTest = new Consultation("11-30-12", "11:24:13", "11-30-12", "these are my comments", 123456789, 987654321, 135246);
            consultationTest.writeServiceToDisk();
        }
    }
}
