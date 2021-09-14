using System;
using System.Collections.Generic;
using AutoMapper;
using codingchallenge.api.Data;
using codingchallenge.api.Dtos;
using codingchallenge.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace codingchallenge.api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SubmitController : ControllerBase
    {
        private readonly INotificationRepo _repository;
        private readonly IMapper _mapper;

        public SubmitController(INotificationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NotificationReadDto>> GetAllNotifications()
        {
            var notificationItems = _repository.GetAllNotifications();

            return Ok(_mapper.Map<IEnumerable<NotificationReadDto>>(notificationItems));
        }

        [HttpGet("{notificationId}", Name = "GetNotification")]
        public ActionResult<NotificationReadDto> GetNotification(int notificationId)
        {
            var notification = _repository.GetNotificationById(notificationId);
            if (notification == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NotificationReadDto>(notification));
        }

        [HttpPost]
        public ActionResult<NotificationReadDto> CreateNotification(NotificationCreateDto notificationDto)
        {
            var notification = _mapper.Map<Notification>(notificationDto);

            _repository.CreateNotification(notification);
            _repository.SaveChanges();

            var notificationReadDto = _mapper.Map<NotificationReadDto>(notification);

            return CreatedAtRoute(nameof(GetNotification), new { notificationId = notificationReadDto.Id }, notificationReadDto);
        }
    }
}