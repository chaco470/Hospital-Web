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
public class AgregarNotaSpecflow {
    IWebDriver  driver = new ChromeDriver();

  string nuevaNota; 

[Given (@"un admin agrega una nota correctamente")]
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
        nuevaNota = "Tamara Benitez y el suicidio";
}

[When(@"llena los campos con la informacion y le da al boton de guardar")]
public void When(){
  
    //identificar elementos necesarios
    var tituloNota = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[2]/div/div/div/form/div[1]/input"));
    var cuerpoNota = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[2]/div/div/div/form/div[2]/textarea"));
    var fechaPublicacionNota = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[2]/div/div/div/form/div[3]/input"));
    var urlImgNota = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[2]/div/div/div/form/div[4]/input"));
    var urlNota = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[2]/div/div/div/form/div[5]/input"));
    var guardar = driver.FindElement(By.XPath("/html/body/div/main/div/div[2]/div[2]/div/div/div/form/button"));
    //llenar campos correspondientes
    System.Threading.Thread.Sleep(1000);
    tituloNota.SendKeys(nuevaNota);
    cuerpoNota.SendKeys("El suicidio es la segunda causa de muerte de los chicas y chicos argentinos que tienen entre 10 y 19 años");
    fechaPublicacionNota.SendKeys("08-06-21");
    urlImgNota.SendKeys("https://www.askideas.com/media/27/Beautiful-Chihuahua-Dog-Face-Photo.jpg");
    urlNota.SendKeys("https://www.unicef.org/argentina/comunicados-prensa/suicidio-adolescencia");
    //guardar los datos
    guardar.Click();
}


[Then(@"la nota se agrega a la pantalla del home")]
public void Then(){
 
    Assert.AreEqual(driver.Url,"https://localhost:5001/Home/AgregarNota");
    driver.Close();
}


  [TestCleanup]
    public void TearDown(){
        driver.Quit();
    }

}


}