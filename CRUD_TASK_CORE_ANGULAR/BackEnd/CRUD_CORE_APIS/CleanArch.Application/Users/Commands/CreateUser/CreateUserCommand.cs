using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Commands.CreateUser
{

    public class CreateUserCommand : IRequest<int>
    {
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




    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IDbContext _context;
        public CreateUserCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                MobileNumber = request.MobileNumber,
                IsDeleted = false,
                Email = request.Email,
                UserAddress = new AddressInfo
                {
                    GovId = request.GovId,
                    CityId = request.CityId,
                    BuildingNumber = request.BuildingNumber,
                    Street = request.Street
                }
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
