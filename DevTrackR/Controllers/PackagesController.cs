using DevTrackR.Entities;
using DevTrackR.Models;
using DevTrackR.Persistence;
using DevTrackR.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevTrackR.Controllers
{
    [ApiController]
    [Route("api/packages")]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageRepository _repository;
        public PackagesController(IPackageRepository repository) // Injecao de dependência da classe de dados
        {
            _repository = repository;
        }

        // GET api/packages
        [HttpGet]
        public IActionResult GetAll()
        {
            var packages = _repository.GetAll();
            return Ok(packages);
        }

        // GET api/packages/1234-5678-1234-5678
        [HttpGet("{code}")]
        public IActionResult GetByCode(string code) // Colocar o parâmetro
        {
            var package = _repository.GetByCode(code); // Busca o código do pacote

            if (package == null)
            {
                return NotFound("Package not found!");
            }

            return Ok(package);
        }

        // POST api/packages
        [HttpPost]
        public IActionResult Post(AddPackageInputModel model)
        {
            if (model.Title.Length < 10)
            {
                return BadRequest("Title lenght must be at least 10 characters long");
            }

            var package = new Package(model.Title, model.Weight);

            _repository.Add(package);

            return CreatedAtAction("GetByCode", new {code = package.Code}, package);
        }

        // POST apí/packges/1234-5678-1234-5678/updates
        [HttpPost("{code}/updates")]
        public IActionResult PostUpdate(string code, AddPackageUpdateInputModel model)
        {
            var package = _repository.GetByCode(code); // Busca o código do pacote

            if (package == null)
            {
                return NotFound();
            }

            package.AddUpdate(model.Status, model.Delivered);

            _repository.Update(package);

            return NoContent();
        }

    }
}
