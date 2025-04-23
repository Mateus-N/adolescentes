using Microsoft.AspNetCore.Mvc;
using ProjetoAdolescentes.Application.DTOs.Usuario;
using ProjetoAdolescentes.Application.Interfaces;
using ProjetoAdolescentes.Application.Notification;

namespace ProjetoAdolescentes.Api.Controllers;

[Route("Adolescentes/api/[controller]")]
public class UsuarioController : BaseController
{
    private readonly IUsuarioAppService usuarioAppService;

    public UsuarioController(
        IUsuarioAppService usuarioAppService,
        NotificationContext notificationContext
    ) : base(notificationContext)
    {
        this.usuarioAppService = usuarioAppService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioDTO dto, CancellationToken ct)
    {
        return ReturnResponse(await usuarioAppService.CriarUsuario(dto, ct));
    }
}
