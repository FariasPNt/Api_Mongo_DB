using ApiMongoDB.Models;
using ApiMongoDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace ApiMongoDB.Controllers;

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
    [Authorize]
    public async Task<List<UsuarioTeste>> GetUsuarios()
        => await _usuarioService.GetAsync();

    [HttpPost]
    public async Task<IActionResult> PostUsuarios(UsuarioTeste usuario)
    {
        var verificationEmail = await _usuarioService.GetEmail(usuario.Email!);
        var verificationUsername = await _usuarioService.GetUsername(usuario.Login!);
        if (verificationEmail != null)
        {
            return Unauthorized("Email já existe.");
        }
        if (verificationUsername != null)
        {
            return Unauthorized("Nome de usuário já existe");
        }
        await _usuarioService.CreatAsync(usuario);
        return Ok(usuario);
    }

    [HttpDelete]

    public async Task<UsuarioTeste> DeleteUsuarios(UsuarioTeste usuario)
    {
            await _usuarioService.RemoveAsync(usuario.Id!);
            return usuario;
    }

    [HttpPut]

    public async Task<UsuarioTeste> UpdateUsuario(UsuarioTeste usuario)
    {
        await _usuarioService.UpdateAsync(usuario.Id!, usuario);
        return usuario; 
    }

}
