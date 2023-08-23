using CTD.BussinessOperations.Models.ViewModels;
using CTD.BussinessOperations.Services;
using CTD.Extensions;
using CTD.Helpers;
using CTD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CTD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _commingSoonViewPath = "~/Views/Home/CommingSoon.cshtml";
        private readonly string _servicesViewPath = "~/Views/Shared/ServicesPages";
        private readonly IUserService _userService;
        private readonly IEmailSendService _emailSender;
        public HomeController(ILogger<HomeController> logger, IUserService userService, IEmailSendService emailSender)
        {
            _logger = logger;
            _userService = userService;
            _emailSender = emailSender;
        }

        #region Home

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Contact

        [HttpGet]
        [Route("contact-us")]
        public IActionResult ContactUs()
        {
            ViewBag.ThankYouMessage = false;
            return View(new UserViewModel());
        }

        [HttpPost]
        [Route("contact-us")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _userService.SaveUserEmailMessageAsync(user);
                ViewBag.ThankYouMessage = true;
            }
            return View(new UserViewModel());
        }

        #endregion

        #region About

        [Route("about-us")]
        public IActionResult AboutUs()
        {
            return View();
        }

        #endregion

        #region Services

        [Route("services")]
        public IActionResult Services()
        {
            return View();
        }

        #region ITStaffAugumentation


        [Route("it-staff-augumentation")]
        public IActionResult ITStaffAugumentation()
        {
            return View();
        }

        [Route("{cityName}-it-staff-augumentation")]
        public IActionResult CitywiseITStaffAugumentation(string cityName)
        {

            if (!string.IsNullOrEmpty(cityName))
            {
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

        #endregion

        #region Web Development


        [Route("web-development")]
        public IActionResult WebDevelopment()
        {
            return View();
        }
        [Route("{cityName}-web-development")]
        public IActionResult CitywiseWebDevelopment(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
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

        #endregion

        #region Graphic designing

        [Route("graphic-designing")]
        public IActionResult GraphicDesigning()
        {
            return View();
        }
        [Route("{cityName}-graphic-designing")]
        public IActionResult CitywiseGraphicDesigning(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
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
        #endregion

        #region SEO 

        [Route("seo")]
        public IActionResult SEO()
        {
            return View();
        }
        [Route("{cityName}-seo")]
        public IActionResult CitywiseSEO(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
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
        #endregion

        #endregion

        #region Portfolio

        [Route("portfolio")]
        public IActionResult Portfolio()
        {
            return View();
        }

        [Route("portfolio/{portfolioSlug}")]
        public IActionResult PortfolioDetail(string portfolioSlug)
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