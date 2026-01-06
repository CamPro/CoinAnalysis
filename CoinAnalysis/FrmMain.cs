using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinAnalysis
{
    public partial class FrmMain : Form
    {
        public static string FolderUserData = Path.Combine(Application.StartupPath, "ChromeUserData");

        public string folderLONG = Path.Combine(Application.StartupPath, "CoinGlass_LONG");
        public string folderSHORT = Path.Combine(Application.StartupPath, "CoinGlass_SHORT");

        public string folderListLONG = Path.Combine(Application.StartupPath, "list_LONG");
        public string folderListSHORT = Path.Combine(Application.StartupPath, "list_SHORT");

        public static ChromeDriver driver = null;
        public static ReadOnlyCollection<IWebElement> elements = null;
        public static IWebElement element = null;
        public static Actions actions = null;
        public static IJavaScriptExecutor js;

        public FrmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Process pc_chrome = new Process();
            pc_chrome.StartInfo.FileName = ".\\runtimes\\win\\native\\selenium-manager.exe";
            pc_chrome.StartInfo.Arguments = "--browser chrome";
            pc_chrome.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pc_chrome.Start();
            pc_chrome.WaitForExit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void StartChromeDriver()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();

            options.AddArgument($"--user-data-dir={FolderUserData}");

            options.AddArgument("--start-maximized");
            //options.AddArgument("--disable-notifications");
            //options.AddArgument("--disable-infobars");
            //options.AddArgument("--disable-popup-blocking");

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            // Undetected webdriver
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddExcludedArgument("enable-automation");
            options.AddExcludedArguments(new List<string>() { "enable-automation" });
            options.AddAdditionalChromeOption("useAutomationExtension", false);

            driver = new ChromeDriver(service, options);

            js = (IJavaScriptExecutor)driver;
            actions = new Actions(driver);
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath);
        }

        private void buttonOpenProfile_Click(object sender, EventArgs e)
        {
            Process pc_chrome = new Process();
            pc_chrome.StartInfo.FileName = "chrome.exe";
            pc_chrome.StartInfo.Arguments = $"https://www.binance.com/vi --start-maximized --user-data-dir={FolderUserData}";
            pc_chrome.Start();
        }

        private void buttonOpenDriver_Click(object sender, EventArgs e)
        {
            StartChromeDriver();
            for (int i = 0; i < 60 * 60; i++)
            {
                Thread.Sleep(1000);
                try
                {
                    driver.FindElement(By.CssSelector("body, div"));
                }
                catch (Exception)
                {
                    break;
                }
            }
            driver.Quit();
        }
        
        private void buttonScanAnalysis_Click(object sender, EventArgs e)
        {
            List<string> listCoinCode = new List<string>();

            string[] listCoinExclude = File.ReadAllLines("setting_coin_exclude.txt");

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            int numPage = Convert.ToInt32(numPageCMC.Value);

            for (int page = 1; page <= numPage; page++)
            {
                driver.Navigate().GoToUrl($"https://coinmarketcap.com/?page={page}");
                Thread.Sleep(2000);

                element = driver.FindElement(By.CssSelector("[data-role='select-trigger']"));

                // hover
                js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);
                Thread.Sleep(500);
                actions.MoveToElement(element).MoveByOffset(1, 1).Perform();
                Thread.Sleep(500);

                // scan list
                elements = driver.FindElements(By.CssSelector("table tbody tr td span.coin-item div[data-nosnippet='true']"));
                foreach (var element in elements)
                {
                    string coinCode = element.Text.Trim();
                    if (string.IsNullOrEmpty(coinCode))
                    {
                        continue;
                    }
                    listCoinCode.Add(coinCode);
                }
            }

            listCoinCode = listCoinCode.Distinct().ToList();

            File.WriteAllLines("list_coins.txt", listCoinCode, Encoding.UTF8);

            //listCoinCode = File.ReadAllLines("list_coins.txt", Encoding.UTF8).ToList();

            string folderImage = Path.Combine(Application.StartupPath, "CoinGlass");

            if (Directory.Exists(folderImage)) Directory.Delete(folderImage, true);
            Thread.Sleep(10);

            if (!Directory.Exists(folderImage)) Directory.CreateDirectory(folderImage);

            int startIndex = Convert.ToInt32(numStartIndex.Value);

            for (int i = startIndex; i < listCoinCode.Count; i++)
            {
                string coinCode = listCoinCode[i];

                if (listCoinExclude.Contains(coinCode)) continue;

                this.Text = $"{i} - {coinCode}";

                // move mouse
                Cursor.Position = new Point(0, 0);

                try
                {
                    driver.Navigate().GoToUrl($"https://www.coinglass.com/en/pro/futures/LiquidationHeatMap?coin={coinCode}&type=pair");
                    Thread.Sleep(500);

                    // wait chart
                    for (var tw = 0; tw < 3; tw++)
                    {
                        try
                        {
                            element = driver.FindElement(By.CssSelector("canvas[data-zr-dom-id]"));
                            break;
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(1000);
                        }
                    }

                    element = driver.FindElement(By.CssSelector("canvas[data-zr-dom-id]"));

                    // hover
                    js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);
                    Thread.Sleep(500);

                    // Chụp màn hình
                    Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    Bitmap fullImage = new Bitmap(new System.IO.MemoryStream(screenshot.AsByteArray));

                    // Lấy vị trí & kích thước element
                    Point location = element.Location;
                    Size size = element.Size;
                    // Crop ảnh
                    Rectangle cropArea = new Rectangle(location.X, 0, size.Width, size.Height);
                    Bitmap elementImage = fullImage.Clone(cropArea, fullImage.PixelFormat);

                    // lưu ảnh
                    elementImage.Save(Path.Combine(folderImage, $"cl_{coinCode}.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch (Exception)
                {
                    File.AppendAllText("list_coin_error.txt", $"{coinCode}{Environment.NewLine}");
                    continue;
                }
            }

            driver.Quit();

            // Analysis
            buttonAnalysis_Click(null, null);

            SystemSounds.Asterisk.Play();
            Application.Exit();
        }

        private void buttonAnalysis_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(folderLONG)) Directory.Delete(folderLONG, true);
            if (Directory.Exists(folderSHORT)) Directory.Delete(folderSHORT, true);
            Thread.Sleep(10);

            if (!Directory.Exists(folderLONG)) Directory.CreateDirectory(folderLONG);
            if (!Directory.Exists(folderSHORT)) Directory.CreateDirectory(folderSHORT);

            if (!Directory.Exists(folderListLONG)) Directory.CreateDirectory(folderListLONG);
            if (!Directory.Exists(folderListSHORT)) Directory.CreateDirectory(folderListSHORT);

            List<string> listLONG = new List<string>();
            List<string> listSHORT = new List<string>();

            string[] fileImages = Directory.GetFiles("D:\\CoinAnalysis\\CoinAnalysis\\bin\\Debug\\CoinGlass");

            foreach (string fileImage in fileImages)
            {
                string coinCode = fileImage.Split('_').Last().Split('.').First();

                byte[] bytes = File.ReadAllBytes(fileImage);
                MemoryStream ms = new MemoryStream(bytes);
                Image img = Image.FromStream(ms);

                Bitmap fullImage = new Bitmap(img);

                int cropX = fullImage.Width * 90 / 100; // lấy đoạn bên phải
                int cropY = 62;
                int cropWidth = 100; // cách từ biên giới màu trắng bên phải lấy 100px
                int cropHeight = 590;
                Color color = Color.White;

                // tìm biên giới màu trắng bên phải
                for (int i = cropX; i < fullImage.Width; i++)
                {
                    color = fullImage.GetPixel(i, cropY + 10);

                    if (color.R > 200 && color.G > 200 && color.B > 200)
                    {
                        cropX = i - cropWidth - 1;
                        break;
                    }
                }

                // Crop ảnh
                Rectangle cropArea = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                fullImage = fullImage.Clone(cropArea, fullImage.PixelFormat);

                //fullImage.Save(fileImage.Replace("\\CoinGlass", ""), System.Drawing.Imaging.ImageFormat.Jpeg);

                // quét tìm điểm MÀU ĐỎ để lấy mốc phân trên dưới, mặc định mốc ở giữa ảnh
                int centerY = fullImage.Height / 2;
                for (var x = fullImage.Width - 1; x > 0; x--)
                {
                    for (var y = 0; y < fullImage.Height; y++)
                    {
                        color = fullImage.GetPixel(x, y);

                        if (color.R > 160 && color.G < 85 && color.B < 140)
                        {
                            centerY = y;
                            x = 0;
                            break;
                        }
                    }
                }

                // đếm số điểm MÀU VÀNG trên và dưới
                int numYellowUp = 0;
                int numYellowDown = 0;
                int numYellowUpHight = 0;
                int numYellowDownHight = 0;

                for (var y = 0; y < fullImage.Height; y++)
                {
                    color = fullImage.GetPixel(fullImage.Width - 5, y);
                    // đếm số vàng nhạt
                    if (color.R > 130 && color.G > 140 && color.B < 100)
                    {
                        if (y < centerY)
                        {
                            numYellowUp += 1;
                        }
                        else
                        {
                            numYellowDown += 1;
                        }
                    }
                    // đếm số vàng đậm
                    if (color.R > 200 && color.G > 200 && color.B < 85)
                    {
                        if (y < centerY)
                        {
                            numYellowUpHight += 1;
                        }
                        else
                        {
                            numYellowDownHight += 1;
                        }
                    }
                }

                int pixelYellow = Convert.ToInt32(numYellowPixel.Value);

                if (numYellowUpHight >= pixelYellow && numYellowDown == 0)
                {
                    File.Copy(fileImage, fileImage.Replace("\\CoinGlass", "\\CoinGlass_LONG"), true);

                    listLONG.Add(coinCode);
                }

                if (numYellowUp == 0 && numYellowDownHight >= pixelYellow)
                {
                    File.Copy(fileImage, fileImage.Replace("\\CoinGlass", "\\CoinGlass_SHORT"), true);

                    listSHORT.Add(coinCode);
                }
            }

            string listLongFile = Path.Combine(folderListLONG, "coin_long_" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt");
            string listShortFile = Path.Combine(folderListSHORT, "coin_short_" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt");

            File.WriteAllLines(listLongFile, listLONG, Encoding.UTF8);
            File.WriteAllLines(listShortFile, listSHORT, Encoding.UTF8);
        }

        private void buttonListCompare_Click(object sender, EventArgs e)
        {
            string listLongFileToday = Path.Combine(folderListLONG, "coin_long_" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt");
            string listLongFileYesterday = Path.Combine(folderListLONG, "coin_long_" + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + ".txt");

            if (!File.Exists(listLongFileToday) || !File.Exists(listLongFileYesterday))
            {
                return;
            }

            List<string> listLongToday = File.ReadAllLines(listLongFileToday, Encoding.UTF8).ToList();
            List<string> listLongYesterday = File.ReadAllLines(listLongFileYesterday, Encoding.UTF8).ToList();

            List<string> intersection = listLongToday.Intersect(listLongYesterday).ToList();

            MessageBox.Show(string.Join("\n", intersection));
        }
    }
}
