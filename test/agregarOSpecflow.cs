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
public class AgregarOSpecflow {
    IWebDriver  driver = new ChromeDriver();

  string nuevaOS; 

[Given (@"un admin agrega una obra social correctamente")]
public void Guiven(){

  driver.Navigate().GoToUrl ("https://localhost:5001/Home/Logueo");
        driver.Manage().Window.Maximize();
            
        System.Threading.Thread.Sleep(2000);

        var usernameBox = driver.FindElement(By.Id("user_email"));            
        var submitBtn = driver.FindElement(By.Id("loggin-usuario"));
        var passwordBox = driver.FindElement(By.Id("user_password"));           
        //Perform Required action with the element
        usernameBox.SendKeys("Leo");
        System.Threading.Thread.Sleep(1000);
        passwordBox.SendKeys("SFadmin");
        System.Threading.Thread.Sleep(1000); 
        submitBtn.Click();

        System.Threading.Thread.Sleep(1000);
        var irAAgregar= driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[1]"));
        irAAgregar.Click();
        System.Threading.Thread.Sleep(1000);
        nuevaOS = "ChacOSDE";
}

[When(@"introduce los datos de la obra social y le da al boton de guardar")]
public void When(){
  
    //identificar elementos necesarios
    var nombreOS = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[3]/div/div/div/form/div[1]/input"));
    var urlNota = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[3]/div/div/div/form/div[5]/input"));
    var guardar = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[3]/div/div/div/form/button"));
    IWebElement selectIsActivated = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[3]/div/div/div/form/div[3]/select"));
    var selectObj = new SelectElement(selectIsActivated); 
    selectObj.SelectByText("Inactiva");
    //llenar campos correspondientes
    System.Threading.Thread.Sleep(1000);
    nombreOS.SendKeys(nuevaOS);
    urlNota.SendKeys("https://www.eleconomista.com.mx/empresas/Pobreza-en-Argentina-trepo-a-42-y-ya-afecta-a-19-millones-de-personas-en-el-pais-20210404-0051.html");
    //guardar los datos
    guardar.Click();
}


[Then(@"la obra social aparece en la seccion correspondiente")]
public void Then(){
 
    Assert.AreEqual(driver.Url,"https://localhost:5001/Home/AgregarObraSocial");
    driver.Close();
}


  [TestCleanup]
    public void TearDown(){
        driver.Quit();
    }

}


}
