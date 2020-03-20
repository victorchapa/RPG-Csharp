using MVCExample.Models;
using MVCExample.ModelsDTO;
using MVCExample.Services;
using System.Net;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class MonstersController : Controller
    {
        private MappleFakeContext db = new MappleFakeContext();
        private MonsterService monsterService = new MonsterService();

        // GET: Monsters
        public ActionResult Index()
        {
            var monstersDTO = monsterService.GetAllMonsters();
            return View(monstersDTO);
        }

        // GET: Monsters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterDTO monsterDTO = monsterService.GetCharacterById(id);
            if (monsterDTO == null)
            {
                return HttpNotFound();
            }
            return View(monsterDTO);
        }

        // GET: Monsters/Create
        public ActionResult Create()
        {
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name");
            return View();
        }

        // POST: Monsters/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonsterId,Name,Move,Health,Defense,Attack,WeaponId")] MonsterDTO monsterDTO)
        {
            if (ModelState.IsValid)
            {
                monsterService.AddNewMonsta(monsterDTO);
                return RedirectToAction("Index");
            }

            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", monsterDTO.WeaponId);
            return View(monsterDTO);
        }

        // GET: Monsters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterDTO monsterDTO = monsterService.GetCharacterById(id);
            if (monsterDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", monsterDTO.WeaponId);
            return View(monsterDTO);
        }

        // POST: Monsters/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonsterId,Name,Move,Health,Defense,Attack,WeaponId")] MonsterDTO monsterDTO)
        {
            if (ModelState.IsValid)
            {
                monsterService.EditMonster(monsterDTO);
                return RedirectToAction("Index");
            }
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", monsterDTO.WeaponId);
            return View(monsterDTO);
        }

        // GET: Monsters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterDTO monsterDTO = monsterService.GetCharacterById(id);
            if (monsterDTO == null)
            {
                return HttpNotFound();
            }
            return View(monsterDTO);
        }

        // POST: Monsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            monsterService.DeleteMonster(id);
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
