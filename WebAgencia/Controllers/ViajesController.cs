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
    public class ViajesController : Controller
    {
        // GET: Viajes
        public async Task<ActionResult> Lista()
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["Viajes"].ToString());
            var ListaViajes = JsonConvert.DeserializeObject<List<tblViajes>>(Json);
            return View(ListaViajes);
        }

        // GET: Viajes/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["Viajes"].ToString() + id);
            var ListaViajes = JsonConvert.DeserializeObject<tblViajes>(Json);
            return View(ListaViajes);
        }

        // GET: Viajes/Create
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: Viajes/Create
        [HttpPost]
        public ActionResult Nuevo(tblViajes tblViajes)
        {
            try
            {
                // TODO: Add insert logic here

                var httpClient = new HttpClient();
                var contet = httpClient.PostAsJsonAsync<tblViajes>(ConfigurationManager.AppSettings["Viajes"].ToString(), tblViajes);

                return RedirectToAction("Lista");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: Viajes/Edit/5
        public async Task<ActionResult> Editar(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["Viajes"].ToString() + id);
            var tblViajes = JsonConvert.DeserializeObject<tblViajes>(Json);
            return View(tblViajes);
        }

        // POST: Viajes/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, tblViajes tblViajes)
        {
            try
            {
                // TODO: Add update logic here
                var httpClient = new HttpClient();
                var contet = httpClient.PutAsJsonAsync<tblViajes>(ConfigurationManager.AppSettings["Viajes"].ToString() + id, tblViajes);

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Viajes/Delete/5
        public async Task<ActionResult> Eliminar(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["Viajes"].ToString() + id);
            var tblViajes = JsonConvert.DeserializeObject<tblViajes>(Json);
            return View(tblViajes);
        }

        // POST: Viajes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Eliminar(int id, tblViajeros tblViajeros)
        {
            try
            {
                // TODO: Add delete logic here
                var httpClient = new HttpClient();
                var Json = await httpClient.DeleteAsync(ConfigurationManager.AppSettings["Viajes"].ToString() + id);

                return RedirectToAction("Lista");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
       
    }
}
