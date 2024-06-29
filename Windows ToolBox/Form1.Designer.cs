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
            disableHibernation = new CheckBox();
            taskBarStartMenuTelemetry = new CheckBox();
            BCDEdit = new CheckBox();
            disableBluetooth = new CheckBox();
            disableWiFi = new CheckBox();
            disableEthernet = new CheckBox();
            SuspendLayout();
            // 
            // xboxGameBar
            // 
            xboxGameBar.AutoSize = true;
            xboxGameBar.ForeColor = SystemColors.ControlText;
            xboxGameBar.Location = new Point(12, 60);
            xboxGameBar.Name = "xboxGameBar";
            xboxGameBar.Size = new Size(148, 19);
            xboxGameBar.TabIndex = 0;
            xboxGameBar.Text = "Disable Xbox Game Bar";
            xboxGameBar.UseVisualStyleBackColor = true;
            xboxGameBar.CheckedChanged += xboxGameBar_CheckedChanged;
            // 
            // cortana
            // 
            cortana.AutoSize = true;
            cortana.ForeColor = SystemColors.ControlText;
            cortana.Location = new Point(12, 85);
            cortana.Name = "cortana";
            cortana.Size = new Size(109, 19);
            cortana.TabIndex = 2;
            cortana.Text = "Disable Cortana";
            cortana.UseVisualStyleBackColor = true;
            cortana.CheckedChanged += DisableCortana_checkChanged;
            // 
            // PrintAndFax
            // 
            PrintAndFax.AutoSize = true;
            PrintAndFax.ForeColor = SystemColors.ControlText;
            PrintAndFax.Location = new Point(12, 110);
            PrintAndFax.Name = "PrintAndFax";
            PrintAndFax.Size = new Size(136, 19);
            PrintAndFax.TabIndex = 3;
            PrintAndFax.Text = "Disable Print and Fax";
            PrintAndFax.UseVisualStyleBackColor = true;
            PrintAndFax.CheckedChanged += Printandfax_checkChanged;
            // 
            // easeOfAccess
            // 
            easeOfAccess.AutoSize = true;
            easeOfAccess.ForeColor = SystemColors.ControlText;
            easeOfAccess.Location = new Point(12, 135);
            easeOfAccess.Name = "easeOfAccess";
            easeOfAccess.Size = new Size(188, 19);
            easeOfAccess.TabIndex = 4;
            easeOfAccess.Text = "Disable Ease of Access Settings";
            easeOfAccess.UseVisualStyleBackColor = true;
            easeOfAccess.CheckedChanged += easeofAccess_CheckedChanged;
            // 
            // snapAssist
            // 
            snapAssist.AutoSize = true;
            snapAssist.ForeColor = SystemColors.ControlText;
            snapAssist.Location = new Point(12, 160);
            snapAssist.Name = "snapAssist";
            snapAssist.Size = new Size(175, 19);
            snapAssist.TabIndex = 5;
            snapAssist.Text = "Disable Windows snap assist";
            snapAssist.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(snapAssist, "Disables resizing layouts in Windows.");
            snapAssist.UseVisualStyleBackColor = true;
            snapAssist.CheckedChanged += snapAssist_checkChanged;
            // 
            // restore
            // 
            restore.AutoSize = true;
            restore.ForeColor = Color.DeepSkyBlue;
            restore.Location = new Point(12, 36);
            restore.Name = "restore";
            restore.Size = new Size(230, 19);
            restore.TabIndex = 6;
            restore.Text = "Create restore point (RECOMMENDED)";
            toolTip.SetToolTip(restore, "A restore point in Windows is a saved state of your system files and settings \r\nthat you can use to revert your computer to a previous state for system \r\nrecovery.");
            restore.UseVisualStyleBackColor = true;
            restore.CheckedChanged += restore_checkChanged;
            // 
            // errorReporting
            // 
            errorReporting.AutoSize = true;
            errorReporting.ForeColor = SystemColors.ControlText;
            errorReporting.Location = new Point(12, 185);
            errorReporting.Name = "errorReporting";
            errorReporting.Size = new Size(196, 19);
            errorReporting.TabIndex = 7;
            errorReporting.Text = "Disable Windows error reporting";
            errorReporting.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(errorReporting, "Stops windows from reporting errors.");
            errorReporting.UseVisualStyleBackColor = true;
            errorReporting.CheckedChanged += errorReporting_checkChanged;
            // 
            // disableInsider
            // 
            disableInsider.AutoSize = true;
            disableInsider.ForeColor = SystemColors.ControlText;
            disableInsider.Location = new Point(12, 210);
            disableInsider.Name = "disableInsider";
            disableInsider.Size = new Size(154, 19);
            disableInsider.TabIndex = 8;
            disableInsider.Text = "Disable Windows Insider";
            disableInsider.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableInsider, "Disables the windows insider service.");
            disableInsider.UseVisualStyleBackColor = true;
            disableInsider.CheckedChanged += disableInsider_checkChanged;
            // 
            // disablesearchIndex
            // 
            disablesearchIndex.AutoSize = true;
            disablesearchIndex.ForeColor = SystemColors.ControlText;
            disablesearchIndex.Location = new Point(12, 235);
            disablesearchIndex.Name = "disablesearchIndex";
            disablesearchIndex.Size = new Size(195, 19);
            disablesearchIndex.TabIndex = 9;
            disablesearchIndex.Text = "Disable Windows search Indexer";
            disablesearchIndex.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disablesearchIndex, "Disable search indexing.");
            disablesearchIndex.UseVisualStyleBackColor = true;
            disablesearchIndex.CheckedChanged += disablesearchIndex_checkChanged;
            // 
            // disableXbox
            // 
            disableXbox.AutoSize = true;
            disableXbox.ForeColor = SystemColors.ControlText;
            disableXbox.Location = new Point(12, 260);
            disableXbox.Name = "disableXbox";
            disableXbox.Size = new Size(94, 19);
            disableXbox.TabIndex = 10;
            disableXbox.Text = "Disable Xbox";
            disableXbox.TextAlign = ContentAlignment.TopCenter;
            disableXbox.UseVisualStyleBackColor = true;
            disableXbox.CheckedChanged += disableXbox_checkChanged;
            // 
            // touchSettings
            // 
            touchSettings.AutoSize = true;
            touchSettings.ForeColor = SystemColors.ControlText;
            touchSettings.Location = new Point(12, 285);
            touchSettings.Name = "touchSettings";
            touchSettings.Size = new Size(142, 19);
            touchSettings.TabIndex = 11;
            touchSettings.Text = "Disable touch settings";
            touchSettings.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(touchSettings, "Disables the touch keyboard.");
            touchSettings.UseVisualStyleBackColor = true;
            touchSettings.CheckedChanged += touchSettings_checkChanges;
            // 
            // taskBarStart
            // 
            taskBarStart.AutoSize = true;
            taskBarStart.ForeColor = SystemColors.ControlText;
            taskBarStart.Location = new Point(12, 310);
            taskBarStart.Name = "taskBarStart";
            taskBarStart.Size = new Size(180, 19);
            taskBarStart.TabIndex = 12;
            taskBarStart.Text = "Clean taskbar and start menu";
            taskBarStart.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(taskBarStart, "Removes unnecessary stuff from taskbar and start menu.");
            taskBarStart.UseVisualStyleBackColor = true;
            taskBarStart.CheckedChanged += taskBarStart_checkChanged;
            // 
            // actionCenter
            // 
            actionCenter.AutoSize = true;
            actionCenter.ForeColor = SystemColors.ControlText;
            actionCenter.Location = new Point(12, 335);
            actionCenter.Name = "actionCenter";
            actionCenter.Size = new Size(140, 19);
            actionCenter.TabIndex = 13;
            actionCenter.Text = "Disable Action Center";
            actionCenter.TextAlign = ContentAlignment.TopCenter;
            actionCenter.UseVisualStyleBackColor = true;
            actionCenter.CheckedChanged += actionCenter_checkChanged;
            // 
            // noGUIBoot
            // 
            noGUIBoot.AutoSize = true;
            noGUIBoot.ForeColor = SystemColors.ControlText;
            noGUIBoot.Location = new Point(12, 360);
            noGUIBoot.Name = "noGUIBoot";
            noGUIBoot.Size = new Size(130, 19);
            noGUIBoot.TabIndex = 14;
            noGUIBoot.Text = "Enable No GUI Boot";
            noGUIBoot.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(noGUIBoot, "No GUI boot disables the effects on Windows boot.");
            noGUIBoot.UseVisualStyleBackColor = true;
            noGUIBoot.CheckedChanged += noGUIBoot_checkChanged;
            // 
            // focusAssist
            // 
            focusAssist.AutoSize = true;
            focusAssist.ForeColor = SystemColors.ControlText;
            focusAssist.Location = new Point(12, 385);
            focusAssist.Name = "focusAssist";
            focusAssist.Size = new Size(129, 19);
            focusAssist.TabIndex = 15;
            focusAssist.Text = "Disable Focus assist";
            focusAssist.TextAlign = ContentAlignment.TopCenter;
            focusAssist.UseVisualStyleBackColor = true;
            focusAssist.CheckedChanged += focusAssist_checkChanged;
            // 
            // liveTiles
            // 
            liveTiles.AutoSize = true;
            liveTiles.ForeColor = SystemColors.ControlText;
            liveTiles.Location = new Point(12, 410);
            liveTiles.Name = "liveTiles";
            liveTiles.Size = new Size(109, 19);
            liveTiles.TabIndex = 16;
            liveTiles.Text = "Disable live tiles";
            liveTiles.TextAlign = ContentAlignment.TopCenter;
            liveTiles.UseVisualStyleBackColor = true;
            liveTiles.CheckedChanged += liveTiles_checkChanged;
            // 
            // lockPowerOption
            // 
            lockPowerOption.AutoSize = true;
            lockPowerOption.ForeColor = SystemColors.ControlText;
            lockPowerOption.Location = new Point(12, 435);
            lockPowerOption.Name = "lockPowerOption";
            lockPowerOption.Size = new Size(163, 19);
            lockPowerOption.TabIndex = 17;
            lockPowerOption.Text = "Disable lock power option";
            lockPowerOption.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(lockPowerOption, "Disables the lock function in Windows.");
            lockPowerOption.UseVisualStyleBackColor = true;
            lockPowerOption.CheckedChanged += lockPowerOption_checkChanged;
            // 
            // lockScreenBlur
            // 
            lockScreenBlur.AutoSize = true;
            lockScreenBlur.ForeColor = SystemColors.ControlText;
            lockScreenBlur.Location = new Point(12, 460);
            lockScreenBlur.Name = "lockScreenBlur";
            lockScreenBlur.Size = new Size(150, 19);
            lockScreenBlur.TabIndex = 18;
            lockScreenBlur.Text = "Disable lock screen blur";
            lockScreenBlur.TextAlign = ContentAlignment.TopCenter;
            lockScreenBlur.UseVisualStyleBackColor = true;
            lockScreenBlur.CheckedChanged += lockScreenBlur_checkChanged;
            // 
            // mobilityCentre
            // 
            mobilityCentre.AutoSize = true;
            mobilityCentre.ForeColor = SystemColors.ControlText;
            mobilityCentre.Location = new Point(12, 485);
            mobilityCentre.Name = "mobilityCentre";
            mobilityCentre.Size = new Size(197, 19);
            mobilityCentre.TabIndex = 19;
            mobilityCentre.Text = "Disable windows mobility centre";
            mobilityCentre.TextAlign = ContentAlignment.TopCenter;
            mobilityCentre.UseVisualStyleBackColor = true;
            mobilityCentre.CheckedChanged += mobilityCentre_checkChanged;
            // 
            // disableNotifications
            // 
            disableNotifications.AutoSize = true;
            disableNotifications.ForeColor = SystemColors.ControlText;
            disableNotifications.Location = new Point(12, 510);
            disableNotifications.Name = "disableNotifications";
            disableNotifications.Size = new Size(133, 19);
            disableNotifications.TabIndex = 20;
            disableNotifications.Text = "Disable notifications";
            disableNotifications.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableNotifications, "Disable app and windows notifications (Except critical notifications like windows defender)");
            disableNotifications.UseVisualStyleBackColor = true;
            disableNotifications.CheckedChanged += disableNotifications_checkChanged;
            // 
            // disableOneDrive
            // 
            disableOneDrive.AutoSize = true;
            disableOneDrive.ForeColor = SystemColors.ControlText;
            disableOneDrive.Location = new Point(12, 535);
            disableOneDrive.Name = "disableOneDrive";
            disableOneDrive.Size = new Size(116, 19);
            disableOneDrive.TabIndex = 21;
            disableOneDrive.Text = "Disable OneDrive";
            disableOneDrive.TextAlign = ContentAlignment.TopCenter;
            disableOneDrive.UseVisualStyleBackColor = true;
            disableOneDrive.CheckedChanged += disableOneDrive_checkChanged;
            // 
            // personalisedItems
            // 
            personalisedItems.AutoSize = true;
            personalisedItems.ForeColor = SystemColors.ControlText;
            personalisedItems.Location = new Point(12, 560);
            personalisedItems.Name = "personalisedItems";
            personalisedItems.Size = new Size(214, 19);
            personalisedItems.TabIndex = 22;
            personalisedItems.Text = "Disable Showing Personalised Items";
            personalisedItems.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(personalisedItems, "Disable personalised results like recent documents and files etc..");
            personalisedItems.UseVisualStyleBackColor = true;
            personalisedItems.CheckedChanged += personalisedItems_checkChanged;
            // 
            // searchHighlights
            // 
            searchHighlights.AutoSize = true;
            searchHighlights.ForeColor = SystemColors.ControlText;
            searchHighlights.Location = new Point(12, 585);
            searchHighlights.Name = "searchHighlights";
            searchHighlights.Size = new Size(158, 19);
            searchHighlights.TabIndex = 23;
            searchHighlights.Text = "Disable Search highlights";
            searchHighlights.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(searchHighlights, "Basically just disables Cortana results in search and Bing search for less bloat.");
            searchHighlights.UseVisualStyleBackColor = true;
            searchHighlights.CheckedChanged += searchHighlights_checkChanged;
            // 
            // disableTransparency
            // 
            disableTransparency.AutoSize = true;
            disableTransparency.ForeColor = SystemColors.ControlText;
            disableTransparency.Location = new Point(12, 610);
            disableTransparency.Name = "disableTransparency";
            disableTransparency.Size = new Size(136, 19);
            disableTransparency.TabIndex = 24;
            disableTransparency.Text = "Disable Transparency";
            disableTransparency.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableTransparency, "Disables Windows Transparency Effects in Personalisation.");
            disableTransparency.UseVisualStyleBackColor = true;
            disableTransparency.CheckedChanged += disableTransparency_checkChanged;
            // 
            // disableCopilot
            // 
            disableCopilot.AutoSize = true;
            disableCopilot.ForeColor = SystemColors.ControlText;
            disableCopilot.Location = new Point(12, 635);
            disableCopilot.Name = "disableCopilot";
            disableCopilot.Size = new Size(158, 19);
            disableCopilot.TabIndex = 25;
            disableCopilot.Text = "Disable Windows Copilot";
            disableCopilot.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableCopilot, "Disables the AI bloat on Win11.");
            disableCopilot.UseVisualStyleBackColor = true;
            disableCopilot.CheckedChanged += disableCopilot_checkChanged;
            // 
            // enableClassicAltTab
            // 
            enableClassicAltTab.AutoSize = true;
            enableClassicAltTab.ForeColor = SystemColors.ControlText;
            enableClassicAltTab.Location = new Point(12, 660);
            enableClassicAltTab.Name = "enableClassicAltTab";
            enableClassicAltTab.Size = new Size(175, 19);
            enableClassicAltTab.TabIndex = 26;
            enableClassicAltTab.Text = "Enable Classic Alt-Tab Menu";
            enableClassicAltTab.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(enableClassicAltTab, "Use classic Windows 10 alt-menu.");
            enableClassicAltTab.UseVisualStyleBackColor = true;
            enableClassicAltTab.CheckedChanged += enableClassicAltTab_checkChanged;
            // 
            // performanceVisual
            // 
            performanceVisual.AutoSize = true;
            performanceVisual.ForeColor = SystemColors.ControlText;
            performanceVisual.Location = new Point(248, 110);
            performanceVisual.Name = "performanceVisual";
            performanceVisual.Size = new Size(202, 19);
            performanceVisual.TabIndex = 27;
            performanceVisual.Text = "Set visual effects for performance";
            performanceVisual.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(performanceVisual, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            performanceVisual.UseVisualStyleBackColor = true;
            performanceVisual.CheckedChanged += performanceVisual_checkChanged;
            // 
            // darkMode
            // 
            darkMode.AutoSize = true;
            darkMode.ForeColor = SystemColors.ControlText;
            darkMode.Location = new Point(248, 36);
            darkMode.Name = "darkMode";
            darkMode.Size = new Size(174, 19);
            darkMode.TabIndex = 28;
            darkMode.Text = "Enable Windows Dark Mode";
            darkMode.TextAlign = ContentAlignment.TopCenter;
            darkMode.UseVisualStyleBackColor = true;
            darkMode.CheckedChanged += darkMode_checkChanged;
            // 
            // ClassicRightClick
            // 
            ClassicRightClick.AutoSize = true;
            ClassicRightClick.ForeColor = SystemColors.ControlText;
            ClassicRightClick.Location = new Point(248, 60);
            ClassicRightClick.Name = "ClassicRightClick";
            ClassicRightClick.Size = new Size(196, 19);
            ClassicRightClick.TabIndex = 29;
            ClassicRightClick.Text = "Enable Classic Right-Click Menu";
            ClassicRightClick.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(ClassicRightClick, "Use the old right-click menu used in Windows 10, but for 11.");
            ClassicRightClick.UseVisualStyleBackColor = true;
            ClassicRightClick.CheckedChanged += ClassicRightClick_checkChanged;
            // 
            // disableshortcutSuffix
            // 
            disableshortcutSuffix.AutoSize = true;
            disableshortcutSuffix.ForeColor = SystemColors.ControlText;
            disableshortcutSuffix.Location = new Point(248, 85);
            disableshortcutSuffix.Name = "disableshortcutSuffix";
            disableshortcutSuffix.Size = new Size(229, 19);
            disableshortcutSuffix.TabIndex = 30;
            disableshortcutSuffix.Text = "Disable \"-Shortcut\" suffix for shortcuts";
            disableshortcutSuffix.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableshortcutSuffix, "Disables the \"-Shortcut\" text that is inputted after\r\na shortcut is created.");
            disableshortcutSuffix.UseVisualStyleBackColor = true;
            disableshortcutSuffix.CheckedChanged += disableshortcutSuffix_checkChanged;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            info.ForeColor = SystemColors.ControlText;
            info.Location = new Point(12, 9);
            info.Name = "info";
            info.Size = new Size(250, 15);
            info.TabIndex = 31;
            info.Text = "Hover over each optimisation for more info";
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
            ultimatePerformance.Location = new Point(248, 135);
            ultimatePerformance.Name = "ultimatePerformance";
            ultimatePerformance.Size = new Size(237, 19);
            ultimatePerformance.TabIndex = 32;
            ultimatePerformance.Text = "Set power plan to Ultimate Performance";
            ultimatePerformance.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(ultimatePerformance, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            ultimatePerformance.UseVisualStyleBackColor = true;
            ultimatePerformance.CheckedChanged += ultimatePerformance_checkChanged;
            // 
            // disablePowerThrottling
            // 
            disablePowerThrottling.AutoSize = true;
            disablePowerThrottling.ForeColor = SystemColors.ControlText;
            disablePowerThrottling.Location = new Point(248, 160);
            disablePowerThrottling.Name = "disablePowerThrottling";
            disablePowerThrottling.Size = new Size(207, 19);
            disablePowerThrottling.TabIndex = 33;
            disablePowerThrottling.Text = "Disable Windows Power Throttling";
            disablePowerThrottling.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disablePowerThrottling, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            disablePowerThrottling.UseVisualStyleBackColor = true;
            disablePowerThrottling.CheckedChanged += disablePowerThrottling_checkChanged;
            // 
            // disableHibernation
            // 
            disableHibernation.AutoSize = true;
            disableHibernation.ForeColor = SystemColors.ControlText;
            disableHibernation.Location = new Point(248, 185);
            disableHibernation.Name = "disableHibernation";
            disableHibernation.Size = new Size(182, 19);
            disableHibernation.TabIndex = 34;
            disableHibernation.Text = "Disable Windows Hibernation";
            disableHibernation.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableHibernation, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            disableHibernation.UseVisualStyleBackColor = true;
            disableHibernation.CheckedChanged += disableHibernation_checkChanged;
            // 
            // taskBarStartMenuTelemetry
            // 
            taskBarStartMenuTelemetry.AutoSize = true;
            taskBarStartMenuTelemetry.ForeColor = SystemColors.ControlText;
            taskBarStartMenuTelemetry.Location = new Point(248, 210);
            taskBarStartMenuTelemetry.Name = "taskBarStartMenuTelemetry";
            taskBarStartMenuTelemetry.Size = new Size(244, 19);
            taskBarStartMenuTelemetry.TabIndex = 35;
            taskBarStartMenuTelemetry.Text = "Disable TaskBar and Start Menu Telemetry";
            taskBarStartMenuTelemetry.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(taskBarStartMenuTelemetry, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            taskBarStartMenuTelemetry.UseVisualStyleBackColor = true;
            taskBarStartMenuTelemetry.CheckedChanged += taskBarStartMenuTelemetry_checkChanged;
            // 
            // BCDEdit
            // 
            BCDEdit.AutoSize = true;
            BCDEdit.ForeColor = SystemColors.ControlText;
            BCDEdit.Location = new Point(248, 235);
            BCDEdit.Name = "BCDEdit";
            BCDEdit.Size = new Size(165, 19);
            BCDEdit.TabIndex = 36;
            BCDEdit.Text = "Optimise BCDEdit Settings";
            BCDEdit.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(BCDEdit, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            BCDEdit.UseVisualStyleBackColor = true;
            BCDEdit.CheckedChanged += BCDEdit_checkChanged;
            // 
            // disableBluetooth
            // 
            disableBluetooth.AutoSize = true;
            disableBluetooth.ForeColor = SystemColors.ControlText;
            disableBluetooth.Location = new Point(248, 260);
            disableBluetooth.Name = "disableBluetooth";
            disableBluetooth.Size = new Size(119, 19);
            disableBluetooth.TabIndex = 37;
            disableBluetooth.Text = "Disable Bluetooth";
            disableBluetooth.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableBluetooth, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            disableBluetooth.UseVisualStyleBackColor = true;
            disableBluetooth.CheckedChanged += disableBluetooth_checkChanged;
            // 
            // disableWiFi
            // 
            disableWiFi.AutoSize = true;
            disableWiFi.ForeColor = SystemColors.ControlText;
            disableWiFi.Location = new Point(248, 285);
            disableWiFi.Name = "disableWiFi";
            disableWiFi.Size = new Size(90, 19);
            disableWiFi.TabIndex = 38;
            disableWiFi.Text = "Disable WiFi";
            disableWiFi.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableWiFi, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            disableWiFi.UseVisualStyleBackColor = true;
            disableWiFi.CheckedChanged += disableWiFi_checkChanegd;
            // 
            // disableEthernet
            // 
            disableEthernet.AutoSize = true;
            disableEthernet.ForeColor = SystemColors.ControlText;
            disableEthernet.Location = new Point(248, 310);
            disableEthernet.Name = "disableEthernet";
            disableEthernet.Size = new Size(111, 19);
            disableEthernet.TabIndex = 39;
            disableEthernet.Text = "Disable Ethernet";
            disableEthernet.TextAlign = ContentAlignment.TopCenter;
            toolTip.SetToolTip(disableEthernet, "This sets all the Visual effects options to disabled in SystemPropertiesPerformance.exe");
            disableEthernet.UseVisualStyleBackColor = true;
            disableEthernet.CheckedChanged += disableEthernet_checkChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 685);
            Controls.Add(disableEthernet);
            Controls.Add(disableWiFi);
            Controls.Add(disableBluetooth);
            Controls.Add(BCDEdit);
            Controls.Add(taskBarStartMenuTelemetry);
            Controls.Add(disableHibernation);
            Controls.Add(disablePowerThrottling);
            Controls.Add(ultimatePerformance);
            Controls.Add(info);
            Controls.Add(disableshortcutSuffix);
            Controls.Add(ClassicRightClick);
            Controls.Add(darkMode);
            Controls.Add(performanceVisual);
            Controls.Add(enableClassicAltTab);
            Controls.Add(disableCopilot);
            Controls.Add(disableTransparency);
            Controls.Add(searchHighlights);
            Controls.Add(personalisedItems);
            Controls.Add(disableOneDrive);
            Controls.Add(disableNotifications);
            Controls.Add(mobilityCentre);
            Controls.Add(lockScreenBlur);
            Controls.Add(lockPowerOption);
            Controls.Add(liveTiles);
            Controls.Add(focusAssist);
            Controls.Add(noGUIBoot);
            Controls.Add(actionCenter);
            Controls.Add(taskBarStart);
            Controls.Add(touchSettings);
            Controls.Add(disableXbox);
            Controls.Add(disablesearchIndex);
            Controls.Add(disableInsider);
            Controls.Add(errorReporting);
            Controls.Add(restore);
            Controls.Add(snapAssist);
            Controls.Add(easeOfAccess);
            Controls.Add(PrintAndFax);
            Controls.Add(cortana);
            Controls.Add(xboxGameBar);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Windows ToolBox [v1.0] (Recommended to restart PC after changes)";
            Load += Form1_Load;
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
        private CheckBox taskBarStartMenuTelemetry;
        private CheckBox BCDEdit;
        private CheckBox disableBluetooth;
        private CheckBox disableWiFi;
        private CheckBox disableEthernet;
    }
}
