using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace web_auto
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:/Users/Agnee/Desktop/chromedriver_win32");
            driver.Manage().Window.FullScreen();
        }

        public void goToUrl()

        {

            driver.Url = "http://automationpractice.com/index.php";
        }

        public void Login (string email, string passw)

        {
            goToUrl();
            driver.FindElement(By.ClassName("login")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("passwd")).SendKeys(passw);
            driver.FindElement(By.Id("SubmitLogin")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            Assert.AreEqual(driver.Url, "http://automationpractice.com/index.php?controller=my-account");

            driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[2]/div/div[2]/div[2]/a[2]")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual(driver.Url, "http://automationpractice.com/index.php?id_product=2&controller=product");

            driver.FindElement(By.XPath("//*[@id='add_to_cart']/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='center_column']/p[2]/a[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='center_column']/form/p/button")).Click();
            driver.FindElement(By.XPath("//*[@id='cgv']")).Click();
            driver.FindElement(By.XPath("//*[@id='form']/p/button")).Click();
            driver.FindElement(By.XPath("//*[@id='HOOK_PAYMENT']/div[1]/div/p/a")).Click();
            driver.FindElement(By.XPath("//*[@id='cart_navigation']/button")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual(driver.Url, "http://automationpractice.com/index.php?controller=order-confirmation&id_cart=1790421&id_module=3&id_order=193925&key=644f27131002eed747d5df09f7783bbf");
        }
        [Test]
        public void Test1()
        {
            Login("agne.bauzyte@gmail.com", "vduevfmk");
        }

        [TearDown]
        public void Close()

        {
            driver.Close();
        }
    }
}