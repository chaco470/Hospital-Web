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
public class AgregarMedicoSpecflow {
    IWebDriver  driver = new ChromeDriver();

  string nuevoProfesional; 

[Given (@"un admin agrega a un especialista correctamente")]
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
        nuevoProfesional = "Micaela Yasmin Mendiberry";
}

[When(@"llena los campos adecuadamente y le da al boton guardar")]
public void When(){
  
    var nyapMedico = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[1]/div/div/div/form/div[1]/input"));
    IWebElement selectEspecialidad = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[1]/div/div/div/form/div[2]/select"));
    var selectObj = new SelectElement(selectEspecialidad); 
    selectObj.SelectByText("Cirugía Plástica y Reparadora");
    IWebElement selectRol = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[1]/div/div/div/form/div[3]/select"));
    var selectObj2 = new SelectElement(selectRol); 
    selectObj2.SelectByText("Cirujana");
    var guardar = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[1]/div/div/div/form/button"));
    System.Threading.Thread.Sleep(1000);
    nyapMedico.SendKeys(nuevoProfesional);
    System.Threading.Thread.Sleep(1000);
    guardar.Click();
}


[Then(@"el especialista aparece en la seccion de especialistas")]
public void Then(){
 
    Assert.AreEqual(driver.Url,"https://localhost:5001/Home/AgregarMedico");
    driver.Close();
}


  [TestCleanup]
    public void TearDown(){
        driver.Quit();
    }

}


}