using Tienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tienda.Controllers
{
    public class ProductosController : Controller
    {
        ExamenEntities cnx;

        public ProductosController()
        {
            cnx = new ExamenEntities();
        }

        public ActionResult Listado()
        {

            return View(cnx.Productos.ToList());
        }

        public ActionResult Formulario()
        {
            
            return View();
        }

        public ActionResult Guardar(int id_producto, string nombre_producto, string codigo_barra, string familia, int precio, string descuento_tope, string descripcion)
        {
            Productos producto = new Productos()
            {
                Id_producto = id_producto,
                Nombre_producto = nombre_producto,
                Codigo_barra = codigo_barra,
                Familia = familia,
                Precio = precio,
                Descuento_tope = descuento_tope,
                Descripcion = descripcion
            };
            cnx.Productos.Add(producto);
            cnx.SaveChanges();

            return View("Listado", cnx.Productos.ToList());
        }

        public ActionResult Ficha(int id_producto)
        {

            return View(cnx.Productos.Where(x => x.Id_producto == id_producto).First());
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id_producto)
        {
            return View("Listado", cnx.Productos.ToList());
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id_producto)
        {
            return View("Listado", cnx.Productos.ToList());
        }

    }
}