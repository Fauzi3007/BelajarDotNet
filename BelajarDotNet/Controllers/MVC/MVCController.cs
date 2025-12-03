using System.Diagnostics;
using BelajarDotNet.Models;
using BelajarDotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BelajarMVC.Controllers
{
    public class MVCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Details()
        {
            ViewData["Title"] = "Student Details Page";
            ViewBag.Header = "Student Details";

            StudentMVC student = new StudentMVC()
            {
                Id = 101,
                Name = "Fauzi",
                Branch = "CSE",
                Section = "A",
                Gender = "Male"
            };

            AddressMVC address = new AddressMVC()
            {
                Id = 101,
                City = "Jakarta",
                State = "DKI Jakarta",
                Country = "Indonesia",
                Pin = "10110"
            };

            StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel()
            {
                Student = student,
                Address = address,
                Title ="Halaman Detail Murid",
                Header = "Detail Murid"
            };

            return View(studentDetailsViewModel);

        }

        public IActionResult SubmitForm()
        {
            TempData["Message"] = "Formulir tersimpan";
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            var message = TempData["Message"] as string;
            return View(model: message);
        }
    }
}
