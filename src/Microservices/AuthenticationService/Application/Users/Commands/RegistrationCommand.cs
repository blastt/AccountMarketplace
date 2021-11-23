using Application.Common.Interfaces;
using Application.Users.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
	public class RegistrationCommand : IRequest<UserDto>
	{

		public string UserName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }
	}
	public class RegistrationHandler : IRequestHandler<RegistrationCommand, UserDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IIdentityService _identityService;
		private readonly IJwtGenerator _jwtGenerator;

		public RegistrationHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService, IJwtGenerator jwtGenerator)
		{
			_context = context;
			_mapper = mapper;
			_identityService = identityService;
			_jwtGenerator = jwtGenerator;
		}

		public async Task<UserDto> Handle(RegistrationCommand request, CancellationToken cancellationToken)
		{
			var existedUser = await _identityService.GetUserIdAsync(request.UserName);
			if (existedUser != null)
			{
				throw new Exception(HttpStatusCode.BadRequest.ToString() + " User already exist");
			}

			if (await _identityService.IsEmailExist(request.Email))
			{
				throw new Exception(HttpStatusCode.BadRequest.ToString() + " User already exist");
			}

			var (result, userId) = await _identityService.CreateUserAsync(request.UserName, request.Password, request.Email);
			
			if (result.Succeeded)
			{
				return new UserDto
				{
					Token = _jwtGenerator.CreateToken(request.UserName),
					UserName = request.UserName,
					Email = request.Email,
					Roles = (await _identityService.GetUserRoles(userId)).ToArray()
				};
			}

			throw new Exception("Client creation failed");
		}
	}
}
