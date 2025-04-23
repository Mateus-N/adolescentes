using Microsoft.AspNetCore.Mvc;
using ProjetoAdolescentes.Application.DTOs;
using ProjetoAdolescentes.Application.Notification;

namespace ProjetoAdolescentes.Api.Controllers;

public class BaseController(NotificationContext notificationContext) : Controller
{
    [NonAction]
    public ActionResult ReturnResponse<T>(T? response)
    {
        if (notificationContext.HasNotifications)
        {
            var errors = notificationContext.Notifications.Select(n => new ApiError
            {
                Key = n.Key,
                Message = n.Message
            }).ToList();
            var objectResult = new BadRequestObjectResult(new ApiResponse<object>()
            {
                Success = false,
                Errors = errors
            });
            notificationContext.Clear();
            return objectResult;
        }
        if (response is null)
        {
            return NoContent();
        }
        return Ok(new ApiResponse<T>
        {
            Success = true,
            Data = response,
            Errors = []
        });
    }
}