using BelajarDotNet.Models;
using BelajarDotNet.Models.Model_Binding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BelajarDotNet.Controllers
{
    public class ModelBindingHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(User user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Message = $"User Created: UserName: {user.UserName}, UserEmail: {user.UserEmail}";

                   
                    ModelState.Clear();

                    return View("Index");
                }
            }
            return View("Index", user);
        }


        //Fromform Attribute Example

        //[HttpGet]
        //public IActionResult CreateFromForm()
        //{
        //    var model = new UserFromForm();
        //    ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
        //    ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult CreateFromForm([FromForm] UserFromForm user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
        //        ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
        //        return View(user);
        //    }
        //    return RedirectToAction("SuccessFromForm", user);
        //}

        [HttpGet]
        public IActionResult CreateFromForm()
        {
            UserFromForm user = new UserFromForm();
            ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
            return View(user);
        }
        [HttpPost]
        public IActionResult CreateFromForm(
            [FromForm(Name = "Name")] string UserName,
            [FromForm(Name = "Email")] string UserEmail,
            [FromForm] string Password,
            [FromForm] string Mobile,
            [FromForm] string Gender,
            [FromForm] string Country,
            [FromForm] List<string> Hobbies,
            [FromForm] DateTime? DateOfBirth,
            [FromForm] bool TermsAccepted)
        {
            var user = new UserFromForm
            {
                UserName = UserName,
                UserEmail = UserEmail,
                Password = Password,
                Mobile = Mobile,
                Gender = Gender,
                Country = Country,
                Hobbies = Hobbies,
                DateOfBirth = DateOfBirth,
                TermsAccepted = TermsAccepted
            };
            if (!ModelState.IsValid)
            {
                ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
                ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
                return View(user);
            }
            return RedirectToAction("SuccessFromForm", user);
        }

        [HttpGet]
        public IActionResult SuccessFromForm(UserFromForm user)
        {
            return View(user);
        }


        // FromQuery Attribute Example
        public async Task<IActionResult> ProductFromQuery([FromQuery] ProductQueryParametersFq queryParameters)
        {
            var _productService = new ProductServiceFq();
            var (products, totalCount) = await _productService.GetProductAsync(queryParameters);
            var categories = Enum.GetValues(typeof(ProductCategoryFq))
                .Cast<ProductCategoryFq>()
                .Select(category => new SelectListItem { Value = category.ToString(), Text = category.ToString() })
                .ToList(); 
        
            var sortOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "price", Text = "Price" }, 
                new SelectListItem { Value = "date", Text = "Date Added" },
            };
            var pageSizeOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "3", Text = "3" }, 
                new SelectListItem { Value = "5", Text = "5" }, 
                new SelectListItem { Value = "10", Text = "10" }, 
                new SelectListItem { Value = "20", Text = "20" },
                new SelectListItem { Value = "25", Text = "25" }, 
                new SelectListItem { Value = "35", Text = "35" }  
            };
            var viewModel = new ProductListViewModelFq
            {
                Products = products, 
                PageNumber = queryParameters.PageNumber, 
                PageSize = queryParameters.PageSize, 
                TotalPages = (int)Math.Ceiling((double)totalCount / queryParameters.PageSize), 
                SearchTerm = queryParameters.SearchTerm, 
                Category = queryParameters.Category, 
                SortBy = queryParameters.SortBy, 
                SortAscending = queryParameters.SortAscending,
                Categories = categories, 
                SortOptions = sortOptions, 
                PageSizeOptions = pageSizeOptions 
            };
            return View(viewModel);
        }
    }
}