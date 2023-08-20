using System.Runtime.InteropServices;

namespace Dynamic_Desktop
{
    public partial class Form1
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        
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
        private void ChangeWallpaper()
        {
            while (true)
            {
                // Get the current hour of the day
                int currentHour = DateTime.Now.Hour;

                // Define paths to your wallpaper images for different times of the day
                string morningWallpaper = @"C:\Users\NGC\Downloads\wall_after.png";
                string afternoonWallpaper = @"C:\Users\NGC\Downloads\wall_after.png";
                string eveningWallpaper = @"C:\Users\NGC\Downloads\wall_after.png";
                string nightWallpaper = @"C:\Path\To\NightWallpaper.jpg";

                // Set the appropriate wallpaper based on the current time
                string wallpaperPath = GetWallpaperPath(currentHour, morningWallpaper, afternoonWallpaper, eveningWallpaper, nightWallpaper);

                // Call the SystemParametersInfo function to set the wallpaper
                SystemParametersInfo(0x0014, 0, wallpaperPath, 0x0001 | 0x0002);

                // Sleep for some time before checking and changing the wallpaper again (e.g., 1 hour)
                Thread.Sleep(3600000); // 1 hour in milliseconds
            }
        }
        private string GetWallpaperPath(int hour, string morning, string afternoon, string evening, string night)
        {
            if (hour >= 5 && hour < 12)
            {
                return morning; // Morning (5 AM to 11:59 AM)
            }
            else if (hour >= 12 && hour < 17)
            {
                return afternoon; // Afternoon (12 PM to 4:59 PM)
            }
            else if (hour >= 17 && hour < 20)
            {
                return evening; // Evening (5 PM to 7:59 PM)
            }
            else
            {
                return night; // Night (8 PM to 4:59 AM)
            }
        }
        private void StartWallpaperChanger()
        {
            Thread wallpaperThread = new Thread(ChangeWallpaper);
            wallpaperThread.Start();
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}