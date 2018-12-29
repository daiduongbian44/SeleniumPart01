using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumPart01
{
    class Program
    {
        static void Main(string[] args)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\");
            IWebDriver driver = new FirefoxDriver(service);
            driver.Url = "https://www.phptravels.net/";
            driver.Close();
        }
    }
}
