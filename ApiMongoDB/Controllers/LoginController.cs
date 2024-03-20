using ApiMongoDB.Models;
using ApiMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongoDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly UsuarioService _usuarioServiceLogin;

    public LoginController(UsuarioService usuarioService)
    {
        _usuarioServiceLogin = usuarioService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLogin acess)
    {
        // Verifica email 
        var usuario = await _usuarioServiceLogin.GetEmail(acess.Email!);

        if (usuario == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        // Verifica senha 
        if (usuario.Senha != acess.Senha)
        {
            return Unauthorized("Senha incorreta.");
        }

        // FOI
        return Ok($"Login bem-sucedido. " +
            $"Login de acesso: {usuario.Email}, " +
            $"Nome: {usuario.NomeCompleto}, " +
            $"Idade: {usuario.Idade}, " +
            $"CPF: {usuario.CPF}, " +
            $"Nome de usuário: {usuario.Login} ");
    }

}
