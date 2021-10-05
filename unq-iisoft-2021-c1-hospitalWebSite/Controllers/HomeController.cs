using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Hospital;
using unq_iisoft_2021_c1_hospitalWebSite.Models;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

namespace unq_iisoft_2021_c1_hospitalWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanatorioContext db;

        public Usuario userOrAdminSession = null;
        public HomeController(ILogger<HomeController> logger,SanatorioContext contexto)
        {
            _logger = logger;
              this.db = contexto;
        }

        public IActionResult Index()
        {
            Usuario usuarioLogueado = CheckSessionOrDefault("UsuarioLogueado");
            if(usuarioLogueado != null){
                ViewBag.NombreUsuario = usuarioLogueado.Nombre;
            }
            ViewBag.Notas = db.Nota.ToList();
            return View();
        }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Prestaciones() {

        return View();
    }
   
   public IActionResult Staff() {
            ViewBag.Especialidades = db.Especialidad.OrderBy(e => e.Nombre).ToList();
            ViewBag.Medicos = db.Medico.Include(m => m.Especialidad).Include(m => m.RolEnEspecialidad).ToList();
            return View();
        }
     public IActionResult Historia() {

        return View();
    }
     public IActionResult Autoridades() {

        return View();
    }


        [HttpPost]
        public IActionResult EditarNota(int ID, string titulo, string cuerpo, string fecha, string imagen, string URLnota){
            Nota nota = db.Nota.FirstOrDefault(n => n.ID == ID);
            nota.Titulo = titulo;
            nota.Cuerpo = cuerpo;
            nota.Fecha = fecha;
            nota.URLImagen = imagen;
            nota.URLNotaCompleta = URLnota;

            db.Nota.Update(nota);
            db.SaveChanges();

            return Redirect("VerNotas");
        }


    public IActionResult AgregarNota(string titulo, string cuerpo, string fecha, string imagen, string URLnota){
            Nota nuevaNota = new Nota{
                Titulo = titulo,
                Cuerpo = cuerpo,
                Fecha = fecha,
                URLImagen = imagen,
                URLNotaCompleta = URLnota
            };
            ViewBag.Boton = "Notas";
            ViewBag.URL = "/Home/VerNotas";
            ViewBag.Info = "La nota " + titulo + " fue agregada con exito !";
            db.Nota.Add(nuevaNota);
            db.SaveChanges();
            return View("ResultadoDelProceso");
        }
        public IActionResult EditarMedico(int ID, string especialidad, string rolEnEspecialidad)
        {
            Medico medico = db.Medico.Include(m => m.Especialidad).Include(m => m.RolEnEspecialidad).FirstOrDefault(n => n.ID == ID);
            medico.Especialidad = db.Especialidad.FirstOrDefault(e => e.Nombre == especialidad);
            medico.RolEnEspecialidad = db.Rol.FirstOrDefault(r => r.Nombre == rolEnEspecialidad);

            db.Medico.Update(medico);
            db.SaveChanges();

            return Redirect("VerMedicos");
        }
        public IActionResult VerNotas(){
            if(CheckSessionOrDefault("AdminLogueado")!=null){
            ViewBag.Notas = db.Nota.ToList();
            return View("VerNotas");
             }
            else {
                return Redirect("Logueo");
            }
        }
    public IActionResult VerMisTurnos() {

        Usuario usuario= CheckSessionOrDefault("UsuarioLogueado");
          if (usuario != null ) { 

            List<Turno> turnos = new List<Turno>();
            turnos = db.Turno.Where(t =>t.MailUsuario.Equals(usuario.Mail)).ToList();
            if(turnos.Count()==0) {

                return View("SinTurnos");
            } else {

                return View ("VerMisTurnos",turnos);
            }

          } else {

              return Redirect("/Home/ErrorUser");
          }
       
    }
      public IActionResult VerMedicos(){
          if(CheckSessionOrDefault("AdminLogueado") !=null){
            ViewBag.Medicos = db.Medico.Include(m => m.RolEnEspecialidad).Include(m => m.Especialidad).OrderBy(m => m.Especialidad.Nombre).ToList();
            ViewBag.Especialidades = db.Especialidad.ToList();
            ViewBag.Turnos= db.Turno.ToList();
            ViewBag.Roles = db.Rol.ToList();
            return View();
            }
            else {
                return Redirect("Logueo");
            }
        }
        public IActionResult AgregarDatos(){
            if(CheckSessionOrDefault("AdminLogueado")!=null){
             ViewBag.Especialidades = db.Especialidad.ToList();
            ViewBag.Roles = db.Rol.ToList();
            return View();
            }
            else{
                return Redirect("Logueo");
            }
        }
    public IActionResult ResultadoDelProceso(){
            return View();
        }

        [HttpPost]
        public IActionResult AgregarMedico(string nombreYApellido, string especialidad, string rolEnEspecialidad) {
            Especialidad esp = db.Especialidad.FirstOrDefault(e => e.Nombre == especialidad);
            ViewBag.Especialidades = db.Especialidad.FirstOrDefault(e => e.Nombre == especialidad);
            
            Rol rol = db.Rol.FirstOrDefault(r => r.Nombre == rolEnEspecialidad);
            Medico nuevoMedico = new Medico{
                NombreYApellido = nombreYApellido,
                Especialidad = esp,
                RolEnEspecialidad = rol
            };
            
            ViewBag.Boton = "Medicos";
            ViewBag.URL = "/Home/VerMedicos";
            ViewBag.Info = " El profesional " + nombreYApellido + " con la especialidad " + especialidad + " fue agregado con exito !";
            db.Medico.Add(nuevoMedico);
            db.SaveChanges();
            return View("ResultadoDelProceso");
        }

         public IActionResult VerObrasSociales(){
             if(CheckSessionOrDefault("AdminLogueado")!=null){
            ViewBag.ObrasSociales = db.ObraSocial.OrderBy(o => o.Nombre).ToList();
            return View();
             }
             else 
             {
                 return Redirect("Logueo");
             }
        }

        public IActionResult EliminarObraSocial(int ID) {
          if(CheckSessionOrDefault("AdminLogueado")!=null){
            ObraSocial obraSocial = db.ObraSocial.FirstOrDefault(os => os.ID == ID);
            
            db.ObraSocial.Remove(obraSocial);
            db.SaveChanges();

            return Redirect("VerObrasSociales");
          }
          return Redirect("Logueo");
        }

        [HttpPost]
        public IActionResult EditarObraSocial(int ID, string nombre, string web, string estado) {
            ObraSocial obraSocial = db.ObraSocial.FirstOrDefault(os => os.ID == ID);
            obraSocial.Nombre = nombre;
            obraSocial.PaginaWeb = web;
            obraSocial.Estado = estado;

            db.ObraSocial.Update(obraSocial);
            db.SaveChanges();

            return Redirect("VerObrasSociales");
        }

        [HttpPost]
        public IActionResult AgregarObraSocial(string nombre, string web, string estado){
            ObraSocial obraSocial = db.ObraSocial.FirstOrDefault(os => os.Nombre == nombre);
            if(obraSocial != null){
                ViewBag.Error = true;
                return View("ResultadoDelProceso");
            }
            ObraSocial nuevaOS = new ObraSocial{
                Nombre = nombre,
                PaginaWeb = web,
                Estado = estado
            };

            ViewBag.Boton = "Obras Sociales";
            ViewBag.URL = "/Home/VerObrasSociales";
            ViewBag.Info = "La obra social " + nombre + " fue agregada con exito !" ;
            db.ObraSocial.Add(nuevaOS);
            db.SaveChanges();
            return View("ResultadoDelProceso");
        }

     public IActionResult Coberturas() {
             ViewBag.ObrasSociales = db.ObraSocial.Include(o => o.Planes).Where(os => os.Estado == "Activa").OrderBy(o => o.Nombre).ToList();
            return View();
        }

    public IActionResult Contacto() {

        return View();
    }

    public IActionResult AdminHome() {
        if(CheckSessionOrDefault("AdminLogueado")!=null){
        return View();}
        else {
            return Redirect("Logueo");
        }
    }
    public IActionResult RegistroResult(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logueo()
        {
            Usuario user = CheckSessionOrDefault("UsuarioLogueado");
            Usuario userAdmin = CheckSessionOrDefault("AdminLogueado");
                if(user!=null){
            return View("LogueoResult");
            }
            else {
                if(userAdmin!=null){
                return View("AdminHome");
                }
                else{
                    return View();
                }
            }
        }
       
    
        public IActionResult ConsultaEnviada() {

            return View();
        }

          [HttpPost]
        public IActionResult Login(string mail, string contraseña){
            Usuario usuarioLogin = db.Usuario.FirstOrDefault(usuario => usuario.Mail == mail);
            if(usuarioLogin != null){
                if(usuarioLogin.ObraSocial=="Administrator"){
                    TempData["Nombre"] = usuarioLogin.Nombre;
                    AgregarAdminASession(usuarioLogin);
                    return RedirectToAction("AdminHome", "Home");
                }
                if(usuarioLogin.Contraseña == contraseña){
                     
                    AgregarUsuarioASession(usuarioLogin);
                    return View("LogueoResult");
                }else{
                    ViewBag.ErrorEnLogin = true;
                    return View("Logueo");
                }
            }else{
                ViewBag.ErrorEnLogin = true;
                return View("Logueo");
            }
        }

       public IActionResult MiPerfil(){
            Usuario usuarioLogeado = CheckSessionOrDefault("UsuarioLogueado");
            Usuario user = db.Usuario.FirstOrDefault(u => u.Mail == usuarioLogeado.Mail);
            ViewBag.Nombre = user.Nombre;
            ViewBag.Apellido = user.Apellido;
            ViewBag.Mail = user.Mail;
            ViewBag.ObraSocial = user.ObraSocial;
            ViewBag.Contraseña = user.Contraseña;
            ViewBag.ObrasSociales = db.ObraSocial.ToList();
            return View();
        }
        
       

          public IActionResult LogueoResult(){
            return View();
        }


         private JsonResult AgregarUsuarioASession(Usuario usuarioLogin) {
           HttpContext.Session.Set<Usuario>("UsuarioLogueado", usuarioLogin);
            return Json(usuarioLogin);
        }
         private JsonResult AgregarAdminASession(Usuario adminLogin) {
           HttpContext.Session.Set<Usuario>("AdminLogueado", adminLogin);
            return Json(adminLogin);
        }


    [HttpPost]
    public IActionResult EnviarContacto (string nombre, string mail, string consulta) {


        try {

           MailMessage correo = new MailMessage();
           correo.From = new MailAddress("fundacionfavaloro6@gmail.com");
           correo.To.Add("fundacionfavaloro6@gmail.com");
           correo.Body= consulta;
           correo.CC.Add(mail);
            correo.IsBodyHtml= true;
            correo.Priority= MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.Host= "smtp.gmail.com";
            smtp.Port=25;
            smtp.EnableSsl=true;
            smtp.UseDefaultCredentials=false;
            string scuentaCorreo="fundacionfavaloro6@gmail.com";
            string sPasswordCorreo="Fundacion123";
             smtp.Credentials= new System.Net.NetworkCredential(scuentaCorreo,sPasswordCorreo);
             smtp.Send(correo);
             ViewBag.Mensaje= "Mensaje enviado correctamente";
        }
        catch (Exception ex) {

            ViewBag.Error=ex.Message;
        }

             this.ViewBag.Nombre = nombre;
            this.ViewBag.Mail = mail;
            this.ViewBag.Consulta = consulta;
          return View("ConsultaEnviada");

    }

        [HttpPost] 
         public IActionResult RegistrarUsuario(string mail, string nombre, string apellido, string obraSocial, string contraseña)   {

             Usuario user = db.Usuario.FirstOrDefault(u => u.Mail == mail);
              if(user != null){
                ViewBag.MailRegistrado = true;
                return View("RegistroResult");
            }

             Usuario nuevoUsuario = new Usuario{
                Mail = mail,
                Nombre = nombre,
                Apellido = apellido,
                ObraSocial = obraSocial,
                Contraseña = contraseña
            };
            
            db.Usuario.Add(nuevoUsuario);
            db.SaveChanges();
            return View("RegistroResult");

        }

        public IActionResult Salir(){
            HttpContext.Session.Remove("UsuarioLogueado");
            HttpContext.Session.Remove("AdminLogueado");
            return RedirectToAction("Logueo", "Home") ;
        }


public IActionResult EliminarCuenta(){
            Usuario user = CheckSessionOrDefault("UsuarioLogueado");
            HttpContext.Session.Remove("UsuarioLogueado");
            Usuario usuario = db.Usuario.FirstOrDefault(u => u.Mail == user.Mail);
            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

     public IActionResult Registro(){
            ViewBag.ObrasSociales = db.ObraSocial.Where(os => os.Estado == "Activa").OrderBy(os => os.Nombre).ToList();
            return View();
        }
    
            public IActionResult Transaccion(){
            return View();
        }

        public IActionResult EditarUsuario(string mail, string nombre, string apellido, string obraSocial, string contraseña){
            Usuario usuario = db.Usuario.FirstOrDefault(u => u.Mail == mail);
            usuario.ObraSocial = obraSocial;
            usuario.Contraseña = contraseña;

            db.Usuario.Update(usuario);
            db.SaveChanges();
            return View("Transaccion");
        }
    
    
        public IActionResult TurnosOnline(){
            Usuario usuarioLogeado =CheckSessionOrDefault("UsuarioLogueado");
            ViewBag.Nombre = usuarioLogeado.Nombre;
            ViewBag.Especialidades=db.Especialidad.OrderBy(es => es.Nombre).ToList();
            return View();
        }
        public IActionResult CancelarTurno(int ID){
            Turno turno = db.Turno.FirstOrDefault(t => t.ID == ID);
            

            db.Turno.Remove(turno);
            db.SaveChanges();
            return Redirect("VerMisTurnos");
        }

        public IActionResult ElegirEspecialista(string especialidad) {
          
            ViewBag.Medicos= db.Medico.Where( m => m.Especialidad.Nombre == especialidad).ToList();
            return View();

        }

        public IActionResult TurnoEnviado(string especialista){
         
           Usuario user =CheckSessionOrDefault("UsuarioLogueado");
           Medico medico = db.Medico.FirstOrDefault(m => m.NombreYApellido == especialista );
           Especialidad especialidad = db.Especialidad.FirstOrDefault(e => e.ID.Equals(medico.EspecialidadID));

           var turno = new Turno{
                MailUsuario=user.Mail,
                Especialidad=especialidad.Nombre,
                Especialista= especialista,
            };
          
            db.Turno.Add(turno);
            db.SaveChanges();

            return View();
        }
        public IActionResult EliminarNota(int ID){
            Nota nota = db.Nota.FirstOrDefault(n => n.ID == ID);
            
            db.Nota.Remove(nota);
            db.SaveChanges();

            return Redirect("VerNotas");
        }

    
 public IActionResult EliminarMedico(int ID)
        {
            Medico medico = db.Medico.FirstOrDefault(m => m.ID == ID);
            
            db.Medico.Remove(medico);
            db.SaveChanges();

            return Redirect("VerMedicos");
        }

    public Usuario CheckSessionOrDefault(string key){
        if(HttpContext.Session.Get<Usuario>(key) == null){
            return userOrAdminSession;
        }
        else{
            return HttpContext.Session.Get<Usuario>(key);
        }
    }

    }
}
