using fullwood.features.CowFeatures.Commands;
using fullwoodweb.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace fullwoodweb.Controllers
{
    public class ImportCowController(IMediator mediator) : Controller
    {
        readonly IMediator _mediator = mediator;

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Index(ImportViewModel model)
        {
            var file = model.JsonFile;
            var dirpath = "/files/";
            var fileName = Path.Combine(dirpath, Path.GetFileName(file.FileName));

            if (!Directory.Exists(dirpath))
                Directory.CreateDirectory(dirpath);

            using (var fileStream = new FileStream(fileName, FileMode.Create))
                file.CopyTo(fileStream);

            var st = new MemoryStream();
            file.CopyTo(st);
            var content = Encoding.ASCII.GetString(st.ToArray());
            
            var importData = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CowViewModel>>(content);

            foreach (var entity in importData)
            {
                await _mediator.Send(new AddCowCommand
                {
                    CowName = entity.CowName,
                    CowNumber = entity.CowNumber,
                    OnFarm = entity.OnFarm,
                    RegisteredDate = DateTime.Now,
                });
            }

            return RedirectToAction("Index", "Cow");
        }
    }
}
