using Microsoft.Win32;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NTLauncher
{
    public partial class LauncherWindow : Form
    {
        private HashSet<string> lstFilesFound = new HashSet<string>();
        private static Color activeButton = Color.FromArgb(58, 173, 87); //active button green
        private static Color inactiveButton = Color.FromArgb(240, 245, 245); //active button green

        public LauncherWindow()
        {
            InitializeComponent();

            BtnCancel.Enabled = false;

            try
            {
                using (new WebClient().OpenRead("http://clients3.google.com/generate_204"))
                {
                    //working just fine, do nothing
                }
            }
            catch
            {
                if (MessageBox.Show("Zur Nutzung des Launchers wird eine aktive Internetverbindung benötigt.\nBitte prüfe deine Internetverbdingung und versuche es noch einmal.",
                        "Keine Internetverbindung", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) != DialogResult.None)
                {
                    Application.Exit();
                    Environment.Exit(1);
                };
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtPath.Text = Properties.Settings.Default.SavePath;
            LblVersion.Text = ("Version: " + Properties.Settings.Default.Version).Replace(",", ".");
            this.Controls.Add(PicStatus);
            //RichTest.BackColor = Color.Transparent;
            RichTest.Text += "\nKerne: " + GetCoreCount() + "/" + Environment.ProcessorCount;
            RichTest.Text += "\nRAM: " + GetMemoryCount() + "MB";
            RichTest.Text += "\nVRAM: " + GetVideoMemory() + "MB";
            RichTest.Text += "\nRegistry: " + Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 107410", "InstallLocation", "Error");

            try
            {
                FtpWebRequest DLrequest = (FtpWebRequest)WebRequest.Create(getFtpUrl() + "version.txt");
                DLrequest.Method = WebRequestMethods.Ftp.DownloadFile;
                DLrequest.Credentials = getCredentials();
                float version = Single.Parse(new StreamReader(DLrequest.GetResponse().GetResponseStream()).ReadToEnd());

                if (!version.Equals(Properties.Settings.Default.Version))
                {
                    //version incorrect
                    if (MessageBox.Show("Es steht ein Update für den Launcher zur Verfügung. Dieses wird automatisch heruntergeladen.\n" +
                        "Sobald der Download abgeschlossen ist, wird die Installation automatisch gestartet und dieser Launcher geschlossen.",
                         "Neue Version verfügbar", MessageBoxButtons.OK, MessageBoxIcon.Information) != DialogResult.None)
                    {
                        this.Enabled = false;
                        BackUpdater.RunWorkerAsync(argument: version);
                    };
                }
            }
            catch (WebException webExcp)
            {
                CatchFTPExceptions(webExcp);
            }
        }

        private void InitializeUpdate(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string newVersion = Convert.ToString((Single)e.Argument);

            try
            {
                string fileName = "NTLauncher.msi";
                string updateFolder = "updates";
                string savePath = Path.Combine(updateFolder, newVersion);
                string appPath = Application.StartupPath;
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                FtpWebRequest DLrequest = (FtpWebRequest)WebRequest.Create(getFtpUrl() + fileName);
                DLrequest.UseBinary = true;
                DLrequest.KeepAlive = false;
                DLrequest.Method = WebRequestMethods.Ftp.DownloadFile;

                if (!Directory.Exists(Path.Combine(documents, "NTLauncher", updateFolder)))
                    Directory.CreateDirectory(Path.Combine(documents, "NTLauncher", updateFolder));

                Directory.CreateDirectory(Path.Combine(documents, "NTLauncher", savePath));

                using (Stream ftpStream = DLrequest.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(Path.Combine(documents, "NTLauncher", savePath, fileName)))
                {
                    ftpStream.CopyTo(fileStream);
                }

                Process.Start(Path.Combine(documents, "NTLauncher", savePath, fileName));
                Application.Exit();
                Environment.Exit(1);
            }
            catch (WebException webExcp)
            {
                CatchFTPExceptions(webExcp);

                Application.Exit();
                Environment.Exit(1);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Der eingegebene Pfad ist leer oder existiert nicht", "Fehler: Speicherpfad existiert nicht",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Console.WriteLine("A FileNotFoundException has been caught.");
                Console.WriteLine(ex.ToString());

                Application.Exit();
                Environment.Exit(1);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Der angegebene Pfad erfordert höhere Berechtigungen.\n" +
                    "Bitte starte das Programm mit Administrator Berechtigngen neu oder wähle einen anderen Speicherpfad.",
                    "Fehler: keine Berechtigungen", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Console.WriteLine("A FileNotFoundException has been caught.");
                Console.WriteLine(ex.ToString());

                Application.Exit();
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("other exception caught!");
                Console.WriteLine(ex.ToString());

                Application.Exit();
                Environment.Exit(1);
            }
        }

        private int GetCoreCount()
        {
            int coreCount = 0;
            foreach (var item in new ManagementObjectSearcher("Select NumberOfCores from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }
            return coreCount;
        }

        private int GetMemoryCount()
        {
            double res = 0;
            foreach (ManagementObject result in new ManagementObjectSearcher(new ObjectQuery("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem")).Get())
            {
                res = Convert.ToDouble(result["TotalVisibleMemorySize"]);
            }
            return Convert.ToInt32(res / 1024);
        }

        private int GetVideoMemory()
        {
            int vram = 0;
            foreach (ManagementObject mo in new ManagementObjectSearcher("select AdapterRAM from Win32_VideoController").Get())
            {
                var ram = mo.Properties["AdapterRAM"].Value as UInt32?;
                if (ram.HasValue)
                {
                    vram = (int)(ram / 1048576);
                }
            }
            return vram;
        }

        private void CatchFTPExceptions(WebException webExcp)
        {
            Console.WriteLine("A WebException has been caught.");
            Console.WriteLine(webExcp.ToString());
            WebExceptionStatus status = webExcp.Status;

            if (status == WebExceptionStatus.ProtocolError)
            {
                Console.Write("The server returned protocol error ");
                FtpWebResponse ftpResponse = (FtpWebResponse)webExcp.Response;
                Console.WriteLine((int)ftpResponse.StatusCode + " - "
                   + ftpResponse.StatusCode);

                int errorCode = (int)ftpResponse.StatusCode;
                string errorTitle = "";
                string errorMsg = "";

                switch (errorCode)
                {
                    case 421:
                        errorTitle = "Fehler: Konnte keine Verbindung herstellen";
                        errorMsg = "Es konnte keine Verbindung zum Server hergestellt werden.\nBitte prüfe, ob innerhalb der nächsten Stunde ein Modupdate angekündigt wurde." +
                            "\n\n\nErrorcode: " + errorCode;
                        break;

                    default:
                        errorTitle = "Fehler: Konnte keine Verbindung herstellen";
                        errorMsg = "Es konnte keine Verbindung zum Server hergestellt werden.\n\n\nErrorcode: " + errorCode;
                        break;
                }
                if (MessageBox.Show(errorMsg,
                errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) != DialogResult.None)
                {
                    Application.Exit();
                    Environment.Exit(1);
                };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!BackDownloader.IsBusy)
            {
                resultLabel.Text = "Überprüfe Dateien... Dieser Vorgang kann einige Minuten dauern";
                PicStatus.Image = Properties.Resources.download;
                BackDownloader.RunWorkerAsync();
                BtnCancel.Enabled = true;
                BtnDownload.Enabled = false;
                BtnStartGame.Enabled = false;
            }
        }

        private void ResetImage()
        {
            PicStatus.Image = null;
        }

        public delegate void UpdateFileNameCallback(Label target, string name, bool hash = false);
        private void UpdateFileName(Label target, string name, bool hash = false)
        {
            if (hash)
            {
                target.Text = "Erstelle Hash: " + name;
            }
            else
            {
                target.Text = "Lade herunter: " + name;
            }
        }

        public delegate void UpdateProgressCallback(ProgressBar target, int progress);
        private void UpdateProgress(ProgressBar target, int progress)
        {
            target.Value = progress;
        }

        private void BackHashing_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void BackHashing_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            /*ProgressDownload.Value = (e.ProgressPercentage);
            resultLabel.Text = ("Downloading: " + e.ProgressPercentage + "%");*/
        }
        private void BackHashing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*if (e.Cancelled)
            {
                resultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
                MessageBox.Show("Alle Dateien wurden erfolgreich heruntergeladen", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            try
            {
                HashSet<HashSet<string>> hash = CheckHashes();
                HashSet<string> toDelete = hash.ElementAt(0);
                HashSet<string> toDownload = hash.ElementAt(1);

                DeleteFiles(toDelete);
                worker.ReportProgress(0);

                //List<string> files = getAllFiles();
                string savePath = getSavePath();

                float progress = 0;
                float total = toDownload.Count;
                int percent = 0;

                foreach (string file in toDownload)
                {
                    LblFilename.Invoke(new UpdateFileNameCallback(UpdateFileName), new object[] { LblFilename, file, false });

                    string subPath = Regex.Replace(file, @"\\([\w_-]*)\.\w*", "");
                    if (subPath.Equals(file))
                    {
                        subPath = "";
                    }
                    else
                    {
                        subPath += @"\";
                    }
                    string[] path = subPath.Split(Convert.ToChar(@"\"));
                    string fileName = Regex.Replace(file, @".*\w*\\", "");
                    FtpWebRequest DLrequest = (FtpWebRequest)WebRequest.Create(getFtpUrl() + file);

                    DLrequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    DLrequest.Credentials = getCredentials();
                    /*DLrequest.Proxy = null;
                    DLrequest.UseBinary = true;
                    DLrequest.UsePassive = false;*/

                    string temp = "";
                    foreach (string p in path)
                    {
                        string workingPath = savePath + temp + p;
                        if (!Directory.Exists(workingPath))
                        {
                            Directory.CreateDirectory(workingPath);
                        }

                        temp += p + @"\";
                    }

                    using (Stream ftpStream = DLrequest.GetResponse().GetResponseStream())
                    using (Stream fileStream = File.Create(savePath + subPath + fileName))
                    {
                        ftpStream.CopyTo(fileStream);
                    }

                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    percent = (int)Math.Round((++progress / total) * 100);
                    worker.ReportProgress(percent);
                }

                PicStatus.Image = Properties.Resources.downloadFin;
            }
            catch (WebException webExcp)
            {
                ResetImage();
                CatchFTPExceptions(webExcp);
            }
            catch (DirectoryNotFoundException ex)
            {
                ResetImage();
                MessageBox.Show("Der eingegebene Pfad ist leer oder existiert nicht", "Fehler: Speicherpfad existiert nicht",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Console.WriteLine("A FileNotFoundException has been caught.");
                Console.WriteLine(ex.ToString());
            }
            catch (UnauthorizedAccessException ex)
            {
                ResetImage();
                MessageBox.Show("Der angegebene Pfad erfordert höhere Berechtigungen.\n" +
                    "Bitte starte das Programm mit Administrator Berechtigngen neu oder wähle einen anderen Speicherpfad.",
                    "Fehler: keine Berechtigungen", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Console.WriteLine("A FileNotFoundException has been caught.");
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                ResetImage();
                Console.WriteLine("other exception caught!");
                Console.WriteLine(ex.ToString());
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressDownload.Value = (e.ProgressPercentage);
            resultLabel.Text = ("Downloading: " + e.ProgressPercentage + "%");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnCancel.Enabled = false;
            BtnDownload.Enabled = true;
            LblFilename.Text = "";
            BtnStartGame.Enabled = true;
            if (e.Cancelled)
            {
                ProgressDownload.Value = 1;
                resultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
                MessageBox.Show("Alle Dateien wurden erfolgreich heruntergeladen", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteFiles(HashSet<string> toDelete)
        {
            string savePath = getSavePath();
            try
            {
                Console.WriteLine(string.Join("\n", toDelete.Cast<string>().ToArray()));
                Console.WriteLine("------------------");
                foreach (string file in toDelete)
                {
                    Console.WriteLine(file);
                    File.Delete(savePath + file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        private NetworkCredential getCredentials()
        {
            return new NetworkCredential("user", "´pw");
        }

        private string getFtpUrl()
        {
            string adress = "ftp://ftpserverurl.de/";
            return adress;
        }

        private string getSavePath()
        {
            string path = TxtPath.Text;
            if (Directory.Exists(path) && !path.Equals(""))
            {
                return (path + @"\");
            }
            else
            {
                throw new DirectoryNotFoundException("Save Path is not defined");
            }
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string savePath = folderBrowserDialog1.SelectedPath;
                TxtPath.Text = savePath;
                Properties.Settings.Default.SavePath = savePath;
                Properties.Settings.Default.Save();
            }
        }

        private HashSet<HashSet<string>> CheckHashes()
        {
            string hashes = Properties.Settings.Default.FileHash;
            Dictionary<string, string> serverHash = new Dictionary<string, string>();
            Dictionary<string, string> clientHash = new Dictionary<string, string>();

            try
            {
                FtpWebRequest DLrequest = (FtpWebRequest)WebRequest.Create(getFtpUrl() + "hashlist.txt");
                DLrequest.UseBinary = true;
                DLrequest.KeepAlive = false;
                DLrequest.Method = WebRequestMethods.Ftp.DownloadFile;
                DLrequest.Credentials = getCredentials();
                Stream ftpStream = DLrequest.GetResponse().GetResponseStream();
                string sHashes = new StreamReader(ftpStream).ReadToEnd();
                foreach (string entry in sHashes.Split(';'))
                {
                    string[] e = entry.Split('~');
                    if (!serverHash.ContainsKey(e[0]))
                    {
                        serverHash.Add(e[0], e[1]);
                    }
                }
            }
            catch (WebException excp)
            {
                CatchFTPExceptions(excp);
                return new HashSet<HashSet<string>>();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
                return new HashSet<HashSet<string>>();
            }

            if (true)
            {
                string sDir = TxtPath.Text;
                SHA1 sec = SHA1.Create();
                HashSet<string> retVal = new HashSet<string>();

                if (DirSearch(sDir) == true)
                {
                    float fileCount = lstFilesFound.Count;
                    float count = 0;
                    foreach (string file in lstFilesFound)
                    {
                        count++;
                        if (File.Exists(file) && file.Contains(@"@NTLauncherRPG"))
                        {
                            using (var stream = File.OpenRead(file))
                            {
                                var hash = sec.ComputeHash(stream);
                                retVal.Add(file.Replace(sDir + @"\", "") + "~" + BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant());

                                //change percentage
                                LblFilename.Invoke(new UpdateFileNameCallback(UpdateFileName), new object[] { LblFilename, file, true });
                                ProgressDownload.Invoke(new UpdateProgressCallback(UpdateProgress), new object[] { ProgressDownload, (int)Math.Round((count / fileCount) * 100) });
                            }
                        }
                    }

                    hashes = string.Join(";", retVal.Cast<string>().ToArray());
                    Properties.Settings.Default.FileHash = hashes;
                    Properties.Settings.Default.Save();
                }

                if (!hashes.Equals(""))
                {
                    clientHash = new Dictionary<string, string>();
                    foreach (string entry in hashes.Split(';'))
                    {
                        string[] e = entry.Split('~');
                        if (!clientHash.ContainsKey(e[0]))
                        {
                            clientHash.Add(e[0], e[1]);
                        }
                    }
                }
            }

            HashSet<string> toDownload = new HashSet<string>();
            HashSet<string> toDelete = new HashSet<string>();
            foreach (KeyValuePair<string, string> kvp in serverHash)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                if (!clientHash.ContainsKey(key))
                {
                    toDownload.Add(key);
                }
                else if (!value.Equals(clientHash[key]))
                {
                    toDownload.Add(key);
                }
            }
            foreach (KeyValuePair<string, string> kvp in clientHash)
            {
                string key = kvp.Key;
                string value = kvp.Value;
                if (!serverHash.ContainsKey(key))
                {
                    if (key.Contains(@"@NTLauncherRPG"))
                    {
                        toDelete.Add(key);
                    }
                }
            }
            foreach (string file in toDownload)
            {
                string path = getSavePath();
                if (File.Exists(path + file))
                {
                    toDelete.Add(file);
                }
            }

            HashSet<HashSet<string>> ret = new HashSet<HashSet<string>>();
            ret.Add(toDelete);
            ret.Add(toDownload);
            return ret;
        }

        private Boolean DirSearch(string sDir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (f.Contains(@"@NTLauncherRPG"))
                    {
                        lstFilesFound.Add(f);
                    }
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (BackDownloader.WorkerSupportsCancellation)
            {
                // Cancel the asynchronous operation.
                BackDownloader.CancelAsync();
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

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            BtnStartGame.Enabled = false;

            if (IsProcessOpen("arma3"))
            {
                MessageBox.Show("Es wurde eine bereits laufende Instanz von Arma 3 erkannt. Bitte stelle sicher, dass Arma 3 nicht im Hintergrund läuft, bevor du das Spiel versuchst zu starten.",
                    "Fehler: Prozess läuft bereits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnStartGame.Enabled = true;
                return;
            }

            string path = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 107410", "InstallLocation", "Error");
            if (path == "Error")
            {
                MessageBox.Show("Der Installationspfad von Arma 3 konnte nicht gefunden werden. Bitte überprüfe über Steam deine Installation.",
                    "Fehler: konnte Installation nicht finden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnStartGame.Enabled = true;
                return;
            }
            string parameters = " -skipIntro -nosplash";
            string mod = " \"-mod=" + Path.Combine(getSavePath(), @"@NTLauncher") + "\"";
            path = ToLiteral(Path.Combine(path, "arma3battleye.exe")); //set path and escape spaces

            string applicationParams = " 2 1 0 -exe arma3.exe";
            if (check64bit.Checked)
            {
                applicationParams = " 2 1 0 -exe arma3_x64.exe";
            }
            if (checkConnectServer.Checked)
            {
                parameters += " -connect=game.nighttech.de -port=2302";
            }
            if (checkDebug.Checked)
            {
                parameters += " -showScriptErrors";
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = @"cmd",
                Arguments = "/C start \"Arma\" /realtime " + path + applicationParams + parameters + mod,
                WindowStyle = ProcessWindowStyle.Hidden
            }; //create stub-progress
            Process.Start(psi); //execute stub
            BtnStartGame.Enabled = true;

        }

        private static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }

        private bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.ToLower().Contains(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
