using CTD.BussinessOperations.Extensions;
using CTD.BussinessOperations.Models.ViewModels;
using CTD.BussinessOperations.Services;
using CTD.Extensions;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CTD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _commingSoonViewPath = "~/Views/Home/CommingSoon.cshtml";
        private readonly string _servicesViewPath = "~/Views/Shared/ServicesPages";
        private readonly IUserService _userService;
        private readonly IEmailSendService _emailSender;
        private readonly IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger, IUserService userService, IEmailSendService emailSender, IWebHostEnvironment env)
        {
            _logger = logger;
            _userService = userService;
            _emailSender = emailSender;
            _env = env;
        }

        #region Home

        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        #endregion

        #region Contact

        [HttpGet]
        [Route("contact-us")]
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }

        [HttpPost("sent-request-data")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUsFromSubmit(UserViewModel user)
        {
            var response = new ResponseModel();
            try
            {
                Log.Information(user.ToJson());
                if (ModelState.IsValid)
                {
                    user.FilePath = $"{_env.WebRootPath}/{Path.Combine("HtmlTemplates")}";
                    user.CleanUserModel(user);
                    await _userService.SaveUserEmailMessageAsync(user);
                    response.Message = "Email has been sent.";
                }
                else
                {
                    response.Success = false;
                    //response.Error = ModelState.Values;
                    response.Message = "Please fill all fields.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred. Please Try later.";
                Log.Error(exception: ex, messageTemplate: "ContactUsFromSubmit - Controller: {0}", user.ToJson());
            }

            return Json(response);
        }

        [HttpPost("services-contact-form")]
        public async Task<IActionResult> ContactFormForServices(string servicePlan)
        {
            ViewBag.ServicePlan = servicePlan;

            return PartialView("~/Views/Shared/ServicesPages/_ServiceContentForm.cshtml");
        }
        [HttpPost("it-staff-services-contact-form")]
        public async Task<IActionResult> ITStaffContactFormForServices(string servicePlan)
        {
            ViewBag.ServicePlan = servicePlan;

            return PartialView($"{_servicesViewPath}/ITStaffAugumentation/_ITStaffContactForm.cshtml");
        }
        [HttpPost("web-development-services-contact-form")]
        public async Task<IActionResult> WebDevelopmentContactFormForServices(string servicePlan)
        {
            ViewBag.ServicePlan = servicePlan;

            return PartialView($"{_servicesViewPath}/WebDevelopment/_WebDevelopmentContactForm.cshtml");
        }
        #endregion

        #region About

        [Route("about-us")]
        public async Task<IActionResult> AboutUs()
        {
            return View();
        }

        #endregion

        #region Services

        [Route("services")]
        public async Task<IActionResult> Services()
        {
            return View();
        }

        #region ITStaffAugumentation

        [Route("it-staff-augumentation")]
        public async Task<IActionResult> ITStaffAugumentation()
        {
            ViewBag.CityName = "UK";
            return View();
        }

        [Route("it-staff-augumentation/{cityName}-it-staff-augumentation")]
        public async Task<IActionResult> CitywiseITStaffAugumentation(string cityName)
        {

            if (!string.IsNullOrEmpty(cityName))
            {
                ViewBag.CityName = cityName.ToTitleCaseText();
                string viewName = cityName.ITStaffServicesViewNameByCity();
                if (!string.IsNullOrEmpty(viewName))
                    return View($"{_servicesViewPath}/ITStaffAugumentation/{viewName}.cshtml");
                return View(_commingSoonViewPath);
            }
            else
            {
                return View(_commingSoonViewPath);
            }
        }

        [Route("{cityName}-it-staff-augumentation")]
        public async Task<IActionResult> OldRouteCitywiseITStaffAugumentation(string cityName)
        {
            return RedirectToActionPermanent(nameof(CitywiseITStaffAugumentation), new { cityName });
        }
        #endregion

        #region Web Development

        [Route("web-development")]
        public async Task<IActionResult> WebDevelopment()
        {
            ViewBag.CityName = "UK";
            return View();
        }

        [Route("web-development/{cityName}-web-development")]
        public async Task<IActionResult> CitywiseWebDevelopment(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                ViewBag.CityName = cityName.ToTitleCaseText();
                string viewName = cityName.WebDevServicesViewNameByCity();
                if (!string.IsNullOrEmpty(viewName))
                    return View($"{_servicesViewPath}/WebDevelopment/{viewName}.cshtml");
                return View(_commingSoonViewPath);
            }
            else
            {
                return View(_commingSoonViewPath);
            }
        }

        [Route("{cityName}-web-development")]
        public async Task<IActionResult> OldRouteCitywiseWebDevelopment(string cityName)
        {
            return RedirectToActionPermanent(nameof(CitywiseWebDevelopment), new { cityName });
        }

        #endregion

        #region Graphic designing

        [Route("graphic-designing")]
        public async Task<IActionResult> GraphicDesigning()
        {
            ViewBag.CityName = "UK";
            return View();
        }

        [Route("graphic-designing/{cityName}-graphic-designing")]
        public async Task<IActionResult> CitywiseGraphicDesigning(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                ViewBag.CityName = cityName.ToTitleCaseText();
                string viewName = cityName.GraphicDesigningServicesViewNameByCity();
                if (!string.IsNullOrEmpty(viewName))
                    return View($"{_servicesViewPath}/GraphicDesigning/{viewName}.cshtml");
                return View(_commingSoonViewPath);
            }
            else
            {
                return View(_commingSoonViewPath);
            }
        }

        [Route("{cityName}-graphic-designing")]
        public async Task<IActionResult> OldRouteCitywiseGraphicDesigning(string cityName)
        {
            return RedirectToActionPermanent(nameof(CitywiseGraphicDesigning), new { cityName });
        }
        #endregion

        #region SEO 

        [Route("seo")]
        public async Task<IActionResult> SEO()
        {
            ViewBag.CityName = "UK";
            return View();
        }

        [Route("seo/{cityName}-seo")]
        public async Task<IActionResult> CitywiseSEO(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                ViewBag.CityName = cityName.ToTitleCaseText();
                string viewName = cityName.SEOServicesViewNameByCity();
                if (!string.IsNullOrEmpty(viewName))
                    return View($"{_servicesViewPath}/SEO/{viewName}.cshtml");
                return View(_commingSoonViewPath);
            }
            else
            {
                return View(_commingSoonViewPath);
            }
        }

        [Route("{cityName}-seo")]
        public async Task<IActionResult> OldRouteCitywiseSEO(string cityName)
        {
            return RedirectToActionPermanent(nameof(CitywiseSEO), new { cityName });
        }
        #endregion

        #endregion

        #region Portfolio

        [Route("portfolio")]
        public async Task<IActionResult> Portfolio()
        {
            return View();
        }

        [Route("portfolio/{portfolioSlug}")]
        public async Task<IActionResult> PortfolioDetail(string portfolioSlug)
        {
            var viewName = portfolioSlug.PortfolioViewName();
            if (!string.IsNullOrEmpty(viewName))
            {
                //ViewBag.Title = portfolioTitle.ToReplaceString()
                //                              .ToTitleCaseText();
                return View($"~/Views/Shared/Portfolio/{viewName}.cshtml");
            }
            else
            {
                return RedirectToAction(nameof(CommingSoon));
            }
        }

        #endregion

        #region Blogs

        [Route("blogs")]
        public IActionResult Blogs()
        {
            return View();
        }
        [Route("blogs/{blogSlug}")]
        public IActionResult BlogDetail(string blogSlug)
        {
            var viewName = blogSlug.BlogViewName();
            if (!string.IsNullOrEmpty(viewName))
            {
                return View($"~/Views/Shared/Blogs/{viewName}.cshtml");
            }
            else
            {
                return RedirectToAction(nameof(CommingSoon));
            }
        }
        #endregion

        #region Impressum

        [Route("impressum")]
        public IActionResult Impressum()
        {
            return View();
        }

        #endregion

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("faq")]
        public IActionResult FAQ()
        {
            return View();
        }

        [Route("price")]
        public IActionResult Price()
        {
            return View();
        }
        [Route("team")]
        public IActionResult Team()
        {
            return View();
        }
        [Route("team-details")]
        public IActionResult TeamDetails()
        {
            return View();
        }
        [Route("testimonial")]
        public IActionResult Testimonial()
        {
            return View();
        }

        [Route("services-detail")]
        public IActionResult ServicesDetail()
        {
            return View();
        }
        [Route("projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [Route("projects-detail")]
        public IActionResult ProjectsDetail()
        {
            return View();
        }
        [Route("shop")]
        public IActionResult OurProducts()
        {
            return View();
        }
        [Route("shop-single")]
        public IActionResult ProductSingle()
        {
            return View();
        }
        [Route("shopping-cart")]
        public IActionResult ShoppingCart()
        {
            return View();
        }
        [Route("checkout")]
        public IActionResult Checkout()
        {
            return View();
        }
        [Route("account")]
        public IActionResult Account()
        {
            return View();
        }
        [Route("our-blog")]
        public IActionResult OurBlog()
        {
            return View();
        }
        [Route("blog-classic")]
        public IActionResult BlogClassic()
        {
            return View();
        }
        [Route("blog-single")]
        public IActionResult BlogSingle()
        {
            return View();
        }

        [Route("coming-soon")]
        public IActionResult CommingSoon()
        {
            return View();
        }
    }
}