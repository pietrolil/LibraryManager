﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
