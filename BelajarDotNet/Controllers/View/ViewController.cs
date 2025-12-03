using System.Diagnostics;
using BelajarDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BelajarDotNet.Controllers
{
    public class ViewController : Controller
    {
        public ViewResult Home()
        {
            List<StudentView> listStudentViews = new List<StudentView>()
            {
               new StudentView() { Id = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
               new StudentView() { Id = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
               new StudentView() { Id = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
               new StudentView() { Id = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
               new StudentView() { Id = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
            return View(listStudentViews);
        }
        public ViewResult Details(int Id)
        {
            var StudentViewDetails = new StudentView() { Id = Id, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" };
            return View(StudentViewDetails);
        }
        private List<ProductView> products = new List<ProductView>()
        {
            new ProductView { Id =1, Name ="Product 1", Category = "Category 1", Description ="Description 1", Price = 10m},
            new ProductView { Id =2, Name ="Product 2", Category = "Category 1", Description ="Description 2", Price = 20m},
            new ProductView { Id =3, Name ="Product 3", Category = "Category 1", Description ="Description 3", Price = 30m},
            new ProductView { Id =4, Name ="Product 4", Category = "Category 2", Description ="Description 4", Price = 40m},
            new ProductView { Id =5, Name ="Product 5", Category = "Category 2", Description ="Description 5", Price = 50m},
            new ProductView { Id =6, Name ="Product 6", Category = "Category 2", Description ="Description 6", Price = 50m}
        };
        

        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult ProductDetails(int Id)
        {
            var ProductDetails = products.FirstOrDefault(prd => prd.Id == Id);
            return View(ProductDetails);
        }

    }
}
