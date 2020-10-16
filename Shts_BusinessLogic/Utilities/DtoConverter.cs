using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic
{
    public static class DtoConverter
    {
        private static User _user;
        private static UserDto _userDto;
        private static Ticket _ticket;
        private static TicketDto _ticketDto;

        public static User ConvertToUserObject(UserDto dto)
        {
            _user = new User() { Id = dto.Id, FirstName = dto.FirstName, LastName = dto.LastName, Gender = Enum.Parse<Gender>(dto.Gender), Role = Enum.Parse<UserRole>(dto.Role), Email = dto.Email, Password = dto.Password };
            return _user;
        }

        public static UserDto ConvertToUserDto(User user)
        {
            _userDto = new UserDto() { FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender.ToString(), Role = user.Role.ToString(), Email = user.Email, Password = user.Password };
            return _userDto;
        }

        public static Ticket ConvertToTicketObject(TicketDto dto)
        {
            _ticket = new Ticket() { Id = dto.Id, Attachment = dto.Attachment, Subject = dto.Subject, Content = dto.Content, CreatedAt = dto.CreatedAt, LastEdited = dto.LastEdited };
            return _ticket;
        }

        public static TicketDto ConvertToTicketDto(Ticket ticket)
        {
            _ticketDto = new TicketDto() { Id = ticket.Id, Attachment = ticket.Attachment, Subject = ticket.Subject, Content = ticket.Content, CreatedAt = ticket.CreatedAt, LastEdited = ticket.LastEdited };
            return _ticketDto;
        }


    }
}
