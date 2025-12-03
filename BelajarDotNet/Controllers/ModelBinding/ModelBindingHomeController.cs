using BelajarDotNet.Models;
using BelajarDotNet.Models.ModelBinding;
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
            ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
            if (!ModelState.IsValid)
            {
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

        // FromRoute Attribute Example

        private List<UserFromRoute> _users = new List<UserFromRoute>() {

                new UserFromRoute(){Id =1, Name ="Fauzi", Age = 22,Mobile="082313131331"},
                new UserFromRoute(){Id =2, Name ="Sigit", Age = 23,Mobile="082313131331"},
                new UserFromRoute(){Id =3, Name ="Berka", Age = 22, Mobile = "082313131331"},
                new UserFromRoute(){Id =4, Name ="Egy", Age=21, Mobile = "082313131331"},
                new UserFromRoute(){Id =5, Name ="Evan", Age=22, Mobile = "082313131331"},
                new UserFromRoute(){Id =5, Name ="Regi", Age=22, Mobile = "082313131331"}
            };
        [HttpGet]
        public IActionResult UsersList()
        {
            return View(_users);
        }


        [HttpGet]
        [Route("users/{Id}/getdetails")]
        public IActionResult GetUserById([FromRoute(Name = "Id")] int Id)
        {
            var user = _users.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Model Binding Complex Types Example

        [HttpGet("Student/Create")]
        public ViewResult CreateComplex()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(GenderMb)).Cast<GenderMb>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "None", Value = "1" },
                new SelectListItem { Text = "CSE", Value = "2" },
                new SelectListItem { Text = "ETC", Value = "3" },
                new SelectListItem { Text = "Mech", Value = "4" }
            };
            ViewBag.Hobbies = new List<string> { "Reading", "Swimming", "Painting", "Cycling", "Hiking" };
            return View();
        }
        [HttpPost("Student/Create")]
        public IActionResult CreateComplex(StudentMb student)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Successful");
            }
            else
            {
                ViewBag.AllGenders = Enum.GetValues(typeof(GenderMb)).Cast<GenderMb>().ToList();
                ViewBag.AllBranches = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "None", Value = "1" },
                    new SelectListItem { Text = "CSE", Value = "2" },
                    new SelectListItem { Text = "ETC", Value = "3" },
                    new SelectListItem { Text = "Mech", Value = "4" }
                };
                ViewBag.Hobbies = new List<string> { "Reading", "Swimming", "Painting", "Cycling", "Hiking" };
                return View(student);
            }
        }
        public string Successful()
        {
            return "Student Created Successfully";
        }

        // Custom Model Binder Example

        public IActionResult CustomDateBinder()
        {
            return View();
        }

        [HttpGet("home/getdata")]
        public IActionResult GetData([ModelBinder(typeof(DateRangeModelBinder))] DateRange range)
        {
            // Do something with range.StartDate and range.EndDate
            return Ok($"The range parameters are From {range.StartDate} to {range.EndDate}");
        }
    }
}