﻿using System.Collections.Generic;
 using buckstore.manager.service.api.v1.Filters;
 using buckstore.manager.service.domain.Exceptions;
 using MediatR;
 using Microsoft.AspNetCore.Mvc;

namespace buckstore.manager.service.api.v1.Controllers
{
	[Route("manager/[controller]")]
	[ServiceFilter(typeof(GlobalExceptionFilterAttribute))]
	public class BaseController : Controller
	{
		private readonly ExceptionNotificationHandler _notifications;

		protected IEnumerable<ExceptionNotification> Notifications => _notifications.GetNotifications();

		protected BaseController(INotificationHandler<ExceptionNotification> notifications)
		{
			_notifications = (ExceptionNotificationHandler) notifications;
		}

		protected bool IsValidOperation()
		{
			return (!_notifications.HasNotifications());
		}

        protected new IActionResult Response(IActionResult action)
        {
            if (IsValidOperation())
            {
                return action;
            }

            return BadRequest
            (
                new
                {
                    success = false,
                    errors = _notifications.GetNotifications()
                }
            );
        }
	}
}
