using CQRS.Mediatr_Application.Dto_S;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediatr_Application.UseCases.User.Commands
{
    public class CreateUser: IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
