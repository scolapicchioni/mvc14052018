using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class PeopleController : Controller
    {
        private static List<Person> list = new List<Person>()
            {
                new Person(){ Id = 1, Name = "Simona", Surname="Colapicchioni", Age = 44 },
                new Person(){ Id = 2, Name = "Alice", Surname="Anderson", Age = 45 },
                new Person(){ Id = 5, Name = "Martha", Surname="Anderson", Age = 35 },
                new Person(){ Id = 6, Name = "Frank", Surname="Anderson", Age = 25 },
                new Person(){ Id = 3, Name = "Bob", Surname="Builder", Age = 46 },
                new Person(){ Id = 4, Name = "Candice", Surname="Clarkson", Age = 47 }
            };
        public ViewResult GetPeople()
        {
            return View(list);
        }

        //people/getperson/3
        [Route("people/details/{id:int}")]
        public ActionResult GetPerson(int id)
        {
            Person person = list.FirstOrDefault(p => p.Id == id);
            if(person!=null)
                return View(person);
            else
                return HttpNotFound();
        }

        //pass parameter via querystring
        //people/getPeopleBySurname?surname=anderson

        //people/surname/anderson
        //people/surname/{surname}
        [Route("people/surname/{surname}")]
        public ActionResult GetPeopleBySurname(string surname)
        {   
            return View("GetPeople", list.Where(p => p.Surname.ToLower() == surname.ToLower()).ToList());
        }

        //pass parameter via querystring
        //people/getPeopleByName?name=simona

            //people/name/Simona
        public ActionResult GetPeopleByName(string name)
        {
            return View("GetPeople", list.Where(p => p.Name.ToLower() == name.ToLower()).ToList());
        }


        //pass parameter via querystring
        //people/YetAnotherMethod?surname=Stewart&name=Martha&id=7&age=99
        public ActionResult YetAnotherMethod(Person pers)
        {
            return View("GetPerson",pers);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person theNewPerson)
        {
            if(!ModelState.IsValid)
                return View(theNewPerson);

            list.Add(theNewPerson);
            return RedirectToAction("GetPeople");
        }

        public ActionResult Update(int id)
        {
            Person person = list.FirstOrDefault(p => p.Id == id);
            if (person != null)
                return View(person);
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Update(Person theNewPerson)
        {
            if (!ModelState.IsValid)
                return View(theNewPerson);

            list.Add(theNewPerson);
            return RedirectToAction("GetPeople");
        }

        public ActionResult Delete(int id)
        {
            Person person = list.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                return View(person);
            }
            else
                return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = list.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                list.Remove(person);
                return RedirectToAction("GetPeople");
            }
            else
                return HttpNotFound();
        }

        [ChildActionOnly]
        public ActionResult MyListBox() {
            //go to the db, get the model

            return PartialView(new Person() { Id = 1, Name = "Mario" });
        }
    }
}