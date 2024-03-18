using ApiMongoDB.Models;
using ApiMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<List<UsuarioTeste>> GetUsuarios()
            => await _usuarioService.GetAsync();

        [HttpPost]
        public async Task<UsuarioTeste> PostUsuarios(UsuarioTeste usuario)
        {
                await _usuarioService.CreatAsync(usuario);
                return usuario;
        }

        [HttpDelete]

        public async Task<UsuarioTeste> DeleteUsuarios(UsuarioTeste usuario)
        {
                await _usuarioService.RemoveAsync(usuario.Id!);
                return usuario;
        }

        [HttpPut]

        public async Task<UsuarioTeste> UpdateAsync(UsuarioTeste usuario)
        {
            await _usuarioService.UpdateAsync(usuario.Id!, usuario);
            return usuario; 
        } 

    }
}
