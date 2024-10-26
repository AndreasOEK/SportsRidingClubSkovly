using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.User.Application.Features.UserManagement.Query.Dto;
using Module.User.Application.Features.UserSession.Query;
using Module.User.Application.Features.UserSession.Query.Dto;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Features.Sessions;

public class GetUserPreviousBookingsQueryHandler : IRequestHandler<GetUserPreviousBookingsQuery, IEnumerable<UserBookingFullResponse>>
{
    private readonly UserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserPreviousBookingsQueryHandler(UserDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Booking, UserBookingFullResponse>();
        }).CreateMapper();
    }
    
    public async Task<IEnumerable<UserBookingFullResponse>> Handle(GetUserPreviousBookingsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Bookings
            .AsNoTracking()
            .Where(booking => 
                booking.User.Id == request.Id && 
                booking.Session.StartTime < DateTime.Now + booking.Session.Duration)
            .ProjectTo<UserBookingFullResponse>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}