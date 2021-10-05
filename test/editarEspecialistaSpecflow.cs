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
public class EditarEspecialistaSpecflow {
    IWebDriver  driver = new ChromeDriver();

  string medico; 

[Given (@"un admin edita a un especialista correctamente")]
public void Given(){

  driver.Navigate().GoToUrl ("https://localhost:5001/Home/Logueo");
        driver.Manage().Window.Maximize();
            
        System.Threading.Thread.Sleep(1000);

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
        var verMedicos= driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a"));
        verMedicos.Click();
        System.Threading.Thread.Sleep(1000);
        medico = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[71]/div[1]/h5")).Text;
}

[When(@"presiona el boton de editar y guardar")]
public void When(){
  
    var editar = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[71]/div[1]/button[2]"));
    System.Threading.Thread.Sleep(1000);
    editar.Click();
    System.Threading.Thread.Sleep(1000);
    IWebElement selectEspecialidad = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/div[71]/div[2]/div/div/form/div[1]/div[1]/select"));
    var selectObj = new SelectElement(selectEspecialidad); 
    selectObj.SelectByText("Cirugía Plástica y Reparadora");
    IWebElement selectRol = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/div[71]/div[2]/div/div/form/div[1]/div[2]/select"));
    var selectObj2 = new SelectElement(selectRol); 
    selectObj2.SelectByText("Cirujano");
    var guardar =driver.FindElement(By.XPath("//html/body/div[1]/main/div/div/div[71]/div[2]/div/div/form/div[2]/button[2]"));
    System.Threading.Thread.Sleep(1000);
    guardar.Click();
}


[Then(@"el especialista aparece con un rol o especialidad editada")]
public void Then(){
    var posicionCarta = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[71]/div[1]/h5"));

    Assert.AreNotEqual(posicionCarta.Text,medico);
    driver.Close();
}


  [TestCleanup]
    public void TearDown(){
        driver.Quit();
    }

}


}