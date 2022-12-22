using CrudOp.Models;
using CrudOp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CrudOp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProfessionRepository _professionRepo;
        private readonly ContactsRepository _contactsRepo;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,
            ProfessionRepository professionRepo,
            ContactsRepository contactsRepo,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _contactsRepo = contactsRepo;
            _professionRepo = professionRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            ModelState.Clear();

            return View(_contactsRepo.GetAllContacts().OrderByDescending(Contact => Contact.ContactID));
        }

        public IActionResult AddContact()
        {
            ViewBag.itemlist = new SelectList(_professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");

            return View();
        }
        
        [HttpPost]
        public IActionResult AddContact(ContactModel contactModel)
        {
            ViewBag.itemlist = new SelectList(_professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    //string contentRootPath = _webHostEnvironment.ContentRootPath;
                    Guid guid = Guid.NewGuid();
                    string NewImageName = guid.ToString() + Path.GetExtension(files[0].FileName);

                    string path = string.Empty;
                    path = Path.Combine(webRootPath, "Upload", NewImageName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                        contactModel.ContactImage = NewImageName;
                    }
                }
                if (_contactsRepo.AddContact(contactModel))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult EditContactDetails(int id)
        {
            ViewBag.itemlist = new SelectList(_professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");

            return View(_contactsRepo.GetAllContacts().Find(Contact => Contact.ContactID == id));
        }
        [HttpPost]
        public IActionResult EditContactDetails(int id, ContactModel contactModel)
        {
            ViewBag.itemlist = new SelectList(_professionRepo.GetAllProfessions().OrderBy(e => e.Profession), "ProfessionID", "Profession");
            string DeleteFile = _contactsRepo.GetAllContacts().Find(Contact => Contact.ContactID == id).ContactImage;
            string webRootPath = _webHostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    //string contentRootPath = _webHostEnvironment.ContentRootPath;
                    Guid guid = Guid.NewGuid();
                    string NewImageName = guid.ToString() + Path.GetExtension(files[0].FileName);

                    string path = string.Empty;
                    path = Path.Combine(webRootPath, "Upload", NewImageName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                        contactModel.ContactImage = NewImageName;
                    }

                    #region Delete Previous Image
                    string DeleteFilePath = Path.Combine(webRootPath, "Upload", DeleteFile);
                    FileInfo file = new FileInfo(DeleteFilePath);
                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete();
                    }
                    #endregion
                }
                if (_contactsRepo.UpdateContact(contactModel))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult DeleteContact(int id)
        {
            if (_contactsRepo.DeleteContact(id))
            {
                ViewBag.AlertMsg = "Contact details deleted successfully";
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ContactDetails(int id)
        {
            return View(_contactsRepo.GetAllContacts().Find(Contact => Contact.ContactID == id));
        }

        public IActionResult NextContact(int id)
        {
            var Result = _contactsRepo.GetAllContacts().SkipWhile(Contact => Contact.ContactID != id).Skip(1).FirstOrDefault();

            if (Result != null)
            {
                return RedirectToAction("ContactDetails", new RouteValueDictionary(new { controller = "Home", action = "ContactDetails", id = Result.ContactID }));
            }
            else
            {
                int FirstRecord = _contactsRepo.GetAllContacts().First().ContactID;
                return RedirectToAction("ContactDetails", new RouteValueDictionary(new { controller = "Home", action = "ContactDetails", id = FirstRecord }));
            }
        }

        public IActionResult PreviousContact(int id)
        {
            var Result = _contactsRepo.GetAllContacts().OrderByDescending(Contact => Contact.ContactID).SkipWhile(Contact => Contact.ContactID != id).Skip(1).FirstOrDefault();

            if (Result != null)
            {
                return RedirectToAction("ContactDetails", new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "ContactDetails",
                    id = Result.ContactID
                }));
            }
            else
            {
                int LastRecord = _contactsRepo.GetAllContacts().OrderByDescending(Contact => Contact.ContactID).First().ContactID;
                return RedirectToAction("ContactDetails", new RouteValueDictionary(new { controller = "Home", action = "ContactDetails", id = LastRecord }));
            }
        }

        [AcceptVerbs("Get","Post")]
        public IActionResult IsEmailAvailable([Bind(Prefix = "emailAddr")] string emailAddr, string initialEmail)
        {
            if (initialEmail != "" && initialEmail != null)
            {
                if (emailAddr.ToLower() == initialEmail.ToLower())
                {
                    return new JsonResult(true);
                }
            }
            var result = _contactsRepo.GetAllContacts().FirstOrDefault(a => a.emailAddr.ToLower() == emailAddr.ToLower());
            if (result == null)
            {
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}