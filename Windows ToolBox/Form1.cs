using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hone_sucks
{
    public partial class Form1 : Form
    {
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

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

        private void xboxGameBar_CheckedChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!xboxGameBar.Checked)
            {
                value = 1; // Enable (default)
            }

            // Game Bar
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "AllowAutoGameMode", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "ShowStartupPanel", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "AutoGameModeEnabled", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\GameBar", "UseNexusForGameBarEnabled", value, RegistryValueKind.DWord);

            // Game DVR
            SetRegistryValue("HKEY_CURRENT_USER\\System\\GameConfigStore", "GameDVR_Enabled", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR", "AllowGameDVR", value, RegistryValueKind.DWord);
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void DisableCortana_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!cortana.Checked)
            {
                value = 1; // Enable (default)
            }

            // Cortana
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", "AllowCortana", value, RegistryValueKind.DWord);
        }

        private void Printandfax_checkChanged(object sender, EventArgs e)
        {
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
        }

        private void easeofAccess_CheckedChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable
            Int32 value2 = 1; // Disable

            if (!easeOfAccess.Checked)
            {
                value = 1; // Enable (default)
                value2 = 0; // Enable (default)
            }

            // Magnifier
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Narrator", "Magnifier", value, RegistryValueKind.DWord);
            // Narrator
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Narrator", "NoRoam", value2, RegistryValueKind.DWord);
            // On-Screen Keyboard
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI\\Roam", "NoLockScreen", value2, RegistryValueKind.DWord);
        }

        private void snapAssist_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!snapAssist.Checked)
            {
                value = 1; // Enable (default)
            }

            // Focus Assist
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", "NOC_GLOBAL_SETTING_TOASTS_ENABLED", value, RegistryValueKind.DWord);
        }

        private void restore_checkChanged(object sender, EventArgs e)
        {
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
        }

        private void errorReporting_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!errorReporting.Checked)
            {
                value = 0; // Enable (default)
            }

            // Error Reporting
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\Windows Error Reporting", "Disabled", value, RegistryValueKind.DWord);
        }

        private void disableInsider_checkChanged(object sender, EventArgs e)
        {
            if (disableInsider.Checked)
            {
                SetServiceStartupType(4, "wisvc");
            }
            else
            {
                SetServiceStartupType(3, "wisvc");
            }
        }

        private void disablesearchIndex_checkChanged(object sender, EventArgs e)
        {
            if (disablesearchIndex.Checked)
            {
                SetServiceStartupType(4, "WSearch");
            }
            else
            {
                SetServiceStartupType(2, "WSearch");
            }
        }

        private void disableXbox_checkChanged(object sender, EventArgs e)
        {
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
        }

        private void touchSettings_checkChanges(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!touchSettings.Checked)
            {
                value = 0; // Enable (default)
            }

            // Touch Keyboard
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\TabletTip\\1.7", "DisableTouchKeyboard", value, RegistryValueKind.DWord);
        }

        private void taskBarStart_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable
            Int32 value2 = 2; // Disable

            if (!taskBarStart.Checked)
            {
                value = 1; // Enable (default)
                value2 = 0; // Enable (default)
            }

            // TaskBar
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarDa", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarMn", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ShowTaskViewButton", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Search", "SearchboxTaskbarMode", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Feeds", "ShellFeedsTaskbarViewMode", value2, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "SecurityHealthSystray", value, RegistryValueKind.DWord);
        }

        private void actionCenter_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!actionCenter.Checked)
            {
                value = 0; // Enable (default)
            }

            // Action Centre
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\Explorer", "DisableNotificationCenter", value, RegistryValueKind.DWord);
        }

        private void noGUIBoot_checkChanged(object sender, EventArgs e)
        {
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
        }

        private void focusAssist_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!focusAssist.Checked)
            {
                value = 1; // Enable (default)
            }

            // Focus Assist
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\FocusAssist", "DefaultAutomaticRules", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\FocusAssist", "FocusAssistMode", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\FocusAssist", "DefaultAutomaticRules", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\FocusAssist", "FocusAssistMode", value, RegistryValueKind.DWord);
        }

        private void liveTiles_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!liveTiles.Checked)
            {
                value = 1; // Enable (default)
            }

            // Live Tiles
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_LiveTiles", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_LiveTiles", value, RegistryValueKind.DWord);
        }

        private void lockPowerOption_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!lockPowerOption.Checked)
            {
                value = 0; // Enable (default)
            }

            // Lock Power option
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLockScreen", value, RegistryValueKind.DWord);
        }

        private void lockScreenBlur_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!lockPowerOption.Checked)
            {
                value = 0; // Enable (default)
            }

            // Lock screen blur
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\System", "DisableAcrylicBackgroundOnLogon", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Policies\\Microsoft\\Windows\\System", "DisableAcrylicBackgroundOnLogon", value, RegistryValueKind.DWord);
        }

        private void mobilityCentre_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!mobilityCentre.Checked)
            {
                value = 0; // Enable (default)
            }

            // Mobility Centre
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "NoMobilityCenter", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "NoMobilityCenter", value, RegistryValueKind.DWord);
        }

        private void disableNotifications_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!disableNotifications.Checked)
            {
                value = 1; // Enable (default)
            }

            // Notifications
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", "NOC_GLOBAL_SETTING_TOASTS_ENABLED", value, RegistryValueKind.DWord);
        }

        private void disableOneDrive_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!disableOneDrive.Checked)
            {
                value = 0; // Enable (default)
            }

            // OneDrive
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\OneDrive", "DisableFileSyncNGSC", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\OneDrive", "DisableFileSync", value, RegistryValueKind.DWord);
        }

        private void personalisedItems_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!personalisedItems.Checked)
            {
                value = 1; // Enable (default)
            }

            // Personalised Items
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackDocs", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackProgs", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackRecentDocs", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackDocs", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackProgs", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackRecentDocs", value, RegistryValueKind.DWord);
        }

        private void searchHighlights_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!searchHighlights.Checked)
            {
                value = 1; // Enable (default)
            }

            // Search Highlights
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", "BingSearchEnabled", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", "CortanaConsent", value, RegistryValueKind.DWord);
        }

        private void disableTransparency_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!disableTransparency.Checked)
            {
                value = 1; // Enable (default)
            }

            // Transparency
            SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "EnableTransparency", value, RegistryValueKind.DWord);
        }

        private void disableCopilot_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!disableCopilot.Checked)
            {
                value = 1; // Enable (default)
            }

            // Copilot
            SetRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", "AllowCortana", value, RegistryValueKind.DWord);
        }

        private void enableClassicAltTab_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Enable

            if (!enableClassicAltTab.Checked)
            {
                value = 0; // Disable (default)
            }

            // Classic alt-tab
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AltTab", "Enabled", value, RegistryValueKind.DWord);
        }



        private void performanceVisual_checkChanged(object sender, EventArgs e)
        {
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
        }

        private void darkMode_checkChanged(object sender, EventArgs e)
        {
            int value = 0; // Disable light-theme

            if (!darkMode.Checked)
            {
                value = 1; // Enable light-theme (default)
            }

            // Set dark mode
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "SystemUsesLightTheme", value, RegistryValueKind.DWord);
        }

        private void ClassicRightClick_checkChanged(object sender, EventArgs e)
        {
            int value = 0; // Set Classic Right Click Menu

            if (!ClassicRightClick.Checked)
            {
                value = 1; // Un-Set Classic Right Click Menu
            }

            // Set Classic Right Click Menu

            if (value == 0)
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
        }

        private void disableshortcutSuffix_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!disableshortcutSuffix.Checked)
            {
                value = 0; // Enable (default)
            }

            // Shortcut Suffix
            if (value == 1)
            {
                CreateRegistryKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "NamingTemplates");
                SetRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates", "ShortcutNameTemplate", "\"%s.lnk\"", RegistryValueKind.String);
            }
            else
            {
                DeleteRegistryKey("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates");
            }

        }

        private void ultimatePerformance_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Enable

            if (!ultimatePerformance.Checked)
            {
                value = 0; // Disable (default)
            }

            // Ultimate performance plan
            if (value == 1)
            {
                try
                {
                    // Command to add the Ultimate Performance power plan
                    string addUltimatePerformanceCmd = "powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61";
                    ExecuteCommand(addUltimatePerformanceCmd);

                    // Command to set the power plan to Ultimate Performance
                    string setUltimatePerformanceCmd = "powercfg -setactive e9a42b02-d5df-448d-aa00-03f14749eb61";
                    ExecuteCommand(setUltimatePerformanceCmd);
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
                    ExecuteCommand(setBalancedPerformanceCmd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        static void ExecuteCommand(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show($"Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void disablePowerThrottling_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 1; // Disable

            if (!disablePowerThrottling.Checked)
            {
                value = 0; // Enable (default)
            }

            SetRegistryValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Power\\PowerThrottling", "PowerThrottlingOff", value, RegistryValueKind.DWord);
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

        private void disableHibernation_checkChanged(object sender, EventArgs e)
        {
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
        }

        private void taskBarStartMenuTelemetry_checkChanged(object sender, EventArgs e)
        {
            Int32 value = 0; // Disable

            if (!taskBarStartMenuTelemetry.Checked)
            {
                value = 1; // Enable (default)
            }

            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ShowTaskbarDataCollection", value, RegistryValueKind.DWord);
            SetRegistryValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection", "AllowStartMenuDataCollection", value, RegistryValueKind.DWord);
        }

        private void BCDEdit_checkChanged(object sender, EventArgs e)
        {
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
        }

        private void disableBluetooth_checkChanged(object sender, EventArgs e)
        {
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
        }

        private void disableWiFi_checkChanegd(object sender, EventArgs e)
        {
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
        }

        private void disableEthernet_checkChanged(object sender, EventArgs e)
        {
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
        }
    }
}
