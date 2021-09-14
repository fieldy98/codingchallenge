using AutoMapper;
using codingchallenge.api.Dtos;
using codingchallenge.api.Models;

namespace codingchallenge.api.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationReadDto>();
            CreateMap<NotificationCreateDto, Notification>();
        }
    }
}