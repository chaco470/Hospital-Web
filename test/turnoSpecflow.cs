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
using OpenQA.Selenium.Support.UI;



namespace test {

[Binding]
public class TurnoSpecflow {
    IWebDriver  driver = new ChromeDriver();

    [Given(@"un usuario solicita un turno")]
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
            System.Threading.Thread.Sleep(2000);

            driver.Navigate().GoToUrl ("https://localhost:5001/Home/TurnosOnline");

    } 

    [When(@"presiona el boton de pedir turno")]
    public void When(){
            
            var continuar = driver.FindElement(By.Id("continua"));
            
            continuar.Click();
            System.Threading.Thread.Sleep(1000);
                    //Locate the Web Elements
            var turnosBtn = driver.FindElement(By.Id("pedir-turno"));
            
            System.Threading.Thread.Sleep(1000);

            turnosBtn.Click();

    }

    [Then(@"se agrega un turno")]
    public void Then(){
        Assert.AreEqual(driver.Url,"https://localhost:5001/Home/TurnoEnviado");
        driver.Close();

    }

    [Given(@"un usuario elije la especialidad Hematología")]
    public void UsuarioElijeEspecialidad(){

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
            System.Threading.Thread.Sleep(2000);

            driver.Navigate().GoToUrl ("https://localhost:5001/Home/TurnosOnline");
            System.Threading.Thread.Sleep(1000);

            //elije la especialidad
            IWebElement select = driver.FindElement(By.Id("especialidad"));
            var selectObj = new SelectElement(select); 
            selectObj.SelectByText("Hematología");
            
            
    }

    [When(@"hace click en continuar")]
    public void WhenContinua(){
        System.Threading.Thread.Sleep(2000);

            var continuar = driver.FindElement(By.Id("continua"));
            
            continuar.Click();
            System.Threading.Thread.Sleep(1000);
 
    }

    [Then(@"elije alguno de los especialistas que coinciden con la especialidad")]
    public void SeEligeElPrimerEspecialistaDeLaLista(){
         IWebElement select = driver.FindElement(By.Id("especialista"));
 
       var selectObj = new SelectElement(select); 
      
        System.Threading.Thread.Sleep(2000);
       
        selectObj.SelectByText("Dra. Andrea Rossi");
       
       System.Threading.Thread.Sleep(2000);
         
         var turnosBtn = driver.FindElement(By.Id("pedir-turno"));
            
       System.Threading.Thread.Sleep(1000);

            turnosBtn.Click();

        Assert.AreEqual(driver.Url,"https://localhost:5001/Home/TurnoEnviado");

        driver.Close();
    }



    [TestCleanup]
    public void TearDown(){
        driver.Quit();
    }



}
}