using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Common.Interfaces;
using CleanArch.Application.Mapping;
using CleanArch.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.Users.Queries.GetUsersWithPagination
{
    public class GetUsersWithPaginationQuery : IRequest<PaginatedList<UserDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }


    public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<UserDto>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersWithPaginationQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<UserDto>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.User
                .Include(x=> x.UserAddress)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Id)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
