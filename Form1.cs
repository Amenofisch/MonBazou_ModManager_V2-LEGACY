using AutoUpdaterDotNET;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Net;
using System.Windows.Forms;

namespace MonBazou_ModManager_V2
{
    public partial class Form1 : Form
    {
        private const string changelogBackupUrl = "https://raw.githubusercontent.com/Amenofisch/MonBazouModRepo/main/changelog.txt";
        private const string changelogUrl = "https://pastebin.com/raw/JGDXLKCp";
        private const string modsBackupUrl = "aHR0cHM6Ly9yYXcuZ2l0aHVidXNlcmNvbnRlbnQuY29tL0FtZW5vZmlzY2gvTW9uQmF6b3VNb2RSZXBvL21haW4vbW9kREIudHh0";
        private const string modsUrl = "aHR0cHM6Ly9wYXN0ZWJpbi5jb20vcmF3LzdlMzlMYnFV";
        private const string bepinexUrl = "https://raw.githubusercontent.com/Amenofisch/MonBazouModRepo/main/BepInEx_x64_5.4.19.0.zip";
        private const string versionUrl = "https://pastebin.com/raw/EEjanzKa";
        private const string version = "1.2.5";
        private bool steamVersion;
        private string InstallLoc = "";
        private dynamic mod;

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static bool DownloadFile(string url, string path, string agent)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                    client.Headers.Add("user-agent", agent);
                    client.DownloadFile(new Uri(url), path);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Error(Exception ex, string errorCode, bool important, bool needsAttention)
        {
            if (important)
            {
                MessageBox.Show("Major error occured (ERRCODE: " + errorCode + ")\nPlease read #mods-faq \nPlease report to Amenofisch#5368 in #mods-general \n\n" + ex.ToString(), "Mod Manager - Mon Bazou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                Application.ExitThread();
                return;
            }
            else
            {
                if (needsAttention)
                {
                    MessageBox.Show("Minor error occured (ERRCODE: " + errorCode + ")\nPlease read #mods-faq \nPlease report this to Amenofisch#5368 in #mods-general! \n\n" + ex.ToString(), "Mod Manager - Mon Bazou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Minor error occured (ERRCODE: " + errorCode + ")\nPlease read #mods-faq \n\n" + ex.ToString(), "Mod Manager - Mon Bazou", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetInstallLoc() // Gets install location of Mon Bazou and returns it as a string
        {
            try
            {
                using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    RegistryKey registryKey2;
                    try
                    {
                        registryKey2 = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 1520370");
                    }
                    catch (Exception ex)
                    {
                        Error(ex, "INSTALLOCFAIL-SUBKEY/POSSPIR", important: true, needsAttention: false);
                        return "";
                    }
                    object value = registryKey2.GetValue("InstallLocation");
                    if (!string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        InstallLoc = value.ToString() + "\\";
                        steamVersion = true;
                        return value.ToString();
                    }
                    Error(new Exception("InstallLocation was Empty. Please make sure to select the right folder!"), "INSTALLOCFAIL", important: true, needsAttention: false);
                    return "";
                }
            }
            catch (Exception ex)
            {
                if (File.Exists("dir.txt"))
                {
                    string temp_path = File.ReadAllText("dir.txt");
                    if (File.Exists(temp_path + "\\Mon Bazou.exe"))
                    {
                        InstallLoc = temp_path.ToString();
                        steamVersion = false;
                        return temp_path.ToString();
                    }
                }
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select Mon Bazou Folder!";

                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);

                        if (File.Exists(fbd.SelectedPath + "\\Mon Bazou.exe"))
                        {
                            InstallLoc = fbd.SelectedPath.ToString();
                            steamVersion = false;
                            string createText = fbd.SelectedPath.ToString();
                            File.WriteAllText("dir.txt", createText);
                            return fbd.SelectedPath.ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                return "";
            }
        }

        private void SetupChangelog()
        {
            textBox1.ScrollBars = ScrollBars.Both;
            try
            {
                using (WebClient client = new WebClient()) // Gets changelog
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                    listView1.Items.Clear();
                    try
                    {
                        var changelog = client.DownloadString(changelogUrl);
                        textBox1.Text = changelog;
                    }
                    catch (Exception ex)
                    {
                        Error(ex, "CHANGELOG-MAIN/FAIL", false, true);
                        try
                        {
                            var changelog = client.DownloadString(changelogBackupUrl);
                            textBox1.Text = changelog;
                        }
                        catch (Exception ex2)
                        {
                            Error(ex2, "CHANGELOG-BACKUP/FAIL", false, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "Error downloading Changelog";
                Error(ex, "CHANGELOG-FULL/FAIL", false, true);
            }
        }

        private void LocSetup()
        {
            try
            {
                var installLoc = GetInstallLoc();
                if (!String.IsNullOrEmpty(installLoc))
                {
                    installLocLabel.BackColor = Color.GreenYellow;
                    installLocLabel.Text = "Mon Bazou Install Location: \n" + installLoc;
                    if (Directory.Exists(InstallLoc + @"\BepInEx\"))
                    {
                        bepinexLabel.Text = "BepInEx Installed? YES";
                        bepinexLabel.BackColor = Color.GreenYellow;
                        bepinexButton.Visible = true;
                        bepinexButton.Visible = true;
                        bepinexConfigButton.Visible = true;
                    }
                    else
                    {
                        bepinexLabel.Text = "BepInEx Installed? NO \nWill be installed when installing a mod";
                        bepinexLabel.BackColor = Color.Red;
                        bepinexButton.Visible = true;
                        bepinexButton.Visible = true;
                        bepinexConfigButton.Visible = true;
                    }
                    if (steamVersion == true)
                    {
                        steamLabel.Text = "Steam Version";
                        steamLabel.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        steamLabel.Text = "Cracked Version";
                        steamLabel.BackColor = Color.OrangeRed;
                    }
                }
                else
                {
                    throw new Exception("Couldn't find Mon Bazou Install Location! \n(installLoc string empty)");
                }
            }
            catch (Exception ex)
            {
                Error(ex, "GAME-INSTALL-LOC/FAIL", true, true);
            }
        }

        private bool CheckForUpdates()
        {
            LocSetup();
            for (int i = 0; i < mod.Count; i++)
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MonBazouModManager\" + mod[i].name.ToString() + ".txt"))
                {
                    string ver = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MonBazouModManager\" + mod[i].name.ToString() + ".txt");
                    if (ver != mod[i].version.ToString())
                    {
                        MessageBox.Show("Update available for " + mod[i].name.ToString(), "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateMod(i, false);
                        return true;
                    }
                }
            }
            return true;
        }

        private void UpdateModList()
        {
            if (Process.GetProcessesByName("Mon Bazou").Any())
            {
                MessageBox.Show("You may not use the Mod Manager while the game is running!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                Application.ExitThread();
                return;
            }
            using (WebClient client = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                string modsDownload;
                listView1.Items.Clear();
                try
                {
                    modsDownload = client.DownloadString(Base64Decode(modsUrl));
                    mod = JsonConvert.DeserializeObject(modsDownload);
                }
                catch (Exception ex)
                {
                    Error(ex, "MAIN-MOD-DB/FAIL", false, true);
                    try
                    {
                        modsDownload = client.DownloadString(Base64Decode(modsBackupUrl));
                        mod = JsonConvert.DeserializeObject(modsDownload);
                    }
                    catch (Exception ex2)
                    {
                        Error(ex2, "BACKUP-MOD-DB/FAIL", true, true);
                        Application.Exit();
                        Application.ExitThread();
                    }
                }
            }
            for (int i = 0; i < mod.Count; i++)
            {
                listView1.Items.Add(mod[i].name.ToString());
                if (mod[i].disabled.ToString() == "true")
                {
                    listView1.Items[i].BackColor = Color.Red;
                }
                if (mod[i].disabled.ToString() == "false")
                {
                    listView1.Items[i].BackColor = Color.Yellow;
                }
                if (mod[i].dllname.ToString() != "")
                {
                    if (File.Exists(InstallLoc + @"\BepInEx\plugins\" + mod[i].dllname.ToString()))
                    {
                        if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MonBazouModManager\" + mod[i].name.ToString() + ".txt"))
                        {
                            listView1.Items.Clear();
                            UpdateMod(i, false);
                        }
                        listView1.Items[i].BackColor = Color.GreenYellow;
                    }
                }
            }
            nameTextBox.Text = "";
            authorTextBox.Text = "";
            descTextBox.Text = "";
            versionTextBox.Text = "";
            gameVersionTextBox.Text = "";
            releaseDateTextBox.Text = "";
            installButton.Enabled = false;
            deinstallButton.Enabled = false;
            reasonLabel.Visible = false;
        }

        private void UpdateMod(int modId, bool forced)
        {
            if (Process.GetProcessesByName("Mon Bazou").Any())
            {
                MessageBox.Show("You may not use the Mod Manager while the game is running!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                Application.ExitThread();
                return;
            }
            try
            {
                listView1.Items.Clear();
                using (WebClient client = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                    Directory.CreateDirectory(InstallLoc + @"\BepInEx\plugins");
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MonBazouModManager\");
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MonBazouModManager\" + mod[modId].name.ToString() + ".txt", mod[modId].version.ToString());
                    if (mod[modId].isZip.ToString() == "false")
                    {
                        File.Delete(InstallLoc + @"\BepInEx\plugins\" + mod[modId].dllname.ToString());
                        if (DownloadFile(mod[modId].downloadurl.ToString(), InstallLoc + @"\BepInEx\plugins\" + mod[modId].dllname.ToString(), "Anything"))
                        {
                            if (!forced)
                            {
                                MessageBox.Show("Update for " + mod[modId].name.ToString() + " is done!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            Error(new Exception("Error while downloading MOD File"), "MOD-DOWNLOAD/UPDATE-FAIL", false, true);
                        }
                    }
                    if (mod[modId].isZip.ToString() == "true")
                    {
                        File.Delete(InstallLoc + @"\BepInEx\plugins\" + mod[modId].dllname.ToString());
                        if (DownloadFile(mod[modId].downloadurl.ToString(), InstallLoc + @"\BepInEx\plugins\" + mod[modId].zipname.ToString(), "Anything"))
                        {
                            ZipFile.ExtractToDirectory(InstallLoc + @"\BepInEx\plugins\" + mod[modId].zipname, InstallLoc + @"\BepInEx\plugins\");
                            File.Delete(InstallLoc + @"\BepInEx\plugins\" + mod[modId].zipname);
                            if (!forced)
                            {
                                MessageBox.Show("Update for " + mod[modId].name.ToString() + " is done!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            Error(new Exception("Error while downloading ZIP File"), "ZIP-DOWNLOAD/UPDATE-FAIL", false, true);
                        }
                    }
                }
                listView1.Items.Clear();
                UpdateModList();
            }
            catch (Exception ex)
            {
                Error(ex, "MOD-UPDATE-FAIL", false, true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            versionlabel.Text = "Version: v" + version.ToString();
            if (Process.GetProcessesByName("Mon Bazou").Any())
            {
                MessageBox.Show("You may not use the Mod Manager while the game is running!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                Application.ExitThread();
                return;
            }
            AutoUpdater.InstalledVersion = new Version(version); // Set Application Version Here
            AutoUpdater.UpdateMode = Mode.Forced;
            AutoUpdater.Mandatory = true;
            AutoUpdater.Start("https://pastebin.com/raw/NfBLWbSa");
            LocSetup();
            SetupChangelog();
            UpdateModList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                installButton.Enabled = true;
                reasonLabel.Visible = false;
                disabledLabel.Visible = false;
                nameTextBox.Text = mod[listView1.SelectedIndices[0]].name.ToString();
                authorTextBox.Text = mod[listView1.SelectedIndices[0]].author.ToString();
                descTextBox.Text = mod[listView1.SelectedIndices[0]].description.ToString();
                releaseDateTextBox.Text = mod[listView1.SelectedIndices[0]].releasedate.ToString();
                versionTextBox.Text = mod[listView1.SelectedIndices[0]].version.ToString();
                gameVersionTextBox.Text = mod[listView1.SelectedIndices[0]].gameversion.ToString();
                if (mod[listView1.SelectedIndices[0]].disabled.ToString() == "true")
                {
                    if (mod[listView1.SelectedIndices[0]].reason.ToString() != "")
                    {
                        reasonLabel.Text = "Reason: " + mod[listView1.SelectedIndices[0]].reason.ToString();
                    }
                    else
                    {
                        reasonLabel.Text = "Reason: Unspecified";
                    }
                    reasonLabel.Visible = true;
                    disabledLabel.Visible = true;
                    installButton.Enabled = false;
                    reasonLabel.Visible = true;
                }

                if (File.Exists(InstallLoc + @"\BepInEx\plugins\" + mod[listView1.SelectedIndices[0]].dllname.ToString()))
                {
                    listView1.Items[listView1.SelectedIndices[0]].BackColor = Color.GreenYellow;
                    installButton.Enabled = false;
                    deinstallButton.Enabled = true;
                }
            }
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("Mon Bazou").Any())
            {
                MessageBox.Show("You may not use the Mod Manager while the game is running!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                Application.ExitThread();
                return;
            }
            if (!String.IsNullOrEmpty(InstallLoc) && !String.IsNullOrEmpty(nameTextBox.Text))
            {
                try
                {
                    if (Directory.Exists(InstallLoc + @"\BepInEx\"))
                    {
                        using (WebClient client = new WebClient())
                        {
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                            Directory.CreateDirectory(InstallLoc + @"\BepInEx\plugins");
                            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MonBazouModManager\");
                            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MonBazouModManager\" + mod[listView1.SelectedIndices[0]].name.ToString() + ".txt", mod[listView1.SelectedIndices[0]].version.ToString());
                            if (mod[listView1.SelectedIndices[0]].isZip.ToString() == "false")
                            {
                                if (DownloadFile(mod[listView1.SelectedIndices[0]].downloadurl.ToString(), InstallLoc + @"\BepInEx\plugins\" + mod[listView1.SelectedIndices[0]].dllname.ToString(), "Anything"))
                                {
                                    MessageBox.Show("You can start the game now!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    Error(new Exception("Error while installing non-zip mod"), "INSTALLFAIL-NONZIP", false, true);
                                }
                            }
                            if (mod[listView1.SelectedIndices[0]].isZip.ToString() == "true")
                            {
                                if (DownloadFile(mod[listView1.SelectedIndices[0]].downloadurl.ToString(), InstallLoc + @"\BepInEx\plugins\" + mod[listView1.SelectedIndices[0]].zipname.ToString(), "Anything"))
                                {
                                    ZipFile.ExtractToDirectory(InstallLoc + @"\BepInEx\plugins\" + mod[listView1.SelectedIndices[0]].zipname, InstallLoc + @"\BepInEx\plugins\");
                                    File.Delete(InstallLoc + @"\BepInEx\plugins\" + mod[listView1.SelectedIndices[0]].zipname);
                                    MessageBox.Show("You can start the game now!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                } else
                                {
                                    Error(new Exception("Error while installing zip mod"), "INSTALLFAIL-ZIP", false, true);
                                }
                            }
                            UpdateModList();
                            LocSetup();
                        }
                    }
                    else
                    {
                        MessageBox.Show("BepInEx isn't installed \nInstalling it now...", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            if(Directory.Exists(InstallLoc + @"\BepInEx")){Directory.Delete(InstallLoc + @"\BepInEx");}
                            if(File.Exists(InstallLoc + @"\winhttp.dll")){File.Delete(InstallLoc + @"\winhttp.dll");}
                            if(File.Exists(InstallLoc + @"\changelog.txt")){File.Delete(InstallLoc + @"\changelog.txt");}
                            if(File.Exists(InstallLoc + @"\doorstop_config.ini")){File.Delete(InstallLoc + @"\doorstop_config.ini");}
                            if(DownloadFile(bepinexUrl, InstallLoc + @"\BepInEx.zip", "Anything"))
                            {
                                ZipFile.ExtractToDirectory(InstallLoc + @"\BepInEx.zip", InstallLoc);
                                File.Delete(InstallLoc + @"\BepInEx.zip");
                            } else
                            {
                                throw new Exception("Error while downloading BepInEx and Extracting.");
                            }
                        } catch (Exception ex)
                        {
                            Error(ex, "WHILE-BEPINEX/INSTALL-FAIL", true, true);
                        }
                       
                        try
                        {
                            Directory.CreateDirectory(InstallLoc + @"\BepInEx\plugins");
                            if(DownloadFile(mod[listView1.SelectedIndices[0]].downloadurl.ToString(), InstallLoc + @"\BepInEx\plugins\" + mod[listView1.SelectedIndices[0]].dllname.ToString(), "Anything"))
                            {
                                MessageBox.Show("BepInEx and Mod installed! \nYou can start the game now!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                throw new Exception("Error while downloading BepInEx and Extracting.");
                            } 
                            
                        } catch (Exception ex)
                        {
                            Error(ex, "AFTER-BEPINEX/MODINSTALL-FAIL", false, true);
                        }
                        listView1.Items.Clear();
                        UpdateModList();
                        LocSetup();
                    }
                }
                catch (Exception ex)
                {
                    Error(ex, "MOD-INSTALL-FAIL", false, true);
                }
            }
        }

        private void deinstallButton_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("Mon Bazou").Any())
            {
                MessageBox.Show("You may not use the Mod Manager while the game is running!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                Application.ExitThread();
                return;
            }
            listView1.Items[listView1.SelectedIndices[0]].BackColor = Color.Yellow;
            try
            {
                File.Delete(InstallLoc + @"\BepInEx\plugins\" + mod[listView1.SelectedIndices[0]].dllname.ToString());
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MonBazouModManager\" + mod[listView1.SelectedIndices[0]].name.ToString() + ".txt");
                if (mod[listView1.SelectedIndices[0]].isZip.ToString() == "true")
                {
                    Directory.Delete(InstallLoc + @"\BepInEx\plugins\" + mod[listView1.SelectedIndices[0]].name.ToString());
                }
                MessageBox.Show("You can start the game now!", "Mon Bazou - Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Error(ex, "MOD-UNINSTALL-FAIL", false, true);
            }
            UpdateModList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://pastebin.com/raw/NfBLWbSa");
        }

        private void forceUpdateButton_Click(object sender, EventArgs e)
        {
            LocSetup();
            UpdateModList();
            for (int i = 0; i < mod.Count; i++)
            {
                if (File.Exists(InstallLoc + @"\BepInEx\plugins\" + mod[i].dllname.ToString()))
                {
                    UpdateMod(i, true);
                }
            }
            MessageBox.Show("Force Update Done ", "Mod Manager - Mon Bazou", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            LocSetup();
            UpdateModList();
            CheckForUpdates();
        }

        private void bepinexButton_Click(object sender, EventArgs e)
        {
            Process.Start(InstallLoc + @"\BepInEx\");
        }

        private void bepinexConfigButton_Click(object sender, EventArgs e)
        {
            Process.Start(InstallLoc + @"\BepInEx\config");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/6NYFSTDuWU");
        }

        private void changelogLabel_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sui);
            player.Play();
        }
    }
}