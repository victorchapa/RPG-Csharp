using MVCExample.Models;
using MVCExample.ModelsDTO;
using MVCExample.Services;
using System.Net;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class CharactersController : Controller
    {
        private MappleFakeContext db = new MappleFakeContext();
        private CharacterService characterService = new CharacterService();

        // GET: Characters
        public ActionResult Index()
        {
            var characters = characterService.GetAllCharacters();
            return View(characters);
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterDTO character = characterService.GetCharacterById(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name");
            return View();
        }

        // POST: Characters/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharacterId,Age,Name,Vocation,Faction,Gender,WeaponId")] CharacterDTO character)
        {
            if (ModelState.IsValid)
            {
                characterService.createCharacter(character);
                return RedirectToAction("Index");
            }

            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", character.WeaponId);
            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterDTO character = characterService.GetCharacterById(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", character.WeaponId);
            return View(character);
        }

        // POST: Characters/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterId,Age,Name,Vocation,Faction,Gender,WeaponId")] CharacterDTO characterDTO)
        {
            if (ModelState.IsValid)
            {
                characterService.EditCharacter(characterDTO);
                return RedirectToAction("Index");
            }
            ViewBag.WeaponId = new SelectList(db.Weapons, "WeaponId", "Name", characterDTO.WeaponId);
            return View(characterDTO);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacterDTO character = characterService.GetCharacterById(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            characterService.RemoveCharacter(id);
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
