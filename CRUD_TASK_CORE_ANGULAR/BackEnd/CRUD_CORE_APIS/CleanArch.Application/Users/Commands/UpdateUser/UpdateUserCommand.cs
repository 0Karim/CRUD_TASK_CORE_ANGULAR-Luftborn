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

namespace CleanArch.Application.Users.Commands.UpdateUser
{

    public class UpdateUserCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }


        #region Address Info 

        public int? GovId { get; set; }

        public int? CityId { get; set; }

        public string BuildingNumber { get; set; }

        public string Street { get; set; }

        #endregion

    }


    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IDbContext _context;
        public UpdateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.User.Include(x => x.UserAddress)
                .Where(u => u.Id == request.UserId && !u.IsDeleted).FirstOrDefault();

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.BirthDate = request.BirthDate;
            user.MiddleName = request.MiddleName;
            user.MobileNumber = request.MobileNumber;
            user.Email = request.Email;

            user.UserAddress.GovId = request.GovId;
            user.UserAddress.CityId = request.CityId;
            user.UserAddress.BuildingNumber = request.BuildingNumber;
            user.UserAddress.Street = request.Street;

            await _context.SaveChangesAsync(cancellationToken);

            int currentUserId = user.Id;

            return currentUserId;
        }
    }
}
