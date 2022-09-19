using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DictController : Controller
    {
        private PhoneModel phoneModel;
        // GET: Dict
        //Указываем что при загрузке
        //элементы загружаются из Json файла
        public ActionResult Index()
        {
            phoneModel = new PhoneModel(Server.MapPath("~/Models/Data.json"));
            ViewBag.phones = phoneModel.phones;
            return View();
        }
        //При нажатии на кнопку "добавить"
        //вызывается этот метод, он в свою
        //очередить методом View вызывает
        //страницу Add, та в совю очередь
        //вызовет метод обработки AddSave()
        [HttpGet]
        public ActionResult Add() {
            return View();
        }
        [HttpPost]
        public ActionResult MAdd(string surName, string phoneNumber) {
            phoneModel = new PhoneModel(Server.MapPath("~/Models/Data.json"));
            phoneModel.Add(surName, phoneNumber);
            ViewBag.phones = phoneModel.phones;
            return View("Index");
        }

    }
}