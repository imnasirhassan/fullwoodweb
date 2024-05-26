using fullwood.features.CowFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fullwoodweb.Controllers
{
    public class AccountController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;
        public async Task<IActionResult> Admin()
        {
            await _mediator.Send(new AuthQuery
            {
                UserName = "Admin",
                RoleName = "Admin"
            });

            return RedirectToAction("Index", "Cow");
        }

        public async Task<IActionResult> UserLogin()
        {
            await _mediator.Send(new AuthQuery
            {
                UserName = "User",
                RoleName = "User"
            });

            return RedirectToAction("Index", "Cow");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
