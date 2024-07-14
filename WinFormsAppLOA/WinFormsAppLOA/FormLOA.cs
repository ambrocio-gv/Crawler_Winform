using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;
using System.Text.Json;

namespace WinFormsAppLOA
{
    public partial class FormLOA : Form
    {
        public FormLOA()
        {
            InitializeComponent();
        }

        public static string CredentialsFile = AppDomain.CurrentDomain.BaseDirectory + @"\credentials.txt";
        private void FormLOA_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            loadCredentials();
            progressBar1.Minimum = 0;
        }

        public class Filedetails
        {
            public string Filename { get; set; }
            public string Description { get; set; }
            public string UploadDate { get; set; }
            public string UploadBy { get; set; }
        }

        public void DisbaleInterface(bool setting)
        {
            textBox_Username.Enabled = !setting;
            textBox_Password.Enabled = !setting;
            textBox_DownloadPath.Enabled = !setting;
            textBox_InquiryIDPath.Enabled = !setting;
            textBox_LogFilePath.Enabled = !setting;
            checkBox1.Enabled = !setting;
            button1.Enabled = !setting;
            button_DownloadedPath.Enabled = !setting;
            button_InquiryPath.Enabled = !setting;
            button_LogPath.Enabled = !setting;
        }





     



        private void button1_Click(object sender, EventArgs e)
        {


            if (ValidateTextboxIsNullOrEmpty() == true)
            {
                string message = "Fill Missing Textbox";
                string title = "Warning";
                MessageBox.Show(message, title);               
            }
            else
            {
                try
                {
                    DisbaleInterface(true);
                    RunWebDriver();
                    string message = "Done with Inquiry Text File!";
                    string title = "Success";
                    MessageBox.Show(message, title);
                    DisbaleInterface(false);
                    progressBar1.Value = 0;
                }
                catch (Exception ex)
                {
                    string title = "Error";
                    MessageBox.Show(ex.Message, title);
                }
            }
        }

        public bool ValidateTextboxIsNullOrEmpty()
        {
            if(String.IsNullOrEmpty(textBox_Username.Text) || String.IsNullOrEmpty(textBox_Password.Text)
                || String.IsNullOrEmpty(textBox_DownloadPath.Text) || String.IsNullOrEmpty(textBox_InquiryIDPath.Text) || String.IsNullOrEmpty(textBox_LogFilePath.Text)){
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public List<string> enquiryList;
        public int enquiryNumber;

        public List<IWebElement> webElementsAll = new List<IWebElement>();
        public List<Filedetails> FiledetailsList = new List<Filedetails>();

        public void RunWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("profile.content_settings.exceptions.automatic_downloads.*.setting", 1);
            chromeOptions.AddUserProfilePreference("download.default_directory", textBox_DownloadPath.Text);
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            chromeOptions.AddArgument(@"--incognito");

            var driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromSeconds(240));

            driver.Navigate().GoToUrl(@"https://hj.200ok.co/LogOn?ReturnUrl=%2f");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();

            var UsernameTextBox = driver.FindElement(By.Id("username"));
            UsernameTextBox.SendKeys(textBox_Username.Text);
            var PasswordTextBox = driver.FindElement(By.Id("password"));
            PasswordTextBox.SendKeys(textBox_Password.Text);
            var LoginButton = driver.FindElement(By.XPath("/html/body/div/div/div/form/div[5]/div/input"));
            LoginButton.Click();

            EnquiryTextRead();

            var delimiter = "\t";
            string status = "";
            string startTime = "";
            string endTime = "";
            string elapseTime = "";
            int numberOfFilesInt = 0;

            string[] headerArray = { "Enquiry ID", "Status", "Start Time", "End Time", "Elapse Time", "Number of Files", "File Description" };

            using (var writer = new StreamWriter(textBox_LogFilePath.Text, true))
            {
                var line = string.Join(delimiter, headerArray);
                writer.WriteLine(line);
            }

            for (int i = 0; i <= enquiryNumber - 1; i++)
            {

                if (i == 0)
                {
                    progressBar1.Maximum = enquiryNumber;
                }

                progressBar1.Value = i+1;


                var EnquiryIDTextBox = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/div[1]/form/div/input[3]"));
                EnquiryIDTextBox.SendKeys(enquiryList[0]);

                var EnquiryGoToButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/div[1]/form/div/span/input"));
                EnquiryGoToButton.Click();

                var startTimestamp = new DateTimeOffset(DateTime.UtcNow);
                startTime = startTimestamp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

                if (driver.FindElements(By.XPath("/html/body/div/div[2]/div[1]/div[2]/div[1]/a[3]")).Count() != 0)
                {
                    var DocumentsTabButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/div[2]/div[1]/a[3]"));
                    ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].scrollIntoView(true);", DocumentsTabButton);
                    DocumentsTabButton.Click();
                }
                else
                {
                }

                if (driver.FindElements(By.XPath("//*[text()='404 - File or directory not found.']")).Count() == 0)
                {
                    webElementsAll = driver.FindElements(By.XPath("//tr[@class='']")).ToList();

                    for (int j = 0; j < webElementsAll.Count; j++)
                    {
                        var element = webElementsAll[j];
                        try
                        {
                            // JavaScript Executor to scroll to element
                            ((IJavaScriptExecutor)driver)
                            .ExecuteScript("arguments[0].scrollIntoView(true);", element);
                        }
                        catch (StaleElementReferenceException ex)
                        {
                            driver.Navigate().Back();
                        }

                        string name = element.FindElement(By.XPath(".//td[1]")).Text;

                        string desc = element.FindElement(By.XPath(".//td[2]")).Text;

                        string uploaddate = element.FindElement(By.XPath(".//td[3]")).Text;

                        string uploadby = element.FindElement(By.XPath(".//td[4]")).Text;

                        Filedetails filedetails = new Filedetails()
                        {
                            Filename = name,
                            Description = desc,
                            UploadDate = uploaddate,
                            UploadBy = uploadby
                        };

                        FiledetailsList.Add(filedetails);
                        if (name.Contains(".pdf") || name.Contains(".docx"))
                        {
                            element.Click();

                        }
                        else if (name.Contains(".png"))
                        {
                            element.Click();

                            var base64string = ((IJavaScriptExecutor)driver).ExecuteScript(@"
                            var c = document.createElement('canvas');
                            var ctx = c.getContext('2d');
                            var img = document.getElementsByTagName('img')[0];
                            c.height=img.naturalHeight;
                            c.width=img.naturalWidth;
                            ctx.drawImage(img, 0, 0,img.naturalWidth, img.naturalHeight);
                            var base64String = c.toDataURL();
                            return base64String;
                            ") as string;

                            var base64 = base64string.Split(',').Last();

                            using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
                            {
                                using (var bitmap = new Bitmap(stream))
                                {
                                    var filepath = Path.Combine(textBox_DownloadPath.Text, name);
                                    bitmap.Save(filepath, ImageFormat.Png);
                                }
                            }
                        }

                        else if (name.Contains(".jpeg") || name.Contains(".jpg"))
                        {
                            element.Click();

                            var base64string = ((IJavaScriptExecutor)driver).ExecuteScript(@"
                            var c = document.createElement('canvas');
                            var ctx = c.getContext('2d');
                            var img = document.getElementsByTagName('img')[0];
                            c.height=img.naturalHeight;
                            c.width=img.naturalWidth;
                            ctx.drawImage(img, 0, 0,img.naturalWidth, img.naturalHeight);
                            var base64String = c.toDataURL();
                            return base64String;
                            ") as string;

                            var base64 = base64string.Split(',').Last();

                            using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
                            {
                                using (var bitmap = new Bitmap(stream))
                                {
                                    var filepath = Path.Combine(textBox_DownloadPath.Text, name);
                                    bitmap.Save(filepath, ImageFormat.Jpeg);
                                }
                            }
                            driver.Navigate().Back();
                        }

                        else if (name.Contains(".gif"))
                        {
                            element.Click();

                            var base64string = ((IJavaScriptExecutor)driver).ExecuteScript(@"
                            var c = document.createElement('canvas');
                            var ctx = c.getContext('2d');
                            var img = document.getElementsByTagName('img')[0];
                            c.height=img.naturalHeight;
                            c.width=img.naturalWidth;
                            ctx.drawImage(img, 0, 0,img.naturalWidth, img.naturalHeight);
                            var base64String = c.toDataURL();
                            return base64String;
                            ") as string;

                            var base64 = base64string.Split(',').Last();

                            using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
                            {
                                using (var bitmap = new Bitmap(stream))
                                {
                                    var filepath = Path.Combine(textBox_DownloadPath.Text, name);
                                    bitmap.Save(filepath, ImageFormat.Gif);
                                }
                            }
                            driver.Navigate().Back();

                        }

                        else if (name.Contains(".tif"))
                        {
                            element.Click();

                            var base64string = ((IJavaScriptExecutor)driver).ExecuteScript(@"
                            var c = document.createElement('canvas');
                            var ctx = c.getContext('2d');
                            var img = document.getElementsByTagName('img')[0];
                            c.height=img.naturalHeight;
                            c.width=img.naturalWidth;
                            ctx.drawImage(img, 0, 0,img.naturalWidth, img.naturalHeight);
                            var base64String = c.toDataURL();
                            return base64String;
                            ") as string;

                            var base64 = base64string.Split(',').Last();

                            using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
                            {
                                using (var bitmap = new Bitmap(stream))
                                {
                                    var filepath = Path.Combine(textBox_DownloadPath.Text, name);
                                    bitmap.Save(filepath, ImageFormat.Tiff);
                                }
                            }
                        }

                        name = "";
                        desc = "";
                        uploaddate = "";
                        uploadby = "";

                        filedetails = new Filedetails();
                        Thread.Sleep(1000);
                    }
                    status = "Matched";
                    numberOfFilesInt = webElementsAll.Count;
                }
                else
                {
                    status = "Unmatched";
                }
                var endTimestamp = new DateTimeOffset(DateTime.UtcNow);
                endTime = endTimestamp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

                var elapseTimestamp = endTimestamp - startTimestamp;
                elapseTime = elapseTimestamp.ToString();

                Thread.Sleep(1000);

                driver.Navigate().GoToUrl("https://hj.200ok.co/");

                Thread.Sleep(1000);

                var json = JsonSerializer.Serialize(FiledetailsList);

                string[] itemsArray = { enquiryList[0], status, startTime, endTime, elapseTime, numberOfFilesInt.ToString(), json };

                using (var writer = new StreamWriter(textBox_LogFilePath.Text, true))
                {
                    var line = string.Join(delimiter, itemsArray);
                    writer.WriteLine(line);
                }

                FiledetailsList.Clear();
                enquiryList.RemoveAt(0);
            }
            driver.Close();

        }
        public void EnquiryTextRead()
        {
            if (File.Exists(textBox_InquiryIDPath.Text))
            {
                enquiryList = File.ReadAllLines(textBox_InquiryIDPath.Text).ToList();
                enquiryNumber = enquiryList.Count();
            }
        }

        public void saveCredentials(string username, string password, string downloaded, string inquiry, string log)
        {
            string Msg = username + "\t" + password + "\t" + downloaded + "\t" + inquiry +"\t" + log;
            FileStream fParameter = new FileStream(CredentialsFile, FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(Msg);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
        }

        public void loadCredentials()
        {
            if (File.Exists(CredentialsFile))
            {
                string[] lines = File.ReadAllLines(CredentialsFile);
                foreach (string line in lines)
                {
                    string[] col = line.Split('\t');

                    textBox_Username.Text = col[0];
                    textBox_Password.Text = col[1];
                    textBox_DownloadPath.Text = col[2];
                    textBox_InquiryIDPath.Text = col[3];
                    textBox_LogFilePath.Text = col[4];
                }
            }

                
        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState == CheckState.Unchecked)
            {

            }
            else if(checkBox1.CheckState == CheckState.Checked)
            {
                saveCredentials(textBox_Username.Text, textBox_Password.Text, textBox_DownloadPath.Text, textBox_InquiryIDPath.Text, textBox_LogFilePath.Text);
            }

        }

        private void button_DownloadedPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_DownloadPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button_InquiryPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_InquiryIDPath.Text = openFileDialog.FileName;
            }

        }

        private void button_LogPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = @"C:\",
                Title = "Create Log Files",
                DefaultExt = "log",
                Filter = "txt files (*.txt)|*.txt|log files (*.log)|*.log|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_LogFilePath.Text = saveFileDialog.FileName;
            }
        }

    }
}