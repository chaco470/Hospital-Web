using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Moq;  
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Models.Hospital;
using unq_iisoft_2021_c1_hospitalWebSite.Controllers;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        public HomeController controller ;
        public SanatorioContext context;

        [TestInitialize]
        public void SetUp(){
           var  opciones= new DbContextOptionsBuilder<SanatorioContext>().UseInMemoryDatabase("Hola.db").Options;
             context = new SanatorioContext(opciones);
            var logger = new Mock<ILogger<HomeController>>().Object;
            controller = new HomeController(logger,context);
            controller.userOrAdminSession= new Usuario{Mail="tamara16@live.com.ar", Nombre="string nombre",Apellido= "string apellido", ObraSocial= "string obraSocial",Contraseña= "12345" };
            controller.ControllerContext=new ControllerContext();
            controller.ControllerContext.HttpContext= new DefaultHttpContext();
            var session= new Mock<ISession>();
            controller.ControllerContext.HttpContext.Session=session.Object ;
        }

        [TestMethod]
        public void LoginYRegisterExitoso()
        {
        var result=controller.RegistrarUsuario("tamara16@live.com.ar", "string nombre", "string apellido", "string obraSocial","12345") as ViewResult; 
        Assert.IsNotNull(result);
        Assert.IsNull(controller.ViewBag.MailRegistrado);
        Assert.AreEqual("RegistroResult",result.ViewName);
         var resultl = controller.Login("tamara16@live.com.ar","12345") as ViewResult;
        Assert.AreEqual("LogueoResult",resultl.ViewName);

        }

    [TestMethod]
    public void RegistarUsuarioYaRegistrado(){
        controller.RegistrarUsuario("tamara16@live.com.ar", "string nombre", "string apellido", "string obraSocial","12345");
          var result=controller.RegistrarUsuario("tamara16@live.com.ar", "string nombre", "string apellido", "string obraSocial","12345") as ViewResult; 
        Assert.IsNotNull(result);
        Assert.IsNotNull(controller.ViewBag.MailRegistrado);
        Assert.AreEqual("RegistroResult",result.ViewName);
    }
    [TestMethod]
    public void LoginUserError(){
        var resultl = controller.Login("tamara15@live.com.ar","12345") as ViewResult;
        Assert.IsTrue(controller.ViewBag.ErrorEnLogin);
        Assert.AreEqual("Logueo",resultl.ViewName);

    }

        [TestMethod]
    public void LoginUserErrorIncorrectPassword(){
        var resultl = controller.Login("tamara16@live.com.ar","1234") as ViewResult;
        Assert.IsTrue(controller.ViewBag.ErrorEnLogin);
        Assert.AreEqual("Logueo",resultl.ViewName);

    }

     [TestMethod]
     public void UnUsuarioYaRegistradoEliminaSuCuenta(){
     controller.RegistrarUsuario("tamara16@live.com.ar", "string nombre", "string apellido", "string obraSocial","12345");
        Assert.IsTrue(context.Usuario.Contains(controller.userOrAdminSession));
        controller.EliminarCuenta();
        Assert.IsFalse(context.Usuario.Contains(controller.userOrAdminSession));
     }

    [TestMethod]
    public void UnMedicoEsAgregadoAlSistema(){
        controller.AgregarMedico("Diego Moronha", "Cardiologia", "Cirujano");
        Assert.IsNotNull(context.Medico.FirstOrDefault(m=>m.NombreYApellido == "Diego Moronha"));
    }

    [TestMethod]
    public void SeAgregaUnaObraSocialAlSistema(){
         controller.AgregarObraSocial("Premedic", "no hay", "Activa");
         var obra=context.ObraSocial.FirstOrDefault(os=>os.Nombre == "Premedic");
         Assert.IsNotNull(obra);

    }

    [TestMethod]
     public void SeEliminaUnaObraSocialAgregada(){
         controller.AgregarObraSocial("Premedic", "no hay", "Activa");
         var obra=context.ObraSocial.FirstOrDefault(os=>os.Nombre == "Premedic");
         Assert.IsNotNull(obra);
         controller.EliminarObraSocial(1);
         var obraBorrada= context.ObraSocial.FirstOrDefault(os=>os.Nombre == "Premedic");
         Assert.IsNull(obraBorrada);
     }

    [TestMethod]
    public void SeEditaElPerfilDeUnUsuarioRegistrado(){
    controller.RegistrarUsuario("tamara16@live.com.ar", "string nombre", "string apellido", "string obraSocial","12345");

        controller.EditarUsuario("tamara16@live.com.ar", "Tamara", "Benitez", "Premedic", "12345");
       var user=  context.Usuario.FirstOrDefault(u=>u.Mail == "tamara16@live.com.ar");
        bool result = user.ObraSocial == "Premedic";
        Assert.IsTrue(result);
    }



    [TestCleanup]
    public void TearDown(){
        context.Database.EnsureDeleted();
        context.Dispose();
    }
    
    }

}
