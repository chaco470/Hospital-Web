using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using TechTalk.SpecFlow;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;


namespace test {

[Binding]
public class TestSpectflow {
    IWebDriver  driver = new ChromeDriver();

    [Given(@"un usuario que se loguea correctamente")]
    public void Given(){

           driver.Navigate().GoToUrl ("https://localhost:5001/Home/Logueo");
          driver.Manage().Window.Maximize();
            
            System.Threading.Thread.Sleep(2000);

         var usernameBox = driver.FindElement(By.Id("user_email"));            
            
            var passwordBox = driver.FindElement(By.Id("user_password"));           
            

            var submitBtn = driver.FindElement(By.Id("loggin-usuario"));
          
            //Perform Required action with the element
            usernameBox.SendKeys("tamara16@live.com.ar");
            System.Threading.Thread.Sleep(2000);
     
            passwordBox.SendKeys("12345");
            System.Threading.Thread.Sleep(2000);
        
         
            submitBtn.Click(); 
    } 

    [When(@"presiona el boton salir")]
    public void When(){
                    //Locate the Web Elements
    var salida=driver.FindElement(By.Id("salir"));
                System.Threading.Thread.Sleep(2000);

        salida.Click();
                System.Threading.Thread.Sleep(2000);

    }

    [Then(@"el usuario sale de la cuenta")]
    public void Then(){
        Assert.AreEqual(driver.Url,"https://localhost:5001/Home/Logueo");
        driver.Close();

    }

    [TestCleanup]
    public void TearDown(){
        driver.Quit();
    }

}
}