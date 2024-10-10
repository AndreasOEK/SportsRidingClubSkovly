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

public class GetTrainerQueryHandler : IRequestHandler<GetTrainerQuery, TrainerResponse>
{
    private readonly UserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTrainerQueryHandler(UserDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Trainer, TrainerResponse>();
            cfg.CreateMap<Domain.Entity.User, UserResponse>();
            cfg.CreateMap<Booking, UserBookingResponse>();
            cfg.CreateMap<Session, TrainerSessionResponse>();
            cfg.CreateMap<Session, UserBookingSessionResponse>();
        }).CreateMapper();
    }

    public async Task<TrainerResponse> Handle(GetTrainerQuery request, CancellationToken cancellationToken) =>
        await _dbContext.Trainers
            .AsNoTracking()
            .Include(trainer => trainer.User)
            .Where(trainer => trainer.Id == request.Id)
            .ProjectTo<TrainerResponse>(_mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken: cancellationToken);
}