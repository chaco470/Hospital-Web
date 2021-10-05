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
public class TestLoginAdminSpectflow {
    IWebDriver  driver = new ChromeDriver();

    [Given(@"un usuario admin se logea correctamente")]
    public void Given(){

           driver.Navigate().GoToUrl ("https://localhost:5001/Home/Logueo");
          driver.Manage().Window.Maximize();
            
            System.Threading.Thread.Sleep(2000);

         var usernameBox = driver.FindElement(By.Id("user_email"));            
            
            var passwordBox = driver.FindElement(By.Id("user_password"));           
            

           
          
            //Perform Required action with the element
            usernameBox.SendKeys("Leo");
            System.Threading.Thread.Sleep(2000);
     
            passwordBox.SendKeys("SFadmin");
            System.Threading.Thread.Sleep(2000);
        
         
            
    } 

    [When(@"presiona el boton ingresar")]
    public void When(){
                    //Locate the Web Elements
        var submitBtn = driver.FindElement(By.Id("loggin-usuario"));
        submitBtn.Click(); 
    }

    [Then(@"le aparece un cartel que se logeo como admin correctamente")]
    public void Then(){
        Assert.AreEqual(driver.Url,"https://localhost:5001/Home/AdminHome");
        driver.Close();
    }

    [TestCleanup]
    public void TearDown(){
        driver.Quit();
    }

}
}