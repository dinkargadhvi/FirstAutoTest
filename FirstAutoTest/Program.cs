using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace FirstAutoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // open chrome browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // launch turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
           // deleted Thread.Sleep(2000);

            // identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // identify password textbox and enter valid password 
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // identify login button and click
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            // check if user has logged in successfully
            IWebElement hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in successfully, login test passed");
                             
            }
            else
            {
                Console.WriteLine("Login failed,login test failed");
            }

            try
            {

                //click on administration tab 
                IWebElement admistrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                admistrationTab.Click();


                // select time & material from dropdown
                IWebElement tmOption = driver.FindElement(By.XPath("//html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
                tmOption.Click();
            }

            catch(Exception ex)
            {
                Console.WriteLine("Turnup Portal can't be accessed ,test failed");
            }


            // click on creat new button 
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // click on TypeCode dropdown and selct Time
            IWebElement tmDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            tmDropdown.Click();
            
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();

            // enter code 
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("FirstTest");

            // enter Description 
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("First Automation Test");

            // enter price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("123");

            // click save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            // click on last page  button
            IWebElement goTolastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")); //*[@id='tmsGrid']/div[4]/a[4]/span
            goTolastPageButton.Click();
            Thread.Sleep(2000);
           
            // check if time record has been created and validate 
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));//*[@id="tmsGrid"]/div[3]/table/tbody/tr[9]/td[1]

            if (actualCode.Text== "FirstTest")
            {
                Console.WriteLine("Time Record created successfully");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }






        }
    }
}
