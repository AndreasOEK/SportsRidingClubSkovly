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

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserFullResponse>
{
    private readonly UserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(UserDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Entity.User, UserFullResponse>();
            cfg.CreateMap<Booking, UserBookingFullResponse>();
            cfg.CreateMap<Session, UserBookingSessionFullResponse>();
            cfg.CreateMap<Trainer, UserBookingSessionTrainerFullResponse>();
            cfg.CreateMap<Domain.Entity.User, UserBookingSessionTrainerUserFullResponse>()
                .ConstructUsing(src =>
                    new UserBookingSessionTrainerUserFullResponse(src.FirstName, src.LastName, src.Email, src.Phone));
        }).CreateMapper();
    }

    public async Task<UserFullResponse> Handle(GetUserQuery request, CancellationToken cancellationToken) =>
        await _dbContext.Users
            .AsNoTracking()
            .Where(user => user.Id == request.Id)
            .Include(u => u.Bookings.Where(b => b.Session.StartTime > DateTime.Now))
            .ProjectTo<UserFullResponse>(_mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken: cancellationToken);
}