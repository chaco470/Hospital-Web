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
public class BorrarMedicoSpecflow {
    IWebDriver  driver = new ChromeDriver();

  string medico; 

[Given (@"un admin se logea correctamente y ve sus medicos")]
public void LoguearYVerMedicos(){

  driver.Navigate().GoToUrl ("https://localhost:5001/Home/Logueo");
        driver.Manage().Window.Maximize();
            
        System.Threading.Thread.Sleep(2000);

        var usernameBox = driver.FindElement(By.Id("user_email"));            
        var submitBtn = driver.FindElement(By.Id("loggin-usuario"));
        var passwordBox = driver.FindElement(By.Id("user_password"));           
        //Perform Required action with the element
        usernameBox.SendKeys("Leo");
        System.Threading.Thread.Sleep(2000);
     
        passwordBox.SendKeys("SFadmin");
        System.Threading.Thread.Sleep(2000); 
        submitBtn.Click();
        System.Threading.Thread.Sleep(2000);
        var verMedicos= driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a"));
        verMedicos.Click();
        System.Threading.Thread.Sleep(2000);
        medico = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[1]/div[1]/h5")).Text;
}

[When(@"presiona el boton borrar y confirma el borrado")]
public void ClickBorrar(){
  
   var eliminaMedico = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[1]/div[1]/button"));
   System.Threading.Thread.Sleep(2000);
  eliminaMedico.Click();
  System.Threading.Thread.Sleep(2000);
  var borrar =driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/div[1]/div[2]/div/div/form/div[2]/button[2]"));
  borrar.Click();
}


[Then(@"el medico seleccionado ya no esta en la cartelera")]
public void CheckearMedicoBorrado(){
var elements = driver.FindElements(By.XPath("//*[@id='card-style']/h5/i"));

var existe = elements.FirstOrDefault(element=>element.Text == medico); 
Assert.AreEqual(existe,null);
driver.Close();
}


  [TestCleanup]
    public void TearDown(){
        driver.Quit();
    }

}


}