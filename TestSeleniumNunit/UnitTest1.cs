using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestSeleniumNunit
{
    [TestFixture]
    public class Tests
    {
        IWebDriver WebDriver;
        [SetUp]
        public void Setup()
        {
            WebDriver = new ChromeDriver("D://internship//TestSeleniumNunit//TestSeleniumNunit//driver");
            WebDriver.Manage().Window.Maximize();
        }

        [Test]
        public void homepage()
        {
            WebDriver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");

            IWebElement title = WebDriver.FindElement(By.CssSelector("head > title"));
            Console.WriteLine("Titlu:   " + title);

            string title2 = WebDriver.Title;
            Console.WriteLine("Titlu2:  " + title2);

            string url = WebDriver.Url;
            Console.WriteLine("URL:  " + url);

            IWebElement logo = WebDriver.FindElement(By.CssSelector(".logo"));
            Console.WriteLine("Logo:" + logo);
            logo.Click();
            //for(int i=1;i<=1000;i++)
            //{
            //  logo.Click();
            //logo = WebDriver.FindElement(By.CssSelector("#header > div > a > img.large")); 
            //}

            IWebElement page = WebDriver.FindElement(By.CssSelector(".nav-primary li.level0"));
            Console.WriteLine("Page:" + page);
            page.Click();
            WebDriver.Navigate().Back();
            WebDriver.Navigate().Forward();
            WebDriver.Navigate().Refresh();
            Assert.That("http://qa1magento.dev.evozon.com/women.html", Is.EqualTo(WebDriver.Url));
            

            
            //Assert.That("http://qa2magento.dev.evozon.com/women.html", Is.EqualTo("http://qa2magento.dev.evozon.com/women.html"));
        }

        [Test]
        public void account()
        {
          
            WebDriver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            IWebElement account = WebDriver.FindElement(By.CssSelector(".account-cart-wrapper"));
            Console.WriteLine("Account:" + account);
            account.Click();
            Assert.IsTrue(WebDriver.FindElement(By.CssSelector(".skip-content.skip-active")).Displayed);
            //WebDriver.Quit();
        }

        [Test]
        public  void languages()
        {
            
            WebDriver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            //Thread.Sleep(5000);
            IWebElement language = WebDriver.FindElement(By.CssSelector("#select-language"));
            SelectElement select = new SelectElement(language);
            //Assert.That(3,Is.EqualTo( select.Options.Count));
            select.SelectByIndex(1);
             select = new SelectElement(WebDriver.FindElement(By.CssSelector("#select-language")));
            Assert.That("French", Is.EqualTo(select.SelectedOption.Text));
          
        }

        [Test]
        public void search()
        {
            
            WebDriver.Navigate().GoToUrl("http://qa1magento.dev.evozon.com");
            IWebElement search = WebDriver.FindElement(By.CssSelector("#search"));
            search.Clear();
            search.SendKeys("woman");
            search.Submit();
            Assert.That("http://qa1magento.dev.evozon.com/catalogsearch/result/?q=woman", Is.EqualTo(WebDriver.Url));
        }
        [Test]
        public void newProductList()
        {
            WebDriver.Navigate().GoToUrl("http://qa2magento.dev.evozon.com/");
            IList<IWebElement> newProductList = WebDriver.FindElements(By.CssSelector(".widget-new-products .products-grid .item"));
            //Console.WriteLine("Number of new products: " + newProductList.Count());
            List<string> name = new List<string>();
            foreach (var i in newProductList)
            {
                name.Add(i.Text);
                //Console.WriteLine(i);

            }
            List<string> name2 = new List<string>(){ "LINEN BLAZER", "ELIZABETH KNIT TOP", "CHELSEA TEE",
            "LAFAYETTE CONVERTIBLE DRESS", "TORI TANK"};
            Assert.AreEqual(name, name2 );

           
           
        }

        [TearDown]
        public void finish()
        {
            WebDriver.Quit();
        }

    }
}