using CQRS.Mediatr_Application.UseCases.User.Commands;
using CQRS.Mediatr_Domen.Entity;
using CQRS.Mediatr_Infastructure;
using Mapster;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediatr_Application.UseCases.User.Handlers
{
    public class CreateUserHandl : IRequestHandler<CreateUser,Mediatr_Domen.Entity.User>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CreateUserHandl(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<CQRS.Mediatr_Domen.Entity.User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<CQRS.Mediatr_Domen.Entity.User>(request);
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return user;
        }

    }  
}
