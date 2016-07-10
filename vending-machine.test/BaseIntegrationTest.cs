using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium.Firefox;

namespace vending_machine.test
{
    [TestClass]
    public abstract class BaseIntegrationTest
    {
        const int iisPort = 5000;
        private string _applicationName;
        private Process _iisProcess;
        public FirefoxDriver FirefoxDriver { get; set; }
 
        protected BaseIntegrationTest(string applicationName) {
            _applicationName = applicationName;
        }
 
        [TestInitialize]
        public void TestInitialize() {            
            StartIIS();
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("webdriver.load.strategy", "unstable");
            this.FirefoxDriver = new FirefoxDriver(profile);
        }
 
 
        [TestCleanup]
        public void TestCleanup() {
            FirefoxDriver.Quit();
            if (!_iisProcess.HasExited) {
                _iisProcess.Kill();
            }
        }
 
 
 
        private void StartIIS() {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
 
            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = programFiles + @"\IIS Express\iisexpress.exe";
            _iisProcess.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, iisPort);
            _iisProcess.Start();
        }
 
 
        protected virtual string GetApplicationPath(string applicationName) {
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }
 
 
        public string GetAbsoluteUrl(string relativeUrl) {
            if (!relativeUrl.StartsWith("/")) {
                relativeUrl = "/" + relativeUrl;
            }
            return String.Format("http://localhost:{0}{1}", iisPort, relativeUrl);
        }
    }
}
