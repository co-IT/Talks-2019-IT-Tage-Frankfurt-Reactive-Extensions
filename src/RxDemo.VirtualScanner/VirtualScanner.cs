using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using RxDemo.VirtualScanner.Properties;

namespace RxDemo.VirtualScanner
{
    public partial class VirtualScanner : Form
    {
        public VirtualScanner()
        {
            InitializeComponent();
            CreateScanFile();
        }

        private static void CreateScanFile()
        {
            var path = Settings.Default.ScanTxtFilePath;

            if (!File.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.Create(path);
            }
        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {
            var file = Path.Combine(Path.GetTempPath(), "scan.txt");

            File.AppendAllLines(file, new []{txtBox.Text}, Encoding.UTF8);

            txtBox.Text = string.Empty;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtBox.Text = "123456";
        }
    }
}