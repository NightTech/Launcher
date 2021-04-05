using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherHash
{
    public partial class Form1 : Form
    {
        private List<string> lstFilesFound = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnHash_Click(object sender, EventArgs e)
        {
            try
            {
                string sDir = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "files");
                SHA1 sec = SHA1.Create();
                List<string> ret = new List<string>();

                if (DirSearch(sDir) == true)
                {
                    foreach (string file in lstFilesFound)
                    {
                        if (File.Exists(file))
                        {
                            using (var stream = File.OpenRead(file))
                            {
                                var hash = sec.ComputeHash(stream);
                                ret.Add(file.Replace(sDir + @"\", "") + "~" + BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant());
                            }
                        }
                    }

                    string hashes = string.Join(";", ret.Cast<string>().ToArray());
                    File.WriteAllText(Path.Combine(sDir, "hashlist.txt"), hashes);

                    Console.WriteLine("Abgeschlossen!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private Boolean DirSearch(string sDir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    lstFilesFound.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    DirSearch(d);
                }
                return true;
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
                return false;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(1);
        }


        private bool mouseIsDown;
        private Point firstPoint;
        private void LblBackgroundTop_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            if (e.Button == MouseButtons.Left)
                mouseIsDown = true;
        }
        private void LblBackgroundTop_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
        private void LblBackgroundTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

    }
}
