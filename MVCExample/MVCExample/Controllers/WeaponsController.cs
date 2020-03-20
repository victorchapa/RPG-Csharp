using MVCExample.Models;
using MVCExample.ModelsDTO;
using MVCExample.Services;
using System.Net;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class WeaponsController : Controller
    {
        private MappleFakeContext db = new MappleFakeContext();
        private WeaponService weaponService = new WeaponService();

        // GET: Weapons
        public ActionResult Index()
        {
            return View(weaponService.GetAllWeapons());
        }

        // GET: Weapons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponDTO weaponDTO = weaponService.GetWeaponByID(id);
            if (weaponDTO == null)
            {
                return HttpNotFound();
            }
            return View(weaponDTO);
        }

        // GET: Weapons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weapons/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeaponId,Attack,Defense,Handler,Name,Kind")] WeaponDTO weaponDTO)
        {
            if (ModelState.IsValid)
            {
                weaponService.ForgeWeapon(weaponDTO);
                return RedirectToAction("Index");
            }

            return View(weaponDTO);
        }

        // GET: Weapons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponDTO weaponDTO = weaponService.GetWeaponByID(id);
            if (weaponDTO == null)
            {
                return HttpNotFound();
            }
            return View(weaponDTO);
        }

        // POST: Weapons/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeaponId,Attack,Defense,Handler,Name,Kind")] WeaponDTO weaponDTO)
        {
            if (ModelState.IsValid)
            {
                weaponService.EditWeapon(weaponDTO);
                return RedirectToAction("Index");
            }
            return View(weaponDTO);
        }

        // GET: Weapons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponDTO weaponDTO = weaponService.GetWeaponByID(id);
            if (weaponDTO == null)
            {
                return HttpNotFound();
            }
            return View(weaponDTO);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            weaponService.RemoveWeapon(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
