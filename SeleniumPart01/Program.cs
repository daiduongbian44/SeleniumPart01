using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPart01
{
    class Program
    {
        /// <summary>
        /// Chờ cho tới khi tải được thẻ cụ thể
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="elementLocator"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = wait.Until((condition) =>
                    {
                        try
                        {
                            var elementToBeDisplayed = driver.FindElement(elementLocator);
                            return elementToBeDisplayed.Displayed;
                        }
                        catch (StaleElementReferenceException)
                        {
                            return false;
                        }
                        catch (NoSuchElementException)
                        {
                            return false;
                        }
                    }
                );
                if(!element)
                {
                    return null;
                }
                return driver.FindElement(elementLocator);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                return null;
            }
        }

        static void Main(string[] args)
        {
            // Đường dẫn đến geckodriver.exe
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"D:\automationTest");
            IWebDriver driver = new ChromeDriver (service);

            // Đường link để test
            driver.Url = "https://www.phptravels.net/";

            // Chờ cho web loaded và xuất hiện thẻ #body-section
            var element = WaitUntilElementExists(driver, By.CssSelector("#body-section"));
            if (element != null)
            {
                Console.WriteLine("#body-section was found");



                //Tìm kiếm search và kết quả trả về 
                driver.FindElement(By.ClassName("dpd1")).SendKeys("10/01/2019");
                driver.FindElement(By.ClassName("dpd2")).SendKeys("13/01/2019");

                driver.FindElement(By.ClassName("pfb0")).Click();


                var result = driver.FindElements(By.ClassName("price_tab"));
                Console.WriteLine(result.Count);

                // Tìm kiếm danh sách link trang web

                //    HttpWebRequest re = null;
                //    var linkElements = driver.FindElements(By.CssSelector("a[href^='http']"));
                //    if(linkElements != null)
                //    {
                //        // In ra màn hình tổng số link và danh sách các links
                //        Console.WriteLine(string.Format("Total links: {0}", linkElements.Count));
                //        foreach(var link in linkElements)
                //        {
                //            re = (HttpWebRequest)WebRequest.Create(link.GetAttribute("href"));
                //            try
                //            {
                //                var response = (HttpWebResponse)re.GetResponse();
                //                System.Console.WriteLine($"URL: {link.GetAttribute("href")} status is :{response.StatusCode}");
                //            }
                //            catch (WebException e)
                //            {
                //                var errorResponse = (HttpWebResponse)e.Response;
                //                System.Console.WriteLine($"URL: {link.GetAttribute("href")} status is :{errorResponse.StatusCode}");
                //            }

                //        }
                //    } else
                //    {
                //        Console.WriteLine("Not found list links");
                //    }
                //} else
                //{
                //    Console.WriteLine("#body-section not found in current context page.");
                //}
            }

            // Đóng web đã mở
            driver.Close();
            Console.WriteLine("Done---------------");
        }
    }
}
