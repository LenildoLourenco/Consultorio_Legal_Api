﻿using System.Threading.Tasks;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Usuario;
using CL.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioManager _manager;

        public UsuariosController(IUsuarioManager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var usuarioLogado = await _manager.ValidaUsuarioEGeraTokenAsync(usuario);
            if (usuarioLogado != null)
            {
                return Ok(usuarioLogado);
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string login = User.Identity.Name;
            var usuario = await _manager.GetAsync(login);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovoUsuario usuario)
        {
            var usuarioInserido = await _manager.InsertAsync(usuario);
            return CreatedAtAction(nameof(Get), new { login = usuario.Login }, usuarioInserido);
        }
    }
}
