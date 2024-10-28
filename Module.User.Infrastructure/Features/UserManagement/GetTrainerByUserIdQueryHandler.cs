using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Module.User.Application.Features.UserManagement.Query.Dto;
using Module.User.Domain.Entity;
using Module.User.Endpoints.UserManagement;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Features.UserManagement;

public class GetTrainerByUserIdQueryHandler : IRequestHandler<GetTrainerByUserIdQuery, CreateSessionTrainerResponse>
{
    private readonly UserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTrainerByUserIdQueryHandler(UserDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Trainer, CreateSessionTrainerResponse>()
                .ConstructUsing(src =>
                    new CreateSessionTrainerResponse(src.Id, $"{src.User.FirstName} {src.User.LastName}"));
        }).CreateMapper();
    }

    public async Task<CreateSessionTrainerResponse> Handle(GetTrainerByUserIdQuery request,
        CancellationToken cancellationToken)
        => await _dbContext.Trainers
               .Include(trainer => trainer.User)
               .AsNoTracking()
               .Where(trainer => trainer.User.Id == request.Id)
               .ProjectTo<CreateSessionTrainerResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(cancellationToken: cancellationToken) ??
           throw new BadHttpRequestException("User is not a trainer");
}