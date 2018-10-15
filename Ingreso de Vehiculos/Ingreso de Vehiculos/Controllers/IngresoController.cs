using Ingreso_de_Vehiculos.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Ingreso_de_Vehiculos.Controllers
{
    public class IngresoController : Controller
    {
        // GET: Ingreso
        public ActionResult Index()
        {
            List<departamentos> Idiomas = new List<departamentos>();
            using (DB_A1E868_ingresoCTPEntities bd = new DB_A1E868_ingresoCTPEntities())
            {
                Idiomas = bd.departamentos.ToList();
            }
            return View(Idiomas);
        }

        public JsonResult GuardarPersonas(FormCollection f)
        {
            string activo = f["activo"];
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-CR");
            TimeZoneInfo setTimeZoneInfo;
            DateTime currentDateTime;

            //Set the time zone information to US Mountain Standard Time 
            setTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");

            //Get date and time in US Mountain Standard Time
            currentDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, setTimeZoneInfo);

            //Print out the date and time
           DateTime hora = currentDateTime;
            int x = 1;
            eResultado Resultado = new eResultado();
            int id = Convert.ToInt32(f["departamento"]);
            try
            { 
                    using (DB_A1E868_ingresoCTPEntities bd = new DB_A1E868_ingresoCTPEntities())
                    
                        {
                            //NUEVO
                            Visitantes Personas = new Visitantes();
                            {
                                Personas.cedula = f["cedula"];
                                Personas.placa = f["placa"];
                                Personas.nombre = f["nombre"];
                                Personas.apellidos = f["apellidos"];
                                Personas.id_departamento = id;
                                Personas.fecha_ingreso = hora;
                            }
                    bd.Visitantes.Add(Personas);
                    //if (activo == "0")
                    //{
                    //    TSE personasActivas = new TSE();
                    //    {
                    //        personasActivas.Nombre = f["nombre"];
                    //        personasActivas.Apellido1 = f["apellidos"];
                    //        personasActivas.Cedula = f["cedula"];
                    //    }
                    //    bd.TSE.Add(personasActivas);
                    //}
                   
                    bd.SaveChanges();
                }

                x = 1;
                Resultado.Estado = true;
            }
            catch (Exception ex)
            {
                x = 2;
                Resultado.Estado = false;
                Resultado.TipoMensaje = 3;
            }
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscarCedula(string cedula)
        {
          
            DB_A1E868_ingresoCTPEntities bd = new DB_A1E868_ingresoCTPEntities();
                var emp = (from i in bd.TSE
                       where i.Cedula == cedula
                       select new { nombre = i.Nombre, apellidos = i.Apellido1 +" " + i.Apellido2,sexo =i.Sexo}).ToList();
            
            return Json(emp, JsonRequestBehavior.AllowGet);
        }


    }
}