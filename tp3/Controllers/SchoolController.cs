using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tp3.Models;
using tp3.Models.Repositories;

namespace tp3.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {

        ISchoolRepository schoolRepository;
        //injection de dépendance
        public SchoolController(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        // GET: School
        public ActionResult Index()
        {
            var schools = schoolRepository.GetAll();
            return View(schools);
        }

        // GET: School/Details/5
        public ActionResult Details(int id)
        { var school = schoolRepository.GetById(id);
            ViewBag.AgeAverage = schoolRepository.StudentAgeAverage(id);
            ViewBag.StudentCount = schoolRepository.StudentCount(id); 
            return View(school);
        }

        // GET: School/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: School/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School s)
        {
            try
            {
                schoolRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        { 
            var school =schoolRepository.GetById(id);
            return View(school);
        }

        // POST: School/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, School NewSchool)
        {
            try
            {
                schoolRepository.Edit(NewSchool);

                return RedirectToAction (nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: School/Delete/5
        public ActionResult Delete(int id)
        {
            var school = schoolRepository.GetById(id);
            return View(school);
        }

        // POST: School/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, School s)
        {
            try
            {
                schoolRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
