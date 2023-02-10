using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//importamos Models
using pj_MVC_CRUD_bdventas.Models;


namespace pj_MVC_CRUD_bdventas.Controllers
{
    public class ClienteController : Controller
    {
        // Part 1 : definir la variable de los DAO a utilizar
        ClienteDAO dao_cli = new ClienteDAO();
        DistritoDAO dao_dis = new DistritoDAO();

        // Part 2 : GET: Cliente
        // DE manera lógica, lista todos los que no han sido eliminados
        public ActionResult ClienteListado()
        {
            // obtener los datos desde el modelo
            var listado = dao_cli.ListarClientes("No");

            // enviar los datos del modelo a la vista
            return View(listado);
        }

        // Part 3 : Insertar un nuevo cliente (GET/POST)
        // GET: Cliente/Create
        public ActionResult ClienteGrabar()
        {
            //declaro un nuevo objeto Cliente 'obj'
            ClienteModel obj = new ClienteModel();
            // valores iniciales para el nuevo cliente
            obj.fec_nac = new DateTime(2001, 10, 28);
            obj.cred_cli = 2500;

            // traer la lista de distritos dentro de un viewbag
            ViewBag.DISTRITOS = new SelectList(
                 dao_dis.ListarDistritos(), // data
                 "cod_dist",  // nombre del campo clave o pk
                 "nom_dist"  // nombre del campo a mostrar en el dropdownlist
                );

            //
            return View(obj);
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult ClienteGrabar(ClienteModel obj)
        {
            string mensaje = "";
            try
            {
                // TODO: Add insert logic here
                // sino hubo error en el modelo
                if (ModelState.IsValid == true)
                {
                    mensaje = dao_cli.GrabarCliente(obj);
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            //
            ViewBag.MENSAJE = mensaje;

            // traer la lista de distritos dentro de un viewbag
            ViewBag.DISTRITOS = new SelectList(
                 dao_dis.ListarDistritos(), // data
                 "cod_dist",  // nombre del campo clave o pk
                 "nom_dist"  // nombre del campo a mostrar en el dropdownlist
                );
            //
            return View(obj);
        }


        // Part 4 : ==============

         
        // GET: Cliente/Details/5
        public ActionResult ClienteDetalle(string id = "")
        {
            // obtener la información del cliente en base a su codigo
            var listado = dao_cli.ListarClientes("No");
            //
            ClienteModel obj = listado.Find(c => c.cod_cli.Equals(id));
            //
            return View(obj);
        }

        // Part 5 : Editar Ciente
        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Part 6 : Eliminar Cliente
        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
