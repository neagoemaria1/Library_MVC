using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactFormService _contactFormService;

        public ContactController(ILogger<ContactController> logger, IContactFormService contactFormService)
        {
            _logger = logger;
            _contactFormService = contactFormService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Contact - Library";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                _contactFormService.AddContactForm(contactForm);

                ViewBag.Message = "The message was sent successfully!";
                return View("Index");
            }

            return View("Index", contactForm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
