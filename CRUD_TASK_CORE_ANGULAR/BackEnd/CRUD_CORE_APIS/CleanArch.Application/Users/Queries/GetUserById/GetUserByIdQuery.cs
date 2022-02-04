using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.Users.Queries.GetUsersWithPagination
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.User
                .Include(x => x.UserAddress)
                .Where(x => x.Id == request.UserId && !x.IsDeleted)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
