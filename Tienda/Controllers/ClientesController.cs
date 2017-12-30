using Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tienda.Controllers
{
    public class ClientesController : Controller
    {
        ExamenEntities cnx;
        public ClientesController()
        {
            cnx = new ExamenEntities();
        }
        
        public ActionResult Formulario()
        {
            return View();
        }

        public ActionResult Guardar(string rut_cliente , string nombre, string apellido, string direccion, string tipo_cliente)
        {
            Clientes cliente = new Clientes()
            {
               Rut_cliente = rut_cliente,
               Nombre = nombre,
               Apellido = apellido,
               Direccion = direccion,
               Tipo_cliente = tipo_cliente
            };
            cnx.Clientes.Add(cliente);
            cnx.SaveChanges();

            return View("Listado", cnx.Clientes.ToList());
        }

        public ActionResult Listado()
        {

            return View(cnx.Clientes.ToList());
        }

        public ActionResult Ficha(string rut_cliente)
        {

            return View(cnx.Clientes.Where(x => x.Rut_cliente.Equals(rut_cliente)).First());
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(string rut_cliente)
        {
            return View("Listado", cnx.Clientes.ToList());
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(string rut_cliente)
        {
            return View("Listado", cnx.Clientes.ToList());
        }

        
    }
}
