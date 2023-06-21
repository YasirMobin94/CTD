using CTD.Extensions;
using CTD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CTD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region Home

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Contact

        [Route("contact-us")]
        public IActionResult ContactUs()
        {
            return View();
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

        [Route("it-staff-augumentation")]
        public IActionResult ITStaffAugumentation()
        {
            return View("~/Views/Shared/ServicesPages/ITStaffAugumentation/_ITStaffAugumentationInLeeds.cshtml");
        }

        [Route("web-development")]
        public IActionResult WebDevelopment()
        {
            return View();
        }

        [Route("graphic-designing")]
        public IActionResult GraphicDesigning()
        {
            return View();
        }

        [Route("seo")]
        public IActionResult SEO()
        {
            return View();
        }

        [Route("custom-software-development")]
        public IActionResult CustomSoftwareDevelopment()
        {
            return View();
        }
        [Route("{pageUrl}-it-staff-augumentation")]
        public IActionResult CitywiseITStaffAugumentation(string pageUrl)
        {
            return View();
        }

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