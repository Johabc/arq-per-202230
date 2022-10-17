using arq_per_202230.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arq_per_202230.Controllers
{
    public class DefaultController : Controller
    {
        // GET: DefaultController
        public ActionResult Index()
        {
            IEnumerable<Persona> persona = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49555/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Personas");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Persona>>();
                    readTask.Wait();

                    persona = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    persona = Enumerable.Empty<Persona>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(persona);

        }


        

        // GET: DefaultController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DefaultController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefaultController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DefaultController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DefaultController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DefaultController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DefaultController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
