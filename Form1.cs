using System;
using System.IO;
using System.Security.Cryptography;

namespace Ascendency_II_Manifest_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string dir = @"C:\Users\Public\Games\Ascendency TC";
            try
            {
                //Set the current directory.
                Directory.SetCurrentDirectory(dir);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(textBox1.Text))
                {
                    var hash = md5.ComputeHash(stream);
                    textBox2.Text = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}