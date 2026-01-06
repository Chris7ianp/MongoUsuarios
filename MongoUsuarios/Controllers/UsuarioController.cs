using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoUsuarios.Dtos;
using MongoUsuarios.Models;
using MongoUsuarios.Service;

namespace MongoUsuarios.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _service;
        private readonly IMapper _mapper;

        public UsuarioController(UsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var usuarios = _service.Get();
            var usuariosDto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return View(usuariosDto);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(UsuarioDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);
                _service.Create(usuario);
                return RedirectToAction("Index");
            }
            return View(usuarioDto);
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            _service.Delete(id);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var usuario = _service.Get(id); // retorna Usuario (Model)

            if (usuario == null)
                return NotFound();

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return View(usuarioDto);
        }


        [HttpPost]
        public IActionResult Edit(UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return View(usuarioDto);

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            _service.Update(usuarioDto.Id, usuario);

            return RedirectToAction("Index");
        }
    }
}
