namespace Dynamic_Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartWallpaperChanger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chooseEveningWallpaperButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Select Evening Wallpaper Image",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                eveningWallpaper = openFileDialog.FileName;
            }
        }

        private void chooseMorningWallpaperButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Select Morning Wallpaper Image",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                morningWallpaper = openFileDialog.FileName;
            }
        }

        private void chooseAfternoonWallpaperButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Select Afternoon Wallpaper Image",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                afternoonWallpaper = openFileDialog.FileName;
            }
        }

        private void chooseNightWallpaperButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Select Night Wallpaper Image",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                nightWallpaper = openFileDialog.FileName;
            }
        }

        private void setWallpaperButton_Click(object sender, EventArgs e)
        {
            // Get the current hour of the day
            int currentHour = DateTime.Now.Hour;

            // Determine which wallpaper to use based on the current time
            string wallpaperPath = GetWallpaperPath(currentHour);

            // Call the SystemParametersInfo function to set the wallpaper
            SystemParametersInfo(0x0014, 0, wallpaperPath, 0x0001 | 0x0002);

            MessageBox.Show("Wallpaper set successfully!");
        }
    }
}