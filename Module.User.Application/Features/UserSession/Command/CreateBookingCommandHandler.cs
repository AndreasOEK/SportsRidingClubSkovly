﻿using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserBooksSession.Command.Dto;
using Module.User.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Application.Features.UserBooksSession.Command
{
    public record CreateBookingCommand(
        CreateBookingRequest CreateBookingRequest) : IRequest;
    internal class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand>
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;

        public CreateBookingCommandHandler(ISessionRepository sessionRepository, IUserRepository userRepository)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
        }
        public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            // Load
            var session = await _sessionRepository.GetSessionById(request.CreateBookingRequest.sessionId);
            var user = await _userRepository.GetUserById(request.CreateBookingRequest.userId);

            // Do
            session.AddBooking(user);

            // Save
            await _sessionRepository.AddBookingAsync();
        }
    }
}
