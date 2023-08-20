using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Timers;

namespace Dynamic_Desktop
{
    internal class WallpaperService
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private System.Timers.Timer timer; // Use the fully qualified name

        private string morningWallpaperPath = "";
        private string afternoonWallpaperPath = "";
        private string eveningWallpaperPath = "";
        private string nightWallpaperPath = "";

        public WallpaperService(string morningPath, string afternoonPath, string eveningPath, string nightPath)
        {
            morningWallpaperPath = morningPath;
            afternoonWallpaperPath = afternoonPath;
            eveningWallpaperPath = eveningPath;
            nightWallpaperPath = nightPath;

            timer = new System.Timers.Timer(); // Use the fully qualified name
            timer.Interval = 3600000; // 1 hour in milliseconds
            timer.Elapsed += new ElapsedEventHandler(ChangeWallpaper);
            timer.Start();
        }

        private void ChangeWallpaper(object sender, ElapsedEventArgs e)
        {
            int currentHour = DateTime.Now.Hour;
            string wallpaperPath = GetWallpaperPath(currentHour);
            SystemParametersInfo(0x0014, 0, wallpaperPath, 0x0001 | 0x0002);
        }

        private string GetWallpaperPath(int hour)
        {
            // Determine which wallpaper to use based on the current time
            if (hour >= 5 && hour < 12)
            {
                return morningWallpaperPath; // Morning (5 AM to 11:59 AM)
            }
            else if (hour >= 12 && hour < 17)
            {
                return afternoonWallpaperPath; // Afternoon (12 PM to 4:59 PM)
            }
            else if (hour >= 17 && hour < 20)
            {
                return eveningWallpaperPath; // Evening (5 PM to 7:59 PM)
            }
            else
            {
                return nightWallpaperPath; // Night (8 PM to 4:59 AM)
            }
        }
    }
}
