using CleanArch.Application.Common.Exceptions;
using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; set; }
    }


    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IDbContext _context;
        public DeleteUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.User.Include(x => x.UserAddress)
                .Where(u => u.Id == request.UserId && !u.IsDeleted).FirstOrDefault();

            if (user == null)
                throw new NotFoundException(nameof(User), request.UserId);

            user.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
