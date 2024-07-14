namespace Hone_sucks
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            xboxGameBar = new CheckBox();
            cortana = new CheckBox();
            PrintAndFax = new CheckBox();
            easeOfAccess = new CheckBox();
            snapAssist = new CheckBox();
            restore = new CheckBox();
            errorReporting = new CheckBox();
            disableInsider = new CheckBox();
            disablesearchIndex = new CheckBox();
            disableXbox = new CheckBox();
            touchSettings = new CheckBox();
            taskBarStart = new CheckBox();
            actionCenter = new CheckBox();
            noGUIBoot = new CheckBox();
            focusAssist = new CheckBox();
            liveTiles = new CheckBox();
            lockPowerOption = new CheckBox();
            lockScreenBlur = new CheckBox();
            mobilityCentre = new CheckBox();
            disableNotifications = new CheckBox();
            disableOneDrive = new CheckBox();
            personalisedItems = new CheckBox();
            searchHighlights = new CheckBox();
            disableTransparency = new CheckBox();
            disableCopilot = new CheckBox();
            enableClassicAltTab = new CheckBox();
            performanceVisual = new CheckBox();
            darkMode = new CheckBox();
            ClassicRightClick = new CheckBox();
            disableshortcutSuffix = new CheckBox();
            info = new Label();
            toolTip = new ToolTip(components);
            ultimatePerformance = new CheckBox();
            disablePowerThrottling = new CheckBox();
            BCDEdit = new CheckBox();
            virtulizationSecurity = new CheckBox();
            disableVPNSupport = new CheckBox();
            disableBrowserActivity = new CheckBox();
            disableHardwareAcceleration = new CheckBox();
            OptimiseContextMenu = new CheckBox();
            SVC4GB = new CheckBox();
            SVC6GB = new CheckBox();
            SVC8GB = new CheckBox();
            SVC12GB = new CheckBox();
            SVC16GB = new CheckBox();
            SVC24GB = new CheckBox();
            SVC32GB = new CheckBox();
            SVC64GB = new CheckBox();
            SVCRESET = new CheckBox();
            FSUTIL = new CheckBox();
            TCPOptimise = new CheckBox();
            Version = new LinkLabel();
            privacyOptimisations = new CheckBox();
            windowsOptimisations = new CheckBox();
            servicesOptimisations = new CheckBox();
            deviceManagerOptimisations = new CheckBox();
            disableCoreIsolation = new CheckBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox7 = new CheckBox();
            disableHibernation = new CheckBox();
            taskBarTelemetry = new CheckBox();
            disableBluetooth = new CheckBox();
            disableWiFi = new CheckBox();
            disableEthernet = new CheckBox();
            disableStartMenuTelemetry = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            tabControl1 = new TabControl();
            GeneralPage = new TabPage();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label1 = new Label();
            VolumeFlyout = new CheckBox();
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            tabControl1.SuspendLayout();
            GeneralPage.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // xboxGameBar
            // 
            xboxGameBar.AutoSize = true;
            xboxGameBar.ForeColor = SystemColors.ControlText;
            xboxGameBar.Location = new Point(6, 30);
            xboxGameBar.Name = "xboxGameBar";
            xboxGameBar.Size = new Size(148, 19);
            xboxGameBar.TabIndex = 0;
            xboxGameBar.Text = "Disable Xbox Game Bar";
            xboxGameBar.UseVisualStyleBackColor = true;
            xboxGameBar.CheckedChanged += CheckBox_checkChanged;
            // 
            // cortana
            // 
            cortana.AutoSize = true;
            cortana.ForeColor = SystemColors.ControlText;
            cortana.Location = new Point(6, 55);
            cortana.Name = "cortana";
            cortana.Size = new Size(109, 19);
            cortana.TabIndex = 2;
            cortana.Text = "Disable Cortana";
            cortana.UseVisualStyleBackColor = true;
            cortana.CheckedChanged += CheckBox_checkChanged;
            // 
            // PrintAndFax
            // 
            PrintAndFax.AutoSize = true;
            PrintAndFax.ForeColor = SystemColors.ControlText;
            PrintAndFax.Location = new Point(6, 80);
            PrintAndFax.Name = "PrintAndFax";
            PrintAndFax.Size = new Size(136, 19);
            PrintAndFax.TabIndex = 3;
            PrintAndFax.Text = "Disable Print and Fax";
            PrintAndFax.UseVisualStyleBackColor = true;
            PrintAndFax.CheckedChanged += CheckBox_checkChanged;
            // 
            // easeOfAccess
            // 
            easeOfAccess.AutoSize = true;
            easeOfAccess.ForeColor = SystemColors.ControlText;
            easeOfAccess.Location = new Point(6, 105);
            easeOfAccess.Name = "easeOfAccess";
            easeOfAccess.Size = new Size(188, 19);
            easeOfAccess.TabIndex = 4;
            easeOfAccess.Text = "Disable Ease of Access Settings";
            easeOfAccess.UseVisualStyleBackColor = true;
            easeOfAccess.CheckedChanged += CheckBox_checkChanged;
            // 
            // snapAssist
            // 
            snapAssist.AutoSize = true;
            snapAssist.ForeColor = SystemColors.ControlText;
            snapAssist.Location = new Point(6, 130);
            snapAssist.Name = "snapAssist";
            snapAssist.Size = new Size(175, 19);
            snapAssist.TabIndex = 5;
            snapAssist.Text = "Disable Windows snap assist";
            snapAssist.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(snapAssist, "Disables resizing layouts in Windows.");
            snapAssist.UseVisualStyleBackColor = true;
            snapAssist.CheckedChanged += CheckBox_checkChanged;
            // 
            // restore
            // 
            restore.AutoSize = true;
            restore.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline);
            restore.ForeColor = Color.Lime;
            restore.Location = new Point(6, 6);
            restore.Name = "restore";
            restore.Size = new Size(241, 19);
            restore.TabIndex = 6;
            restore.Text = "Create restore point (RECOMMENDED)";
            toolTip.SetToolTip(restore, "A restore point in Windows is a saved state of your system files and settings \r\nthat you can use to revert your computer to a previous state for system \r\nrecovery. (HIGHLY RECOMMENDED TO DO)");
            restore.UseVisualStyleBackColor = true;
            restore.CheckedChanged += CheckBox_checkChanged;
            // 
            // errorReporting
            // 
            errorReporting.AutoSize = true;
            errorReporting.ForeColor = SystemColors.ControlText;
            errorReporting.Location = new Point(6, 155);
            errorReporting.Name = "errorReporting";
            errorReporting.Size = new Size(196, 19);
            errorReporting.TabIndex = 7;
            errorReporting.Text = "Disable Windows error reporting";
            errorReporting.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(errorReporting, "Stops windows from reporting errors.");
            errorReporting.UseVisualStyleBackColor = true;
            errorReporting.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableInsider
            // 
            disableInsider.AutoSize = true;
            disableInsider.ForeColor = SystemColors.ControlText;
            disableInsider.Location = new Point(6, 180);
            disableInsider.Name = "disableInsider";
            disableInsider.Size = new Size(154, 19);
            disableInsider.TabIndex = 8;
            disableInsider.Text = "Disable Windows Insider";
            disableInsider.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableInsider, "Disables the windows insider service.");
            disableInsider.UseVisualStyleBackColor = true;
            disableInsider.CheckedChanged += CheckBox_checkChanged;
            // 
            // disablesearchIndex
            // 
            disablesearchIndex.AutoSize = true;
            disablesearchIndex.ForeColor = SystemColors.ControlText;
            disablesearchIndex.Location = new Point(6, 205);
            disablesearchIndex.Name = "disablesearchIndex";
            disablesearchIndex.Size = new Size(195, 19);
            disablesearchIndex.TabIndex = 9;
            disablesearchIndex.Text = "Disable Windows search Indexer";
            disablesearchIndex.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disablesearchIndex, "Disable search indexing.");
            disablesearchIndex.UseVisualStyleBackColor = true;
            disablesearchIndex.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableXbox
            // 
            disableXbox.AutoSize = true;
            disableXbox.ForeColor = SystemColors.ControlText;
            disableXbox.Location = new Point(6, 230);
            disableXbox.Name = "disableXbox";
            disableXbox.Size = new Size(94, 19);
            disableXbox.TabIndex = 10;
            disableXbox.Text = "Disable Xbox";
            disableXbox.TextAlign = ContentAlignment.TopCenter;
            disableXbox.UseVisualStyleBackColor = true;
            disableXbox.CheckedChanged += CheckBox_checkChanged;
            // 
            // touchSettings
            // 
            touchSettings.AutoSize = true;
            touchSettings.ForeColor = SystemColors.ControlText;
            touchSettings.Location = new Point(6, 255);
            touchSettings.Name = "touchSettings";
            touchSettings.Size = new Size(142, 19);
            touchSettings.TabIndex = 11;
            touchSettings.Text = "Disable touch settings";
            touchSettings.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(touchSettings, "Disables the touch keyboard.");
            touchSettings.UseVisualStyleBackColor = true;
            touchSettings.CheckedChanged += CheckBox_checkChanged;
            // 
            // taskBarStart
            // 
            taskBarStart.AutoSize = true;
            taskBarStart.ForeColor = SystemColors.ControlText;
            taskBarStart.Location = new Point(6, 280);
            taskBarStart.Name = "taskBarStart";
            taskBarStart.Size = new Size(180, 19);
            taskBarStart.TabIndex = 12;
            taskBarStart.Text = "Clean taskbar and start menu";
            taskBarStart.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(taskBarStart, "Removes unnecessary stuff from taskbar and start menu.");
            taskBarStart.UseVisualStyleBackColor = true;
            taskBarStart.CheckedChanged += CheckBox_checkChanged;
            // 
            // actionCenter
            // 
            actionCenter.AutoSize = true;
            actionCenter.ForeColor = SystemColors.ControlText;
            actionCenter.Location = new Point(6, 305);
            actionCenter.Name = "actionCenter";
            actionCenter.Size = new Size(140, 19);
            actionCenter.TabIndex = 13;
            actionCenter.Text = "Disable Action Center";
            actionCenter.TextAlign = ContentAlignment.TopCenter;
            actionCenter.UseVisualStyleBackColor = true;
            actionCenter.CheckedChanged += CheckBox_checkChanged;
            // 
            // noGUIBoot
            // 
            noGUIBoot.AutoSize = true;
            noGUIBoot.ForeColor = SystemColors.ControlText;
            noGUIBoot.Location = new Point(6, 31);
            noGUIBoot.Name = "noGUIBoot";
            noGUIBoot.Size = new Size(130, 19);
            noGUIBoot.TabIndex = 14;
            noGUIBoot.Text = "Enable No GUI Boot";
            noGUIBoot.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(noGUIBoot, "No GUI boot disables the effects on Windows boot.");
            noGUIBoot.UseVisualStyleBackColor = true;
            noGUIBoot.CheckedChanged += CheckBox_checkChanged;
            // 
            // focusAssist
            // 
            focusAssist.AutoSize = true;
            focusAssist.ForeColor = SystemColors.ControlText;
            focusAssist.Location = new Point(6, 330);
            focusAssist.Name = "focusAssist";
            focusAssist.Size = new Size(129, 19);
            focusAssist.TabIndex = 15;
            focusAssist.Text = "Disable Focus assist";
            focusAssist.TextAlign = ContentAlignment.TopCenter;
            focusAssist.UseVisualStyleBackColor = true;
            focusAssist.CheckedChanged += CheckBox_checkChanged;
            // 
            // liveTiles
            // 
            liveTiles.AutoSize = true;
            liveTiles.ForeColor = SystemColors.ControlText;
            liveTiles.Location = new Point(6, 355);
            liveTiles.Name = "liveTiles";
            liveTiles.Size = new Size(109, 19);
            liveTiles.TabIndex = 16;
            liveTiles.Text = "Disable live tiles";
            liveTiles.TextAlign = ContentAlignment.TopCenter;
            liveTiles.UseVisualStyleBackColor = true;
            liveTiles.CheckedChanged += CheckBox_checkChanged;
            // 
            // lockPowerOption
            // 
            lockPowerOption.AutoSize = true;
            lockPowerOption.ForeColor = SystemColors.ControlText;
            lockPowerOption.Location = new Point(6, 380);
            lockPowerOption.Name = "lockPowerOption";
            lockPowerOption.Size = new Size(163, 19);
            lockPowerOption.TabIndex = 17;
            lockPowerOption.Text = "Disable lock power option";
            lockPowerOption.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(lockPowerOption, "Disables the lock function in Windows.");
            lockPowerOption.UseVisualStyleBackColor = true;
            lockPowerOption.CheckedChanged += CheckBox_checkChanged;
            // 
            // lockScreenBlur
            // 
            lockScreenBlur.AutoSize = true;
            lockScreenBlur.ForeColor = SystemColors.ControlText;
            lockScreenBlur.Location = new Point(6, 405);
            lockScreenBlur.Name = "lockScreenBlur";
            lockScreenBlur.Size = new Size(150, 19);
            lockScreenBlur.TabIndex = 18;
            lockScreenBlur.Text = "Disable lock screen blur";
            lockScreenBlur.TextAlign = ContentAlignment.TopCenter;
            lockScreenBlur.UseVisualStyleBackColor = true;
            lockScreenBlur.CheckedChanged += CheckBox_checkChanged;
            // 
            // mobilityCentre
            // 
            mobilityCentre.AutoSize = true;
            mobilityCentre.ForeColor = SystemColors.ControlText;
            mobilityCentre.Location = new Point(6, 430);
            mobilityCentre.Name = "mobilityCentre";
            mobilityCentre.Size = new Size(197, 19);
            mobilityCentre.TabIndex = 19;
            mobilityCentre.Text = "Disable windows mobility centre";
            mobilityCentre.TextAlign = ContentAlignment.TopCenter;
            mobilityCentre.UseVisualStyleBackColor = true;
            mobilityCentre.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableNotifications
            // 
            disableNotifications.AutoSize = true;
            disableNotifications.ForeColor = SystemColors.ControlText;
            disableNotifications.Location = new Point(6, 455);
            disableNotifications.Name = "disableNotifications";
            disableNotifications.Size = new Size(133, 19);
            disableNotifications.TabIndex = 20;
            disableNotifications.Text = "Disable notifications";
            disableNotifications.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableNotifications, "Disable app and windows notifications (Except critical notifications like windows defender)");
            disableNotifications.UseVisualStyleBackColor = true;
            disableNotifications.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableOneDrive
            // 
            disableOneDrive.AutoSize = true;
            disableOneDrive.ForeColor = SystemColors.ControlText;
            disableOneDrive.Location = new Point(6, 480);
            disableOneDrive.Name = "disableOneDrive";
            disableOneDrive.Size = new Size(116, 19);
            disableOneDrive.TabIndex = 21;
            disableOneDrive.Text = "Disable OneDrive";
            disableOneDrive.TextAlign = ContentAlignment.TopCenter;
            disableOneDrive.UseVisualStyleBackColor = true;
            disableOneDrive.CheckedChanged += CheckBox_checkChanged;
            // 
            // personalisedItems
            // 
            personalisedItems.AutoSize = true;
            personalisedItems.ForeColor = SystemColors.ControlText;
            personalisedItems.Location = new Point(6, 505);
            personalisedItems.Name = "personalisedItems";
            personalisedItems.Size = new Size(214, 19);
            personalisedItems.TabIndex = 22;
            personalisedItems.Text = "Disable Showing Personalised Items";
            personalisedItems.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(personalisedItems, "Disable personalised results like recent documents and files etc..");
            personalisedItems.UseVisualStyleBackColor = true;
            personalisedItems.CheckedChanged += CheckBox_checkChanged;
            // 
            // searchHighlights
            // 
            searchHighlights.AutoSize = true;
            searchHighlights.ForeColor = SystemColors.ControlText;
            searchHighlights.Location = new Point(6, 530);
            searchHighlights.Name = "searchHighlights";
            searchHighlights.Size = new Size(158, 19);
            searchHighlights.TabIndex = 23;
            searchHighlights.Text = "Disable Search highlights";
            searchHighlights.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(searchHighlights, "Basically just disables Cortana results in search and Bing search for less bloat.");
            searchHighlights.UseVisualStyleBackColor = true;
            searchHighlights.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableTransparency
            // 
            disableTransparency.AutoSize = true;
            disableTransparency.ForeColor = SystemColors.ControlText;
            disableTransparency.Location = new Point(6, 555);
            disableTransparency.Name = "disableTransparency";
            disableTransparency.Size = new Size(136, 19);
            disableTransparency.TabIndex = 24;
            disableTransparency.Text = "Disable Transparency";
            disableTransparency.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableTransparency, "Disables Windows Transparency Effects in Personalisation.");
            disableTransparency.UseVisualStyleBackColor = true;
            disableTransparency.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableCopilot
            // 
            disableCopilot.AutoSize = true;
            disableCopilot.ForeColor = SystemColors.ControlText;
            disableCopilot.Location = new Point(6, 580);
            disableCopilot.Name = "disableCopilot";
            disableCopilot.Size = new Size(158, 19);
            disableCopilot.TabIndex = 25;
            disableCopilot.Text = "Disable Windows Copilot";
            disableCopilot.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableCopilot, "Disables the AI bloat on Win11.");
            disableCopilot.UseVisualStyleBackColor = true;
            disableCopilot.CheckedChanged += CheckBox_checkChanged;
            // 
            // enableClassicAltTab
            // 
            enableClassicAltTab.AutoSize = true;
            enableClassicAltTab.ForeColor = SystemColors.ControlText;
            enableClassicAltTab.Location = new Point(253, 279);
            enableClassicAltTab.Name = "enableClassicAltTab";
            enableClassicAltTab.Size = new Size(175, 19);
            enableClassicAltTab.TabIndex = 26;
            enableClassicAltTab.Text = "Enable Classic Alt-Tab Menu";
            enableClassicAltTab.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(enableClassicAltTab, "Use classic Windows 10 alt-menu.");
            enableClassicAltTab.UseVisualStyleBackColor = true;
            enableClassicAltTab.CheckedChanged += CheckBox_checkChanged;
            // 
            // performanceVisual
            // 
            performanceVisual.AutoSize = true;
            performanceVisual.ForeColor = SystemColors.ControlText;
            performanceVisual.Location = new Point(253, 56);
            performanceVisual.Name = "performanceVisual";
            performanceVisual.Size = new Size(202, 19);
            performanceVisual.TabIndex = 27;
            performanceVisual.Text = "Set visual effects for performance";
            performanceVisual.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(performanceVisual, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            performanceVisual.UseVisualStyleBackColor = true;
            performanceVisual.CheckedChanged += CheckBox_checkChanged;
            // 
            // darkMode
            // 
            darkMode.AutoSize = true;
            darkMode.ForeColor = SystemColors.ControlText;
            darkMode.Location = new Point(253, 254);
            darkMode.Name = "darkMode";
            darkMode.Size = new Size(174, 19);
            darkMode.TabIndex = 28;
            darkMode.Text = "Enable Windows Dark Mode";
            darkMode.TextAlign = ContentAlignment.TopCenter;
            darkMode.UseVisualStyleBackColor = true;
            darkMode.CheckedChanged += CheckBox_checkChanged;
            // 
            // ClassicRightClick
            // 
            ClassicRightClick.AutoSize = true;
            ClassicRightClick.ForeColor = SystemColors.ControlText;
            ClassicRightClick.Location = new Point(253, 6);
            ClassicRightClick.Name = "ClassicRightClick";
            ClassicRightClick.Size = new Size(196, 19);
            ClassicRightClick.TabIndex = 29;
            ClassicRightClick.Text = "Enable Classic Right-Click Menu";
            ClassicRightClick.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(ClassicRightClick, "Use the old right-click menu used in Windows 10, but for 11.");
            ClassicRightClick.UseVisualStyleBackColor = true;
            ClassicRightClick.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableshortcutSuffix
            // 
            disableshortcutSuffix.AutoSize = true;
            disableshortcutSuffix.ForeColor = SystemColors.ControlText;
            disableshortcutSuffix.Location = new Point(253, 31);
            disableshortcutSuffix.Name = "disableshortcutSuffix";
            disableshortcutSuffix.Size = new Size(229, 19);
            disableshortcutSuffix.TabIndex = 30;
            disableshortcutSuffix.Text = "Disable \"-Shortcut\" suffix for shortcuts";
            disableshortcutSuffix.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableshortcutSuffix, "Disables the \"-Shortcut\" text that is inputted after\r\na shortcut is created.");
            disableshortcutSuffix.UseVisualStyleBackColor = true;
            disableshortcutSuffix.CheckedChanged += CheckBox_checkChanged;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            info.ForeColor = SystemColors.ControlText;
            info.Location = new Point(748, 9);
            info.Name = "info";
            info.Size = new Size(253, 15);
            info.TabIndex = 31;
            info.Text = "Hover over each optimisation for more info.";
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 5000000;
            toolTip.AutoPopDelay = 50000000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 5000000;
            toolTip.ShowAlways = true;
            // 
            // ultimatePerformance
            // 
            ultimatePerformance.AutoSize = true;
            ultimatePerformance.ForeColor = SystemColors.ControlText;
            ultimatePerformance.Location = new Point(253, 81);
            ultimatePerformance.Name = "ultimatePerformance";
            ultimatePerformance.Size = new Size(237, 19);
            ultimatePerformance.TabIndex = 32;
            ultimatePerformance.Text = "Set power plan to Ultimate Performance";
            ultimatePerformance.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(ultimatePerformance, "This sets the Windows power plan to \"Ultimate Performance\".\r\nWARNING: It consumes more power.");
            ultimatePerformance.UseVisualStyleBackColor = true;
            ultimatePerformance.CheckedChanged += CheckBox_checkChanged;
            // 
            // disablePowerThrottling
            // 
            disablePowerThrottling.AutoSize = true;
            disablePowerThrottling.ForeColor = SystemColors.ControlText;
            disablePowerThrottling.Location = new Point(253, 106);
            disablePowerThrottling.Name = "disablePowerThrottling";
            disablePowerThrottling.Size = new Size(207, 19);
            disablePowerThrottling.TabIndex = 33;
            disablePowerThrottling.Text = "Disable Windows Power Throttling";
            disablePowerThrottling.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disablePowerThrottling, "Disables power throttling in Windows.");
            disablePowerThrottling.UseVisualStyleBackColor = true;
            disablePowerThrottling.CheckedChanged += CheckBox_checkChanged;
            // 
            // BCDEdit
            // 
            BCDEdit.AutoSize = true;
            BCDEdit.ForeColor = SystemColors.ControlText;
            BCDEdit.Location = new Point(6, 81);
            BCDEdit.Name = "BCDEdit";
            BCDEdit.Size = new Size(165, 19);
            BCDEdit.TabIndex = 36;
            BCDEdit.Text = "Optimise BCDEdit Settings";
            BCDEdit.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(BCDEdit, "This disables dynamic tick and hypervisor.");
            BCDEdit.UseVisualStyleBackColor = true;
            BCDEdit.CheckedChanged += CheckBox_checkChanged;
            // 
            // virtulizationSecurity
            // 
            virtulizationSecurity.AutoSize = true;
            virtulizationSecurity.ForeColor = SystemColors.ControlText;
            virtulizationSecurity.Location = new Point(6, 106);
            virtulizationSecurity.Name = "virtulizationSecurity";
            virtulizationSecurity.Size = new Size(240, 19);
            virtulizationSecurity.TabIndex = 40;
            virtulizationSecurity.Text = "Disable Virtulization Based Security (VBS)";
            virtulizationSecurity.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(virtulizationSecurity, "Virtulization Based Security causes stuttering and uneccessary cpu usage.");
            virtulizationSecurity.UseVisualStyleBackColor = true;
            virtulizationSecurity.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableVPNSupport
            // 
            disableVPNSupport.AutoSize = true;
            disableVPNSupport.ForeColor = SystemColors.ControlText;
            disableVPNSupport.Location = new Point(6, 56);
            disableVPNSupport.Name = "disableVPNSupport";
            disableVPNSupport.Size = new Size(135, 19);
            disableVPNSupport.TabIndex = 41;
            disableVPNSupport.Text = "Disable VPN Support";
            disableVPNSupport.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableVPNSupport, "Disables vpn for Windows.");
            disableVPNSupport.UseVisualStyleBackColor = true;
            disableVPNSupport.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableBrowserActivity
            // 
            disableBrowserActivity.AutoSize = true;
            disableBrowserActivity.ForeColor = Color.Red;
            disableBrowserActivity.Location = new Point(253, 230);
            disableBrowserActivity.Name = "disableBrowserActivity";
            disableBrowserActivity.Size = new Size(232, 19);
            disableBrowserActivity.TabIndex = 42;
            disableBrowserActivity.Text = "Optimise Browser Background Activity ";
            disableBrowserActivity.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableBrowserActivity, "Stops Edge and Chrome from running in the background after close.\r\nWARNING: This is untested, so procceed with caution");
            disableBrowserActivity.UseVisualStyleBackColor = true;
            disableBrowserActivity.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableHardwareAcceleration
            // 
            disableHardwareAcceleration.AutoSize = true;
            disableHardwareAcceleration.ForeColor = Color.Red;
            disableHardwareAcceleration.Location = new Point(6, 56);
            disableHardwareAcceleration.Name = "disableHardwareAcceleration";
            disableHardwareAcceleration.Size = new Size(232, 19);
            disableHardwareAcceleration.TabIndex = 45;
            disableHardwareAcceleration.Text = "Disable Browser Hardware Acceleration";
            disableHardwareAcceleration.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableHardwareAcceleration, resources.GetString("disableHardwareAcceleration.ToolTip"));
            disableHardwareAcceleration.UseVisualStyleBackColor = true;
            disableHardwareAcceleration.CheckedChanged += CheckBox_checkChanged;
            // 
            // OptimiseContextMenu
            // 
            OptimiseContextMenu.AutoSize = true;
            OptimiseContextMenu.ForeColor = Color.Red;
            OptimiseContextMenu.Location = new Point(6, 6);
            OptimiseContextMenu.Name = "OptimiseContextMenu";
            OptimiseContextMenu.Size = new Size(151, 19);
            OptimiseContextMenu.TabIndex = 47;
            OptimiseContextMenu.Text = "Optimise context menu";
            OptimiseContextMenu.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(OptimiseContextMenu, "Adds the \"Take Ownership\" option to the context menu in Windows.\r\nAlso adds common file types to the file creation menu.");
            OptimiseContextMenu.UseVisualStyleBackColor = true;
            OptimiseContextMenu.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVC4GB
            // 
            SVC4GB.AutoSize = true;
            SVC4GB.ForeColor = Color.Red;
            SVC4GB.Location = new Point(419, 184);
            SVC4GB.Name = "SVC4GB";
            SVC4GB.Size = new Size(237, 19);
            SVC4GB.TabIndex = 48;
            SVC4GB.Text = "SVC split threshold optimisation for 4GB";
            SVC4GB.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVC4GB, resources.GetString("SVC4GB.ToolTip"));
            SVC4GB.UseVisualStyleBackColor = true;
            SVC4GB.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVC6GB
            // 
            SVC6GB.AutoSize = true;
            SVC6GB.ForeColor = Color.Red;
            SVC6GB.Location = new Point(419, 209);
            SVC6GB.Name = "SVC6GB";
            SVC6GB.Size = new Size(237, 19);
            SVC6GB.TabIndex = 53;
            SVC6GB.Text = "SVC split threshold optimisation for 6GB";
            SVC6GB.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVC6GB, resources.GetString("SVC6GB.ToolTip"));
            SVC6GB.UseVisualStyleBackColor = true;
            SVC6GB.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVC8GB
            // 
            SVC8GB.AutoSize = true;
            SVC8GB.ForeColor = Color.Red;
            SVC8GB.Location = new Point(419, 234);
            SVC8GB.Name = "SVC8GB";
            SVC8GB.Size = new Size(237, 19);
            SVC8GB.TabIndex = 54;
            SVC8GB.Text = "SVC split threshold optimisation for 8GB";
            SVC8GB.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVC8GB, resources.GetString("SVC8GB.ToolTip"));
            SVC8GB.UseVisualStyleBackColor = true;
            SVC8GB.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVC12GB
            // 
            SVC12GB.AutoSize = true;
            SVC12GB.ForeColor = Color.Red;
            SVC12GB.Location = new Point(419, 259);
            SVC12GB.Name = "SVC12GB";
            SVC12GB.Size = new Size(243, 19);
            SVC12GB.TabIndex = 55;
            SVC12GB.Text = "SVC split threshold optimisation for 12GB";
            SVC12GB.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVC12GB, resources.GetString("SVC12GB.ToolTip"));
            SVC12GB.UseVisualStyleBackColor = true;
            SVC12GB.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVC16GB
            // 
            SVC16GB.AutoSize = true;
            SVC16GB.ForeColor = SystemColors.ControlText;
            SVC16GB.Location = new Point(419, 284);
            SVC16GB.Name = "SVC16GB";
            SVC16GB.Size = new Size(243, 19);
            SVC16GB.TabIndex = 56;
            SVC16GB.Text = "SVC split threshold optimisation for 16GB";
            SVC16GB.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVC16GB, resources.GetString("SVC16GB.ToolTip"));
            SVC16GB.UseVisualStyleBackColor = true;
            SVC16GB.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVC24GB
            // 
            SVC24GB.AutoSize = true;
            SVC24GB.ForeColor = Color.Red;
            SVC24GB.Location = new Point(419, 309);
            SVC24GB.Name = "SVC24GB";
            SVC24GB.Size = new Size(243, 19);
            SVC24GB.TabIndex = 57;
            SVC24GB.Text = "SVC split threshold optimisation for 24GB";
            SVC24GB.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVC24GB, resources.GetString("SVC24GB.ToolTip"));
            SVC24GB.UseVisualStyleBackColor = true;
            SVC24GB.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVC32GB
            // 
            SVC32GB.AutoSize = true;
            SVC32GB.ForeColor = Color.Red;
            SVC32GB.Location = new Point(419, 334);
            SVC32GB.Name = "SVC32GB";
            SVC32GB.Size = new Size(243, 19);
            SVC32GB.TabIndex = 58;
            SVC32GB.Text = "SVC split threshold optimisation for 32GB";
            SVC32GB.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVC32GB, resources.GetString("SVC32GB.ToolTip"));
            SVC32GB.UseVisualStyleBackColor = true;
            SVC32GB.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVC64GB
            // 
            SVC64GB.AutoSize = true;
            SVC64GB.ForeColor = Color.Red;
            SVC64GB.Location = new Point(419, 359);
            SVC64GB.Name = "SVC64GB";
            SVC64GB.Size = new Size(243, 19);
            SVC64GB.TabIndex = 59;
            SVC64GB.Text = "SVC split threshold optimisation for 64GB";
            SVC64GB.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVC64GB, resources.GetString("SVC64GB.ToolTip"));
            SVC64GB.UseVisualStyleBackColor = true;
            SVC64GB.CheckedChanged += CheckBox_checkChanged;
            // 
            // SVCRESET
            // 
            SVCRESET.AutoSize = true;
            SVCRESET.ForeColor = SystemColors.ControlText;
            SVCRESET.Location = new Point(419, 396);
            SVCRESET.Name = "SVCRESET";
            SVCRESET.Size = new Size(301, 19);
            SVCRESET.TabIndex = 60;
            SVCRESET.Text = "SVC split threshold optimisation RESET TO DEFAULTS";
            SVCRESET.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(SVCRESET, resources.GetString("SVCRESET.ToolTip"));
            SVCRESET.UseVisualStyleBackColor = true;
            SVCRESET.CheckedChanged += CheckBox_checkChanged;
            // 
            // FSUTIL
            // 
            FSUTIL.AutoSize = true;
            FSUTIL.ForeColor = SystemColors.ControlText;
            FSUTIL.Location = new Point(6, 131);
            FSUTIL.Name = "FSUTIL";
            FSUTIL.Size = new Size(297, 19);
            FSUTIL.TabIndex = 63;
            FSUTIL.Text = "FSUTIL Tweaks for NTFS Performance and Reliability";
            FSUTIL.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(FSUTIL, "FSUTIL is a general-purpose NTFS tweak tool.\r\nThis optimisation applys general tweaks\r\nfor better performance.");
            FSUTIL.UseVisualStyleBackColor = true;
            FSUTIL.CheckedChanged += CheckBox_checkChanged;
            // 
            // TCPOptimise
            // 
            TCPOptimise.AutoSize = true;
            TCPOptimise.ForeColor = SystemColors.ControlText;
            TCPOptimise.Location = new Point(6, 81);
            TCPOptimise.Name = "TCPOptimise";
            TCPOptimise.Size = new Size(264, 19);
            TCPOptimise.TabIndex = 64;
            TCPOptimise.Text = "Download TCP Optimiser and TCP Config File";
            TCPOptimise.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(TCPOptimise, "After download, Run TCP Optimiser as ADMIN, then go to\r\nFile > Import > Select the Export File > Open > Then Apply.");
            TCPOptimise.UseVisualStyleBackColor = true;
            TCPOptimise.CheckedChanged += CheckBox_checkChanged;
            // 
            // Version
            // 
            Version.AutoSize = true;
            Version.LinkColor = Color.Teal;
            Version.Location = new Point(12, 9);
            Version.Name = "Version";
            Version.Size = new Size(164, 15);
            Version.TabIndex = 52;
            Version.TabStop = true;
            Version.Text = "Check For Updates on GitHub";
            toolTip.SetToolTip(Version, "Click to open up the latest release for Windows ToolBox on GitHub.");
            Version.VisitedLinkColor = Color.Red;
            Version.LinkClicked += Version_LinkClicked;
            // 
            // privacyOptimisations
            // 
            privacyOptimisations.AutoSize = true;
            privacyOptimisations.ForeColor = Color.Blue;
            privacyOptimisations.Location = new Point(520, 64);
            privacyOptimisations.Name = "privacyOptimisations";
            privacyOptimisations.Size = new Size(282, 19);
            privacyOptimisations.TabIndex = 47;
            privacyOptimisations.Text = "General Privacy Optimisations (COMING SOON!)";
            privacyOptimisations.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(privacyOptimisations, "Disables certain Privacy Features and tracking found in Privacy settings.");
            privacyOptimisations.UseVisualStyleBackColor = true;
            privacyOptimisations.CheckedChanged += CheckBox_checkChanged;
            // 
            // windowsOptimisations
            // 
            windowsOptimisations.AutoSize = true;
            windowsOptimisations.ForeColor = Color.Blue;
            windowsOptimisations.Location = new Point(520, 40);
            windowsOptimisations.Name = "windowsOptimisations";
            windowsOptimisations.Size = new Size(293, 19);
            windowsOptimisations.TabIndex = 48;
            windowsOptimisations.Text = "General Windows Optimisations (COMING SOON!)";
            windowsOptimisations.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(windowsOptimisations, resources.GetString("windowsOptimisations.ToolTip"));
            windowsOptimisations.UseVisualStyleBackColor = true;
            windowsOptimisations.CheckedChanged += CheckBox_checkChanged;
            // 
            // servicesOptimisations
            // 
            servicesOptimisations.AutoSize = true;
            servicesOptimisations.ForeColor = SystemColors.ControlText;
            servicesOptimisations.Location = new Point(253, 330);
            servicesOptimisations.Name = "servicesOptimisations";
            servicesOptimisations.Size = new Size(188, 19);
            servicesOptimisations.TabIndex = 49;
            servicesOptimisations.Text = "General Services Optimisations";
            servicesOptimisations.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(servicesOptimisations, resources.GetString("servicesOptimisations.ToolTip"));
            servicesOptimisations.UseVisualStyleBackColor = true;
            servicesOptimisations.CheckedChanged += CheckBox_checkChanged;
            // 
            // deviceManagerOptimisations
            // 
            deviceManagerOptimisations.AutoSize = true;
            deviceManagerOptimisations.ForeColor = SystemColors.ControlText;
            deviceManagerOptimisations.Location = new Point(6, 156);
            deviceManagerOptimisations.Name = "deviceManagerOptimisations";
            deviceManagerOptimisations.Size = new Size(188, 19);
            deviceManagerOptimisations.TabIndex = 64;
            deviceManagerOptimisations.Text = "Device Manager Optimisations";
            deviceManagerOptimisations.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(deviceManagerOptimisations, "Disables certain drivers found in Device Manager that\r\naren't required.");
            deviceManagerOptimisations.UseVisualStyleBackColor = true;
            deviceManagerOptimisations.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableCoreIsolation
            // 
            disableCoreIsolation.AutoSize = true;
            disableCoreIsolation.ForeColor = SystemColors.ControlText;
            disableCoreIsolation.Location = new Point(6, 181);
            disableCoreIsolation.Name = "disableCoreIsolation";
            disableCoreIsolation.Size = new Size(140, 19);
            disableCoreIsolation.TabIndex = 65;
            disableCoreIsolation.Text = "Disable Core Isolation";
            disableCoreIsolation.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableCoreIsolation, "Core isolation isn't required and it causes a lot of\r\nstuttering/cpu usage. Only disable if you know\r\nthat you don't want the extra-protection from Windows.");
            disableCoreIsolation.UseVisualStyleBackColor = true;
            disableCoreIsolation.CheckedChanged += CheckBox_checkChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.Blue;
            checkBox1.Location = new Point(520, 89);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(314, 19);
            checkBox1.TabIndex = 50;
            checkBox1.Text = "NVIDIA Control Panel Optimisations (COMING SOON!)";
            checkBox1.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(checkBox1, "Optimises the NVIDIA Control Panel 3D Settings for lower\r\nlatency and higher FPS.");
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.ForeColor = Color.Blue;
            checkBox2.Location = new Point(520, 115);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(265, 19);
            checkBox2.TabIndex = 51;
            checkBox2.Text = "Disable Windows Defender (COMING SOON!)";
            checkBox2.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(checkBox2, "Disables Windows Defender. As it causes stuttering and \r\nhigher cpu usage. NOT RECOMMENDED!");
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.ForeColor = Color.Blue;
            checkBox3.Location = new Point(520, 139);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(304, 19);
            checkBox3.TabIndex = 52;
            checkBox3.Text = "Enable old Windows Photo Viewer (COMING SOON!)";
            checkBox3.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(checkBox3, "Enables the old windows photo viewer.");
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.ForeColor = Color.Blue;
            checkBox4.Location = new Point(520, 165);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(304, 19);
            checkBox4.TabIndex = 53;
            checkBox4.Text = "Enable old Windows Photo Viewer (COMING SOON!)";
            checkBox4.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(checkBox4, "Enables the old windows photo viewer.");
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.ForeColor = Color.Blue;
            checkBox5.Location = new Point(520, 230);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(189, 19);
            checkBox5.TabIndex = 55;
            checkBox5.Text = "Junk cleaner (COMING SOON!)";
            checkBox5.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(checkBox5, "Cleans junk, caches, temp files, etc to help boost performance.");
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.ForeColor = Color.Blue;
            checkBox7.Location = new Point(520, 279);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(264, 19);
            checkBox7.TabIndex = 57;
            checkBox7.Text = "Scan and Fix System Errors (COMING SOON!)";
            checkBox7.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(checkBox7, "Scans and fixes system errors using cmd.");
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // disableHibernation
            // 
            disableHibernation.AutoSize = true;
            disableHibernation.ForeColor = SystemColors.ControlText;
            disableHibernation.Location = new Point(253, 131);
            disableHibernation.Name = "disableHibernation";
            disableHibernation.Size = new Size(182, 19);
            disableHibernation.TabIndex = 34;
            disableHibernation.Text = "Disable Windows Hibernation";
            disableHibernation.TextAlign = ContentAlignment.TopCenter;
            disableHibernation.UseVisualStyleBackColor = true;
            disableHibernation.CheckedChanged += CheckBox_checkChanged;
            // 
            // taskBarTelemetry
            // 
            taskBarTelemetry.AutoSize = true;
            taskBarTelemetry.ForeColor = SystemColors.ControlText;
            taskBarTelemetry.Location = new Point(253, 156);
            taskBarTelemetry.Name = "taskBarTelemetry";
            taskBarTelemetry.Size = new Size(160, 19);
            taskBarTelemetry.TabIndex = 35;
            taskBarTelemetry.Text = "Disable TaskBar Telemetry";
            taskBarTelemetry.TextAlign = ContentAlignment.TopCenter;
            taskBarTelemetry.UseVisualStyleBackColor = true;
            taskBarTelemetry.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableBluetooth
            // 
            disableBluetooth.AutoSize = true;
            disableBluetooth.ForeColor = SystemColors.ControlText;
            disableBluetooth.Location = new Point(253, 205);
            disableBluetooth.Name = "disableBluetooth";
            disableBluetooth.Size = new Size(119, 19);
            disableBluetooth.TabIndex = 37;
            disableBluetooth.Text = "Disable Bluetooth";
            disableBluetooth.TextAlign = ContentAlignment.TopCenter;
            disableBluetooth.UseVisualStyleBackColor = true;
            disableBluetooth.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableWiFi
            // 
            disableWiFi.AutoSize = true;
            disableWiFi.ForeColor = SystemColors.ControlText;
            disableWiFi.Location = new Point(6, 6);
            disableWiFi.Name = "disableWiFi";
            disableWiFi.Size = new Size(90, 19);
            disableWiFi.TabIndex = 38;
            disableWiFi.Text = "Disable WiFi";
            disableWiFi.TextAlign = ContentAlignment.TopCenter;
            disableWiFi.UseVisualStyleBackColor = true;
            disableWiFi.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableEthernet
            // 
            disableEthernet.AutoSize = true;
            disableEthernet.ForeColor = SystemColors.ControlText;
            disableEthernet.Location = new Point(6, 31);
            disableEthernet.Name = "disableEthernet";
            disableEthernet.Size = new Size(111, 19);
            disableEthernet.TabIndex = 39;
            disableEthernet.Text = "Disable Ethernet";
            disableEthernet.TextAlign = ContentAlignment.TopCenter;
            disableEthernet.UseVisualStyleBackColor = true;
            disableEthernet.CheckedChanged += CheckBox_checkChanged;
            // 
            // disableStartMenuTelemetry
            // 
            disableStartMenuTelemetry.AutoSize = true;
            disableStartMenuTelemetry.ForeColor = SystemColors.ControlText;
            disableStartMenuTelemetry.Location = new Point(253, 181);
            disableStartMenuTelemetry.Name = "disableStartMenuTelemetry";
            disableStartMenuTelemetry.Size = new Size(179, 19);
            disableStartMenuTelemetry.TabIndex = 43;
            disableStartMenuTelemetry.Text = "Disable Start Menu Telemetry";
            disableStartMenuTelemetry.TextAlign = ContentAlignment.TopCenter;
            disableStartMenuTelemetry.UseVisualStyleBackColor = true;
            disableStartMenuTelemetry.CheckedChanged += CheckBox_checkChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(762, 30);
            label2.Name = "label2";
            label2.Size = new Size(239, 15);
            label2.TabIndex = 45;
            label2.Text = "Optimisations coloured          are untested.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(893, 30);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 46;
            label3.Text = "RED";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(GeneralPage);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 48);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(989, 633);
            tabControl1.TabIndex = 51;
            // 
            // GeneralPage
            // 
            GeneralPage.Controls.Add(label11);
            GeneralPage.Controls.Add(label10);
            GeneralPage.Controls.Add(label9);
            GeneralPage.Controls.Add(label8);
            GeneralPage.Controls.Add(label7);
            GeneralPage.Controls.Add(checkBox7);
            GeneralPage.Controls.Add(checkBox5);
            GeneralPage.Controls.Add(label1);
            GeneralPage.Controls.Add(checkBox4);
            GeneralPage.Controls.Add(checkBox3);
            GeneralPage.Controls.Add(checkBox2);
            GeneralPage.Controls.Add(checkBox1);
            GeneralPage.Controls.Add(servicesOptimisations);
            GeneralPage.Controls.Add(windowsOptimisations);
            GeneralPage.Controls.Add(privacyOptimisations);
            GeneralPage.Controls.Add(VolumeFlyout);
            GeneralPage.Controls.Add(restore);
            GeneralPage.Controls.Add(xboxGameBar);
            GeneralPage.Controls.Add(cortana);
            GeneralPage.Controls.Add(PrintAndFax);
            GeneralPage.Controls.Add(easeOfAccess);
            GeneralPage.Controls.Add(snapAssist);
            GeneralPage.Controls.Add(errorReporting);
            GeneralPage.Controls.Add(disableInsider);
            GeneralPage.Controls.Add(disableStartMenuTelemetry);
            GeneralPage.Controls.Add(disablesearchIndex);
            GeneralPage.Controls.Add(disableBrowserActivity);
            GeneralPage.Controls.Add(disableXbox);
            GeneralPage.Controls.Add(touchSettings);
            GeneralPage.Controls.Add(taskBarStart);
            GeneralPage.Controls.Add(actionCenter);
            GeneralPage.Controls.Add(disableBluetooth);
            GeneralPage.Controls.Add(focusAssist);
            GeneralPage.Controls.Add(liveTiles);
            GeneralPage.Controls.Add(taskBarTelemetry);
            GeneralPage.Controls.Add(lockPowerOption);
            GeneralPage.Controls.Add(disableHibernation);
            GeneralPage.Controls.Add(lockScreenBlur);
            GeneralPage.Controls.Add(disablePowerThrottling);
            GeneralPage.Controls.Add(mobilityCentre);
            GeneralPage.Controls.Add(ultimatePerformance);
            GeneralPage.Controls.Add(disableNotifications);
            GeneralPage.Controls.Add(disableOneDrive);
            GeneralPage.Controls.Add(disableshortcutSuffix);
            GeneralPage.Controls.Add(personalisedItems);
            GeneralPage.Controls.Add(ClassicRightClick);
            GeneralPage.Controls.Add(searchHighlights);
            GeneralPage.Controls.Add(darkMode);
            GeneralPage.Controls.Add(disableTransparency);
            GeneralPage.Controls.Add(performanceVisual);
            GeneralPage.Controls.Add(disableCopilot);
            GeneralPage.Controls.Add(enableClassicAltTab);
            GeneralPage.Location = new Point(4, 24);
            GeneralPage.Name = "GeneralPage";
            GeneralPage.Padding = new Padding(3);
            GeneralPage.Size = new Size(981, 605);
            GeneralPage.TabIndex = 0;
            GeneralPage.Text = "General";
            GeneralPage.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Blue;
            label11.Location = new Point(520, 434);
            label11.Name = "label11";
            label11.Size = new Size(381, 15);
            label11.TabIndex = 62;
            label11.Text = "Settings! Like to configure the theme and check for updates on startup!";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Blue;
            label10.Location = new Point(520, 380);
            label10.Name = "label10";
            label10.Size = new Size(165, 15);
            label10.TabIndex = 61;
            label10.Text = "Light Theme and Dark Theme!";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Blue;
            label9.Location = new Point(520, 405);
            label9.Name = "label9";
            label9.Size = new Size(377, 15);
            label9.TabIndex = 60;
            label9.Text = "Self-update so you dont need to download the new version each time.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Blue;
            label8.Location = new Point(520, 355);
            label8.Name = "label8";
            label8.Size = new Size(364, 15);
            label8.TabIndex = 59;
            label8.Text = "Presets Coming! Like for example, apply Recommened settings, etc.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Blue;
            label7.Location = new Point(520, 330);
            label7.Name = "label7";
            label7.Size = new Size(121, 15);
            label7.TabIndex = 58;
            label7.Text = "New UI Coming Soon";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(520, 10);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 54;
            label1.Text = "Coming in v1.0.3!";
            // 
            // VolumeFlyout
            // 
            VolumeFlyout.AutoSize = true;
            VolumeFlyout.ForeColor = Color.Red;
            VolumeFlyout.Location = new Point(253, 304);
            VolumeFlyout.Name = "VolumeFlyout";
            VolumeFlyout.Size = new Size(239, 19);
            VolumeFlyout.TabIndex = 46;
            VolumeFlyout.Text = "Enable the old Windows 7 Volume flyout";
            VolumeFlyout.TextAlign = ContentAlignment.TopCenter;
            VolumeFlyout.UseVisualStyleBackColor = true;
            VolumeFlyout.CheckedChanged += CheckBox_checkChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(TCPOptimise);
            tabPage2.Controls.Add(disableWiFi);
            tabPage2.Controls.Add(disableEthernet);
            tabPage2.Controls.Add(disableVPNSupport);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(981, 605);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Network";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(disableCoreIsolation);
            tabPage1.Controls.Add(deviceManagerOptimisations);
            tabPage1.Controls.Add(FSUTIL);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(SVCRESET);
            tabPage1.Controls.Add(SVC64GB);
            tabPage1.Controls.Add(SVC32GB);
            tabPage1.Controls.Add(SVC24GB);
            tabPage1.Controls.Add(SVC16GB);
            tabPage1.Controls.Add(SVC12GB);
            tabPage1.Controls.Add(SVC8GB);
            tabPage1.Controls.Add(SVC6GB);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(SVC4GB);
            tabPage1.Controls.Add(OptimiseContextMenu);
            tabPage1.Controls.Add(noGUIBoot);
            tabPage1.Controls.Add(disableHardwareAcceleration);
            tabPage1.Controls.Add(BCDEdit);
            tabPage1.Controls.Add(virtulizationSecurity);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(981, 605);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Advanced";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(419, 122);
            label6.Name = "label6";
            label6.Size = new Size(322, 45);
            label6.TabIndex = 62;
            label6.Text = "SELECT HOW MUCH RAM IN GB YOU HAVE ON YOUR PC.\r\nIF YOU DON'T KNOW HOW TO, YOU SHOULDN'T BE IN\r\nTHIS PAGE LOL.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(419, 64);
            label5.Name = "label5";
            label5.Size = new Size(475, 45);
            label5.TabIndex = 61;
            label5.Text = "UNCHECKING WONT DO ANYTHING, CHECK the \"RESET TO DEFAULTS\",\r\noption located near the bottom to OVERRIDE the current setting to system defaults.\r\nYOU MUST RESTART YOUR PC TO APPLY CHANGES.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(419, 22);
            label4.Name = "label4";
            label4.Size = new Size(322, 30);
            label4.TabIndex = 52;
            label4.Text = "VERY ADVANCED NOT RECOMMENDED FOR BEGINNERS,\r\nPROCEED WITH CAUTION:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 685);
            Controls.Add(Version);
            Controls.Add(tabControl1);
            Controls.Add(info);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Windows ToolBox v1.0.2 (Recommended to restart PC after changes)";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            GeneralPage.ResumeLayout(false);
            GeneralPage.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox xboxGameBar;
        private CheckBox cortana;
        private CheckBox PrintAndFax;
        private CheckBox easeOfAccess;
        private CheckBox snapAssist;
        private CheckBox restore;
        private CheckBox errorReporting;
        private CheckBox disableInsider;
        private CheckBox disablesearchIndex;
        private CheckBox disableXbox;
        private CheckBox touchSettings;
        private CheckBox taskBarStart;
        private CheckBox actionCenter;
        private CheckBox noGUIBoot;
        private CheckBox focusAssist;
        private CheckBox liveTiles;
        private CheckBox lockPowerOption;
        private CheckBox lockScreenBlur;
        private CheckBox mobilityCentre;
        private CheckBox disableNotifications;
        private CheckBox disableOneDrive;
        private CheckBox personalisedItems;
        private CheckBox searchHighlights;
        private CheckBox disableTransparency;
        private CheckBox disableCopilot;
        private CheckBox enableClassicAltTab;
        private CheckBox performanceVisual;
        private CheckBox darkMode;
        private CheckBox ClassicRightClick;
        private CheckBox disableshortcutSuffix;
        private Label info;
        private ToolTip toolTip;
        private CheckBox ultimatePerformance;
        private CheckBox disablePowerThrottling;
        private CheckBox disableHibernation;
        private CheckBox taskBarTelemetry;
        private CheckBox BCDEdit;
        private CheckBox disableBluetooth;
        private CheckBox disableWiFi;
        private CheckBox disableEthernet;
        private CheckBox virtulizationSecurity;
        private CheckBox disableVPNSupport;
        private CheckBox disableBrowserActivity;
        private CheckBox disableStartMenuTelemetry;
        private Label label2;
        private Label label3;
        private TabControl tabControl1;
        private TabPage GeneralPage;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private CheckBox disableHardwareAcceleration;
        private CheckBox VolumeFlyout;
        private CheckBox OptimiseContextMenu;
        private Label label4;
        private CheckBox SVC4GB;
        private Label label6;
        private Label label5;
        private CheckBox SVCRESET;
        private CheckBox SVC64GB;
        private CheckBox SVC32GB;
        private CheckBox SVC24GB;
        private CheckBox SVC16GB;
        private CheckBox SVC12GB;
        private CheckBox SVC8GB;
        private CheckBox SVC6GB;
        private CheckBox FSUTIL;
        private CheckBox TCPOptimise;
        private LinkLabel Version;
        private CheckBox privacyOptimisations;
        private CheckBox servicesOptimisations;
        private CheckBox windowsOptimisations;
        private CheckBox deviceManagerOptimisations;
        private CheckBox disableCoreIsolation;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private Label label8;
        private Label label7;
        private CheckBox checkBox7;
        private CheckBox checkBox5;
        private Label label1;
        private Label label11;
        private Label label10;
        private Label label9;
    }
}
