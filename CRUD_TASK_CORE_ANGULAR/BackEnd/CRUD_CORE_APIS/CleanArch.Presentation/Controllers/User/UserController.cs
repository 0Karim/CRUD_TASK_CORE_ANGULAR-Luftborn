using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Models;
using CleanArch.Application.Users.Commands.CreateUser;
using CleanArch.Application.Users.Commands.DeleteUser;
using CleanArch.Application.Users.Commands.UpdateUser;
using CleanArch.Application.Users.Queries;
using CleanArch.Application.Users.Queries.GetUsersWithPagination;
using CleanArch.Presentation.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Presentation.Controllers.User
{
    public class UserController : ApiController
    {

        [HttpPost("CreateUser")]
        public async Task<ActionResult<int>> CreateUser(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<int>> UpdateUser([FromQuery]int Id , UpdateUserCommand command)
        {
            command.UserId = Id;
            return await Mediator.Send(command);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<PaginatedList<UserDto>>> GetAllUsers([FromQuery]GetUsersWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDto>> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            return await Mediator.Send(query);
        }


        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser([FromQuery] int Id)
        {
            await Mediator.Send(new DeleteUserCommand { UserId = Id });

            return NoContent();
        }
    }
}
