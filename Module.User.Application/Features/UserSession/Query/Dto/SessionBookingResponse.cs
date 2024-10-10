using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.User.Application.Features.UserManagement.Query.Dto;

namespace Module.User.Application.Features.UserSession.Query.Dto
{
    public record SessionBookingResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
