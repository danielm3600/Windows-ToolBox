using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Management;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Collections.Generic;
using System.Text;

namespace Hone_sucks
{
    public partial class Form1 : Form
    {
        private const string FolderPath = @"C:\Program Files (x86)\WindowsToolBox";
        private const string ConfigFilePath = @"C:\Program Files (x86)\WindowsToolBox\Config.ini";

        Dictionary<string, System.Windows.Forms.CheckBox> checkboxMap = new Dictionary<string, System.Windows.Forms.CheckBox>();

        bool config_isLoading = false;

        private void CreateConfigFileIfNotExist()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            if (!File.Exists(ConfigFilePath))
            {
                using (StreamWriter sw = File.CreateText(ConfigFilePath))
                {

                }
            }
        }

        private void LoadConfig(Dictionary<string, System.Windows.Forms.CheckBox> checkboxMap)
        {
            config_isLoading = true;

            string[] configLines = File.ReadAllLines(ConfigFilePath);
            foreach (string line in configLines)
            {
                System.Windows.Forms.CheckBox Foundcheckbox = this.Controls.Find(line, true).FirstOrDefault() as System.Windows.Forms.CheckBox;
                checkboxMap[line] = Foundcheckbox;
                Foundcheckbox.Checked = true;

            }

            config_isLoading = false;
        }

        private void SaveConfig(Dictionary<string, System.Windows.Forms.CheckBox> checkboxMap)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ConfigFilePath))
                {
                    foreach (string checkboxName in checkboxMap.Keys)
                    {
                        sw.WriteLine(checkboxName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving configuration file: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Form1()
        {
            InitializeComponent();

            CreateConfigFileIfNotExist();
            LoadConfig(checkboxMap);
        }

        // Constants for power settings
        private const uint GUID_PROCESSOR_SETTINGS_SUBGROUP = 0x54533251;
        private const uint PROCESSOR_THROTTLE_DISABLE = 0x3f5b3fe3;

        // Import necessary Windows API functions
        [DllImport("powrprof.dll", SetLastError = true)]
        static extern UInt32 PowerGetActiveScheme(IntPtr UserRootPowerKey, out IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll", SetLastError = true)]
        static extern UInt32 PowerWriteACValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, uint AcValueIndex);

        [DllImport("powrprof.dll", SetLastError = true)]
        static extern UInt32 PowerWriteDCValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, uint DcValueIndex);


        private void Form1_Load(object sender, EventArgs e) { }

        private async Task<string> GetLatestTag(string owner, string repo)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("C# HttpClient");

                HttpResponseMessage response = await httpClient.GetAsync($"https://api.github.com/repos/{owner}/{repo}/releases/latest");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response to get the tag name
                dynamic release = System.Text.Json.JsonSerializer.Deserialize<dynamic>(responseBody);
                string latestTag = release["tag_name"];

                return latestTag;
            }
        }

        static void SetServiceStartupType(int startupType, string serviceName)
        {
            try
            {
                string registryPath = $@"SYSTEM\CurrentControlSet\Services\{serviceName}";
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath, true))
                {
                    if (key != null)
                    {
                        key.SetValue("Start", startupType, RegistryValueKind.DWord);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to access the registry key for {serviceName}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Error: Unauthorized access - {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteRegistryKey(string fullKeyPath)
        {
            try
            {
                // Split the full key path into hive and subkey path
                int idx = fullKeyPath.IndexOf('\\');
                string hiveName = fullKeyPath.Substring(0, idx);
                string subKeyPath = fullKeyPath.Substring(idx + 1);

                // Get the base registry key corresponding to the hive
                RegistryKey baseKey = null;
                switch (hiveName.ToUpper())
                {
                    case "HKEY_CLASSES_ROOT":
                        baseKey = Registry.ClassesRoot;
                        break;
                    case "HKEY_CURRENT_USER":
                        baseKey = Registry.CurrentUser;
                        break;
                    case "HKEY_LOCAL_MACHINE":
                        baseKey = Registry.LocalMachine;
                        break;
                    case "HKEY_USERS":
                        baseKey = Registry.Users;
                        break;
                    case "HKEY_CURRENT_CONFIG":
                        baseKey = Registry.CurrentConfig;
                        break;
                    default:
                        throw new ArgumentException($"Invalid hive name: {hiveName}");
                }

                // Open the subkey and delete its entire tree
                using (RegistryKey key = baseKey.OpenSubKey(subKeyPath, true))
                {
                    if (key != null)
                    {
                        baseKey.DeleteSubKeyTree(subKeyPath);
                        MessageBox.Show($"Registry key '{fullKeyPath}' deleted successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Registry key '{fullKeyPath}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting registry key '{fullKeyPath}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CreateRegistryKey(string keyPath, string keyName)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath + "\\" + keyName))
                {
                    if (key == null)
                    {
                        MessageBox.Show($"Failed to create registry key '{keyName}' under '{keyPath}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating registry key '{keyName}' under '{keyPath}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void SetRegistryValue(string key, string name, object value, RegistryValueKind kind) // Set an existing or CREATE a new under the name
        {
            try
            {
                Registry.SetValue(key, name, value, kind);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to set {name} at {key}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void RunBcdeditCommand(string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "bcdedit.exe",
                Arguments = arguments,
                UseShellExecute = true,
                Verb = "runas"
            };

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    MessageBox.Show($"bcdedit command failed with exit code {process.ExitCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CheckBox_checkChanged(object sender, EventArgs e)
        {
            // regedit value
            Int32 value = 0x00000000;

            System.Windows.Forms.CheckBox checkBox = sender as System.Windows.Forms.CheckBox;

            // Checks if the config is not loading to prevent the config re-applying the settings
            if (!config_isLoading)
            {
                if (checkBox != null)
                {
                    string checkboxName = checkBox.Name;
                    if (checkBox.Checked)
                    {
                        checkboxMap[checkboxName] = checkBox;
                    }
                    else
                    {
                        checkboxMap.Remove(checkboxName);
                    }

                    switch (checkBox.Name)
                    {
                        case "restore":
                            if (restore.Checked)
                            {
                                string exeFilePath = @"C:\Windows\System32\SystemPropertiesProtection.exe";

                                try
                                {
                                    ProcessStartInfo startInfo = new ProcessStartInfo();
                                    startInfo.FileName = exeFilePath;
                                    startInfo.UseShellExecute = true;

                                    Process.Start(startInfo);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        case "xboxGameBar":
                            if (!xboxGameBar.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Game Bar
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "AllowAutoGameMode", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "ShowStartupPanel", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "AutoGameModeEnabled", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "UseNexusForGameBarEnabled", value, RegistryValueKind.DWord);

                            // Game DVR
                            SetRegistryValue("HKEY_CURRENT_USER\\System\\GameConfigStore", "GameDVR_Enabled", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", "AllowGameDVR", value, RegistryValueKind.DWord);
                            break;
                        case "cortana":
                            if (!cortana.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Cortana
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", "AllowCortana", value, RegistryValueKind.DWord);
                            break;
                        case "PrintAndFax":
                            if (PrintAndFax.Checked)
                            {
                                SetServiceStartupType(4, "Spooler");
                                SetServiceStartupType(4, "Fax");
                            }
                            else
                            {
                                SetServiceStartupType(2, "Spooler");
                                SetServiceStartupType(2, "Fax");
                            }
                            break;
                        case "easeofAccess":
                            Int32 value2 = 0x00000001; // Disable

                            if (!easeOfAccess.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                                value2 = 0x00000000; // Enable (default)
                            }

                            // Magnifier
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Narrator", "Magnifier", value, RegistryValueKind.DWord);
                            // Narrator
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Narrator", "NoRoam", value2, RegistryValueKind.DWord);
                            // On-Screen Keyboard
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI\\Roam", "NoLockScreen", value2, RegistryValueKind.DWord);
                            break;
                        case "snapAssist":
                            value = 0x00000000; // Disable

                            if (!snapAssist.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Focus Assist
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", "NOC_GLOBAL_SETTING_TOASTS_ENABLED", value, RegistryValueKind.DWord);
                            break;
                        case "errorReporting":
                            value = 0x00000001; // Disable

                            if (!errorReporting.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            // Error Reporting
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\Windows Error Reporting", "Disabled", value, RegistryValueKind.DWord);
                            break;
                        case "disableInsider":
                            if (disableInsider.Checked)
                            {
                                SetServiceStartupType(4, "wisvc");
                            }
                            else
                            {
                                SetServiceStartupType(3, "wisvc");
                            }
                            break;
                        case "disablesearchIndex":
                            if (disablesearchIndex.Checked)
                            {
                                SetServiceStartupType(4, "WSearch");
                            }
                            else
                            {
                                SetServiceStartupType(2, "WSearch");
                            }
                            break;
                        case "disableXbox":
                            if (disableXbox.Checked)
                            {
                                SetServiceStartupType(4, "XboxGipSvc");
                                SetServiceStartupType(4, "XblAuthManager");
                                SetServiceStartupType(4, "XblGameSave");
                                SetServiceStartupType(4, "XboxNetApiSvc");
                            }
                            else
                            {
                                SetServiceStartupType(3, "XboxGipSvc");
                                SetServiceStartupType(3, "XblAuthManager");
                                SetServiceStartupType(3, "XblGameSave");
                                SetServiceStartupType(3, "XboxNetApiSvc");
                            }
                            break;
                        case "touchSettings":
                            value = 0x00000001; // Disable

                            if (!touchSettings.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            // Touch Keyboard
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\TabletTip\\1.7", "DisableTouchKeyboard", value, RegistryValueKind.DWord);
                            break;
                        case "taskBarStart":
                            value = 0x00000000; // Disable
                            value2 = 0x00000002; // Disable

                            if (!taskBarStart.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                                value2 = 0x00000000; // Enable (default)
                            }

                            // TaskBar
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarDa", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarMn", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ShowTaskViewButton", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Search", "SearchboxTaskbarMode", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Feeds", "ShellFeedsTaskbarViewMode", value2, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "SecurityHealthSystray", value, RegistryValueKind.DWord);
                            break;
                        case "actionCenter":
                            value = 0x00000001; // Disable

                            if (!actionCenter.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            // Action Centre
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\Explorer", "DisableNotificationCenter", value, RegistryValueKind.DWord);
                            break;
                        case "noGUIBoot":
                            if (noGUIBoot.Checked)
                            {
                                try
                                {
                                    RunBcdeditCommand("/set {current} quietboot on");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred while enabling No GUI Boot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                try
                                {
                                    RunBcdeditCommand("/deletevalue {current} quietboot");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred while disabling No GUI Boot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        case "focusAssist":
                            value = 0x00000000; // Disable

                            if (!focusAssist.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Focus Assist
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\FocusAssist", "DefaultAutomaticRules", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\FocusAssist", "FocusAssistMode", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\FocusAssist", "DefaultAutomaticRules", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\FocusAssist", "FocusAssistMode", value, RegistryValueKind.DWord);
                            break;
                        case "liveTiles":
                            value = 0x00000000; // Disable

                            if (!liveTiles.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Live Tiles
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_LiveTiles", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_LiveTiles", value, RegistryValueKind.DWord);
                            break;
                        case "lockPowerOption":
                            value = 0x00000001; // Disable

                            if (!lockPowerOption.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            // Lock Power option
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLockScreen", value, RegistryValueKind.DWord);
                            break;
                        case "lockScreenBlur":
                            value = 0x00000001; // Disable

                            if (!lockScreenBlur.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            // Lock screen blur
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\System", "DisableAcrylicBackgroundOnLogon", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Policies\\Microsoft\\Windows\\System", "DisableAcrylicBackgroundOnLogon", value, RegistryValueKind.DWord);
                            break;
                        case "mobilityCentre":
                            value = 0x00000001; // Disable

                            if (!mobilityCentre.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            // Mobility Centre
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "NoMobilityCenter", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "NoMobilityCenter", value, RegistryValueKind.DWord);
                            break;
                        case "disableNotifications":
                            value = 0x00000000; // Disable

                            if (!disableNotifications.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Notifications
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", "NOC_GLOBAL_SETTING_TOASTS_ENABLED", value, RegistryValueKind.DWord);
                            break;
                        case "disableOneDrive":
                            value = 0x00000001; // Disable

                            if (!disableOneDrive.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            // OneDrive
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\OneDrive", "DisableFileSyncNGSC", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\OneDrive", "DisableFileSync", value, RegistryValueKind.DWord);
                            break;
                        case "personalisedItems":
                            value = 0x00000000; // Disable

                            if (!personalisedItems.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Personalised Items
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackDocs", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackProgs", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackRecentDocs", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackDocs", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackProgs", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackRecentDocs", value, RegistryValueKind.DWord);
                            break;
                        case "searchHighlights":
                            value = 0x00000000; // Disable

                            if (!searchHighlights.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Search Highlights
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", "BingSearchEnabled", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", "CortanaConsent", value, RegistryValueKind.DWord);
                            break;
                        case "disableTransparency":
                            value = 0x00000000; // Disable

                            if (!disableTransparency.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Transparency
                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "EnableTransparency", value, RegistryValueKind.DWord);
                            break;
                        case "disableCopilot":
                            value = 0x00000000; // Disable

                            if (!disableCopilot.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            // Copilot
                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", "AllowCortana", value, RegistryValueKind.DWord);
                            break;
                        case "enableClassicAltTab":
                            value = 0x00000001; // Enable

                            if (!enableClassicAltTab.Checked)
                            {
                                value = 0x00000000; // Disable (default)
                            }

                            // Classic alt-tab
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AltTab", "Enabled", value, RegistryValueKind.DWord);
                            break;
                        case "performanceVisual":
                            if (performanceVisual.Checked)
                            {
                                byte[] userPreferencesMask = new byte[] { 0x90, 0x12, 0x03, 0x80, 0x10, 0x00, 0x00, 0x00 };

                                // Set the registry value
                                SetRegistryValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "UserPreferencesMask", userPreferencesMask, RegistryValueKind.Binary);



                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects", "VisualFXSetting", 3, RegistryValueKind.DWord);

                                // Set values in HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics
                                SetRegistryValue("HKEY_CURRENT_USER\\Control Panel\\Desktop\\WindowMetrics", "MinAnimate", "0", RegistryValueKind.String);

                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarAnimations", 0, RegistryValueKind.DWord);


                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "CompositionPolicy", 0, RegistryValueKind.DWord);
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "ColorizationOpaqueBlend", 0, RegistryValueKind.DWord);
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "AlwaysHibernateThumbnails", 0, RegistryValueKind.DWord);

                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "DisableThumbnails", 1, RegistryValueKind.DWord);

                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ListviewAlphaSelect", 0, RegistryValueKind.DWord);
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ListviewShadow", 0, RegistryValueKind.DWord);

                                // Set values in HKEY_CURRENT_USER\Control Panel\Desktop
                                SetRegistryValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "DragFullWindows", "0", RegistryValueKind.String);
                                SetRegistryValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "FontSmoothing", "0", RegistryValueKind.String);

                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ThemeManager
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ThemeManager", "ThemeActive", "0", RegistryValueKind.String);

                                // Enable Peek
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "EnableAeroPeek", 0, RegistryValueKind.DWord);
                            }
                            else
                            {
                                byte[] userPreferencesMask = new byte[] { 0x9E, 0x1E, 0x07, 0x80, 0x12, 0x00, 0x00, 0x00 };

                                // Set the registry value
                                SetRegistryValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "UserPreferencesMask", userPreferencesMask, RegistryValueKind.Binary);



                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects", "VisualFXSetting", 0, RegistryValueKind.DWord);

                                // Set values in HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics
                                SetRegistryValue("HKEY_CURRENT_USER\\Control Panel\\Desktop\\WindowMetrics", "MinAnimate", "1", RegistryValueKind.String);

                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarAnimations", 1, RegistryValueKind.DWord);


                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "CompositionPolicy", 1, RegistryValueKind.DWord);
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "ColorizationOpaqueBlend", 1, RegistryValueKind.DWord);
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "AlwaysHibernateThumbnails", 1, RegistryValueKind.DWord);

                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "DisableThumbnails", 0, RegistryValueKind.DWord);

                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ListviewAlphaSelect", 1, RegistryValueKind.DWord);
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ListviewShadow", 1, RegistryValueKind.DWord);

                                // Set values in HKEY_CURRENT_USER\Control Panel\Desktop
                                SetRegistryValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "DragFullWindows", "1", RegistryValueKind.String);
                                SetRegistryValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "FontSmoothing", "2", RegistryValueKind.String);

                                // Set values in HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ThemeManager
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ThemeManager", "ThemeActive", "1", RegistryValueKind.String);

                                // Enable Peek
                                SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "EnableAeroPeek", 1, RegistryValueKind.DWord);
                            }
                            break;
                        case "darkMode":
                            value = 0x00000000; // Disable light-theme

                            if (!darkMode.Checked)
                            {
                                value = 0x00000001; // Enable light-theme (default)
                            }

                            // Set dark mode
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "SystemUsesLightTheme", value, RegistryValueKind.DWord);
                            break;
                        case "ClassicRightClick":
                            value = 0x00000000; // Set Classic Right Click Menu

                            if (!ClassicRightClick.Checked)
                            {
                                value = 0x00000001; // Un-Set Classic Right Click Menu
                            }

                            // Set Classic Right Click Menu

                            if (value == 0x00000000)
                            {
                                CreateRegistryKey("SOFTWARE\\Classes\\CLSID", "{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
                                CreateRegistryKey("SOFTWARE\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}", "InprocServer32");

                                try
                                {
                                    using (RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32"))
                                    {
                                        if (key != null)
                                        {
                                            // Set the default value for the key
                                            key.SetValue(null, "", RegistryValueKind.String);
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Failed to set default value.Key not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error setting default value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                DeleteRegistryKey("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32");
                                DeleteRegistryKey("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
                            }
                            break;
                        case "disableshortcutSuffix":
                            value = 0x00000001; // Disable

                            if (!disableshortcutSuffix.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            // Shortcut Suffix
                            if (value == 0x00000001)
                            {
                                CreateRegistryKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "NamingTemplates");
                                SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates", "ShortcutNameTemplate", "\"%s.lnk\"", RegistryValueKind.String);
                            }
                            else
                            {
                                DeleteRegistryKey("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates");
                            }
                            break;
                        case "ultimatePerformance":
                            value = 0x00000001; // Enable

                            if (!ultimatePerformance.Checked)
                            {
                                value = 0x00000000; // Disable (default)
                            }

                            // Ultimate performance plan
                            if (value == 0x00000001)
                            {
                                try
                                {
                                    // Command to add the Ultimate Performance power plan
                                    string addUltimatePerformanceCmd = "powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61";
                                    ExecuteCmd(addUltimatePerformanceCmd);

                                    // Command to set the power plan to Ultimate Performance
                                    string setUltimatePerformanceCmd = "powercfg -setactive e9a42b02-d5df-448d-aa00-03f14749eb61";
                                    ExecuteCmd(setUltimatePerformanceCmd);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                try
                                {
                                    string setBalancedPerformanceCmd = "powercfg -setactive 381b4222-f694-41f0-9685-ff5bb260df2e";
                                    ExecuteCmd(setBalancedPerformanceCmd);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        case "disablePowerThrottling":
                            value = 0x00000001; // Disable

                            if (!disablePowerThrottling.Checked)
                            {
                                value = 0x00000000; // Enable (default)
                            }

                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Power\\PowerThrottling", "PowerThrottlingOff", value, RegistryValueKind.DWord);
                            break;
                        case "disableHibernation":
                            if (disableHibernation.Checked)
                            {
                                ExecuteCmd("powercfg -h off");
                                ExecuteCmd("powercfg.exe /hibernate off");
                            }
                            else
                            {
                                ExecuteCmd("powercfg -h on");
                                ExecuteCmd("powercfg.exe /hibernate on");
                            }
                            break;
                        case "BCDEdit":
                            if (BCDEdit.Checked)
                            {
                                ExecuteCmd("bcdedit /set disabledynamictick yes");
                                ExecuteCmd("bcdedit /set hypervisorlaunchtype off");
                            }
                            else
                            {
                                ExecuteCmd("bcdedit /deletevalue disabledynamictick");
                                ExecuteCmd("bcdedit /set hypervisorlaunchtype auto");
                            }
                            break;
                        case "disableBluetooth":
                            if (disableBluetooth.Checked)
                            {
                                SetServiceStartupType(4, "BTAGService");
                                SetServiceStartupType(4, "bthserv");
                                SetServiceStartupType(4, "BluetoothUserService_70cd4");
                            }
                            else
                            {
                                SetServiceStartupType(2, "BTAGService");
                                SetServiceStartupType(2, "bthserv");
                                SetServiceStartupType(2, "BluetoothUserService_70cd4");
                            }
                            break;
                        case "disableWiFi":
                            if (disableWiFi.Checked)
                            {
                                ExecuteCmd("net stop WlanSvc");
                                SetServiceStartupType(4, "WlanSvc");
                            }
                            else
                            {
                                SetServiceStartupType(2, "WlanSvc");
                                ExecuteCmd("net start WlanSvc");
                            }
                            break;
                        case "disableEthernet":
                            if (disableEthernet.Checked)
                            {
                                ExecuteCmd("net stop WwanSvc");
                                SetServiceStartupType(4, "WwanSvc");
                            }
                            else
                            {
                                SetServiceStartupType(2, "WwanSvc");
                                ExecuteCmd("net start WwanSvc");
                            }
                            break;
                        case "virtulizationSecurity":
                            value = 0x00000000; // Disable

                            if (!virtulizationSecurity.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            SetRegistryValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\DeviceGuard", "EnableVirtualizationBasedSecurity", value, RegistryValueKind.DWord);
                            break;
                        case "disableVPNSupport":
                            if (disableVPNSupport.Checked)
                            {
                                ExecuteCmd("net stop RemoteAccess");
                                SetServiceStartupType(4, "RemoteAccess");

                                ExecuteCmd("net stop IKEEXT");
                                SetServiceStartupType(4, "IKEEXT");

                                ExecuteCmd("net stop PolicyAgent");
                                SetServiceStartupType(4, "PolicyAgent");
                            }
                            else
                            {
                                SetServiceStartupType(3, "RemoteAccess");
                                ExecuteCmd("net start RemoteAccess");

                                SetServiceStartupType(2, "IKEEXT");
                                ExecuteCmd("net start IKEEXT");

                                SetServiceStartupType(2, "PolicyAgent");
                                ExecuteCmd("net start PolicyAgent");
                            }
                            break;
                        case "disableBrowserActivity":
                            value = 0x00000000; // Disable

                            if (!disableBrowserActivity.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Google\\Chrome\\Advanced", "BackgroundModeEnabled", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Edge\\BackgroundModeEnabled", "", value, RegistryValueKind.DWord);
                            break;
                        case "taskBarTelemetry":
                            value = 0x00000000; // Disable

                            if (!taskBarTelemetry.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ShowTaskbarDataCollection", value, RegistryValueKind.DWord);
                            break;
                        case "disableStartMenuTelemetry":
                            value = 0x00000000; // Disable

                            if (!disableStartMenuTelemetry.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection", "AllowStartMenuDataCollection", value, RegistryValueKind.DWord);
                            break;
                        case "disableHardwareAcceleration":
                            value = 0x00000000; // Disable

                            if (!disableHardwareAcceleration.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Policies\\Google\\Chrome", "HardwareAccelerationModeEnabled", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Edge", "HardwareAccelerationModeEnabled", value, RegistryValueKind.DWord);
                            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Policies\\BraveSoftware\\Brave", "HardwareAccelerationModeEnabled", value, RegistryValueKind.DWord);
                            break;
                        case "VolumeFlyout":
                            value = 0x00000000; // Enable

                            if (!VolumeFlyout.Checked)
                            {
                                value = 0x00000001; // Disable (default)
                            }

                            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "HideSCAVolumeFlyout", value, RegistryValueKind.DWord);
                            break;
                        case "OptimiseContextMenu":
                            if (OptimiseContextMenu.Checked)
                            {
                                try
                                {
                                    string keyName = @"*\shell\runas";
                                    using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(keyName))
                                    {
                                        if (key != null)
                                        {
                                            key.SetValue("", "Take Ownership");
                                            key.SetValue("NoWorkingDirectory", "");

                                            using (RegistryKey commandKey = key.CreateSubKey("command"))
                                            {
                                                if (commandKey != null)
                                                {
                                                    commandKey.SetValue("", "cmd.exe /c takeown /f \"%1\" && icacls \"%1\" /grant administrators:F");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error: '{ex.Message}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                AddNewFileType(".txt", "Text Document");
                                AddNewFileType(".doc", "Word Document");
                            }
                            else
                            {
                                try
                                {
                                    string keyName = @"*\shell\runas";
                                    Registry.ClassesRoot.DeleteSubKeyTree(keyName, false);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error: '{ex.Message}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        case "FSUTIL":
                            if (FSUTIL.Checked)
                            {
                                ExecuteCmd("fsutil 8dot3name set 1");
                                ExecuteCmd("fsutil behavior set memoryusage 2");
                                ExecuteCmd("fsutil behavior set disablelastaccess 1");
                                ExecuteCmd("fsutil resource setavailable C:\\");
                                ExecuteCmd("fsutil resource setlog shrink 10 C:\\");
                                ExecuteCmd("fsutil repair set C: 0x01");
                                ExecuteCmd("fsutil resource setautoreset true C:\\");
                                ExecuteCmd("fsutil resource setconsistent C:\\");
                                ExecuteCmd("fsutil resource setlog shrink 10 C:\\");
                                ExecuteCmd("fsutil behaviour set mftzone 1");
                            }
                            else
                            {
                                ExecuteCmd("fsutil 8dot3name set 0");
                                ExecuteCmd("fsutil behavior set memoryusage 1");
                                ExecuteCmd("fsutil behavior set disablelastaccess 0");
                                ExecuteCmd("fsutil resource setlog notshrink C:\\");
                                ExecuteCmd("fsutil repair set C: 0x00");
                                ExecuteCmd("fsutil resource setautoreset false C:\\");
                                ExecuteCmd("fsutil resource setconsistent false C:\\");
                                ExecuteCmd("fsutil resource setlog notshrink C:\\");
                                ExecuteCmd("fsutil behaviour set mftzone 0");
                            }
                            break;
                        case "TCPOptimise":
                            ExecuteCmd("start https://www.speedguide.net/files/TCPOptimizer.exe");
                            ExecuteCmd("start https://download1587.mediafire.com/xvhl89qigmwgyX-Bb9_xOUDGfzkgYCpL7Qz-7toCpwWJ3TJyLSDMxOFRHpdMJ0fMpCqF2Rs1hpx3kjJ7TMLZCBO08e_zxPf2mlItQC-oBLtruV7ctnX7RiOFrP3kQWiM94p1QEiXjnkMQnE5LMfB5HjLxREyEQlDnKI1-Zq0_7s/h37uolwj9j03saz/Export.spg");
                            break;
                        case "SVC4GB":
                            SVC(400000);
                            break;
                        case "SVC6GB":
                            SVC(0x00600000);
                            break;
                        case "SVC8GB":
                            SVC(0x00800000);
                            break;
                        case "SVC12GB":
                            SVC(0x00c00000);
                            break;
                        case "SVC16GB":
                            SVC(0x01000000);
                            break;
                        case "SVC24GB":
                            SVC(0x01800000);
                            break;
                        case "SVC32GB":
                            SVC(0x02000000);
                            break;
                        case "SVC64GB":
                            SVC(0x04000000);
                            break;
                        case "SVC_RESET":
                            SVC(0x00380000);
                            break;
                        case "disableCoreIsolation":
                            value = 0x00000000; // Disable

                            if (!disableCoreIsolation.Checked)
                            {
                                value = 0x00000001; // Enable (default)
                            }

                            SetRegistryValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios\\HypervisorEnforcedCodeIntegrity", "Enabled", value, RegistryValueKind.DWord);
                            break;
                        case "deviceManagerOptimisations":
                            try
                            {
                                if (deviceManagerOptimisations.Checked)
                                {
                                    DisableDevice("Microsoft GS Wavetable Synth");
                                    DisableDevice("Composite Bus Enumerator");
                                    DisableDevice("Intel(R) SMBus - 43A3");
                                    DisableDevice("Intel(R) SPI (flash) Controller - 43A4");
                                    DisableDevice("Microsoft Hyper-V Virtualization Infrastructure Driver");
                                    DisableDevice("Microsoft Virtual Drive Enumerator");
                                    DisableDevice("NDIS Virtual Network Adapter Enumerator");
                                    DisableDevice("Numeric data processor");
                                    DisableDevice("Remote Desktop Device Redirector Bus");
                                    DisableDevice("System timer");
                                    DisableDevice("UMBus Root Bus Enumerator");
                                }
                                else
                                {
                                    EnableDevice("Microsoft GS Wavetable Synth");
                                    EnableDevice("Composite Bus Enumerator");
                                    EnableDevice("Intel(R) SMBus - 43A3");
                                    EnableDevice("Intel(R) SPI (flash) Controller - 43A4");
                                    EnableDevice("Microsoft Hyper-V Virtualization Infrastructure Driver");
                                    EnableDevice("Microsoft Virtual Drive Enumerator");
                                    EnableDevice("NDIS Virtual Network Adapter Enumerator");
                                    EnableDevice("Numeric data processor");
                                    EnableDevice("Remote Desktop Device Redirector Bus");
                                    EnableDevice("System timer");
                                    EnableDevice("UMBus Root Bus Enumerator");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occured: {ex.Message}. It is normal to encouter this error. This doesn't mean it hasn't performed the task successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "servicesOptimisations":
                            if (servicesOptimisations.Checked)
                            {
                                SetServiceStartupType(4, "SysMain");
                                SetServiceStartupType(4, "tzautoupdate");
                                SetServiceStartupType(4, "DiagTrack");
                                SetServiceStartupType(4, "MapsBroker");
                                SetServiceStartupType(4, "Fax");
                                SetServiceStartupType(4, "lfsvc");
                                SetServiceStartupType(4, "QWAVE");
                                SetServiceStartupType(4, "TermService");
                                SetServiceStartupType(4, "RemoteRegistry");
                                SetServiceStartupType(4, "RemoteAccess");
                                SetServiceStartupType(4, "icssvc");
                                SetServiceStartupType(4, "WSearch");
                                SetServiceStartupType(3, "W32Time");
                                SetServiceStartupType(3, "LanmanWorkstation");
                            }
                            else
                            {
                                SetServiceStartupType(2, "SysMain");
                                SetServiceStartupType(2, "tzautoupdate");
                                SetServiceStartupType(2, "DiagTrack");
                                SetServiceStartupType(3, "MapsBroker");
                                SetServiceStartupType(2, "Fax");
                                SetServiceStartupType(2, "lfsvc");
                                SetServiceStartupType(2, "QWAVE");
                                SetServiceStartupType(2, "TermService");
                                SetServiceStartupType(3, "RemoteRegistry");
                                SetServiceStartupType(3, "RemoteAccess");
                                SetServiceStartupType(2, "icssvc");
                                SetServiceStartupType(2, "WSearch");
                                SetServiceStartupType(2, "W32Time");
                                SetServiceStartupType(2, "LanmanWorkstation");
                            }
                            break;
                    }
                    SaveConfig(checkboxMap);
                }
            }
        }
        static void DisableDevice(string deviceName)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%" + deviceName + "%'");
            foreach (ManagementObject device in searcher.Get())
            {
                device.InvokeMethod("Disable", new object[] { false });
            }
        }

        static void EnableDevice(string deviceName)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%" + deviceName + "%'");
            foreach (ManagementObject device in searcher.Get())
            {
                device.InvokeMethod("Enable", new object[] { false });
            }
        }

        public static bool ExecuteCmd(string command)
        {
            try
            {
                // Set up ProcessStartInfo
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {command}",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // Start the process
                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    process.WaitForExit();

                    // Check if there were any errors
                    if (process.ExitCode != 0)
                    {
                        string errorMessage = process.StandardError.ReadToEnd();
                        MessageBox.Show($"Error executing command: \"{command}\". Error Message: {errorMessage}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                MessageBox.Show($"Error executing command: \"{command}\". Error Message: {errorMessage}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = MessageBox.Show($"It is recommended to restart windows to fully apply the tweaks made to your system.", "Restart Windows To Apply?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                ExecuteCmd("shutdown /r /t 0");
            }
        }

        static void AddNewFileType(string extension, string description)
        {
            try
            {
                string keyName = $@"{extension}\ShellNew";
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(keyName))
                {
                    if (key != null)
                    {
                        key.SetValue("NullFile", "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: '{ex.Message}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void SVC(object value)
        {
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "SvcHostSplitThresholdInKB", value, RegistryValueKind.DWord);
        }

        private void Version_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExecuteCmd("start https://github.com/danielm3600/Windows-ToolBox/releases/");
        }
    }
}