using CrudOp.Models;
using CrudOp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudOp.Controllers
{
    public class ProfessionController : Controller
    {
        private readonly ProfessionRepository _professionRepo;
        public ProfessionController(ProfessionRepository professionRepo)
        {
            _professionRepo = professionRepo;
        }

        public IActionResult Index()
        {
            ModelState.Clear();

            return View(_professionRepo.GetAllProfessions().OrderByDescending(p => p.ProfessionID).OrderByDescending(p=>p.LastModified));
        }
        public IActionResult AddProfession()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProfession(ProfessionModel professionModel)
        {
            if (ModelState.IsValid)
            {
                if (_professionRepo.AddProfession(professionModel))
                {
                    return RedirectToAction("Index", "Profession");
                }
            }
            return View();
        }
        public IActionResult EditProfessionDetails(int id)
        {
            return View(_professionRepo.GetAllProfessions().Find(prof => prof.ProfessionID == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfessionDetails(int id, ProfessionModel professionModel)
        {
            if (ModelState.IsValid)
            {
                if (_professionRepo.UpdateProfession(professionModel))
                {
                    return RedirectToAction("Index", "Profession");
                }
            }
            return View(professionModel);
        }
        public IActionResult DeleteProfession(int id)
        {
            if (_professionRepo.DeleteProfession(id))
            {
                ViewBag.AlertMsg = "Profession details deleted successfully";
            }
            return RedirectToAction("Index","Profession");
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsProfessionAvailable([Bind(Prefix = "Profession")] string Profession, string initialProfession)
        {
            if (initialProfession != "" && initialProfession != null)
            {
                if (Profession.ToLower() == initialProfession.ToLower())
                {
                    return new JsonResult(true);
                }
            }
            var result = _professionRepo.GetAllProfessions().FirstOrDefault(a => a.Profession.ToLower() == Profession.ToLower());
            if (result == null)
            {
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }
    }
}
