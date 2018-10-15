using Ingreso_de_Vehiculos.Models;
using Ingreso_de_Vehiculos.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ingreso_de_Vehiculos.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region Ingreso
        public ActionResult visorDeEventos()
        {
            List<VisitanteMostrar> visitantesmostrar = new List<VisitanteMostrar>();
            using (DB_A1E868_ingresoCTPEntities bd = new DB_A1E868_ingresoCTPEntities())
            {
                visitantesmostrar = (from v in bd.Visitantes
                                    join d in bd.departamentos on v.id_departamento equals d.id_departamento
                                    select new VisitanteMostrar
                                    {
                                        id_visitante = v.id_visitante,
                                        nombre = v.nombre,
                                        apellidos = v.apellidos,
                                        cedula = v.cedula,
                                        fecha_ingreso = v.fecha_ingreso,
                                        departamento = d.nombre,
                                        placa = v.placa
                                    }).ToList();
            }
            return View(visitantesmostrar);
        }
        public ActionResult mantenimientoDepartamentos()
        {
            return View();
        }
        #endregion

    }
}