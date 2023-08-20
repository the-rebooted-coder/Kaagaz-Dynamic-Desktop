using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System;

namespace Dynamic_Desktop
{
    public partial class Form1
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        private string morningWallpaper = "";
        private string afternoonWallpaper = "";
        private string eveningWallpaper = "";
        private string nightWallpaper = "";
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void ChangeWallpaper()
        {
            while (true)
            {
                // Get the current hour of the day
                int currentHour = DateTime.Now.Hour;

                // Determine which wallpaper to use based on the current time
                string wallpaperPath = GetWallpaperPath(currentHour);

                // Call the SystemParametersInfo function to set the wallpaper
                SystemParametersInfo(0x0014, 0, wallpaperPath, 0x0001 | 0x0002);

                // Sleep for some time before checking and changing the wallpaper again (e.g., 1 hour)
                Thread.Sleep(3600000); // 1 hour in milliseconds
            }
        }
        private string GetWallpaperPath(int hour)
        {
            if (hour >= 5 && hour < 12)
            {
                return morningWallpaper; // Morning (5 AM to 11:59 AM)
            }
            else if (hour >= 12 && hour < 17)
            {
                return afternoonWallpaper; // Afternoon (12 PM to 4:59 PM)
            }
            else if (hour >= 17 && hour < 20)
            {
                return eveningWallpaper; // Evening (5 PM to 7:59 PM)
            }
            else
            {
                return nightWallpaper; // Night (8 PM to 4:59 AM)
            }
        }
        private void StartWallpaperChanger()
        {
            Thread wallpaperThread = new Thread(ChangeWallpaper);
            wallpaperThread.Start();
        }
        private void InitializeComponent()
        {
            chooseMorningWallpaperButton = new Button();
            chooseAfternoonWallpaperButton = new Button();
            chooseEveningWallpaperButton = new Button();
            chooseNightWallpaperButton = new Button();
            label1 = new Label();
            setWallpaperButton = new Button();
            SuspendLayout();
            // 
            // chooseMorningWallpaperButton
            // 
            chooseMorningWallpaperButton.Location = new Point(274, 61);
            chooseMorningWallpaperButton.Name = "chooseMorningWallpaperButton";
            chooseMorningWallpaperButton.Size = new Size(138, 33);
            chooseMorningWallpaperButton.TabIndex = 1;
            chooseMorningWallpaperButton.Text = "Morning Image";
            chooseMorningWallpaperButton.UseVisualStyleBackColor = true;
            chooseMorningWallpaperButton.Click += chooseMorningWallpaperButton_Click_1;
            // 
            // chooseAfternoonWallpaperButton
            // 
            chooseAfternoonWallpaperButton.Location = new Point(274, 100);
            chooseAfternoonWallpaperButton.Name = "chooseAfternoonWallpaperButton";
            chooseAfternoonWallpaperButton.Size = new Size(138, 33);
            chooseAfternoonWallpaperButton.TabIndex = 2;
            chooseAfternoonWallpaperButton.Text = "Afternoon Image";
            chooseAfternoonWallpaperButton.UseVisualStyleBackColor = true;
            chooseAfternoonWallpaperButton.Click += chooseAfternoonWallpaperButton_Click_1;
            // 
            // chooseEveningWallpaperButton
            // 
            chooseEveningWallpaperButton.Location = new Point(274, 139);
            chooseEveningWallpaperButton.Name = "chooseEveningWallpaperButton";
            chooseEveningWallpaperButton.Size = new Size(138, 33);
            chooseEveningWallpaperButton.TabIndex = 3;
            chooseEveningWallpaperButton.Text = "Evening Image";
            chooseEveningWallpaperButton.UseVisualStyleBackColor = true;
            chooseEveningWallpaperButton.Click += chooseEveningWallpaperButton_Click_1;
            // 
            // chooseNightWallpaperButton
            // 
            chooseNightWallpaperButton.Location = new Point(274, 178);
            chooseNightWallpaperButton.Name = "chooseNightWallpaperButton";
            chooseNightWallpaperButton.Size = new Size(138, 33);
            chooseNightWallpaperButton.TabIndex = 4;
            chooseNightWallpaperButton.Text = "Night Image";
            chooseNightWallpaperButton.UseVisualStyleBackColor = true;
            chooseNightWallpaperButton.Click += chooseNightWallpaperButton_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(196, 9);
            label1.Name = "label1";
            label1.Size = new Size(304, 32);
            label1.TabIndex = 5;
            label1.Text = "Kaagaz Dynamic Desktop";
            // 
            // setWallpaperButton
            // 
            setWallpaperButton.BackColor = SystemColors.InactiveCaptionText;
            setWallpaperButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            setWallpaperButton.ForeColor = SystemColors.ButtonHighlight;
            setWallpaperButton.Location = new Point(257, 231);
            setWallpaperButton.Name = "setWallpaperButton";
            setWallpaperButton.Size = new Size(169, 33);
            setWallpaperButton.TabIndex = 6;
            setWallpaperButton.Text = "Kaagaz!";
            setWallpaperButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            setWallpaperButton.UseVisualStyleBackColor = false;
            setWallpaperButton.Click += setWallpaperButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(711, 356);
            Controls.Add(setWallpaperButton);
            Controls.Add(label1);
            Controls.Add(chooseNightWallpaperButton);
            Controls.Add(chooseEveningWallpaperButton);
            Controls.Add(chooseAfternoonWallpaperButton);
            Controls.Add(chooseMorningWallpaperButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button chooseMorningWallpaperButton;
        private Button chooseAfternoonWallpaperButton;
        private Button chooseEveningWallpaperButton;
        private Button chooseNightWallpaperButton;
        private Label label1;
        private Button setWallpaperButton;
    }
}