using fullwood.features.CowFeatures.Commands;
using fullwood.features.CowFeatures.Queries;
using fullwoodweb.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fullwoodweb.Controllers
{
    public class CowController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _mediator.Send(new GetAllCowQuery());
            var result = data.Select(x => new CowViewModel
            {
                Id = x.Id,
                CowName = x.CowName,
                CowNumber = x.CowNumber,
                OnFarm  = x.OnFarm,
                RegisteredDate = x.RegisteredDate
            });

            return View(result.ToList());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> Create(CowViewModel entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _mediator.Send(new AddCowCommand
                    {
                        CowName = entity.CowName,
                        CowNumber = entity.CowNumber,
                        OnFarm = entity.OnFarm,
                        RegisteredDate = DateTime.Now,
                    });

                    //This is for demonstration and exception/ error handling will be added later.
                    if (result == -1)
                    {
                        ModelState.AddModelError("already_exists", "Record already exists");
                        return View();
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"exception: {ex.Message}");
                }
            }

            return View(entity);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _mediator.Send(new GetCowByIdQuery
            {
                Id = id
            });

            var result = new CowViewModel
            {
                Id = data.Id,
                CowName = data.CowName,
                CowNumber = data.CowNumber,
                OnFarm = data.OnFarm,
                RegisteredDate = data.RegisteredDate
            };

            return View(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> Update(CowViewModel entity)
        {
            await _mediator.Send(new UpdateCowCommand
            {
                Id = entity.Id,
                OnFarm = entity.OnFarm,
                CowName = entity.CowName,
                CowNumber = entity.CowNumber,
                RegisteredDate = entity.RegisteredDate
            });

            return RedirectToAction("Index", "Cow");
        }

        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCowCommand
            {
                Id = id,
            });

            return RedirectToAction("Index");
        }
    }
}


