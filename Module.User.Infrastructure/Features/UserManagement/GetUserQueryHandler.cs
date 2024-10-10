using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.User.Application.Features.UserManagement.Query;
using Module.User.Application.Features.UserManagement.Query.Dto;
using Module.User.Application.Features.UserSession.Query.Dto;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Features.UserManagement;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly UserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(UserDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Entity.User, UserResponse>();
            cfg.CreateMap<Booking, UserBookingResponse>();
            cfg.CreateMap<Session, UserBookingSessionResponse>();
        }).CreateMapper();
    }

    public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken) =>
        await _dbContext.Users
            .AsNoTracking()
            .Where(user => user.Id == request.Id)
            .Include(user => user.Bookings)
            .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken: cancellationToken);
}