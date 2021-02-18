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
    public class ViajerosController : Controller
    {
        // GET: ViajerosLista
        public async Task<ActionResult> Lista()
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["Viajeros"].ToString());
            var ListaViajeros = JsonConvert.DeserializeObject<List<tblViajeros>>(Json);
            return View(ListaViajeros);
        }

        // GET: ViajerosLista/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id);
            var tblViajeros = JsonConvert.DeserializeObject<tblViajeros>(Json);
            return View(tblViajeros);
        }

        // GET: ViajerosLista/Create
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: ViajerosLista/Create
        [HttpPost]
        public ActionResult Nuevo(tblViajeros tblViajeros)
        {
            try
            {
                // TODO: Add insert logic here

                var httpClient = new HttpClient();
                var contet = httpClient.PostAsJsonAsync<tblViajeros>(ConfigurationManager.AppSettings["ViajerosViajes"].ToString(), tblViajeros);

                return RedirectToAction("Lista");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: ViajerosLista/Edit/5
        public async Task<ActionResult> Editar(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id);
            var tblViajeros = JsonConvert.DeserializeObject<tblViajeros>(Json);
            return View(tblViajeros);
        }

        // POST: ViajerosLista/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, tblViajeros tblViajeros)
        {
            try
            {
                // TODO: Add update logic here
                var httpClient = new HttpClient();
                var contet = httpClient.PutAsJsonAsync<tblViajeros>(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id, tblViajeros);

                return RedirectToAction("Lista");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: ViajerosLista/Delete/5
        public async Task<ActionResult> Eliminar(int id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id);
            var tblViajeros = JsonConvert.DeserializeObject<tblViajeros>(Json);
            return View(tblViajeros);
        }

        // POST: ViajerosLista/Delete/5
        [HttpPost]
        public async Task<ActionResult> Eliminar(int id, tblViajeros tblViajerosn)
        {
            try
            {
                // TODO: Add delete logic here
                var httpClient = new HttpClient();
                var Json = await httpClient.DeleteAsync(ConfigurationManager.AppSettings["ViajerosViajes"].ToString() + id);

                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
        }
    }
}
