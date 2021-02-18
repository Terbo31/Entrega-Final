using AgenciaAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAgencia.Controllers
{
    public class ViajerosViajesController : Controller
    {
        // GET: ViajerosViajes
        public async Task<ActionResult> Lista()
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString());
            var ListaViajesViajeros = JsonConvert.DeserializeObject<List<tblViajesViajeros>>(Json);
            return View(ListaViajesViajeros);
        }

        // GET: ViajerosViajes/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id);
            var ListaViajesViajeros = JsonConvert.DeserializeObject<tblViajesViajeros>(Json);
            return View(ListaViajesViajeros);
        }

        // GET: ViajerosViajes/Create
        public async Task<ActionResult> Nuevo()
        {

            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["Viajes"].ToString());
            var ListaViajes = JsonConvert.DeserializeObject<List<tblViajes>>(Json);
            ViewBag.CodigoViaje = new SelectList(ListaViajes, "CodigoViaje", "Destino");
         
            return View();
        }

        // POST: ViajerosViajes/Create
        [HttpPost]
        public async Task<ActionResult> Nuevo(tblViajesViajeros tblViajesViajeros)
        {
            // TODO: Add insert logic here
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["Viajeros"].ToString());
            var Viajero = JsonConvert.DeserializeObject<List<tblViajeros>>(Json);
            Viajero = Viajero.Where(c => c.Cedula == tblViajesViajeros.Cedula).ToList();

            if (Viajero.Count > 0)
            {

                try
                {

                    var contet = httpClient.PostAsJsonAsync<tblViajesViajeros>(ConfigurationManager.AppSettings["ViajerosViajes"].ToString(), tblViajesViajeros);

                    return RedirectToAction("Lista");
                }
                catch (Exception e)
                {
                    return View(e.Message);
                }
            }
            else
            {

                Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["Viajes"].ToString());
                var ListaViajes = JsonConvert.DeserializeObject<List<tblViajes>>(Json);
                ViewBag.CodigoViaje = new SelectList(ListaViajes, "CodigoViaje", "Destino");
                ModelState.AddModelError("Cedula", "cedula no esta registrada por favor registre");
                return View();
            }
        }

        // GET: ViajerosViajes/Edit/5
        public async Task<ActionResult> Editar(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id);
            var ListaViajesViajeros = JsonConvert.DeserializeObject<tblViajesViajeros>(Json); 
            return View(ListaViajesViajeros);
        }

        // POST: ViajerosViajes/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, tblViajesViajeros tblViajesViajeros)
        {
            try
            {
                // TODO: Add update logic here
                var httpClient = new HttpClient();
                var contet = httpClient.PutAsJsonAsync<tblViajesViajeros>(ConfigurationManager.AppSettings["Viajes"].ToString() + id, tblViajesViajeros);

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: ViajerosViajes/Delete/5
        public async Task<ActionResult> Eliminar(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id);
            var tblViajesViajeros = JsonConvert.DeserializeObject<tblViajesViajeros>(Json);
            return View(tblViajesViajeros);
        }

        // POST: ViajerosViajes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Eliminar(int id, tblViajesViajeros tblViajesViajeros)
        {
            try
            {
                // TODO: Add delete logic here
                var httpClient = new HttpClient();
                var Json = await httpClient.DeleteAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id);

                return RedirectToAction("Lista");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
    }
}
