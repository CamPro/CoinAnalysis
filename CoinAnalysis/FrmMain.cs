using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> listCoinCode = new List<string>();

            string[] listCoinExclude = File.ReadAllLines("setting_coin_exclude.txt");

            // start chrome driver
            StartChromeDriver();
            Thread.Sleep(1000);

            /*
            for (int page = 1; page <= 5; page++)
            {
                driver.Navigate().GoToUrl($"https://coinmarketcap.com/?page={page}");
                Thread.Sleep(2000);

                element = driver.FindElement(By.CssSelector("[data-role='select-trigger']"));

                // hover
                js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'})", element);
                Thread.Sleep(500);
                action.MoveToElement(element).MoveByOffset(1, 1).Perform();
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

            File.WriteAllLines("list_500_coin.txt", listCoinCode, Encoding.UTF8);
            */
            listCoinCode = File.ReadAllLines("list_500_coin.txt", Encoding.UTF8).ToList();

            string folderImage = Path.Combine(Application.StartupPath, "CoinGlass");

            if (!Directory.Exists(folderImage)) Directory.CreateDirectory(folderImage);

            int start = 60;

            for (int i = start; i < listCoinCode.Count; i++)
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

            SystemSounds.Asterisk.Play();

            Application.Exit();
        }

    }
}
